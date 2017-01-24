using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
