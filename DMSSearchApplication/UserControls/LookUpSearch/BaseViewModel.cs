using DMSSearchApplication.UserControls.LookUpSearch.HelperClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSSearchApplication.UserControls.LookUpSearch
{
    public class BaseViewModel
    {
        #region " INotifyPropertyChanged Members "
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property)); 
            }
        }
        #endregion

        #region Initialize Common Commands
        /// <summary>
        /// VNL : Use this method to initialize commands,Global commands can define in BaseViewModel.
        ///       Override this to initialize from your Child View Model.  
        /// </summary>
        protected virtual void InitializeCommands()
        {
            
        }

        protected virtual void OnWindowLoaded(object sender, object Event)
        {
        }

        public CommonDelegateCommand _WindowLoaded;
        public CommonDelegateCommand WindowLoaded
        {
            get
            {                
                if (_WindowLoaded == null)
                    _WindowLoaded = new CommonDelegateCommand(OnWindowLoaded);
                return _WindowLoaded;
            }
        }
        #endregion
    }
}
