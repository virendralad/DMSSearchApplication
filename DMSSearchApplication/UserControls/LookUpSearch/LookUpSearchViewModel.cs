using DMSSearchApplication.UserControls.LookUpSearch.HelperClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;
 

namespace DMSSearchApplication.UserControls.LookUpSearch
{
    public static class ApplicationLevelConstants
    {
        public static DataTable SearchResult { get; set; }
    }


    public class LookUpSearchViewwModel : BaseViewModel, INotifyPropertyChanged
    {
        #region Global Variable
        public bool IsShowInActiveRecords;
        public string _FormName = string.Empty;
        public string _SearchType = string.Empty;
        public string _ColumnName = string.Empty;
        Window WindowEvent=null;
        KeyEventArgs WindowKeyEvent = null;

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
                OnPropertyChanged("ColumnCollection");
            }
        }
        //public DataGrid gridData = new DataGrid();
        #endregion

        #region Binding Properties
        private int _ScrollHeight;
        public int ScrollHeight
        {
            get
            {
                return _ScrollHeight;
            }
            set
            {
                _ScrollHeight = value;
            }
        }

        private DataTable _dtData;
        public DataTable dtData
        {
            get
            {
                return _dtData;
            }
            set
            {
                _dtData = value;
            }
        }

        private DataRow _selectedItem;

        public DataRow SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        

        private int _TotalReocords;
        public int TotalReocords
        {
            get
            {
                return _TotalReocords;
            }
            set
            {
                _TotalReocords = value;
            }
        }

        private string _GridToolTip;
        public string GridToolTip
        {
            get
            {
                return _GridToolTip;
            }
            set
            {
                _GridToolTip = value;
            }
        }

        private Visibility _LoadIconVisibility;
        public Visibility LoadIconVisibility
        {
            get
            {
                return _LoadIconVisibility;
            }
            set
            {
                _LoadIconVisibility = value;
            }
        }
        #endregion

        #region Commands
        public CommonDelegateCommand _DataGridPreviewKeyDown;
        public CommonDelegateCommand DataGridPreviewKeyDown
        {
            get { return _DataGridPreviewKeyDown; }
        }
        #endregion

        #region RelayCommand
        RelayCommand _cancelCommand;
        RelayCommand _windowKeyDown;
        RelayCommand _windowPreviewKeyDown;

        public ICommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                    _cancelCommand = new RelayCommand(param => this.CancelCommandExecute(), param => this.CanCancelCommandExecute());

                return _cancelCommand;
            }
        }

        private bool CanCancelCommandExecute()
        {
            return true;
        }

        private object CancelCommandExecute()
        {
            ApplicationLevelConstants.SearchResult = null;   
            WindowEvent.Close();
            //Application.Current.Windows[Application.Current.Windows.Count - 1].Close();           
            return true;
        }

        public ICommand WindowKeyDown
        {
            get {
                if (_windowKeyDown == null)
                    _windowKeyDown = new RelayCommand(param => this.ExecuteWindowKeyDown(), param => this.CanExecuteWindowKeyDown());
                return _windowKeyDown;
            }
        }

        private bool CanExecuteWindowKeyDown()
        {
            return true;
        }

        private object ExecuteWindowKeyDown()
        {
            return true;
        }

        public ICommand WindowPreviewKeyDown
        {
            get {
                if (_windowPreviewKeyDown == null)
                    _windowPreviewKeyDown = new RelayCommand(param =>this.ExecuteWindowPreviewKeyDown(param),param =>this.CanExecuteWindowPreviewKeyDown());
                return _windowPreviewKeyDown;
            }
        }

        private bool CanExecuteWindowPreviewKeyDown()
        {
            return true;       
        }

        private void ExecuteWindowPreviewKeyDown(object obj)
        {
            //if (WindowKeyEvent.Key == System.Windows.Input.Key.Escape)
                WindowEvent.Close();            
        }

        #endregion

        #region Constructor
        public LookUpSearchViewwModel(string FormName, string GridName, string SearchType, string ColumnName,string CurrViewName, string searchWindowName = "", string searchGridName = "", string ScreenName = "", bool isShowInActiveRecords = false)
        {
            _FormName = FormName;
            _SearchType = SearchType;
            IsShowInActiveRecords = isShowInActiveRecords;
            _ColumnName = ColumnName;
            InitializeCommonCMDS();
            _DataGridPreviewKeyDown = new CommonDelegateCommand(DataGridPreviewKeyDownM);
            GridColumnsTemplates obj = new GridColumnsTemplates();
            ColumnCollection = obj.FindColumns(FormName, CurrViewName);
            OnPropertyChanged("ColumnCollection");
        }
        #endregion

        #region Methods
        protected void DataGridPreviewKeyDownM(object sender, object Event)
        {
            if (Event is KeyEventArgs)
            {
                KeyEventArgs e = Event as KeyEventArgs;
                if (e != null)
                {
                    if (e.Key == System.Windows.Input.Key.Enter)
                    {
                        //btnOk_Click(null, null);
                        e.Handled = true;
                    }
                }
            }
        }
        protected override void OnWindowLoaded(object sender, object Event)
        {
            base.OnWindowLoaded(sender, Event);           
            Window Window = null;
            if (sender is Window)
                Window= sender as Window;

            WindowEvent = sender as Window;
            WindowKeyEvent = Event as KeyEventArgs;

            if (Window != null)
            {
                (Window.FindResource("WaitStoryboard") as Storyboard).Begin();
                LoadIconVisibility = System.Windows.Visibility.Hidden;
                OnPropertyChanged("LoadIconVisibility");
                if (_SearchType == "advance")
                {
                    Window.DialogResult = true;
                    Window.Close();
                }
                btnSearchAsync_Click(Window);
            }
        }

        public void GetsearchData(Window Window)
        {
            //MessageBoxManager.Unregister();
            Window.Height = 595;
            DataTable dtSearchData = LookUpSearchCommonFuntions.GetsearchData(_SearchType, _FormName, IsShowInActiveRecords);

            if (dtSearchData != null)
                ApplicationLevelConstants.SearchResult = dtSearchData;
        }

        public async void GetGridData(Window Window)
        {
            #region Show Loading Icon
            LoadIconVisibility = System.Windows.Visibility.Visible;
            OnPropertyChanged("LoadIconVisibility");
            Window.IsEnabled = false;
            #endregion

            #region Fill Data and Total Record Count
            DataTable ds = new DataTable();
            Task<Dictionary<string, object>> Result = null;
            await Task.Run(() =>
            {
                Result = LookUpSearchCommonFuntions.GetGridData(_FormName, _SearchType, IsShowInActiveRecords);
            });
            TotalReocords = (int)Result.Result["TotalReocords"];
            ds = (DataTable)Result.Result["DataSet"];
            if (ds.Rows.Count > 0)
            {
                dtData = ds;
                OnPropertyChanged("dtData");
            }

            SelectedItem = dtData.Rows[0];
            OnPropertyChanged("TotalReocords");
            #endregion
            
            #region Grid Tool Tip
            if (dtData != null)
            {
                GridToolTip = "Total Records present in Grid: " + dtData.Rows.Count.ToString();
                OnPropertyChanged("GridToolTip");
            }
            #endregion

            //System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            //{
            //    foreach (object obj in gridData.Items)
            //    {
            //        gridData.SelectedItem = obj;
            //        if (gridData.Columns.Count > 0)
            //        {
            //            DataGridCellInfo cellInfo = new DataGridCellInfo(gridData.SelectedItem, gridData.Columns[0]);
            //            gridData.CurrentCell = cellInfo;
            //        }

            //        break;
            //    }

            //}), System.Windows.Threading.DispatcherPriority.Normal);
            

            #region Hide Loading Icon
            LoadIconVisibility = System.Windows.Visibility.Hidden;
            OnPropertyChanged("LoadIconVisibility");
            Window.IsEnabled = true;
            #endregion
           
        }

        private void btnSearchAsync_Click(Window Window)
        {
            GetsearchData(Window);

            GetGridData(Window);
            //------------------------------------------------------------------------------------------------------------------------


            //TODO Viren
            //Dispatcher.BeginInvoke(new Action(() =>
            //{
            //    // gridData.Focus();
            //    foreach (object obj in gridData.Items)
            //    {
            //        gridData.SelectedItem = obj;
            //        if (gridData.Columns.Count > 0)
            //        {
            //            DataGridCellInfo cellInfo = new DataGridCellInfo(gridData.SelectedItem, gridData.Columns[0]);
            //            //set the cell to be the active one
            //            gridData.CurrentCell = cellInfo;
            //        }

            //        break;
            //    }

            //}), System.Windows.Threading.DispatcherPriority.Normal);


        }
        #endregion
    
public  Window sender { get; set; }}
}
