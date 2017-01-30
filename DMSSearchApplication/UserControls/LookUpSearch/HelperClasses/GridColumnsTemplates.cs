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

        public ObservableCollection<DataGridColumn> FindColumns(string LookUpName, string ViewName)
        {
            switch (ViewName)
            {
                case "MainWindows":
                    return MainWindow(LookUpName);
                default:
                    return null;
            }
        }

        public ObservableCollection<DataGridColumn> MainWindow(string LookUpName)
        {
            ObservableCollection<DataGridColumn> ColumnCollection = new ObservableCollection<DataGridColumn>();
            if (LookUpName == "EmployeeFirstNames")
            {
                System.Windows.Data.Binding bindings = new System.Windows.Data.Binding("FirstName");
                DataGridTextColumn s = new DataGridTextColumn();
                s.Header = "First Name";
                s.Binding = bindings;
                ColumnCollection.Add(s);
            }
            else if (LookUpName == "EmployeeLastNames")
            {
                System.Windows.Data.Binding bindings = new System.Windows.Data.Binding("LastName");
                DataGridTextColumn s = new DataGridTextColumn();
                s.Header = "Last Name";
                s.Binding = bindings;
                ColumnCollection.Add(s);
            }
            else if (LookUpName == "ERMEmployee")
            {
                System.Windows.Data.Binding FNameBinding = new System.Windows.Data.Binding("FirstName");
                DataGridTextColumn FName = new DataGridTextColumn();
                FName.Header = "First Name";
                FName.Binding = FNameBinding;
                ColumnCollection.Add(FName);

                System.Windows.Data.Binding MNameBinding = new System.Windows.Data.Binding("MiddleName");
                DataGridTextColumn MName = new DataGridTextColumn();
                MName.Header = "Middle Name";
                MName.Binding = MNameBinding;
                ColumnCollection.Add(MName);

                System.Windows.Data.Binding LNameBinding = new System.Windows.Data.Binding("LastName");
                DataGridTextColumn LName = new DataGridTextColumn();
                LName.Header = "Last Name";
                LName.Binding = LNameBinding;
                ColumnCollection.Add(LName);
            }
            return ColumnCollection;
        }
    }
}
