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
            LookUpSearchView objEmployee = new LookUpSearchView("ERMEmployee", "", "Normal", "EmployeeID");
            //objEmployee.OnSearch += new LookUpSearchView.SearchHandler(objEmployee_OnSearch);
            SetOwner(objEmployee);
            objEmployee.ShowDialog();
        }

        void objEmployee_OnSearch(args obj)
        {
        }


        public static void SetOwner(System.Windows.Window objWD)
        {
            WindowInteropHelper child = new WindowInteropHelper(objWD);
            WindowInteropHelper parent = new WindowInteropHelper(System.Windows.Application.Current.MainWindow);
            child.Owner = parent.Handle;
        }
    }
}
