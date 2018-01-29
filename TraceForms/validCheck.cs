using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using System.Data.EntityClient;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using  FlexControls;
using FlexModel;
using System.Runtime.InteropServices;

namespace TraceForms
{
    class validCheck
    {
        public static void check(object sender, ErrorProvider error, Action validationCall, BindingSource source)
        {
            source.EndEdit();
            try
            {
                validationCall();
                    error.SetError((Control)sender, "");
            }
            catch (ValidationException ex)
            {
                error.SetError(((Control)sender), ex.Message.Substring(ex.Message.IndexOf(":") + 1));
            }
        }

        public static bool checkAll(Control.ControlCollection cc, ErrorProvider error, Func<List<ValidationException>> validationCall, BindingSource source)
        {
            source.EndEdit();
            bool valid = true;
            //error.Clear();


            Dictionary<string, int> bindings = new Dictionary<string, int>();
            int i = 0;
            string test = "";
            foreach (Control ctrl in cc)
            {
                try
                {
                    test = ((Control)ctrl).DataBindings[0].BindingMemberInfo.BindingMember;
                    bindings.Add(test, i);
                }
                catch
                {
                    try
                    {
                        test = ((GridSearchControl)ctrl).ButtonEdit.DataBindings[0].BindingMemberInfo.BindingMember;
                        bindings.Add(test, i);
                    }
                    catch
                    {
                    }
                }
                i++;
            }


            List<ValidationException> errors = validationCall();
            foreach (ValidationException ex in errors)
            {
                //d.TryGetValue("key", out value)
                int value;
                string name = ex.Message.Substring(0, ex.Message.IndexOf(":"));
                if (bindings.TryGetValue(name, out value))
                {

                    error.SetError(((Control)cc[value]), ex.Message.Substring(ex.Message.IndexOf(":") + 1));
                    valid = false;
                }
                else
                {
                    XtraMessageBox.Show(ex.Message, name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    valid = false;
                }
            }

            return valid;
        }
        public static bool checkAll(Control.ControlCollection cc, ErrorProvider error, Func<List<ValidationException>> validationCall, BindingSource source, FlextourEntities context)
        {
            source.EndEdit();
            bool valid = true;
            //error.Clear();


            Dictionary<string, int> bindings = new Dictionary<string, int>();
            int i = 0;
            string test = "";
            foreach (Control ctrl in cc)
            {
                try
                {
                    test = ((Control)ctrl).DataBindings[0].BindingMemberInfo.BindingMember;
                    bindings.Add(test, i);
                }
                catch
                {
                    try
                    {
                        test = ((GridSearchControl)ctrl).ButtonEdit.DataBindings[0].BindingMemberInfo.BindingMember;
                        bindings.Add(test, i);
                    }
                    catch
                    {
                    }
                }
                i++;
            }


            List<ValidationException> errors = validationCall();
            foreach (ValidationException ex in errors)
            {
                string name = ex.Message.Substring(0, ex.Message.IndexOf(":"));
                if (bindings.ContainsKey(name))
                {
                    error.SetError(((Control)cc[bindings[name]]), ex.Message.Substring(ex.Message.IndexOf(":") + 1));
                    valid = false;
                }
            }

            return valid;
        }


        public static bool saveRec(ref bool modified, bool validated, ref bool newRec, FlexModel.FlextourEntities context, BindingSource source, string name, ErrorProvider error, Cursor curse, bool prompt)
        {
            //context = new  .FlextourEntities();
            try
            {

                if (modified || newRec)/////Has the record been changed?
                {
                    DialogResult select = DialogResult.Yes;
                    if (prompt)
                        select = DevExpress.XtraEditors.XtraMessageBox.Show("Do you want to confirm these changes?", name, MessageBoxButtons.YesNoCancel);
                    curse = Cursors.WaitCursor;
                    if (select == DialogResult.Yes)////keep changes
                    {
                        if (validated) ////are changes valid?
                        {
                            error.Clear();
                            context.SaveChanges();
                            modified = false;
                            newRec = false;
                            curse = Cursors.Arrow;
                            return true; ///Form is saved
                        }
                        DevExpress.XtraEditors.XtraMessageBox.Show("Please correct invalid data entries", "Could Not Save", MessageBoxButtons.OK);
                        return false; ///There was invalid data
                    }
                    if (select == DialogResult.No) ////Discard changes
                    {
                        error.Clear();
                        modified = false;
                        if (newRec)
                        {
                            //MessageBox.Show("I am coming here");
                            source.RemoveCurrent();
                            context.SaveChanges();
                            newRec = false;
                            curse = Cursors.Arrow;
                        }
                        return true;
                    }
                    curse = Cursors.Arrow;
                    return false; ///Pressed cancel
                }
                else
                    return true; ///No changes to save
                ///
            }

            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message.Contains("Cannot insert duplicate"))
                {
                    MessageBox.Show("You are attempting to enter a duplicate record please make the necessary changes.");

                }
                else
                {
                    if (ex.Message.Contains("inner exception"))
                        MessageBox.Show(ex.InnerException.Message);
                    else
                        MessageBox.Show(ex.Message);
                }
                return false;
            }

        }

        public static bool saveRec(ref bool modified, bool validated, ref bool newRec, FlexModel.FlextourEntities context, BindingSource source, string name, ErrorProvider error, Cursor curse)
        {
            return saveRec(ref modified, validated, ref newRec, context, source, name, error, curse, true);
        }

        //public static bool saveRec(ref bool modified, bool validated, ref bool newRec, FlexModel.FlextourEntities context, BindingSource source, string name, ErrorProvider error, Control.ControlCollection cc)
        //{
        //    //context = new  .FlextourEntities();
        //    try
        //    {
        //        DialogResult select;
        //        if (modified || newRec)/////Has the record been changed?
        //        {
        //            if (name == "BeforeLeaveRow")
        //            {
        //                name = "Warning Message!";
        //                select = DevExpress.XtraEditors.XtraMessageBox.Show("You are attempting to navigate away from the record that is currently being edited. \n If you wish to save your changes select Yes. \n If you wish to disregard changes select No. \n Or to continue editing the record select Cancel.", name, MessageBoxButtons.YesNoCancel);
                       
        //            }
        //            else
        //                select = DevExpress.XtraEditors.XtraMessageBox.Show("Do you want to save?", name, MessageBoxButtons.YesNoCancel);

        //            if (select == DialogResult.Yes)////keep changes
        //            {
        //                foreach (Control ctrl in cc)
        //                {
        //                    if (!String.IsNullOrWhiteSpace(error.GetError(ctrl)))
        //                        validated = false;
        //                }

        //                if (validated) ////are changes valid?
        //                {
        //                    context.SaveChanges();

        //                    modified = false;
        //                    newRec = false;
        //                    return true; ///Form is saved
        //                }
        //                DevExpress.XtraEditors.XtraMessageBox.Show("Please correct invalid data entries", "Could Not Save", MessageBoxButtons.OK);
        //                return false; ///There was invalid data
        //            }
        //            if (select == DialogResult.No) ////Discard changes
        //            {
        //                modified = false;
        //                if (newRec)
        //                {
        //                    newRec = false;
        //                    source.RemoveCurrent();
        //                    context.SaveChanges();
        //                }
        //                newRec = false;
        //                return true;
        //            }

        //            return false; ///Pressed cancel
        //        }
        //        else
        //            return true; ///No changes to save
        //                                                        ///
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.InnerException.Message.Contains("Cannot insert duplicate"))
        //        {
        //            MessageBox.Show("You are attempting to enter a duplicate record please make the necessary changes.");

        //        }

        //        if (ex.Message.Contains("The changes to the database were committed successfully, but an error occurred while updating the object context."))
        //        {
        //            modified = false;
        //            newRec = false;
        //            return true;
        //        }
              
        //        return false;
        //    }
        //}
        //public static bool dummy()
        //{
        //    return false;
        //}

        //public static bool saveRoutine(BindingSource source, FlexModel.FlextourEntities context, ErrorProvider error, ref bool newRec, ref bool modified, Func<List<ValidationException>> validate, Control.ControlCollection cc, Func<bool> doThis)
        //{
        //    try
        //    {
        //        bool returnVal = true;
        //        if (modified || newRec)
        //        {
        //            returnVal = false;
        //            bool temp = newRec;
        //            bool ok = validCheck.checkAll(cc, error, validate, source);

        //            if (saveRec(ref modified, ok, ref newRec, context, source, "Save Message", error, cc))
        //            {
        //                error.Clear();
        //                returnVal = true;
        //                modified = false;
        //            }
        //            else
        //                doThis();
        //        }

        //        return returnVal;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.InnerException.Message);
        //        return false;
        //    }
        //}
        //Comprod2 specific
        //public static bool saveRoutine(BindingSource source, FlexModel.FlextourEntities context, ErrorProvider error, ref bool newRec, ref bool modified, Func<List<ValidationException>> validate, Control.ControlCollection cc, Func<bool> doThis, string name)
        //{
        //    try
        //    {
        //        bool returnVal = true;
        //        if (modified || newRec)
        //        {
        //            returnVal = false;
        //            bool temp = newRec;
        //            bool ok = validCheck.checkAll(cc, error, validate, source);

        //            if (saveRec(ref modified, ok, ref newRec, context, source, name, error, cc))
        //            {
        //                error.Clear();
        //                returnVal = true;
        //                modified = false;
        //            }
        //            else
        //                doThis();
        //        }

        //        return returnVal;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return false;
        //    }
        //}

        public static System.Boolean IsNumeric(System.Object Expression)
        {
            if (Expression == null || Expression is DateTime)
            {
                return false;
            }
            if (Expression is Int16 || Expression is Int32 || Expression is Int64 || Expression is Decimal || Expression is Single || Expression is Double || Expression is Boolean)
            {
                return true;
            }
            try
            {
                if (Expression is string)
                    Double.Parse(Expression as string);
                else
                    Double.Parse(Expression.ToString());
                return true;
            }
            catch
            {
            } // just dismiss errors but return false
            return false;
        }

        public static string convertDate(string value)
        {
            string temp = "";
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (!value.Contains("/") && value.Length == 8)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        temp += value[i];
                        if (i == 1 || i == 3)
                            temp += "/";
                    }
                    value = temp;
                }
                else if (!value.Contains("/") && value.Length == 6)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        temp += value[i];
                        if (i == 1 || i == 3)
                            temp += "/";
                    }
                    value = temp;
                }
                else if (!value.Contains("/") && value.Length == 7)
                {

                    for (int i = 0; i < 7; i++)
                    {
                        
                        if (i == 1 || i == 3)
                            temp += "/";
                        temp += value[i];
                    }
                    value = temp;

                }

                DateTime val;
                if (DateTime.TryParse(value, out val))
                {
                    val = Convert.ToDateTime(value);
                    int day = val.Day;
                    int year = val.Year;
                    int month = val.Month;
                    string month_st;

                    switch (month)
                    {
                        case 1:
                            month_st = "Jan";
                            value = day + "-" + month_st + "-" + year;
                            return value;

                        case 2:
                            month_st = "Feb";
                            value = day + "-" + month_st + "-" + year;
                            return value;

                        case 3:
                            month_st = "Mar";
                            value = day + "-" + month_st + "-" + year;
                            return value;

                        case 4:
                            month_st = "Apr";
                            value = day + "-" + month_st + "-" + year;
                            return value;

                        case 5:
                            month_st = "May";
                            value = day + "-" + month_st + "-" + year;
                            return value;

                        case 6:
                            month_st = "Jun";
                            value = day + "-" + month_st + "-" + year;
                            return value;

                        case 7:
                            month_st = "Jul";
                            value = day + "-" + month_st + "-" + year;
                            return value;

                        case 8:
                            month_st = "Aug";
                            value = day + "-" + month_st + "-" + year;
                            return value;

                        case 9:
                            month_st = "Sep";
                            value = day + "-" + month_st + "-" + year;
                            return value;

                        case 10:
                            month_st = "Oct";
                            value = day + "-" + month_st + "-" + year;
                            return value;

                        case 11:
                            month_st = "Nov";
                            value = day + "-" + month_st + "-" + year;
                            return value;

                        case 12:
                            month_st = "Dec";
                            value = day + "-" + month_st + "-" + year;
                            return value;
                    }
                }
            }
            return "";
        }




        public static void reorderPositions(object sender, string recordModification, int reqPosition = 0)
        {
            GridView view = (GridView)sender;
            if (view.RowCount == 0)
                return;

            switch (recordModification)
            {
                case ("Deletion"):
                    rowDeletion(view);
                    break;
                case ("Insertion"):
                    rowInsertion(view, reqPosition);
                    break;
                case ("ChangePosition"):
                    changePosition(view, reqPosition);
                    break;
            }
        }

        private static void changePosition(GridView view, int reqPosition)
        {
            int requiredPosition = reqPosition;
            var position = view.GetFocusedRowCellValue("Position");
            if (reqPosition < (int)position)
            {
                view.SetRowCellValue((requiredPosition - 1), "Position", reqPosition);
                for (int i = requiredPosition; i < (int)position; i++)
                {
                    view.SetRowCellValue(i, "Position", i + 2);
                }
            }
            if (reqPosition > (int)position)
            {
                view.SetRowCellValue((requiredPosition - 1), "Position", reqPosition);
                for (int i = requiredPosition; i > (int)position; i--)
                {
                    view.SetRowCellValue(i, "Position", i - 2);
                }
            }
            rowSort(view);
            view.FocusedRowHandle = requiredPosition;
        }

        private static void rowDeletion(GridView view)
        {
            int deletedrowPos = view.FocusedRowHandle;
            int viewRowsCount = view.RowCount;

            for (int i = deletedrowPos; i < viewRowsCount; i++)
            {
                view.SetRowCellValue(i, "Position", i + 1);
            }
            rowSort(view);
        }

        private static void rowInsertion(GridView view, int requiredPosition)
        {
            int insertedRowPos = requiredPosition;
            int viewRowCountInsert = view.RowCount;

            for (int i = (insertedRowPos - 1); i < viewRowCountInsert; i++)
            {
                view.SetRowCellValue(i, "Position", i + 2);
            }
            rowSort(view);
        }

        private static void rowSort(object sender)
        {
            GridView view = (GridView)sender;
            view.BeginSort();
            try
            {
                view.ClearSorting();
                view.Columns["Position"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            }
            finally
            {
                view.EndSort();
            }
        }
    }
}
