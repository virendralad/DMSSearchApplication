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
        protected virtual void InitializeCommonCMDS()
        {
            _WindowLoaded = new CommonDelegateCommand(OnWindowLoaded);
        }

        protected virtual void OnWindowLoaded(object sender, object Event)
        {
        }

        public CommonDelegateCommand _WindowLoaded;
        public CommonDelegateCommand WindowLoaded
        {
            get { return _WindowLoaded; }
        }
        #endregion
    }
}
