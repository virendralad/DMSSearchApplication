/// <summary>
/// Class Name      :  AdvanceSearchView
/// Purpose         :  Common Screen used for Advance Search of multiple entities (Company, GL Account, Supplier, etc.)
/// Created Date    :  11-FEB-2013
/// </summary>

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
//using DMS.AppCommon;
//using DMS.MainApp.CustomControl;
//using DMS.MainApp.HelperClasses;
//using AdvancedSearchControlLibrary;
//using DMS.MainApp.ViewModels;
using System.Windows.Media.Animation;
using System.Linq;
using DMSSearchApplication.UserControls.LookUpSearch.HelperClasses;
using System.Collections.ObjectModel;
using System.ComponentModel;

//9158 line of code was here
namespace DMSSearchApplication.UserControls.LookUpSearch
{
    /// <summary>
    /// Interaction logic for AdvanceSearchView.xaml
    /// </summary>
    public partial class LookUpSearchView : Window
    {
        #region Declaration
        public delegate void SearchHandler(args obj);
        public event SearchHandler OnSearch;
        public BaseViewModel ObjBaseVM = new BaseViewModel();
        LookUpSearchViewwModel LookUpSearchViewwModel = null;
        #endregion

        #region Constructor

        public void InitialLogicBasedOnFrmNGrdName(string FormName, string GridName)
        {

        }

        public void SetGlobalGridNameNID(string GridName)
        {

        }

        public LookUpSearchView(string FormName, string GridName, string SearchType, string ColumnName,string CurrViewName, string searchWindowName = "", string searchGridName = "", string ScreenName = "", bool isShowInActiveRecords = false)
        {
            InitializeComponent();
            LookUpSearchViewwModel = new LookUpSearchViewwModel(FormName, GridName, SearchType, ColumnName, searchWindowName, searchGridName, ScreenName, isShowInActiveRecords);
            //ResetSearch(FormName, GridName, true);
            GridColumnsTemplates obj = new GridColumnsTemplates();
            ColumnCollection = obj.FindColumns(FormName, CurrViewName);
            ObjBaseVM.OnPropertyChanged("ColumnCollection");
            DataContext = LookUpSearchViewwModel;

        }
        //public void ResetSearch(string formName, string gridName, bool RunAsync = false)
        //{
        //    List<AdvancedSearchControlLibrary.clsItems> lstFillColumns = new List<AdvancedSearchControlLibrary.clsItems>();
        //    foreach (GridColumnHeaders.clsItems obj in GridColumnHeaders.GetGridDetails(formName, gridName))
        //    {
        //        lstFillColumns.Add(new AdvancedSearchControlLibrary.clsItems { Text = obj.text, Value = obj.value, FormName = formName, DataType = obj.DataType });
        //    }
        //    List<AdvancedSearchControlLibrary.clsItems> lstDisplayColumns = new List<AdvancedSearchControlLibrary.clsItems>();
        //    foreach (GridColumnHeaders.clsItems obj in GridColumnHeaders.GetDefaultGridDetails(formName, gridName))
        //    {
        //        lstDisplayColumns.Add(new AdvancedSearchControlLibrary.clsItems { Text = obj.text, Value = obj.value, DataType = obj.DataType });
        //    }

        //    advancedSearchView1.dtFillData = lstFillColumns;
        //    advancedSearchView1.dtDisplayData = lstDisplayColumns;
        //    advancedSearchView1.RunAsync = RunAsync;
        //    advancedSearchView1.ResetData();
        //}
        #endregion

        #region Methods



        #endregion

        #region Events

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ApplicationLevelConstants.SearchResult = null;
            this.Close();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }
        int totalRecord = 0;
        private void gridData_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void Window_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //if (e.Key == System.Windows.Input.Key.Escape)
            //    this.Close();
        }

        private void gridData_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {

        }
        #endregion

        private ObservableCollection<DataGridColumn> _columnCollection = new ObservableCollection<DataGridColumn>();
        public ObservableCollection<DataGridColumn> ColumnCollection
        {
            get
            {
                return this._columnCollection;
            }
            set
            {
                _columnCollection = value;
                ObjBaseVM.OnPropertyChanged("ColumnCollection");
            }
        }

    }
}
