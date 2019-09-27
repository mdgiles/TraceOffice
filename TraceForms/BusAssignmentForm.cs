using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using FlexModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Net.Mail;
using System.Text;

namespace TraceForms
{
    public partial class BusAssignmentForm : DevExpress.XtraEditors.XtraForm
    {
		FlexInterfaces.Core.ICoreSys _sys;
        FlextourEntities _context;
		RepositoryItemCheckedComboBoxEdit _busLookup = new RepositoryItemCheckedComboBoxEdit();
		List<BusDepartureAssignment> _busAssignments;
		List<PassengerAssignment> _psgrAssignments = new List<PassengerAssignment>();
		BusAssignment _currentAssignment;
		List<ResRouteAssignment> _psgrStops;
		List<Bus> _buses;
		RepositoryItemImageComboBox _busPsgrLookup = new RepositoryItemImageComboBox();
		DateTime _selectedDate;
		Timer actionConfirmation;
		bool _changed = false;
		List<RESITM> _resItems;
		List<NameAssignment> _nameAssignments;
        List<ResTransportAssignment> _transport;

        public BusAssignmentForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
			gridControlServices.Left = gridControlRoutes.Left;
			Connect(sys);
			LoadLookups();
        }

        private void LoadLookups()
        {
            _buses = _context.Bus.Where(x => x.InService).OrderBy(b => b.Name).ToList();

            _busLookup.SelectAllItemVisible = false;
            _busLookup.DataSource = _buses;
            _busLookup.ValueMember = "ID";
            _busLookup.DisplayMember = "Name";
            colBuses.ColumnEdit = _busLookup;
			colBusesRegular.ColumnEdit = _busLookup;
            _busLookup.EditValueChanged += new EventHandler(buses_EditValueChanged);

            _busPsgrLookup.EditValueChanged += new EventHandler(psgrBus_EditValueChanged);

        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            _context = new FlextourEntities(sys.Settings.EFConnectionString);
			_context.ContextOptions.UseCSharpNullComparisonBehavior = true;
			_sys = sys;
			textEmailAddress.Text = sys.User.EmailAddress;
        }

        private void dateEditServiceStart_EditValueChanged(object sender, EventArgs e)
        {
			LoadRoutes();
		}

		private void LoadRoutes()
		{
			try {
                if (isHopper) {
                    labelControlInstructions.Text = "Assign buses to routes and departures";
                    gridControlRoutes.Visible = true;
                    gridControlServices.Visible = false;
                } else {
                    labelControlInstructions.Text = "Assign buses to services";
                    gridControlRoutes.Visible = false;
                    gridControlServices.Visible = true;
                }

                if (DateTime.TryParse(dateEditDepartureDate.Text, out _selectedDate)) {
					Cursor = Cursors.WaitCursor;
					_busAssignments = _context.BusDepartureAssignment.Where(x => x.Date == _selectedDate).ToList();

					if (isHopper) {
						LoadHopperRoutes();
					}
					else {
						LoadRegularRoutes();
					}
					Cursor = Cursors.Default;
				}
			}
			catch (Exception ex) {
				Cursor = Cursors.Default;
                this.DisplayError(ex);
			}
		}

		private void LoadRegularRoutes()
		{
			//Include the passenger info because we're going to need it later
			//Checking a vaue from r.COMP enforces the join to COMP so we don't have to check
			//RESITM.TYPE == "OPT".  There is only one ResRoom for an OPT record, so we don't have
			//to worry about duplicates of RESITM
			_resItems = _context.RESITM.
						Include(r => r.PSGRROOM.Select(p => p.PSGRLIST)).
						Include(r => r.COMP).
                        Include(r => r.RESHDR).
						Include(r => r.ResRoom).
						Where(r => _sys.Settings.BusTourServiceType.Contains(r.COMP.SERV_TYPE)
                            && r.STRT_DATE == _selectedDate && r.Inactive == false && r.Status == "R"
                            //The following restricts selection to only items that actually have a pickup or dropoff, so the manifest
                            //will turn into a "boarding" or "disembarking" list rather than a manifest
                            //&& (!string.IsNullOrEmpty(r.BUS_DRP_TYPE ?? string.Empty) || !string.IsNullOrEmpty(r.BUS_PUP_TYPE ?? string.Empty))
                            ).ToList();

			var items = _resItems.GroupBy(r => new {
							Code = r.CODE,
							Description = r.COMP.NAME,
							ServiceTime24 = r.TOUR_TIME,
						}).Select(g => new BusAssignment() {
							Code = g.Key.Code,
							Description = g.Key.Description,
							ServiceTime24 = g.Key.ServiceTime24,
							Count = g.Sum(f => (f.NBR_ADULTS ?? 0))
						}).ToList();

			foreach (var item in items) {
                item.ServiceTime = Convert24HourToDateTime(_selectedDate, item.ServiceTime24);
                var busList = _busAssignments.Where(x => x.Comp_Code == item.Code && x.ServiceTime == item.ServiceTime24).
                    Select(p => p.Bus_ID).ToList();
                item.SelectedBuses = string.Join(",", busList);
                LoadPassengers(item);
            }

			LoadNames(items);
			passengerAssignmentBindingSource.DataSource = null;
			busAssignmentBindingSource.DataSource = items;
			if (items.Count > 0) {
				gridViewServices.FocusedRowHandle = 0;
				DisplayPassengersAndNames(gridViewServices, 0);
			}
		}

		private void LoadHopperRoutes()
		{
			//Include PSGRLIST because we will need the names later
			_psgrStops = _context.ResRouteAssignment.Include(p => p.PSGRLIST).
				Where(rra => rra.DepartureDate == _selectedDate).ToList();

            //get all the pickups, dropoffs, and stops for the selected date to avoid multiple trips to db
            _transport = _context.ResTransportAssignment.Where(rta => DbFunctions.TruncateTime(rta.Time) == _selectedDate).ToList();

            //Get the count of passengers per route departure
            //NOTE: this will not catch any passengers who have booked hopper tours and
            // haven't reserved seats, because they will not be in ResRouteAssignment
            var busAssgns = _context.ResRouteAssignment.Include(rra => rra.RESITM).
				Where(rra => rra.DepartureDate == _selectedDate && rra.RESITM.Inactive == false
					&& rra.RESITM.Status == "R").
				GroupBy(x => new {
					BusRouteID = x.BusRoute.ID,
					BusDepartureID = x.BusDeparture.ID,
					BusRouteName = x.BusRoute.Name,
					BusDepartureTime = x.BusDeparture.Time,
                    x.ResNo,
                    x.Item
				}).
				Select(g => new BusAssignment() {
					DepartureTime = g.Key.BusDepartureTime,
					RouteName = g.Key.BusRouteName,
					DepartureID = g.Key.BusDepartureID,
					RouteID = g.Key.BusRouteID,
					Count = g.Select(f => new { f.ResNo, f.Item, ClientNo = f.PsgrList_ClientNo }).Distinct().Count(),
				}).ToList();

			foreach (var busAssgn in busAssgns) {
				var busList = _busAssignments.Where(x => x.BusDeparture_ID == busAssgn.DepartureID).Select(p => p.Bus_ID).ToList();
				busAssgn.SelectedBuses = string.Join(",", busList);
				LoadPassengers(busAssgn);
			}

			LoadNames(busAssgns);
			passengerAssignmentBindingSource.DataSource = null;
			busAssignmentBindingSource.DataSource = busAssgns;
			if (busAssgns.Count > 0) {
				gridViewRoutes.FocusedRowHandle = 0;
				DisplayPassengersAndNames(gridViewRoutes, 0);
			}
		}

		private DateTime? Convert24HourToDateTime(DateTime date, string time)
		{
			if (string.IsNullOrEmpty(time) || time.Length < 4) {
				return null;
			}

			int hours = int.Parse(time.Substring(0, 2));
			int minutes = int.Parse(time.Substring(2, 2));
			date = date.AddHours(hours).AddMinutes(minutes);
			return date;
		}

		private void topGrid_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
		{
			var view = (GridView)sender;
			DisplayPassengersAndNames(view, e.FocusedRowHandle);
		}

		private void DisplayPassengersAndNames(GridView view, int row)
		{
			if (row >= 0) {
				_currentAssignment = (BusAssignment)view.GetRow(row);
				passengerAssignmentBindingSource.DataSource = _currentAssignment.Assignments;
                DisplayNames();
            }
			else {
				_currentAssignment = null;
				passengerAssignmentBindingSource.DataSource = null;
				nameAssignmentBindingSource.DataSource = null;
			}
		}

        private void DisplayNames()
        {
            //Get the names for the currently selected departure/service/time combo
            var names = _nameAssignments.Where(x => x.DepartureID == _currentAssignment.DepartureID
                && x.Code == _currentAssignment.Code && x.ServiceTime24 == _currentAssignment.ServiceTime24);
            if (names.Count() == 0) {
                nameAssignmentBindingSource.DataSource = null;
            }
            else {
                nameAssignmentBindingSource.DataSource = names;
            }
        }

        private void LoadPassengers(BusAssignment busAssgn)
		{
			if (isHopper) {
				LoadPassengersHopper(busAssgn);
			}
			else {
				LoadPassengersRegular(busAssgn);
			}
		}

		private void LoadNames(List<BusAssignment> assignments)
		{
			//The driver and guide are saved in the db with the bus and departure (or service and time)
			// so we need to get a collection of them for all the buses that are selected 
			_nameAssignments = new List<NameAssignment>();

			//First group by service and time
			var grouped = assignments.GroupBy(x => new {
				x.DepartureID,
				x.Code,
				x.ServiceTime24
			}).Select(g => new BusAssignment() {
				DepartureID = g.Key.DepartureID,
				Code = g.Key.Code,
				ServiceTime24 = g.Key.ServiceTime24
			}).ToList();

			NameAssignment nameAssgn;
			BusDepartureAssignment dbName;
			//For each departure/service/time combo, get the unique list of buses assigned, then for each bus
			//create an element for the driver and guide names
			foreach (var groupItem in grouped) {
				var buses = assignments.Where(x => x.DepartureID == groupItem.DepartureID && x.ServiceTime24 == groupItem.ServiceTime24
					&& x.Code == groupItem.Code).SelectMany(x => x.SelectedBusesList).Distinct();
				foreach (int busID in buses) {
					nameAssgn = new NameAssignment();
					nameAssgn.BusID = busID;
					nameAssgn.BusName = _buses.Single(b => b.ID == busID).Name;
					nameAssgn.DepartureID = groupItem.DepartureID;
					nameAssgn.ServiceTime24 = groupItem.ServiceTime24;
					nameAssgn.Code = groupItem.Code;
					//Now check to see if there was a record in the db for this departure/service/time combo,
					//and if so, populate the names
					dbName = _busAssignments.SingleOrDefault(x => x.Bus_ID == busID && x.BusDeparture_ID == groupItem.DepartureID
						&& x.Comp_Code == groupItem.Code && x.ServiceTime == groupItem.ServiceTime24);
					if (dbName != null) {
						nameAssgn.DriverName = dbName.DriverName;
						nameAssgn.DriverPhone = dbName.DriverPhone;
						nameAssgn.GuideName = dbName.GuideName;
						nameAssgn.GuidePhone = dbName.GuidePhone;
					}
					_nameAssignments.Add(nameAssgn);
				}
			}
		}

		private void LoadPassengersRegular(BusAssignment busAssgn)
		{
            var psgrs = GetPassengersRegular(busAssgn);

            busAssgn.Assignments = psgrs.Select(p => new PassengerAssignment() {
                RouteName = busAssgn.ServiceTime == null ? busAssgn.Description :
                    string.Format("{0} - {1:hh:mm tt}", busAssgn.Description, busAssgn.ServiceTime),
                ClientNo = p.ClientNo,
                LastName = p.LastName,
                Age = p.Age,
                FirstName = p.FirstName,
                Phone = p.Phone,
                ResNo = p.ResNo,
                Item = p.Item,
                PickupTime = Convert24HourToDateTime(_selectedDate, p.PickupTime24),
                PickupLocation = GetName(p.PickupLocationType, p.PickupLocationCode),
            }).ToList();

            foreach (var psgr in busAssgn.Assignments) {
                var assgn = _context.BusPassengerAssignment.Include(p => p.BusDepartureAssignment).
                    FirstOrDefault(x => x.ResNo == psgr.ResNo && x.Item == psgr.Item && x.PsgrList_ClientNo == psgr.ClientNo);
                if (assgn != null) {
                    psgr.BusID = assgn.BusDepartureAssignment.Bus_ID;
                }
            }
		}

		private void LoadPassengersHopper(BusAssignment busAssgn)
		{
			var psgrs = GetPassengersHopper(busAssgn);

			busAssgn.Assignments = psgrs.Select(p => new PassengerAssignment() {
				DepartureID = busAssgn.DepartureID,
				DepartureName = busAssgn.DepartureTime.ToString("hh:mm tt"),
				RouteID = busAssgn.RouteID,
				RouteName = busAssgn.RouteName,
				ClientNo = p.ClientNo,
				LastName = p.LastName,
				Age = p.Age,
				FirstName = p.FirstName,
				Phone = p.Phone,
				ResNo = p.ResNo,
				Item = p.Item,
            }).ToList();

			foreach (var psgr in busAssgn.Assignments) {
				var assgn = _context.BusPassengerAssignment.Include(p => p.BusDepartureAssignment).
					FirstOrDefault(x => x.ResNo == psgr.ResNo && x.Item == psgr.Item && x.PsgrList_ClientNo == psgr.ClientNo);
				if (assgn != null) {
					psgr.BusID = assgn.BusDepartureAssignment.Bus_ID;
				}

                var pickup = _transport.FirstOrDefault(t => t.BusDeparture_ID == psgr.DepartureID
                    && t.PsgrList_ClientNo == psgr.ClientNo && t.ResNo == psgr.ResNo && t.Item == psgr.Item
                    && t.PointType == "P");

                var dropoff = _transport.FirstOrDefault(t => t.BusDeparture_ID == psgr.DepartureID
                    && t.PsgrList_ClientNo == psgr.ClientNo && t.ResNo == psgr.ResNo && t.Item == psgr.Item
                    && t.PointType == "D");

                psgr.PickupLocation = GetName(pickup.LocationType, pickup.Location);
                psgr.PickupTime = pickup.Time;
                psgr.DropoffLocation = GetName(dropoff.LocationType, dropoff.Location);
                psgr.DropoffTime = dropoff.Time;
            }
        }

		private IEnumerable<Passenger> GetPassengersRegular(BusAssignment route)
		{
			return _resItems.Where(r => r.CODE == route.Code && r.TOUR_TIME == route.ServiceTime24).
				SelectMany(r => r.PSGRROOM).
				Select(p => new Passenger() {
					ClientNo = p.CLIENT_NO,
					FirstName = p.PSGRLIST.FIRST_NAME,
					LastName = p.PSGRLIST.LAST_NAME,
					Title = p.PSGRLIST.TITLE,
					Age = p.PSGRLIST.AGE,
					Phone = p.PSGRLIST.PHONE_NBR,
					ResNo = p.RES_NO,
					Item = p.ITEM,
                    PickupLocationCode = p.RESITM.BUS_PUP,
                    PickupLocationType = p.RESITM.BUS_PUP_TYPE,
                    PickupTime24 = p.RESITM.PUP_TIME
				}).DistinctBy(x => x.ClientNo).
				OrderBy(x => x.ResNo).
				ThenBy(x => x.ClientNo);
		}

		private IEnumerable<Passenger> GetPassengersHopper(BusAssignment route) {
			//TODO: for B2C repeat guests may appear with the same client number in multiple trips
			// so we may need to account for that
			return _psgrStops.Where(rra => rra.BusDeparture_ID == route.DepartureID).
					Select(p => new Passenger() {
						ClientNo = p.PsgrList_ClientNo,
						FirstName = p.PSGRLIST.FIRST_NAME,
						LastName = p.PSGRLIST.LAST_NAME,
						Title = p.PSGRLIST.TITLE,
						Age = p.PSGRLIST.AGE,
						Phone = p.PSGRLIST.PHONE_NBR,
						ResNo = p.ResNo,
						Item = p.Item,
                    }).DistinctBy(x => x.ClientNo).
					OrderBy(x => x.ResNo).
					ThenBy(x => x.ClientNo);
		}

		private void AssignNamesToBus()
		{
            //Modify the collection of bus drivers and guides. We don't want to start with a completely new
            //collection, because then we would lose existing names the user might have entered.

            //Get rid of names for buses which were just unassigned 
            _nameAssignments.RemoveAll(b => b.DepartureID == _currentAssignment.DepartureID 
                && b.Code == _currentAssignment.Code && b.ServiceTime24 == _currentAssignment.ServiceTime24
                && !_currentAssignment.SelectedBusesList.Any(x => x == b.BusID));

            //Add names for buses which were just assigned. 
            foreach (int bus in _currentAssignment.SelectedBusesList) {
				if (!_nameAssignments.Any(x => x.DepartureID == _currentAssignment.DepartureID
					&& x.Code == _currentAssignment.Code && x.ServiceTime24 == _currentAssignment.ServiceTime24
					&& x.BusID == bus)) {
					_nameAssignments.Add(new NameAssignment() {
						BusID = bus,
						BusName = _buses.Single(b => b.ID == bus).Name,
						DepartureID = _currentAssignment.DepartureID,
						Code = _currentAssignment.Code,
						ServiceTime24 = _currentAssignment.ServiceTime24
					});
				}
			}

            DisplayNames();
		}

		private void AssignPassengersAndNamesToBus()
		{
			AssignPassengersToBus();
			AssignNamesToBus();
		}

		private void AssignPassengersToBus()
		{
            //This assignment will not make any attempt to keep passengers in the same reservation together, however the
            //passengers are ordered by resno and clientno, so that will get it close
            Bus bus = null;
            int currentBus = 0;
            int psgrsAssignedToBus = 0;
            foreach (var psgr in _currentAssignment.Assignments) {
                if (currentBus <= _currentAssignment.SelectedBusesList.Count - 1) {
                    bus = _buses.Single(b => b.ID == _currentAssignment.SelectedBusesList[currentBus]);
                    psgr.BusID = bus.ID;
                    psgr.BusName = bus.Name;
                    psgrsAssignedToBus++;
                }
                else {
                    bus = null;
                    psgr.BusID = 0;
                    psgr.BusName = string.Empty;
                }
                if (bus != null && psgrsAssignedToBus == bus.Capacity) {
                    psgrsAssignedToBus = 0;
                    currentBus++;
                }
            }
            passengerAssignmentBindingSource.DataSource = _currentAssignment.Assignments;
            gridControlPassengers.RefreshDataSource();
		}

        void buses_EditValueChanged(object sender, EventArgs e)
        {
            _changed = true;
            object editValue = (sender as CheckedComboBoxEdit).EditValue;

            _currentAssignment.SelectedBuses = editValue.ToString();
            int capacity = 0;
            bool capacityExceeded = false;
            foreach (int busID in _currentAssignment.SelectedBusesList) {
                //If the capacity assigned is already greater than the number of guests and yet they have
                //assigned another bus, then warn
                if (capacity > _currentAssignment.Count) {
                    capacityExceeded = true;
                }
                capacity += _buses.Single(b => b.ID == busID).Capacity;
            }
            if (capacityExceeded) {
                XtraMessageBox.Show("You may have selected too much capacity for the number of guests.\nYou may wish to change the assigned buses.",
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            AssignPassengersAndNamesToBus();
        }

        void psgrBus_EditValueChanged(object sender, EventArgs e)
		{
			_changed = true;
		}

		private void gridViewPassengers_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
		{
			if (e.Column == colBusName) {
				_busPsgrLookup.Items.Clear();
				if (_currentAssignment != null) {
					if (!string.IsNullOrEmpty(_currentAssignment.SelectedBuses)) {
						foreach (int busID in _currentAssignment.SelectedBusesList) {
							var bus = _buses.Single(x => x.ID == busID);
							var item = new ImageComboBoxItem() { Description = bus.NameWithCapacity, Value = bus.ID };
							_busPsgrLookup.Items.Add(item);
						}
					}
				}
				e.RepositoryItem = _busPsgrLookup;
			}
		}

		private bool isHopper
		{
			get {
				return (radioGroupType.SelectedIndex == 0);
			}
		}

		private bool SaveAssignments()
		{
			try {
				GridView view;
				if (isHopper) {
					view = gridViewRoutes;
				}
				else {
					view = gridViewServices;
				}

                if (view.DataRowCount == 0) {
                    //Nothing to save. We do not save rows that are filtered out. If we were to save them,
                    //we would have to unfilter them to show errors to the user, and that would mean they
                    //would also show on the manifest, which defeats the purpose of the user filtering
                    //them out in the first place
                    return false;       
                }

                List<BusAssignment> assignments = new List<BusAssignment>();
                for (int handle = 0; handle < view.DataRowCount; handle++) {
					BusAssignment row  = (BusAssignment)view.GetRow(handle);
                    assignments.Add(row);       //collection of data from visible rows
					foreach (int busID in row.SelectedBusesList) {
						var pax = (row.Assignments == null) ? 0 : row.Assignments.Count(x => x.BusID == busID);
						var bus = _buses.Single(x => x.ID == busID);
						if (pax == 0) {
							view.FocusedRowHandle = handle;
							XtraMessageBox.Show(string.Format("You have selected {0} but not assigned any guests.\n", bus.Name), 
								Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
							return false;
						}
						if (pax > bus.Capacity) {
							view.FocusedRowHandle = handle;
							XtraMessageBox.Show(string.Format("You have assigned {0} guests to a bus with a capacity of {1}.\n", pax, bus.Capacity),
								Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
							return false;
						}
					}
					for (int ctr = 0; ctr < row.Assignments.Count; ctr++) {
						if (row.SelectedBusesList.Count > 0 && !row.SelectedBusesList.Contains(row.Assignments[ctr].BusID)) {
							view.FocusedRowHandle = handle;
							gridViewPassengers.FocusedRowHandle = ctr;
							XtraMessageBox.Show(string.Format("Guest {0} {1} does not have a valid bus assigned.", 
								row.Assignments[ctr].FirstName, row.Assignments[ctr].LastName),
								Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
							return false;
						}

                        //TODO: Do we need an error or warning if people in the same reservation are split between buses?
					}
				}

				Cursor = Cursors.WaitCursor;

				//For regular bus tours, we include pickup point just for convenience of assigning to bus
				//in case one bus does certain pickups, and another different pickups. However, the pickups
				//are not saved in BusDepartureAssignment (because they can be linked to using the passenger)
				//so we need to group by the data without pickups, otherwise we will get duplicate records
				var grouped = assignments.GroupBy(x => new {
					x.Code,
					x.ServiceTime24,
					x.DepartureID
				}).Select(g => new BusAssignment() {
					Code = g.Key.Code,
					ServiceTime24 = g.Key.ServiceTime24,
					DepartureID = g.Key.DepartureID,
				}).ToList();

				foreach (var groupItem in grouped) {
					//NOTE make sure _context.ContextOptions.UseCSharpNullComparisonBehavior is true to generate sql
					// that compares null using IS, otherwise it will compare null using = and no rows will return

                    //If there is a service code, then we also check for service time. We don't want to check for
                    //string.IsNullOrEmpty(groupItem.ServiceTime24) because service time can be an empty string in resitm
                    //and we don't want that converted to null in BusDepartureAssignment or it won't find a match when
                    //loading again
                    var serviceCode = string.IsNullOrEmpty(groupItem.Code) ? null : groupItem.Code;
                    var serviceTime = string.IsNullOrEmpty(groupItem.Code) ? null : groupItem.ServiceTime24;
                    var serviceType = string.IsNullOrEmpty(groupItem.Code) ? null : "OPT";

                    var dbAssgns = _context.BusDepartureAssignment.Where(x => x.BusDeparture_ID == groupItem.DepartureID 
						&& x.Date == _selectedDate
                        && x.Comp_Type == serviceType
                        && x.Comp_Code == serviceCode
						&& x.ServiceTime == serviceTime).ToList();
					var localMatches = assignments.Where(x => x.DepartureID == groupItem.DepartureID
						&& x.Code == groupItem.Code && x.ServiceTime24 == groupItem.ServiceTime24);
					var buses = localMatches.SelectMany(x => x.SelectedBusesList).Distinct();

					foreach (int busID in buses) {
						//first find and save the bus assignment based on what the user selected this time
						var dbMatch = dbAssgns.SingleOrDefault(x => x.Bus_ID == busID);
						var localMatch = localMatches.First();
						var nameAssign = _nameAssignments.SingleOrDefault(x => x.DepartureID == groupItem.DepartureID && 
							x.Code == groupItem.Code && x.ServiceTime24 == groupItem.ServiceTime24 && x.BusID == busID);

						if (dbMatch == null) {
							//add the bus assignment record
							dbMatch = new BusDepartureAssignment() {
								Date = _selectedDate,
								BusDeparture_ID = ((localMatch.DepartureID > 0) ? (int?)localMatch.DepartureID : null),
								Comp_Code = serviceCode,
								Comp_Type = serviceType,
								ServiceTime = serviceTime,
								DriverName = nameAssign.DriverName,
								DriverPhone = nameAssign.DriverPhone,
								GuideName = nameAssign.GuideName,
								GuidePhone = nameAssign.GuidePhone,
								Bus_ID = busID
							};
							_context.BusDepartureAssignment.AddObject(dbMatch);
							_context.SaveChanges();
						}
						else {
							dbMatch.DriverName = nameAssign.DriverName;
							dbMatch.DriverPhone = nameAssign.DriverPhone;
							dbMatch.GuideName = nameAssign.GuideName;
							dbMatch.GuidePhone = nameAssign.GuidePhone;
							//delete the passengers because it's too hard to find the ones that were
							//previously assigned and no longer will be 
							var matchPsgrs = _context.BusPassengerAssignment.Where(x => x.BusDepartureAssignment_ID == dbMatch.ID);
							foreach (var psgr in matchPsgrs) {
								_context.BusPassengerAssignment.DeleteObject(psgr);
							}
							_context.SaveChanges();
						}
						//save the passenger assignments
						var passengers = localMatches.SelectMany(x => x.Assignments);
						foreach (PassengerAssignment psgr in passengers.Where(x => x.BusID == busID)) {
							var matchPsgr = _context.BusPassengerAssignment.SingleOrDefault(x => x.BusDepartureAssignment_ID == dbMatch.ID && 
								x.PsgrList_ClientNo == psgr.ClientNo && x.ResNo == psgr.ResNo && x.Item == psgr.Item);
							//add the passenger
							if (matchPsgr == null) {
								matchPsgr = new BusPassengerAssignment() {
									BusDepartureAssignment_ID = dbMatch.ID,
									PsgrList_ClientNo = psgr.ClientNo,
									ResNo = psgr.ResNo,
									Item = psgr.Item
								};
								_context.BusPassengerAssignment.AddObject(matchPsgr);
							}
						}
						_context.SaveChanges();
					}
					//now find and delete the bus assignments left over from last time that are not selected this time
					foreach (var dbMatch in dbAssgns) {
						if (!localMatches.SelectMany(x => x.SelectedBusesList).Contains(dbMatch.Bus_ID)) {
							//delete the passenger assignment records
							foreach (var psgr in _context.BusPassengerAssignment.Where(x => x.BusDepartureAssignment_ID == dbMatch.ID)) {
								_context.BusPassengerAssignment.DeleteObject(psgr);
							}
							_context.SaveChanges();
							//delete the record
							_context.BusDepartureAssignment.DeleteObject(dbMatch);
							_context.SaveChanges();
						}
					}
				}

				Cursor = Cursors.Default;
				_changed = false;
				return true;
			}
			catch (Exception ex) {
				Cursor = Cursors.Default;
				XtraMessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			if (SaveAssignments()) {
				ShowActionConfirmation("Assignments Saved", buttonSave.Left);
			}
		}

		private void ShowActionConfirmation(string confirmation, int leftPos)
		{
			panelControlStatus.Left = leftPos;
			panelControlStatus.Visible = true;
			LabelStatus.Text = confirmation;
			actionConfirmation = new Timer();
			actionConfirmation.Interval = 3000;
			actionConfirmation.Start();
			actionConfirmation.Tick += TimedEvent;
		}

		private void TimedEvent(object sender, EventArgs e)
		{
			panelControlStatus.Visible = false;
			actionConfirmation.Stop();
		}

		private void dateEditDepartureDate_EditValueChanging(object sender, ChangingEventArgs e)
		{
			e.Cancel = AskAboutSaving();
		}

		private bool AskAboutSaving()
		{
			if (_changed) {
				var response = XtraMessageBox.Show("You have made changes which have not been saved.\nWould you like to save your changes?",
					Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
				if (response == DialogResult.Cancel) {
					return true;
				}
				else if (response == DialogResult.Yes) {
					if (!SaveAssignments()) {
						return true;
					}
				}
				else if (response == DialogResult.No) {
					_changed = false;
				}
			}
			return false;

		}
		private void buttonSendManifest_Click(object sender, EventArgs e)
		{
			if (SaveAssignments()) {
				if (GenerateReport()) {
					ShowActionConfirmation("Manifest sent", buttonSendManifest.Left);
				}
			}
		}

		private void BusAssignmentForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = AskAboutSaving();
		}

		private void BusAssignmentForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			_sys.Dispose();
			_context.Dispose();
		}

		public bool GenerateReport()
		{
			bool nothingToDo = true;
			if (busAssignmentBindingSource.List.Count > 0) {
				foreach (BusAssignment assgn in busAssignmentBindingSource.List) {
					if (assgn.SelectedBusesList.Count > 0 && assgn.Assignments.Count > 0) {
						nothingToDo = false;
						break;
					}
				}
			}
			if (nothingToDo) {
				XtraMessageBox.Show("There are no assignments to export to the manifest.", Text, 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			try {
				Cursor = Cursors.WaitCursor;
				using (ExcelPackage xl = new ExcelPackage()) {
					if (isHopper) {
						ExportReportHopper(xl);
					}
					else {
						ExportReportRegular(xl);
					}

                    string name = string.Format("BusManifest {0:dd-MMM-yyyy}", _selectedDate);
                    string filename = name + ".xlsx";
                    //string folder = Path.GetTempPath();
                    //FileInfo file = new FileInfo(Path.Combine(folder, filename));
                    //xl.SaveAs(file);

                    using (MemoryStream stream = new MemoryStream()) {
                        xl.SaveAs(stream);
                        stream.Flush();
                        stream.Position = 0;
                        using (SmtpClient smtp = new SmtpClient(_sys.Settings.MailServer, _sys.Settings.EmailPort)) {
                            smtp.Credentials = new System.Net.NetworkCredential(_sys.Settings.EmailUser, _sys.Settings.EmailPassword);
                            using (MailMessage message = new MailMessage(_sys.Settings.UnmonitoredEmail, textEmailAddress.Text)) {
                                message.Subject = name;
                                message.Body = string.Format("The bus manifest is attached for the date {0:dd-MMM-yyyy}.",
                                    _selectedDate);
                                message.Attachments.Add(new Attachment(stream, filename, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"));
                                smtp.Send(message);
                            }
                        }
                    }
                }
                Cursor = Cursors.Default;
				return true;
			}
			catch (Exception ex) {
				Cursor = Cursors.Default;
				XtraMessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

		}

		private string GetName(string type, string code)
		{
            try {
                switch (type) {
                    case "HTL":
                        return _context.HOTEL.Single(h => h.CODE == code).NAME;
                    case "OPT":
                        return _context.COMP.Single(h => h.CODE == code).NAME;
                    case "WAY":
                        return _context.WAYPOINT.Single(h => h.CODE == code).DESC;
                    case "BUS":
                        return _context.BusStation.Single(h => h.Code == code).Name;
                    case "TRN":
                        return _context.TrainStation.Single(h => h.Code == code).Name;
                    case "SEA":
                        return _context.SeaPort.Single(h => h.Code == code).Name;
                    case "CTY":
                        return _context.CITYCOD.Single(h => h.CODE == code).NAME;
                    case "AIR":
                        return _context.Airport.Single(h => h.Code == code).Name;
                    case "TBA":
                        return "To Be Advised";
                    default:
                        return "To Be Advised";
                }
            }
            catch {
                return "To Be Advised";
            }
        }

		private string ReplaceEverySecondInstance(string input, char replace, string replaceWith)
		{
			StringBuilder ret = new StringBuilder();
			bool isSecond = false;
			for (int chIndex = 0; chIndex < input.Length; chIndex++) {
				char ch = input[chIndex];

				if (ch == replace) {
					if (isSecond) {
						ret.Append(replaceWith);
					}
					else {
						ret.Append(ch);
					}

					isSecond = !isSecond;
				}
				else {
					ret.Append(ch);
				}
			}
			return ret.ToString();
		}

		private void ExportReportRegular(ExcelPackage xl)
		{
			//Each sheet represents a service and time, and may have multiple buses
			//First group by service and time
			IList<BusAssignment> services = busAssignmentBindingSource.List.Cast<BusAssignment>().ToList();
			var grouped = services.GroupBy(x => new {
				x.Code,
				x.ServiceTime24,
                x.PackageCode
			}).Select(g => new BusAssignment() {
				Code = g.Key.Code,
				ServiceTime24 = g.Key.ServiceTime24,
                PackageCode = g.Key.PackageCode
			}).ToList();

			foreach (BusAssignment groupItem in grouped) {
				string wsName = string.Format("{0} {1}{2}{3}", groupItem.Code, string.IsNullOrEmpty(groupItem.ServiceTime24) ? string.Empty : "(",
					groupItem.ServiceTime24, string.IsNullOrEmpty(groupItem.ServiceTime24) ? string.Empty : ")");
				var ws = xl.Workbook.Worksheets.Add(wsName);
				var matches = services.Where(x => x.Code == groupItem.Code && x.ServiceTime24 == groupItem.ServiceTime24);
				var buses = matches.SelectMany(x => x.SelectedBusesList).Distinct();

				//Get the list of possible categories from cprates for the service date of the item (not res date
				// because we need this list to be consistent regardless of when the trips were booked)
				//We are also leaving out service time, because it can change, in which case no ratesheets would be found
				var cats = _context.CPRATES.Include(x => x.ROOMCOD).
					Where(x => x.Inactive == false && x.CODE == groupItem.Code
					&& x.START_DATE <= _selectedDate && x.END_DATE >= _selectedDate).
					Select(x => new {
						x.CAT,
						x.ROOMCOD.DESC
					}).
					Distinct().
					OrderBy(x => x.DESC).
					ToList();

                var pkgCats = _context.PRATES.Include(x => x.ROOMCOD).
                    Where(x => x.Inactive == false && x.CODE == groupItem.PackageCode
                    && x.START_DATE <= _selectedDate && x.END_DATE >= _selectedDate).
                    Select(x => new {
                        x.CAT,
                        x.ROOMCOD.DESC
                    }).
                    Distinct().
                    OrderBy(x => x.DESC).
                    ToList();

                //Cells array is 1 based, using the same Row number as Excel displays
                ws.Cells[2, 1].Value = "Bus Manifest";
				ws.Cells[2, 1].Style.Font.Size = 16;
				ws.Cells[2, 1].Style.Font.Bold = true;
				ws.Cells[3, 1].Value = "Service:";
				ws.Cells[3, 2].Value = matches.First().Description;
				ws.Cells[3, 2, 3, 10].Merge = true;
				ws.Cells[4, 1].Value = "Tour Date:";
				ws.Cells[4, 2].Value = _selectedDate.ToString("MM/dd/yyyy");
				ws.Cells[5, 1].Value = "Tour Time:";
				ws.Cells[5, 2].Value = string.Format("{0:hh:mm tt}", matches.First().ServiceTime);
				ws.Cells[6, 1].Value = "Buses Assigned:";
				ws.Cells[6, 2].Value = buses.Count();
				ws.Cells[6, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
				ws.Cells[7, 1].Value = "Total Pax:";
				ws.Cells[7, 2].Value = services.SelectMany(x => x.Assignments).Count();
				ws.Cells[7, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

				int col = 0;
				int row = 9;
				foreach (int busID in buses) {
					int topOfPanel = row;
					var bus = _buses.Single(b => b.ID == busID);
					ws.Cells[row, 1].Value = "Bus:";
					ws.Cells[row, 2].Value = bus.Name;
					row++;
					ws.Cells[row, 1].Value = "Bus Size:";
					ws.Cells[row, 2].Value = bus.Capacity;
					ws.Cells[row, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
					row++;
					ws.Cells[row, 1].Value = "Seats remaining:";
					int assignedToThisBus = matches.SelectMany(x => x.Assignments).Where(a => a.BusID == busID).Count();
					ws.Cells[row, 2].Value = bus.Capacity - assignedToThisBus;
					ws.Cells[row, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
					var names = _nameAssignments.SingleOrDefault(n => n.Code == groupItem.Code 
						&& n.ServiceTime24 == groupItem.ServiceTime24 && n.BusID == busID);
					row++;
					ws.Cells[row, 1].Value = "Driver:";
					ws.Cells[row, 2].Value = names.DriverName;
					ws.Cells[row, 3].Value = names.DriverPhone;
					row++;
					ws.Cells[row, 1].Value = "Guide:";
					ws.Cells[row, 2].Value = names.GuideName;
					ws.Cells[row, 3].Value = names.GuidePhone;
					ws.Cells[topOfPanel, 1, row, 3].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

					row += 2;
					ws.Cells[row, 1, row, 3].Merge = true;
					ws.Cells[row, 1, row, 3].Value = "Booking Party Information";
					ws.Cells[row, 1, row, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
					ws.Cells[row, 1, row, 3].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
					ws.Cells[row, 1, row + 1, 3].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
					ws.Cells[row, 1, row + 1, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
					ws.Cells[row, 1, row + 1, 3].Style.Fill.BackgroundColor.SetColor(Color.Wheat);
					row++;
					ws.Cells[row, 1].Value = "Booking\nDate";
					ws.Cells[row, 2].Value = "Booking Company";
					ws.Cells[row, 3].Value = "Trip No.";
					ws.Cells[row, 4].Value = "Pickup\nTime";
					ws.Cells[row, 5].Value = "Pickup Point";
					ws.Cells[row, 6].Value = "No. of Pax";

					col = 7;
					foreach (var cat in cats) {
						string caption = ReplaceEverySecondInstance(cat.DESC, ' ', Environment.NewLine);
						ws.Cells[row, col].Value = caption;
						col++;
					}

					ws.Cells[row, col].Value = "Main Guest Name";
					ws.Cells[row, col+1].Value = "Phone";
					ws.Cells[row, col+2].Value = "Handled by";
					ws.Cells[row, col+3].Value = "Remarks";
					ws.Cells[row, 1, row, col+3].Style.Font.Size = 9;
					ws.Cells[row - 1, 4, row - 1, col + 3].Merge = true;
					ws.Cells[row - 1, 4, row - 1, col + 3].Value = "Operations Information";
					ws.Cells[row - 1, 4, row - 1, col + 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
					ws.Cells[row - 1, 4, row, col + 3].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
					ws.Cells[row - 1, 4, row - 1, col + 3].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
					ws.Cells[row - 1, 4, row, col + 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
					ws.Cells[row - 1, 4, row, col + 3].Style.Fill.BackgroundColor.SetColor(Color.AliceBlue);

					var trips = matches.SelectMany(x => x.Assignments).
						Where(a => a.BusID == busID).
						GroupBy(x => new {
						x.ResNo,
						x.Item 
					}).Select(g => new {
						g.Key.ResNo,
						g.Key.Item
					});

					foreach (var trip in trips) {
						row++;
						var resitm = _resItems.Single(x => x.RES_NO == trip.ResNo && x.ITEM == trip.Item);
						var psgrAssignments = matches.SelectMany(x => x.Assignments).
							Where(a => a.ResNo == trip.ResNo && a.Item == trip.Item && a.BusID == busID).
							OrderBy(p => p.ClientNo);		//sort to get primary first
						ws.Cells[row, 1].Value = string.Format("{0:MM/dd/yyyy}", resitm.RES_DATE);
						ws.Cells[row, 2].Value = resitm.RESHDR.AGY_NAME;
						ws.Cells[row, 3].Value = string.Format("{0}-{1:0#}",trip.ResNo, trip.Item);
						//We can use .First() because all the passengers booked for a regular bus tour in resitm have 
						//the same pickup location. To get a different pickup location per passenger an agent would have
						//to book a separate item (unlike hopper tours where end guests can select the pickup location)
						var mainPsgr = psgrAssignments.First();
						ws.Cells[row, 4].Value = string.Format("{0:hh:mm tt}", mainPsgr.PickupTime);
						ws.Cells[row, 5].Value = mainPsgr.PickupLocation;
						ws.Cells[row, 6].Value = psgrAssignments.Count();

						col = 7;
						//There is only one ResRoom record per item for services, and it holds category description
						foreach (var cat in cats) {
							if (resitm.ResRoom.Any(r => r.Cat == cat.CAT)) {
								ws.Cells[row, col].Value = psgrAssignments.Count();
							}
							else {
								ws.Cells[row, col].Value = 0;
							}
							col++;
						}

                        //If they split a reservation between multiple buses, then they may end up with a passenger
                        //on a bus for whom they do not have a phone number, because only one phone number is taken per res,
                        //but they will have to be aware of this when assigning the passengers to the buses to try to
                        //keep everyone in the same reservation together. Also, this name will not be the lead name
                        //for the res, but just the name of the first passenger from the res who is on this bus.
                        ws.Cells[row, col].Value = string.Format("{0}, {1}", mainPsgr.LastName, mainPsgr.FirstName);
						col++;
						ws.Cells[row, col].Value = mainPsgr.Phone;
						col++;
						ws.Cells[row, col].Value = resitm.RES_AGT;
						col++;
						ws.Cells[row, col].Value = resitm.InternalRemarks;
					}

					row += 3;
				}

				//col will be the last column accessed in the loop above
				for (int colIndex = 1; colIndex <= col; colIndex++) {
                    ws.Column(colIndex).AutoFit();
                    ws.Column(colIndex).Style.WrapText = true;
                }
            }

			//ws.Column(1).Style.Numberformat.Format = "MM/dd/yyyy";      //TODO: put this in the config file
		}

		private void ExportReportHopper(ExcelPackage xl)
		{
            var psgrStops = _context.ResRouteAssignment.Where(rra => rra.DepartureDate == _selectedDate).ToList();
			var busStops = _context.BusRouteStop.ToList();

			IList<BusAssignment> assignments = busAssignmentBindingSource.List.Cast<BusAssignment>().ToList();
			foreach (BusAssignment assgn in assignments) {
				foreach (int busID in assgn.SelectedBusesList) {
					var bus = _buses.Single(b => b.ID == busID);
                    string wsName = bus.Name;
                    if (assignments.SelectMany(a => a.SelectedBusesList.Where(s => s == busID)).Count() > 1) {
                        //Sheet names cannot be duplicates, so in case the same bus is assigned to multiple routes,
                        //use name (1), name (2) etc 
                        int count = xl.Workbook.Worksheets.Count(w => w.Name.StartsWith(wsName + " ("));
                        wsName = string.Format("{0} ({1})", bus.Name, count + 1);
                    }
                    var ws = xl.Workbook.Worksheets.Add(wsName);
					var psgrAssignments = assgn.Assignments.Where(a => a.BusID == busID).OrderBy(p => p.ResNo).ThenBy(p => p.ClientNo);
					//Cells array is 1 based, using the same Row number as Excel displays
					ws.Cells[1, 1].Value = "Hopper Manifest";
					ws.Cells[1, 1].Style.Font.Size = 16;
					ws.Cells[1, 1].Style.Font.Bold = true;
					ws.Cells[2, 1].Value = "Bus";
					ws.Cells[2, 2].Value = bus.Name;
                    var names = _nameAssignments.SingleOrDefault(n => n.DepartureID == assgn.DepartureID
                        && n.BusID == busID);
                    ws.Cells[3, 1].Value = "Driver";
                    ws.Cells[3, 2].Value = names.DriverName;
                    ws.Cells[3, 3].Value = names.DriverPhone;
                    ws.Cells[4, 1].Value = "Guide";
                    ws.Cells[4, 2].Value = names.GuideName;
                    ws.Cells[4, 3].Value = names.GuidePhone;
                    ws.Cells[5, 1].Value = "Route";
					ws.Cells[5, 2].Value = assgn.RouteName;
					ws.Cells[6, 1].Value = "Departure Date";
					ws.Cells[6, 2].Value = _selectedDate.ToString("MM/dd/yyyy");
					ws.Cells[7, 1].Value = "Departure Time";
					ws.Cells[7, 2].Value = assgn.DepartureTime.ToString("hh:mm tt");
					ws.Cells[8, 1].Value = "Total Guests";
					ws.Cells[8, 2].Value = psgrAssignments.Count();

					ws.Cells[10, 1].Value = "Trip Nbr";
					ws.Cells[10, 2].Value = "Last Name";
					ws.Cells[10, 3].Value = "First Name";
					ws.Cells[10, 4].Value = "Age";
					ws.Cells[10, 5].Value = "Pickup Time";
					ws.Cells[10, 6].Value = "Pickup Point";
					ws.Cells[10, 7].Value = "Stop Time";
					ws.Cells[10, 8].Value = "Stop Point";
					ws.Cells[10, 9].Value = "Dropoff Time";
					ws.Cells[10, 10].Value = "Dropoff Point";

					int rowIndex = 11;
					foreach (PassengerAssignment psgr in psgrAssignments) {
						var item = _context.RESITM.Single(r => r.RES_NO == psgr.ResNo && r.ITEM == psgr.Item);
						string code = item.CODE;
						string type = item.TYPE;
						string cat = item.CAT;

						ws.Cells[rowIndex, 1].Value = psgr.ResNo;
						ws.Cells[rowIndex, 2].Value = psgr.LastName;
						ws.Cells[rowIndex, 3].Value = psgr.FirstName;
						ws.Cells[rowIndex, 4].Value = psgr.Age;
						ws.Cells[rowIndex, 5].Value = string.Format("{0:hh:mm tt}", psgr.PickupTime);
						ws.Cells[rowIndex, 6].Value = psgr.PickupLocation;

						var stops = psgrStops.Where(s => s.BusDeparture_ID == psgr.DepartureID
							&& s.PsgrList_ClientNo == psgr.ClientNo && s.ResNo == psgr.ResNo && s.Item == psgr.Item);
						if (stops.Count() > 0) {
							foreach (var stop in stops) {
								var busStop = busStops.SingleOrDefault(b => b.ID == stop.BusRouteStop_ID_To);
								if (busStop != null) {
									ws.Cells[rowIndex, 7].Value = string.Format("{0:hh:mm tt}", stop.ArrivalTime);
									ws.Cells[rowIndex, 8].Value = GetName(busStop.Type, busStop.Code);
									rowIndex++;
								}
							}
							rowIndex--;		//the dropoffs should go to the right of the last stop, not on the next row
						}

						ws.Cells[rowIndex, 9].Value = string.Format("{0:hh:mm tt}", psgr.DropoffTime);
                        ws.Cells[rowIndex, 10].Value = psgr.DropoffLocation;
						rowIndex++;
					}

					ws.Cells["A10:J10"].AutoFilter = true;

					for (int colIndex = 1; colIndex <= 10; colIndex++) {
						ws.Column(colIndex).AutoFit();
						ws.Column(colIndex).Style.WrapText = true;
					}
				}
			}

			//ws.Column(1).Style.Numberformat.Format = "MM/dd/yyyy";      //TODO: put this in the config file
		}

		private void radioGroupType_SelectedIndexChanged(object sender, EventArgs e)
		{
			LoadRoutes();
		}

		private void radioGroupType_EditValueChanging(object sender, ChangingEventArgs e)
		{
			e.Cancel = AskAboutSaving();
		}

    }

    public class Passenger {
        public int ClientNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
        public string Age { get; set; }
        public int ResNo { get; set; }
        public short Item { get; set; }
        public string PickupLocationCode { get; set; }
        public string PickupLocationType { get; set; }
        public string PickupLocation { get; set; }
        public string PickupTime24 { get; set; }
        public DateTime? PickupTime { get; set; }
        public string DropoffLocationCode { get; set; }
        public string DropoffLocationType { get; set; }
        public string DropoffLocation { get; set; }
        public string DropoffTime24 { get; set; }
        public DateTime? DropoffTime { get; set; }
    }

    public class NameAssignment
	{
		public int BusID { get; set; }
		public string BusName { get; set; }
		public int? DepartureID { get; set; }
		public string Code { get; set; }
		public string ServiceTime24 { get; set; }
		public string DriverName { get; set; }
		public string GuideName { get; set; }
		public string DriverPhone { get; set; }
		public string GuidePhone { get; set; }
	}

	public class BusAssignment
	{
		public BusAssignment()
		{
			SelectedBuses = string.Empty;
		}

		public string Code { get; set; }
		public string Description { get; set; }
        public string PackageCode { get; set; }
        public string ServiceTime24 { get; set; }
		public DateTime? ServiceTime { get; set; }
		public int? DepartureID { get; set; }
		public int RouteID { get; set; }
		public DateTime DepartureTime { get; set; }
		public string RouteName { get; set; }

		public int Count { get; set; }
		public string SelectedBuses { get; set; }
		public List<int> SelectedBusesList
		{
			get
			{
				if (string.IsNullOrEmpty(SelectedBuses)) {
					return new List<int>();
				}
				else {
					string[] split = SelectedBuses.Split(',');
					return split.Select(s => int.Parse(s)).ToList();
				}
			}
		}
		public List<PassengerAssignment> Assignments { get; set; }
	}

	public class PassengerAssignment
	{
		public int ClientNo { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Phone { get; set; }
		public string Age { get; set; }
		public int BusID { get; set; }
		public string BusName { get; set; }
		public int? DepartureID { get; set; }
		public string DepartureName { get; set; }
		public int RouteID { get; set; }
		public string RouteName { get; set; }
		public int ResNo { get; set; }
		public short Item { get; set; }
		public string PickupLocation { get; set; }
		public DateTime? PickupTime { get; set; }
        public string DropoffLocation { get; set; }
        public DateTime? DropoffTime { get; set; }
    }

}
