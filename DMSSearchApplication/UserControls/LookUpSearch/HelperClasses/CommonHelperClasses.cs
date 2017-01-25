using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DMSSearchApplication.UserControls.LookUpSearch.HelperClasses
{
    public class clsData
    {
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

    }
    public class args
    {
        private object _obj;
        public object obj
        {
            get
            {
                return _obj;
            }
            set
            {
                _obj = value;
            }
        }
    }

    public class DataGridColumnsBehavior : DependencyObject
    {
        public static readonly DependencyProperty BindableColumnsProperty =
            DependencyProperty.RegisterAttached("BindableColumns",
                                                typeof(ObservableCollection<DataGridColumn>),
                                                typeof(DataGridColumnsBehavior),
                                                new UIPropertyMetadata(null, BindableColumnsPropertyChanged));

        private static void BindableColumnsPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            DataGrid dataGrid = source as DataGrid;
            ObservableCollection<DataGridColumn> columns = e.NewValue as ObservableCollection<DataGridColumn>;
            dataGrid.Columns.Clear();
            if (columns == null)
            {
                return;
            }

            foreach (DataGridColumn column in columns)
                dataGrid.Columns.Add(column);
        }

        public static void SetBindableColumns(DependencyObject element, ObservableCollection<DataGridColumn> value)
        {
            element.SetValue(BindableColumnsProperty, value);
        }
        public static ObservableCollection<DataGridColumn> GetBindableColumns(DependencyObject element)
        {
            return (ObservableCollection<DataGridColumn>)element.GetValue(BindableColumnsProperty);
        }
    }
}
