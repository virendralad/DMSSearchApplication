using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DMSSearchApplication.UserControls.LookUpSearch.HelperClasses
{
    public class DataGridCommonBehavior : DependencyObject
    {
        public static readonly DependencyProperty BindableColumnsProperty =
            DependencyProperty.RegisterAttached("BindableColumns",
                                                typeof(ObservableCollection<DataGridColumn>),
                                                typeof(DataGridCommonBehavior),
                                                new UIPropertyMetadata(null, BindableColumnsPropertyChanged));
        private static void BindableColumnsPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            DataGrid dataGrid = source as DataGrid;
            dataGrid.Focus();
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


        #region DataGrid Common Commands

        #region DependencyProperty Grid PreviewKeyDown
        public static readonly DependencyProperty PreviewKeyDownProperty = DependencyProperty.RegisterAttached("PreviewKeyDown", typeof(CommonDelegateCommand),
         typeof(DataGridCommonBehavior), new PropertyMetadata(PropertyPreviewKeyDown));
        #endregion

        #region PropertyMetadata for Grid PreviewKeyDown DependencyProperty
        public static void PropertyPreviewKeyDown(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            if (depObj != null && depObj is DataGrid)
            {
                DataGrid DataGrid = depObj as DataGrid;
                DataGrid.PreviewKeyDown += DataGrid_PreviewKeyDown;
            }
        }

        static void DataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (sender is DataGrid)
            {
                DataGrid DataGrid = (DataGrid)sender;
                if (DataGrid != null)
                {
                    CommonDelegateCommand command = DataGrid.GetValue(PreviewKeyDownProperty) as CommonDelegateCommand;
                    if (command != null)
                        command.Execute(sender, e);
                }
            }
        }

        #endregion

        #region Get Set Grid PreviewKeyDown DependencyProperty
        public static ICommand GetPreviewKeyDown(UIElement element)
        {
            return (ICommand)element.GetValue(PreviewKeyDownProperty);
        }

        public static void SetPreviewKeyDown(UIElement element, ICommand command)
        {
            element.SetValue(PreviewKeyDownProperty, command);
        }

        #endregion

        #region DependencyProperty Grid CurrentCell
        public static readonly DependencyProperty SelectFirstRowProperty = DependencyProperty.RegisterAttached("SelectFirstRow", typeof(bool),
         typeof(DataGridCommonBehavior), new UIPropertyMetadata(PropertySelectFirstRow));
        #endregion

        #region PropertyMetadata for Grid CurrentCell DependencyProperty
        static bool IsDefaultRowSelected = false;
        public static void PropertySelectFirstRow(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            if (source != null && source is DataGrid)
            {
                DataGrid DataGrid = source as DataGrid;
                DataGrid.Focus();
                if (bool.Equals(e.NewValue, true))
                {
                    DataGrid.SelectedItem = DataGrid.Items[0];
                    DataGridCellInfo cellInfo = new DataGridCellInfo(DataGrid.SelectedItem, DataGrid.Columns[0]);
                    DataGrid.CurrentCell = cellInfo;
                }
            }
        }

        #endregion

        #region Get Set Grid CurrentCell DependencyProperty
        public static ICommand GetSelectFirstRow(UIElement element)
        {
            return (ICommand)element.GetValue(SelectFirstRowProperty);
        }

        public static void SetSelectFirstRow(UIElement element, ICommand command)
        {
            element.SetValue(SelectFirstRowProperty, command);
        }

        #endregion

        #region DependencyProperty Grid SelectionChanged
        public static readonly DependencyProperty SelectionChangedProperty = DependencyProperty.RegisterAttached("SelectionChanged", typeof(CommonDelegateCommand),
         typeof(DataGridCommonBehavior), new PropertyMetadata(PropertySelectionChanged));
        #endregion

        #region PropertyMetadata for Grid SelectionChanged DependencyProperty
        public static void PropertySelectionChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            if (depObj != null && depObj is DataGrid)
            {
                DataGrid DataGrid = depObj as DataGrid;
                DataGrid.SelectionChanged += DataGrid_SelectionChanged;
            }
        }

        static void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DataGrid)
            {
                DataGrid DataGrid = (DataGrid)sender;
                if (DataGrid != null)
                {
                    CommonDelegateCommand command = DataGrid.GetValue(SelectionChangedProperty) as CommonDelegateCommand;
                    if (command != null)
                        command.Execute(sender, e);
                }
            }
        }        

        #endregion

        #region Get Set Grid SelectionChanged DependencyProperty
        public static ICommand GetSelectionChanged(UIElement element)
        {
            return (ICommand)element.GetValue(PreviewKeyDownProperty);
        }

        public static void SetSelectionChanged(UIElement element, ICommand command)
        {
            element.SetValue(PreviewKeyDownProperty, command);
        }

        #endregion

        #endregion
    }
}
