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
        public static DataTable GetsearchData(string _SearchType, LookUpName _LookUpName, bool IsShowInActiveRecords)
        {
            DataTable dtSearchData = new DataTable();
            dtSearchData.TableName = "SearchCriteria";
            dtSearchData.Columns.Add("HeaderName", typeof(string));
            dtSearchData.Columns.Add("MappingName", typeof(string));
            dtSearchData.Columns.Add("SearchCriteria", typeof(string));
            dtSearchData.Columns.Add("SearchValue", typeof(string));

            if (_SearchType != "Duplicate" && _LookUpName != LookUpName.Srt  && !IsShowInActiveRecords) // condition added for Parts master to open with all parts Active & Inactive both and restricted this filter for parts master called from sales FC/BC
            {
                if (_LookUpName != LookUpName.ZipCodeSearch)
                    dtSearchData.Rows.Add("Active", "Active", "EQUAL TO", "YES");
                else
                    dtSearchData.Rows.Add("Active", "Active", "EQUAL TO", "1");
            }
            return dtSearchData;
        }

        public static DataTable CreateEmployeeData()
        {
            Thread.Sleep(1000);
            int i = 1000;
            DataTable dt = new DataTable();
            dt.TableName = "EmployeeMaster";

            dt.Columns.Add("EmployeeID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("OldEmployeeID", typeof(int));

            DataRow dr15 = dt.NewRow();
            dr15["EmployeeID"] = 437815;
            dr15["Name"] = "Virendra Lad15";
            dr15["OldEmployeeID"] = 100015;
            dt.Rows.Add(dr15);

            while (i > 0)
            {
                DataRow dr = dt.NewRow();
                dr["EmployeeID"] = 4378;
                dr["Name"] = "Virendra Lad";
                dr["OldEmployeeID"] = 1000;
                dt.Rows.Add(dr);
                i--;
            }
            return dt;
        }


        public static DataTable CreateZipSearchData()
        {
            Thread.Sleep(1000);
            int i = 1000;
            DataTable dt = new DataTable();
            dt.TableName = "ZipCodeMaster";

            dt.Columns.Add("City", typeof(string));
            dt.Columns.Add("State", typeof(string));
            dt.Columns.Add("ZipCode", typeof(int));

            DataRow dr15 = dt.NewRow();
            dr15["City"] = "Mumbai15";
            dr15["State"] = "Maharashtra15";
            dr15["ZipCode"] = 40007815;
            dt.Rows.Add(dr15);

            while (i > 0)
            {
                DataRow dr = dt.NewRow();
                dr["City"] = "Mumbai";
                dr["State"] = "Maharashtra";
                dr["ZipCode"] = 400078;
                dt.Rows.Add(dr);
                i--;
            }
            return dt;
        }

        public static DataTable CreateCitySearchData()
        {
            Thread.Sleep(1000);
            int i = 1000;
            DataTable dt = new DataTable();
            dt.TableName = "CityMaster";

            dt.Columns.Add("City", typeof(string));
            dt.Columns.Add("State", typeof(string));
            dt.Columns.Add("Country", typeof(string));

            DataRow dr15 = dt.NewRow();
            dr15["City"] = "Mumbai15";
            dr15["State"] = "Maharashtra15";
            dr15["Country"] = "India15";
            dt.Rows.Add(dr15);

            while (i > 0)
            {
                DataRow dr = dt.NewRow();
                dr["City"] = "Mumbai";
                dr["State"] = "Maharashtra";
                dr["Country"] = "India";
                dt.Rows.Add(dr);
                i--;
            }
            return dt;
        }

        public static async Task<Dictionary<string, object>> GetGridData(LookUpName _LookUpName, string _SearchType, bool IsShowInActiveRecords)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            DataTable ds = new DataTable();
            int TotalReocords = 0;

            switch (_LookUpName)
            {
                case LookUpName.ERMEmployee:
                    ds = CreateEmployeeData();
                    break;

                case LookUpName.ZipCodeSearch:
                    ds = CreateZipSearchData();
                    break;

                case LookUpName.City:
                    ds = CreateCitySearchData();
                    break;

            }

            TotalReocords = ds.Rows.Count;
            dic.Add("DataSet", ds);
            dic.Add("TotalReocords", TotalReocords);
            return dic;
        }
    }
}
