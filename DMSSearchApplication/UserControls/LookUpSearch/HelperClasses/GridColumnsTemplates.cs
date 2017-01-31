using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DMSSearchApplication.UserControls.LookUpSearch.HelperClasses
{
    public class GridColumnsTemplates
    {
        public GridColumnsTemplates()
        {
        }

        public ObservableCollection<DataGridColumn> FindColumns(LookUpName LookUpName, ViewName ViewName)
        {
            switch (ViewName)
            {
                case HelperClasses.ViewName.Employee:
                    return Employee(LookUpName);
                default:
                    return null;
            }
        }

        public ObservableCollection<DataGridColumn> Employee(LookUpName LookUpName)
        {
            ObservableCollection<DataGridColumn> ColumnCollection = new ObservableCollection<DataGridColumn>();

            switch (LookUpName)
            {
                case HelperClasses.LookUpName.ZipCodeSearch:
                    System.Windows.Data.Binding bindings = new System.Windows.Data.Binding("ZipCode");
                    DataGridTextColumn s = new DataGridTextColumn();
                    s.Header = "Zip Code";
                    s.Binding = bindings;
                    ColumnCollection.Add(s);

                    System.Windows.Data.Binding bindings2 = new System.Windows.Data.Binding("City");
                    DataGridTextColumn s2 = new DataGridTextColumn();
                    s2.Header = "City";
                    s2.Binding = bindings2;
                    ColumnCollection.Add(s2);

                    System.Windows.Data.Binding bindings3 = new System.Windows.Data.Binding("State");
                    DataGridTextColumn s3 = new DataGridTextColumn();
                    s3.Header = "State";
                    s3.Binding = bindings3;
                    ColumnCollection.Add(s3);

                    System.Windows.Data.Binding bindings4 = new System.Windows.Data.Binding("Country");
                    DataGridTextColumn s4 = new DataGridTextColumn();
                    s4.Header = "Country";
                    s4.Binding = bindings4;
                    ColumnCollection.Add(s4);
                    break;

                case HelperClasses.LookUpName.ERMEmployee:
                    System.Windows.Data.Binding bindings5 = new System.Windows.Data.Binding("EmployeeID");
                    DataGridTextColumn s5 = new DataGridTextColumn();
                    s5.Header = "Employee (#)";
                    s5.Binding = bindings5;
                    ColumnCollection.Add(s5);

                    System.Windows.Data.Binding bindings6 = new System.Windows.Data.Binding("Name");
                    DataGridTextColumn s6 = new DataGridTextColumn();
                    s6.Header = "Employee Name";
                    s6.Binding = bindings6;
                    ColumnCollection.Add(s6);

                    System.Windows.Data.Binding bindings7 = new System.Windows.Data.Binding("OldEmployeeID");
                    DataGridTextColumn s7 = new DataGridTextColumn();
                    s7.Header = "Old Employee (#)";
                    s7.Binding = bindings7;
                    ColumnCollection.Add(s7);
                    break;

                case HelperClasses.LookUpName.City:
                    System.Windows.Data.Binding bindings8 = new System.Windows.Data.Binding("City");
                    DataGridTextColumn s8 = new DataGridTextColumn();
                    s8.Header = "City";
                    s8.Binding = bindings8;
                    ColumnCollection.Add(s8);

                    System.Windows.Data.Binding bindings9 = new System.Windows.Data.Binding("State");
                    DataGridTextColumn s9 = new DataGridTextColumn();
                    s9.Header = "State";
                    s9.Binding = bindings9;
                    ColumnCollection.Add(s9);

                    System.Windows.Data.Binding bindings10 = new System.Windows.Data.Binding("Country");
                    DataGridTextColumn s10 = new DataGridTextColumn();
                    s10.Header = "Country";
                    s10.Binding = bindings10;
                    ColumnCollection.Add(s10);
                    break;
            }
            return ColumnCollection;
        }
    }
}
