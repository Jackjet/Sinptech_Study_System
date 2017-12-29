using SSSBLL;
using SSSModel;
using SSSUtility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace SSSWeb.ResourceManage
{
    /// <summary>
    /// ResouceFileUpload 的摘要说明
    /// </summary>
    public class ResouceFileUpload : IHttpHandler
    {
        ResourceService Bll = new ResourceService();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Upload(context);
        }
        private void Upload(HttpContext context)
        {
            JsonModel jsonModel = null;
            JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            string CreateUID = context.Request["CreateUID"].SafeToString();
            string FoldUrl = HttpUtility.UrlDecode(context.Request["FoldUrl"]);
            string UrlPre = ConfigHelper.GetConfigString("FileManageName");
            if (FoldUrl.IndexOf(UrlPre) < 0)
            {
                FoldUrl = UrlPre + FoldUrl;
            }
            if (FoldUrl.IndexOf(CreateUID) < 0)
            {
                FoldUrl += "/" + CreateUID;
            }
            string Pid = context.Request.Form["Pid"].SafeToString();
            string result = "0";
            string code = context.Request.Form["code"].SafeToString().Trim();

            try
            {
                if (!FileHelper.IsExistDirectory(context.Server.MapPath(FoldUrl)))
                {
                    FileHelper.CreateDirectory(context.Server.MapPath(FoldUrl));
                }
                HttpPostedFile file = context.Request.Files[0];

                string ext = Path.GetExtension(file.FileName);

                string fileName = Path.GetFileName(file.FileName);// DateTime.Now.Ticks + ext;

                string p = FoldUrl + "/" + fileName;

                string path = context.Server.MapPath(p);

                #region 处理文件同名问题
                if (FileHelper.IsExistFile(path))
                {
                    int i = 0;
                    while (true)
                    {
                        i++;
                        if (!FileHelper.IsExistFile(context.Server.MapPath(FoldUrl + "/" + fileName.Split('.')[0] + "(" + i + ")" + "." + fileName.Split('.')[1])))
                        {
                            fileName = fileName.Split('.')[0] + "(" + i + ")" + "." + fileName.Split('.')[1];
                            p = FoldUrl + "/" + fileName;
                            path = context.Server.MapPath(p);

                            break;
                        }
                    }
                }
                #endregion
                file.SaveAs(path);
                Resource re = new Resource();
                string Name = fileName.Replace(ext, "");
                re.Name = Name;
                re.PID = int.Parse(Pid);
                re.FileSize = file.ContentLength;
                re.FileUrl = p;
                re.postfix = ext;
                re.CreateUID = CreateUID;
                re.EditUID = CreateUID;
                re.IsFolder = 0;
                if (Pid == "0")
                {
                    re.code = "0";
                }
                else
                {
                    re.code = code == "0" ? "" : code + "|" + re.PID;
                }

                jsonModel = Bll.Add(re);
            }
            catch (Exception ex)
            {
                jsonModel = new JsonModel()
                {
                    errNum = 400,
                    errMsg = ex.Message,
                    retData = ""
                };
                LogService.WriteErrorLog(ex.Message);
            }
            result = "{\"result\":" + jss.Serialize(jsonModel) + "}";

            context.Response.Write(result);
            context.Response.End();
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}