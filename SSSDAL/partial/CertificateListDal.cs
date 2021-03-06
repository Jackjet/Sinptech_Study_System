﻿using SSSIDAL;
using SSSModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSSUtility;

namespace SSSDAL
{
    public partial class CertificateListDal : BaseDal<CertificateList>, ICertificateListDal
    {
        public override DataTable GetListByPage(Hashtable ht, out int RowCount, bool IsPage = true, string Where = "")
        {
            RowCount = 0;
            DataTable dt = new DataTable();
            try
            {
                StringBuilder str = new StringBuilder();
                str.Append(@"select a.*,b.Name as cName,ImageUrl from [dbo].[CertificateList] a ,CertificateManage b,CertificateModol c where a.CertificateID=b.ID and b.ModelID=c.ID");

                int StartIndex = 0;
                int EndIndex = 0;
                if (ht.ContainsKey("ID") && !string.IsNullOrEmpty(ht["ID"].SafeToString()))
                {
                    str.Append(" and a.ID = " + ht["ID"].SafeToString());
                }
                if (ht.ContainsKey("CertificateID") && !string.IsNullOrEmpty(ht["CertificateID"].SafeToString()))
                {
                    str.Append(" and b.ID = " + ht["CertificateID"].SafeToString());
                }
                if (ht.ContainsKey("NStatus") && !string.IsNullOrEmpty(ht["NStatus"].SafeToString()))
                {
                    str.Append(" and a.Status<>" + ht["NStatus"].SafeToString());
                }
                if (ht.ContainsKey("IDCard") && !string.IsNullOrEmpty(ht["IDCard"].SafeToString()))
                {
                    str.Append(" and a.IDCard='" + ht["IDCard"].SafeToString() + "'");
                }
                if (ht.ContainsKey("Status") && !string.IsNullOrEmpty(ht["Status"].SafeToString()))
                {
                    str.Append(" and a.Status='" + ht["Status"].SafeToString() + "'");
                }
                if (ht.ContainsKey("Identifier") && !string.IsNullOrEmpty(ht["Identifier"].SafeToString()))
                {
                    str.Append(" and Identifier=" + ht["Identifier"].SafeToString());
                }
                if (ht.ContainsKey("CourceID") && !string.IsNullOrEmpty(ht["CourceID"].SafeToString()))
                {
                    str.Append(" and b.ID in (select CertificateID from CertificateCourse where CourseID=" + ht["CourceID"].SafeToString() + ")");
                }
                
                if (IsPage)
                {
                    StartIndex = Convert.ToInt32(ht["StartIndex"].ToString());
                    EndIndex = Convert.ToInt32(ht["EndIndex"].ToString());
                }
                dt = SQLHelp.GetListByPage("(" + str.ToString() + ")", Where, "", StartIndex,
                    EndIndex, IsPage, null, out RowCount);
                dt.Columns.Add("CourseName",typeof(string));
                foreach (DataRow dr in dt.Rows)
                {
                    dr["CourseName"] = GetCourseName(dr["CertificateID"].SafeToString());
                }

            }
            catch (Exception ex)
            {
                LogService.WriteErrorLog(ex.Message);
            }
            return dt;
        }
        private string GetCourseName(string CerID)
        {
            string Name = "";
            string strSql = "select b.Name from CertificateCourse a inner join Course b on a.CourseID=b.ID and a.CertificateID=" + CerID;
            DataTable dt = SQLHelp.ExecuteDataTable(strSql, CommandType.Text, null);
            foreach (DataRow dr in dt.Rows)
            {
                Name += dr["Name"] + ",";
            }
            return Name.TrimEnd(',');
        }
    }
}
