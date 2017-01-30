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
        public string _LooUpName = string.Empty;
        public string _ViewName = string.Empty;
        public string _SearchType = string.Empty;
        public string _ColumnName = string.Empty;
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

        private bool _SelectFirstRow;
        public bool SelectFirstRow
        {
            get
            {
                return _SelectFirstRow;
            }
            set
            {
                _SelectFirstRow = value;
                OnPropertyChanged("SelectFirstRow");
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

        private DataRow _CurrentSelectedRow;
        public DataRow CurrentSelectedRow
        {
            get
            {
                return _CurrentSelectedRow;
            }
            set
            {
                _CurrentSelectedRow = value;
            }
        }


        private Window _CurrentWindow;
        public Window CurrentWindow
        {
            get { return _CurrentWindow; }
            set { _CurrentWindow = value; }
        }
        #endregion

        #region Commands

        private CommonDelegateCommand _DataGridSelectionChanged;
        public CommonDelegateCommand DataGridSelectionChanged
        {
            get { return _DataGridSelectionChanged; }
        }

        private CommonDelegateCommand _DataGridPreviewKeyDown;
        public CommonDelegateCommand DataGridPreviewKeyDown
        {
            get { return _DataGridPreviewKeyDown; }
        }

        RelayCommand _SearchButtonClickCommand;
        public ICommand SearchButtonClickCommand
        {
            get
            {
                return _SearchButtonClickCommand;
            }
        }

        RelayCommand _OkButtonClickCommand;
        public RelayCommand OkButtonClickCommand
        {
            get
            {
                return _OkButtonClickCommand;
            }
        }

        private Boolean CanTemplateCommandExecute()
        {
            return true;
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
            CurrentWindow.Close();            
            return true;
        }

        public ICommand WindowKeyDown
        {
            get
            {
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
            get
            {
                if (_windowPreviewKeyDown == null)
                    _windowPreviewKeyDown = new RelayCommand(param => this.ExecuteWindowPreviewKeyDown(param), param => this.CanExecuteWindowPreviewKeyDown());
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
            CurrentWindow.Close();
        }

        #endregion

        #region Constructor
        public LookUpSearchViewwModel(string ViewName, string LooUpName, string GridName, string SearchType, string ColumnName, string searchWindowName = "", string searchGridName = "", string ScreenName = "", bool isShowInActiveRecords = false)
        {
            _LooUpName = LooUpName;
            _ViewName = ViewName;
            _SearchType = SearchType;
            IsShowInActiveRecords = isShowInActiveRecords;
            _ColumnName = ColumnName;

            InitializeCommands();
        }
        #endregion


        #region Observable Collection
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
        #endregion

        #region Methods

        private void OkButtonClick()
        {
            if (CurrentSelectedRow != null && CurrentSelectedRow[_ColumnName] != null)
            {
                string ValueToShow = CurrentSelectedRow[_ColumnName].ToString();
            }
        }

        protected void SearchButtonClick()
        {
            btnSearchAsync_Click(CurrentWindow);
        }

        protected void DataGridSelectionChangedM(object sender, object Event)
        {
            if (sender is DataGrid && (sender as DataGrid).SelectedItem is DataRowView)
            {
                DataRowView drView = (DataRowView)(sender as DataGrid).SelectedItem;
                if (drView != null && drView.Row != null)
                {
                    CurrentSelectedRow = drView.Row;
                    OnPropertyChanged("CurrentSelectedRow");
                }
            }
        }

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
            if (sender is Window)
                CurrentWindow = sender as Window;

            if (CurrentWindow != null)
            {
                (CurrentWindow.FindResource("WaitStoryboard") as Storyboard).Begin();
                LoadIconVisibility = System.Windows.Visibility.Hidden;
                OnPropertyChanged("LoadIconVisibility");
                if (_SearchType == "advance")
                {
                    CurrentWindow.DialogResult = true;
                    CurrentWindow.Close();
                }
                btnSearchAsync_Click(CurrentWindow);
            }

        }

        protected override void InitializeCommands()
        {
            base.InitializeCommands();
            _DataGridPreviewKeyDown = new CommonDelegateCommand(DataGridPreviewKeyDownM);
            _OkButtonClickCommand = new RelayCommand(param => OkButtonClick());
            _SearchButtonClickCommand = new RelayCommand(param => SearchButtonClick());
            _DataGridSelectionChanged = new CommonDelegateCommand(DataGridSelectionChangedM);
        }

        public void GetsearchData(Window Window)
        {
            //MessageBoxManager.Unregister();
            Window.Height = 595;
            DataTable dtSearchData = LookUpSearchCommonFuntions.GetsearchData(_SearchType, _LooUpName, IsShowInActiveRecords);

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
                Result = LookUpSearchCommonFuntions.GetGridData(_LooUpName, _SearchType, IsShowInActiveRecords);
            });
            TotalReocords = (int)Result.Result["TotalReocords"];
            ds = (DataTable)Result.Result["DataSet"];
            if (ds.Rows.Count > 0)
            {
                dtData = ds;
                OnPropertyChanged("dtData");
            }
            OnPropertyChanged("TotalReocords");
            #endregion

            #region Grid Tool Tip
            if (dtData != null)
            {
                GridToolTip = "Total Records present in Grid: " + dtData.Rows.Count.ToString();
                OnPropertyChanged("GridToolTip");
            }
            #endregion

            SelectFirstRow = true;
            OnPropertyChanged("SelectFirstRow");

            #region Hide Loading Icon
            LoadIconVisibility = System.Windows.Visibility.Hidden;
            OnPropertyChanged("LoadIconVisibility");
            Window.IsEnabled = true;
            #endregion
        }

        private void btnSearchAsync_Click(Window Window)
        {
            GridColumnsTemplates Temp = new GridColumnsTemplates();
            ColumnCollection = Temp.FindColumns(_LooUpName, _ViewName);
            GetsearchData(Window);
            GetGridData(Window);
            SelectFirstRow = false;
            OnPropertyChanged("SelectFirstRow");
        }
        #endregion
    }
}
