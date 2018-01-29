using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors;
using FlexModel;
using DevExpress.XtraGrid.Columns;
using System.ComponentModel.DataAnnotations;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using System.Linq;
using System.Collections;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Runtime.InteropServices;
using System.Data.Entity;

namespace TraceForms
{  
    public partial class MediaInfoMatchForm : DevExpress.XtraEditors.XtraForm
    {
        public FlextourEntities context;
        public ArrayList unboundPosition = new ArrayList();
        public ArrayList unboundSelection = new ArrayList();
        public int mediaInfoSectID;
        public string lang;
        public string code;
        public string type;
        public Timer rowStatusSave;
        public MEDIAINFO rcd;
        public MediaInfoMatchForm(FlextourEntities cont, MEDIAINFO record)
        {
            InitializeComponent();
            context = cont;
            rcd = record;
            AddButton.Visible = true;
            
            List<MEDIARPT> resultList = loadGrid(record);

            if (resultList.Count > 0)
                GridViewAddToReports.GridControl.DataSource = resultList;
        }

        private List<MEDIARPT> loadGrid(MEDIAINFO record)
        {
            
            List<MEDIARPT> resultList = new List<MEDIARPT>();
            unboundSelection.RemoveRange(0, unboundSelection.Count);
            unboundPosition.RemoveRange(0, unboundSelection.Count);
            unboundPosition.Clear();
            unboundSelection.Clear();
            GridViewAddToReports.GridControl.DataSource = null;

            lang = record.LANG;
            code = record.CODE;
            type = record.TYPE;
            mediaInfoSectID = record.ID;
            IEnumerable<MEDIARPT> mediaRecs = from mrpt in context.MEDIARPT
                                              where mrpt.TYPE == type && mrpt.LANG == lang && mrpt.CODE == code
                                              select mrpt;

            foreach (MEDIARPT rec in mediaRecs)
            {
                if ((from mediaItem in context.MediaRptItem where mediaItem.REPORT_ID == rec.ID && mediaItem.SECTION_ID == mediaInfoSectID select mediaItem).Count() == 0)
                {
                    resultList.Add(rec);
                }

            }

            //04Sep12 - LRUPE: updated how we populate the array list that is bound as an object to the upbound columns 
            //so that every row can store values and not a static number.
            for (int I = 0; I <= resultList.Count -1; I++) 
            {
                unboundPosition.Add("");
                unboundSelection.Add("");
            }

            return resultList;
         
           
        }
        public MediaInfoMatchForm(FlextourEntities cont, int ID)
        {
            InitializeComponent();
            mediaInfoSectID = ID;
            GridViewAddToReports.Columns.ColumnByFieldName("Selected").Visible = false;
            AddButton.Visible = false;
            context = cont;
            GridViewAddToReports.GridControl.DataSource = from mediaRpt in context.MediaRptItem
                                                          from rpt in context.MEDIARPT
                                                          where mediaRpt.SECTION_ID == ID && rpt.ID == mediaRpt.REPORT_ID
                                                          select new { mediaRpt.POSITION, rpt.RPT_TYPE, rpt.LANG, rpt.TYPE, rpt.CODE, rpt.CAT, rpt.AGENCY,
                                                              rpt.SVCDATE_START, rpt.SVCDATE_END, rpt.RESDATE_START, rpt.RESDATE_END };
            GridViewAddToReports.OptionsBehavior.Editable = false;
        }

        private void GridViewAddToReports_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "Selected")
                {
                    if (e.IsGetData)
                        e.Value = unboundSelection[e.ListSourceRowIndex];

                    if (e.IsSetData)
                        unboundSelection[e.ListSourceRowIndex] = e.Value;
                }

                if (e.Column.FieldName == "POSITION")
                {
                    if (e.IsGetData)
                        e.Value = unboundPosition[e.ListSourceRowIndex];

                    if (e.IsSetData)
                        unboundPosition[e.ListSourceRowIndex] = e.Value;
                }
            }
            catch (Exception ex)
            {

            }
        }

        //private void GridViewAddToReports_BeforeLeaveRow(object sender, RowAllowEventArgs e)
        //{
        //    string position = GridViewAddToReports.GetFocusedRowCellDisplayText("POSITION");
        //    string selection = GridViewAddToReports.GetFocusedRowCellDisplayText("Selected");
        //    if (((selection == "Checked") && string.IsNullOrWhiteSpace(position)) || (!string.IsNullOrWhiteSpace(position) && (selection == "Unchecked" || selection == "Indeterminate")))
        //    {
        //        MessageBox.Show("If the row is selected or a position is chosen a value must also be entered in the other column.");
        //        e.Allow = false;
        //    }
        //    else
        //        e.Allow = true;
        //}

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            int rowsAdded = 0;
            for (int x = 0; x < GridViewAddToReports.RowCount; x++)
            {
                short position = 0;
                string selection = GridViewAddToReports.GetRowCellDisplayText(x, "Selected");
                int ID = (int)GridViewAddToReports.GetRowCellValue(x, ColumnIDAddToReports);
                string strPos = (string)GridViewAddToReports.GetRowCellValue(x, GridColumnPosition);
                if ((selection == "Checked") && (!string.IsNullOrEmpty(strPos)))
                {

                    object strPosition = GridViewAddToReports.GetRowCellValue(x, GridColumnPosition); //Get the selection from position combobox
                    //If selection is First
                    if (strPosition == (object)("First"))
                    {
                        if ((from mRptItem in context.MediaRptItem where mRptItem.REPORT_ID == ID orderby mRptItem.POSITION select mRptItem).Count() > 0)
                        {
                            //Bring the data from mediaRptItem with the selected reportID  and increment the positions of remaining rows by 1
                            var items = context.MediaRptItem
                                .Include(mri => mri.MEDIARPT)
                                .Where(mri => mri.REPORT_ID == ID);
                            foreach (MediaRptItem mRptItem in items)
                            {
                                mRptItem.MEDIARPT.ChgDate = DateTime.Now;
                                mRptItem.POSITION = (Int16)(mRptItem.POSITION++);
                            }
                        }
                        position = 1;   //Newly added row is set at the top position
                    }

                //If selection is last
                    else if (strPosition == (object)("Last"))
                    {
                        int positionMax = Convert.ToInt32((from mRptItem in context.MediaRptItem where mRptItem.REPORT_ID == ID orderby mRptItem.POSITION select mRptItem.POSITION).Max());
                        //Set the position to the highest value
                        position = (short)(positionMax + 1);
                    }

                //If selection is <enter any number>
                    else
                    {
                        try
                        {
                            short pos = short.Parse((GridViewAddToReports.GetRowCellValue(x, GridColumnPosition)).ToString());
                            int positionMax = Convert.ToInt32((from mRptItem in context.MediaRptItem where mRptItem.REPORT_ID == ID orderby mRptItem.POSITION select mRptItem.POSITION).Max());

                            //if entered number is larger than the max position in MediaRptItem set the position to the highest value
                            if (pos > positionMax)
                            {
                                GridViewAddToReports.SetRowCellValue(x, GridColumnPosition, positionMax + 1);
                            }
                            else
                            //Otherwise set the position value to the entered number
                            {
                                //Bring the data from mediaRptItem with rows having position equal to or greater than the entered position  and increment their positions by 1
                                var items = context.MediaRptItem
                                    .Include(mri => mri.MEDIARPT)
                                    .Where(mri => mri.REPORT_ID == ID && mri.POSITION >= pos);
                                foreach (MediaRptItem mRptItem in items)
                                {
                                    mRptItem.MEDIARPT.ChgDate = DateTime.Now;
                                    mRptItem.POSITION = (Int16)(mRptItem.POSITION++);
                                }
                                GridViewAddToReports.SetRowCellValue(x, GridColumnPosition, pos);
                            }
                            position = pos;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Please! Enter a position value to add the report");
                        }
                    }

                    if (position > 0)
                    {
                        MediaRptItem item = new MediaRptItem();
                        int reportId = (int)(GridViewAddToReports.GetRowCellValue(x, "ID"));
                        item.REPORT_ID = reportId;
                        item.SECTION_ID = mediaInfoSectID;
                        item.POSITION = (short)position;
                        context.AddToMediaRptItem(item);
                        var rpt = context.MEDIARPT.FirstOrDefault(mr => mr.ID == reportId);
                        if (rpt != null) {
                            rpt.ChgDate = DateTime.Now;
                        }
                        context.SaveChanges();
                        mediaRptItemBindingSource.ResetBindings(false);
                        GridViewAddToReports.RefreshData();
                        rowsAdded++;
                    }

            }
                else if ((selection == "Checked") && (string.IsNullOrEmpty(strPos)))
                {
                    MessageBox.Show("If the row is selected or a position is chosen a value must also be entered in the other column.");
                }
               }

            GridViewAddToReports.RefreshData();

            if (rowsAdded > 0)
            {
                List<MEDIARPT> resultList = loadGrid(rcd);
                GridControlAddToReports.DataSource = resultList;
            }
         
            context.SaveChanges();
            mediaRptItemBindingSource.ResetBindings(false);
            GridControlAddToReports.Refresh();
            GridViewAddToReports.RefreshData();
            panelControlStatus.Visible = true;
            if (rowsAdded > 1)
            {
                LabelStatus.Text = rowsAdded + " " + "reports added";
            }
            else if (rowsAdded == 1)
            {
                LabelStatus.Text = rowsAdded + " " + "report added";
            }
            else if (rowsAdded == 0)
            { LabelStatus.Text = "No reports added"; }
            rowStatusSave = new Timer();
            rowStatusSave.Interval = 3000;
            rowStatusSave.Start();
            rowStatusSave.Tick += TimedEventSave;                                
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private void GridViewAddToReports_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "POSITION")
            {
                if (GridViewAddToReports.Columns.ColumnByFieldName("Selected").Visible == false)
                {
                    e.RepositoryItem = repositoryItemTextEdit1;
                }
                else
                    e.RepositoryItem = repositoryItemComboBox1;
            }

        }

        private void MediaInfoMatchForm_Shown(object sender, EventArgs e)
        {
            if (GridViewAddToReports.RowCount == 0)
            {
                MessageBox.Show("No matching reports found.");
                this.Close();
            }
        }


    }
}
