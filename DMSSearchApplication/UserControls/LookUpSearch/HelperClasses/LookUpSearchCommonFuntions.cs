using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DMSSearchApplication.UserControls.LookUpSearch.HelperClasses
{
    public class LookUpSearchCommonFuntions
    {
        public static DataTable GetsearchData(string _SearchType, string _FormName, bool IsShowInActiveRecords)
        {
            DataTable dtSearchData = new DataTable();
            dtSearchData.TableName = "SearchCriteria";
            dtSearchData.Columns.Add("HeaderName", typeof(string));
            dtSearchData.Columns.Add("MappingName", typeof(string));
            dtSearchData.Columns.Add("SearchCriteria", typeof(string));
            dtSearchData.Columns.Add("SearchValue", typeof(string));

            if (_SearchType != "Duplicate" && _FormName.ToLower() != "srt" && !IsShowInActiveRecords) // condition added for Parts master to open with all parts Active & Inactive both and restricted this filter for parts master called from sales FC/BC
            {
                if (_FormName != "ZipCodeSearch")
                    dtSearchData.Rows.Add("Active", "Active", "EQUAL TO", "YES");
                else
                    dtSearchData.Rows.Add("Active", "Active", "EQUAL TO", "1");
            }
            return dtSearchData;
        }

        public static DataTable CreateData()
        {
            Thread.Sleep(1000);
            int i = 1000;
            DataTable dt = new DataTable();
            dt.TableName = "EmployeeMaster";

            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("MiddleName", typeof(string));
            dt.Columns.Add("LastName", typeof(string));

            while (i > 0)
            {
                DataRow dr = dt.NewRow();
                dr["FirstName"] = "Virendra";
                dr["MiddleName"] = "Narendra";
                dr["LastName"] = "Lad";
                dt.Rows.Add(dr);
                i--;
            }
            return dt;
        }

        public static async Task<Dictionary<string, object>> GetGridData(string _FormName, string _SearchType, bool IsShowInActiveRecords)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            DataTable ds = new DataTable();
            int TotalReocords = 0;

            if (_FormName.ToLower() == "ermemployee")
                ds = CreateData();

            TotalReocords = ds.Rows.Count;
            dic.Add("DataSet", ds);
            dic.Add("TotalReocords", TotalReocords);
            return dic;
        }
    }
}
