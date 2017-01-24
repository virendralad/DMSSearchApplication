using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DMSSearchApplication.UserControls.LookUpSearch.HelperClasses
{
    public class CommandBehaviour
    {
        #region DependencyProperty Grid PreviewKeyDown
        public static readonly DependencyProperty PreviewKeyDownProperty = DependencyProperty.RegisterAttached("PreviewKeyDown", typeof(CommonDelegateCommand),
         typeof(CommandBehaviour), new PropertyMetadata(PropertyPreviewKeyDown));
        #endregion

        #region PropertyMetadata for SelectionChanged DependencyProperty
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

        #region Get Set DependencyProperty
        public static ICommand GetPreviewKeyDown(UIElement element)
        {
            return (ICommand)element.GetValue(WindowLoadedProperty);
        }

        public static void SetPreviewKeyDown(UIElement element, ICommand command)
        {
            element.SetValue(WindowLoadedProperty, command);
        }

        #endregion

        #endregion

        #region DependencyProperty Declaration
        public static readonly DependencyProperty WindowLoadedProperty = DependencyProperty.RegisterAttached("WindowLoaded", typeof(CommonDelegateCommand),
        typeof(CommandBehaviour), new PropertyMetadata(PropertyChangedSelectionChanged));
        #endregion

        #region PropertyMetadata for SelectionChanged DependencyProperty
        public static void PropertyChangedSelectionChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            if (depObj != null && depObj is Window)
            {
                Window Window = depObj as Window;
                Window.Loaded += Window_Loaded;
            }
        }

        static void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is Window)
            {
                Window Window = (Window)sender;
                if (Window != null)
                {
                    CommonDelegateCommand command = Window.GetValue(WindowLoadedProperty) as CommonDelegateCommand;
                    if (command != null)
                        command.Execute(sender, e);
                }
            }
        }

        #endregion

        #region Get Set DependencyProperty
        public static ICommand GetWindowLoaded(UIElement element)
        {
            return (ICommand)element.GetValue(WindowLoadedProperty);
        }

        public static void SetWindowLoaded(UIElement element, ICommand command)
        {
            element.SetValue(WindowLoadedProperty, command);
        }

        #endregion
    }
}
