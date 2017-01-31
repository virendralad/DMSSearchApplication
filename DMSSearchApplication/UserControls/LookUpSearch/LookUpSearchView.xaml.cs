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

//9158 line of code was here
namespace DMSSearchApplication.UserControls.LookUpSearch
{
    /// <summary>
    /// Interaction logic for AdvanceSearchView.xaml
    /// </summary>
    public partial class LookUpSearchView : Window
    {
        #region Declaration
        LookUpSearchViewwModel LookUpSearchViewwModel = null;
        #endregion

        #region Constructor

        public void InitialLogicBasedOnFrmNGrdName(string FormName, string GridName)
        {

        }

        public void SetGlobalGridNameNID(string GridName)
        {

        }

        public LookUpSearchView(ViewName ViewName, LookUpName LooUpName, string GridName, string SearchType, string ColumnName, string searchWindowName = "", string searchGridName = "", string ScreenName = "", bool isShowInActiveRecords = false)
        {
            InitializeComponent();
            LookUpSearchViewwModel = new LookUpSearchViewwModel(ViewName, LooUpName, GridName, SearchType, ColumnName, searchWindowName, searchGridName, ScreenName, isShowInActiveRecords);
            //ResetSearch(FormName, GridName, true);
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

        //#region Events       

        //int totalRecord = 0;         

        //private void gridData_ScrollChanged(object sender, ScrollChangedEventArgs e)
        //{

        //}
        //#endregion
        

        //public List<clsItems> dtFillData
        //{
        //    get;
        //    set;
        //}       

    }
}
