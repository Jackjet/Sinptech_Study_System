using SSSBLL;
using SSSModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using SSSUtility;
using System.IO;
namespace SSSWeb.CourseManage
{
    /// <summary>
    /// UploadHtml5 的摘要说明
    /// </summary>
    public class UploadHtml5 : IHttpHandler
    {
        JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
        JsonModel jsonModel = null;
        Couse_ResourceService bll = new Couse_ResourceService();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            if (context.Request["REQUEST_METHOD"] == "OPTIONS")
            {
                context.Response.End();
            }
            string FuncName = context.Request["Func"].SafeToString();
            string result = string.Empty;

            context.Response.ContentType = "text/plain";
            context.Response.ContentEncoding = System.Text.Encoding.UTF8;
            if (FuncName != null && FuncName != "")
            {
                try
                {
                    switch (FuncName)
                    {
                        case "Uplod"://普通资源
                            Uplod(context);
                            break;
                        case "UplodWeik"://普通资源
                            UplodWeik(context);
                            break;
                        case "UplodeCourse_Work":
                            UplodeCourse_Work(context);
                            break;
                    }
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
            }
        }

        #region 上传资源

        /// <summary>
        /// 上传微课资源
        /// </summary>
        /// <param name="context"></param>
        private void UplodWeik(HttpContext context)
        {
            string result = "";
            JsonModel JsonModel = new JsonModel();
            string UserIdCard = context.Request["UserIdCard"].SafeToString();
            string Type = context.Request["Type"].SafeToString();
            HttpPostedFile file = HttpContext.Current.Request.Files[0];
            string Fpath = ConfigHelper.GetConfigString("FileManageName") + "/PubFolder/Cource/微课/";
            FileHelper.CreateDirectory(context.Server.MapPath(Fpath));

            string ext = System.IO.Path.GetExtension(file.FileName);

            string fileName = Path.GetFileName(file.FileName);// DateTime.Now.Ticks + ext;

            string p = Fpath + "/" + fileName;

            string path = context.Server.MapPath(p);
            #region 处理文件同名问题
            if (FileHelper.IsExistFile(path))
            {
                int i = 0;
                while (true)
                {
                    i++;
                    if (!FileHelper.IsExistFile(context.Server.MapPath(Fpath + "/" + fileName.Split('.')[0] + "(" + i + ")" + "." + fileName.Split('.')[1])))
                    {
                        fileName = fileName.Split('.')[0] + "(" + i + ")" + "." + fileName.Split('.')[1];
                        p = Fpath + "/" + fileName;
                        path = context.Server.MapPath(p);

                        break;
                    }
                }
            }
            #endregion

            file.SaveAs(path);
            if (Type == "1")
            {
                jsonModel = new JsonModel()
                {
                    errNum = 0,
                    errMsg = "",
                    retData = p
                };
                result = "{\"error\":0,\"url\":\"" + context.Server.UrlEncode(p) + "\"}";
            }
            else
            {
                ResourceService resourcedll = new ResourceService();
                Resource re = new Resource();
                string Name = fileName.Replace(ext, "");
                re.Name = Name;// fileName.Split('.')[0];
                re.FileSize = file.ContentLength;
                re.FileUrl = p;
                re.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                //re.FileIcon = "ic" + fileName.Split('.')[1] + ".gif";
                re.postfix = ext;
                re.CreateUID = UserIdCard;
                re.EditUID = UserIdCard;
                JsonModel = resourcedll.Add(re);
                jsonModel = new JsonModel()
                {
                    errNum = 0,
                    errMsg = "",
                    retData = JsonModel.retData.ToString() + "-" + p
                };
                if (context.Request["CourceID"] != null)
                {
                    AddWeike(context, jsonModel.retData.ToString().Split('-')[0]);
                }
                result = string.IsNullOrEmpty(result) ? "{\"result\":" + jss.Serialize(jsonModel) + "}" : result;

            }
            context.Response.Write(result);
            context.Response.End();

        }
        /// <summary>
        /// 上传普通资源
        /// </summary>
        /// <param name="context"></param>
        private void Uplod(HttpContext context)
        {
            string result = "";
            HttpPostedFile file = HttpContext.Current.Request.Files[0];
            string Fpath = ConfigHelper.GetConfigString("FileManageName") + "/Attatchment/CourceAttr";
            FileHelper.CreateDirectory(context.Server.MapPath(Fpath));

            string ext = Path.GetExtension(file.FileName);

            string fileName = Path.GetFileName(file.FileName); //DateTime.Now.Ticks + ext;

            string p = Fpath + "/" + fileName;

            string path = context.Server.MapPath(p);
            #region 处理文件同名问题
            if (FileHelper.IsExistFile(path))
            {
                int i = 0;
                while (true)
                {
                    i++;
                    if (!FileHelper.IsExistDirectory(context.Server.MapPath(Fpath + "/" + fileName.Split('.')[0] + "(" + i + ")" + "." + fileName.Split('.')[1])))
                    {
                        fileName = fileName.Split('.')[0] + "(" + i + ")" + "." + fileName.Split('.')[1];
                        p = Fpath + "/" + fileName;
                        path = context.Server.MapPath(p);

                        break;
                    }
                }
            }
            #endregion
            file.SaveAs(path);
            jsonModel = new JsonModel()
            {
                errNum = 0,
                errMsg = "",
                retData = p
            };
            result = string.IsNullOrEmpty(result) ? "{\"result\":" + jss.Serialize(jsonModel) + "}" : result;
            context.Response.Write(result);
            context.Response.End();

        }
        #endregion
        #region 新增资源
        /// <summary>
        /// 新增资源
        /// </summary>
        /// <param name="context"></param>
        private void AddWeike(HttpContext context, string id)
        {
            string result = "";
            Couse_Resource model = new Couse_Resource();
            try
            {
                model.IsVideo = Convert.ToByte(context.Request["IsVideo"]);
                model.VidoeImag = context.Request["VidoeImag"].SafeToString();
                model.CouseID = int.Parse(context.Request["CourceID"].SafeToString());
                model.ChapterID = context.Request["ChapterID"].SafeToString();
                model.CreateUID = "";
                string resourceid = "";
                if (id != "")
                {
                    resourceid = id;
                }
                else
                {
                    resourceid = context.Request["ResourcesID"].SafeToString();
                }
                if (resourceid.Length > 0)
                {
                    string[] idArray = resourceid.Split(',');
                    for (int i = 0; i < idArray.Length; i++)
                    {
                        if (idArray[i].Length > 0)
                        {
                            model.ResourcesID = int.Parse(idArray[i]);
                            jsonModel = bll.Add(model);
                        }
                    }
                }
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
        #endregion

        #region 上传作业
        /// <summary>
        /// 上传作业
        /// </summary>
        /// <param name="context"></param>
        private void UplodeCourse_Work(HttpContext context)
        {
            string result = "";
            HttpPostedFile file = HttpContext.Current.Request.Files[0];
            string Fpath = ConfigHelper.GetConfigString("FileManageName") + "/Attatchment/CourseWork";
            FileHelper.CreateDirectory(context.Server.MapPath(Fpath));
            string ext = System.IO.Path.GetExtension(file.FileName);
            string fileName = System.IO.Path.GetFileNameWithoutExtension(file.FileName) + "_" + DateTime.Now.Ticks + ext;
            string p = Fpath + "/" + fileName;
            string path = context.Server.MapPath(p);
            file.SaveAs(path);
            jsonModel = new JsonModel()
            {
                errNum = 0,
                errMsg = "",
                retData = p
            };
            result = string.IsNullOrEmpty(result) ? "{\"result\":" + jss.Serialize(jsonModel) + "}" : result;
            context.Response.Write(result);
            context.Response.End();

        }
        #endregion
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}