using System;
using System.Collections.Generic;
using System.Data;
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
        #region WindowLoaded

        #region DependencyProperty WindowLoaded Declaration
        public static readonly DependencyProperty WindowLoadedProperty = DependencyProperty.RegisterAttached("WindowLoaded", typeof(CommonDelegateCommand),
        typeof(CommandBehaviour), new PropertyMetadata(PropertyWindowLoaded));
        #endregion

        #region PropertyMetadata for WindowLoaded DependencyProperty
        public static void PropertyWindowLoaded(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
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

        #region Get Set WindowLoaded Property
        public static ICommand GetWindowLoaded(UIElement element)
        {
            return (ICommand)element.GetValue(WindowLoadedProperty);
        }

        public static void SetWindowLoaded(UIElement element, ICommand command)
        {
            element.SetValue(WindowLoadedProperty, command);
        }

        #endregion

        #endregion
    }
}
