
using DMSSearchApplication.UserControls.LookUpSearch;
using DMSSearchApplication.UserControls.LookUpSearch.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DMSSearchApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEmployeeName_Click(object sender, RoutedEventArgs e)
        {
            LookUpSearchView objEmployee = new LookUpSearchView(ViewName.Employee, LookUpName.ERMEmployee, "", "Normal", "Name");
            

            // This has beend done fill look up with out creating any extra class and object and handler.
            txtEmployeeName.DataContext = objEmployee.DataContext;

            SetOwner(objEmployee);
            objEmployee.ShowDialog();

            // Need to confirm with ravi.
            if (objEmployee.DataContext is ISelectedRow)
            {
                System.Data.DataRow dr = (objEmployee.DataContext as ISelectedRow).CurrentSelectedRow;
                txtId.Text = dr["EmployeeID"].ToString();
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            LookUpSearchView objEmployee = new LookUpSearchView(ViewName.Employee, LookUpName.ZipCodeSearch, "", "Normal", "ZipCode");
            txtZipCode.DataContext = objEmployee.DataContext;
            SetOwner(objEmployee);
            objEmployee.ShowDialog();
        }

        private void btnId_Click(object sender, RoutedEventArgs e)
        {
            LookUpSearchView objEmployee = new LookUpSearchView(ViewName.Employee, LookUpName.ERMEmployee, "", "Normal", "EmployeeID");
            txtId.DataContext = objEmployee.DataContext;
            SetOwner(objEmployee);
            objEmployee.ShowDialog();

            // Need to confirm with ravi.
            if (objEmployee.DataContext is ISelectedRow)
            {
                System.Data.DataRow dr = (objEmployee.DataContext as ISelectedRow).CurrentSelectedRow;
                txtEmployeeName.Text = dr["Name"].ToString();
            }
        }

        private void SetOwner(System.Windows.Window objWD)
        {
            WindowInteropHelper child = new WindowInteropHelper(objWD);
            WindowInteropHelper parent = new WindowInteropHelper(System.Windows.Application.Current.MainWindow);
            child.Owner = parent.Handle;
        }

        private void btnCity_Click(object sender, RoutedEventArgs e)
        {
            LookUpSearchView objEmployee = new LookUpSearchView(ViewName.Employee, LookUpName.City, "", "Normal", "City");
            txtId_City.DataContext = objEmployee.DataContext;
            SetOwner(objEmployee);
            objEmployee.ShowDialog();           
        }
    }
}

