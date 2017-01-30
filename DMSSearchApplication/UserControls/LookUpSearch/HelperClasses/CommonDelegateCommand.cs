using System;
using System.Collections.Generic;
using System.Diagnostics;
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



        public bool CanExecute(object parameters)
        {
            return true;
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

    public class RelayCommand : ICommand
    {
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }

        [DebuggerStepThrough]
        public bool CanExecute(object parameters)
        {
            return _canExecute == null ? true : _canExecute(parameters);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameters)
        {
            _execute(parameters);
        }
    }
}
