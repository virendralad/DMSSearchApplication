using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSSearchApplication.UserControls.LookUpSearch.HelperClasses
{
    public interface ISelectedRow
    {
        DataRow CurrentSelectedRow { get; set; }
    }

    public enum LookUpName
    {
        ERMEmployee,
        ZipCodeSearch,
        City,
        Srt
    }

    public enum ViewName
    {
         Employee
    }
}
