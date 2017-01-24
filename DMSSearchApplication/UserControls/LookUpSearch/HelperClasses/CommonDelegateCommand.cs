using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DMSSearchApplication.UserControls.LookUpSearch.HelperClasses
{
    public delegate void SingleParameterCommand(object SelectedKey);
    public delegate void DelegateBindControlEvent(object Sender, object EventArgs);
    public class CommonDelegateCommand : ICommand
    {
        private SingleParameterCommand _executeMethod;
        private DelegateBindControlEvent _ControlEvent;

        public CommonDelegateCommand(SingleParameterCommand executeMethod)
        {
            _executeMethod = executeMethod;
        }

        public CommonDelegateCommand(DelegateBindControlEvent ExecuteControlEvent)
        {
            _ControlEvent = ExecuteControlEvent;
        }
        public bool CanExecute(object parameter)
        {
            if (parameter != null)
                return true;
            else return false;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _executeMethod.Invoke(parameter);
        }
        public void Execute(object Sender, object EventArgs)
        {
            _ControlEvent.Invoke(Sender, EventArgs);
        }
    }
}
