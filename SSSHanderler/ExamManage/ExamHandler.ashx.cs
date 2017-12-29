using SSSBLL;
using SSSModel;
using SSSUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace SSSHanderler.ExamManage
{
    /// <summary>
    /// ExamHandler 的摘要说明
    /// </summary>
    public class ExamHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        { }
        /*{
            JsonModel jsonModel = new JsonModel() { errNum = 0, errMsg = "success", retData = "" };
            JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            Exam_QuestionTypeService examTypeservice = new Exam_QuestionTypeService();
            Exam_ExamPaperService paperservice = new Exam_ExamPaperService();
            Exam_ExaminationService nationservice = new Exam_ExaminationService();
            Exam_ExamPaperObjQService perobjqservice = new Exam_ExamPaperObjQService();
            Exam_ExamPaperSubQService persubqservice = new Exam_ExamPaperSubQService();
            Exam_service examservice = new Exam_service();
            CacheHelper cachehelper = new CacheHelper();
            public void ProcessRequest(HttpContext context)
            {
                context.Response.ContentType = "text/plain";
                string action = context.Request["action"].ToString();
                string result = string.Empty;
                try
                {
                    if (action != null && action != "")
                    {
                        switch (action)
                        {
                            case "GetExamQTList":
                                GetExamQTList(context);
                                break;
                            case "GetExamQPageList":
                                GetExamQPageList(context);
                                break;
                      
                            case "AddExamQuestion":
                                AddExamQuestion(context);
                                break;
                            case "EditExamQuestion":
                                EditExamQuestion(context);
                                break;
                       
                            case "ChangPaperStatus":
                                ChangPaperStatus(context);
                                break;
                            case "GetChildNode":
                                GetChildNode(context);
                                break;
                            case "GetOption":
                                GetOption(context);
                                break;
                            case "FileManager":
                                FileManager(context);
                                break;
                            case "Upload_json":
                                Uploadjson(context);
                                break;
                      
                            case "ChangeNum":
                                ChangeNum(context);
                                break;
                            case "AddNum":
                                AddNum(context);
                                break;
                            case "ReduceNum":
                                ReduceNum(context);
                                break;
                            case "GetQuestionTypeList":
                                GetQuestionTypeList(context);
                                break;
                        
                            case "getTestBasket":
                                gettestbasket(context);
                                break;
                            case "AddQToTesstBasket":
                                AddQToTesstBasket(context);
                                break;
                            case "DelTestBasket":
                                DelTestBasket(context);
                                break;
                            case "getTextBasketTypeQ":
                                getTextBasketTypeQ(context);
                                break;
                            case "getQTcount":
                                getQTcount(context);
                                break;
                            case "GetExamNPageList":
                                GetExamNPageList(context);
                                break;
                            case "annanduchakexun":
                                annanduchakexun(context);
                                break;
                            case "annanduchazhuxun":
                                annanduchazhuxun(context);
                                break;
                            case "GetObjNum":
                                GetObjNum(context);
                                break;
                            case "GetSubQNum":
                                GetSubQNum(context);
                                break;
                            case "checkrandomIDke":
                                checkrandomIDke(context);
                                break;
                            case "checkrandomIDzhu":
                                checkrandomIDzhu(context);
                                break;
                            case "GetQNumByTypeObj":
                                GetQNumByTypeObj(context);
                                break;
                            case "GetQNumByTypeSub":
                                GetQNumByTypeSub(context);
                                break;
                            case "GetQDetailOfObj":
                                GetQDetailOfObj(context);
                                break;
                            case "GetQDetailOfSub":
                                GetQDetailOfSub(context);
                                break;
                            case "GetExamPaper":
                                GetExamPaper(context);
                                break;
                            case "addexamlist":
                                addexamlist(context);
                                break;
                            case "GetQNumByTypePaperObj":
                                GetQNumByTypePaperObj(context);
                                break;
                            case "GetQNumByTypePaperSub":
                                GetQNumByTypePaperSub(context);
                                break;
                            case "GetQDetailOfPaperObj":
                                GetQDetailOfPaperObj(context);
                                break;
                            case "GetQDetailOfPaperSub":
                                GetQDetailOfPaperSub(context);
                                break;
                            case "addExam_ExamAnswer":
                                addExam_ExamAnswer(context);
                                break;
                            case "inquirycategory":
                                inquirycategory(context);
                                break;
                            case "inquirytitlezhu":
                                inquirytitlezhu(context);
                                break;
                            case "inquirytitle":
                                inquirytitle(context);
                                break;
                            case "addExam_ExamPaperSubQ":
                                addExam_ExamPaperSubQ(context);
                                break;
                            case "addExam_ExamPaperObjQ":
                                addExam_ExamPaperObjQ(context);
                                break;
                            case "chaxunzhu":
                                chaxunzhu(context);
                                break;
                            case "chaxunke":
                                chaxunke(context);
                                break;
                            case "chaxunscore":
                                chaxunscore(context);
                                break;
                            case "chaxunTitle":
                                chaxunTitle(context);
                                break;
                            case "upExam_ExamPaperDal":
                                upExam_ExamPaperDal(context);
                                break;
                            case "addExamination":
                                addExamination(context);
                                break;
                            case "GetdataEA":
                                GetdataEA(context);
                                break;
                            case "upExam_ExamAnswer":
                                upExam_ExamAnswer(context);
                                break;
                            case "upExam_Examination":
                                upExam_Examination(context);
                                break;

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

           

            private void DelTestBasket(HttpContext context)
            {
                try
                {
                    string typeid = context.Request["Type"];
                    //清空试题蓝
                    if (string.IsNullOrEmpty(typeid))
                    {
                        if (CacheHelper.Contains("Testbasket"))
                        //if (context.Session["Testbasket"] != null)
                        {
                            CacheHelper.ClearCache("Testbasket");
                            //context.Session.Remove("Testbasket");
                            //Bindtestbasket();
                            jsonModel = new JsonModel()
                            {
                                errNum = 0,
                                errMsg = "删除成功！",
                                retData = ""
                            };
                        }
                    }
                    //删除试题蓝类型试题
                    else
                    {
                        DataTable Testbasket = CacheHelper.GetCache<DataTable>("Testbasket");// context.Session["Testbasket"] as DataTable;
                        DataTable newtestbasket = CreateDataTable(new string[] { "ID", "Type", "QType", "Score" });
                        string ID = context.Request["ID"];
                        //根据试题类型删除试题
                        if (string.IsNullOrEmpty(ID))
                        {
                            int id = Convert.ToInt32(typeid);
                            //判断session里是否存在该试题篮（存在修改数据）
                            if (CacheHelper.Contains("Testbasket"))
                            //if (context.Session["Testbasket"] != null)
                            {

                                foreach (DataRow item in Testbasket.Rows)
                                {
                                    if (!item["Type"].SafeToString().Equals(id.SafeToString()))
                                    {
                                        DataRow newdr = newtestbasket.NewRow();
                                        newdr.ItemArray = item.ItemArray;
                                        newtestbasket.Rows.Add(newdr);
                                    }

                                }
                                CacheHelper.SetCacheHours("Testbasket", newtestbasket, 2);
                                //context.Session["Testbasket"] = newtestbasket;
                                jsonModel = new JsonModel()
                                {
                                    errNum = 0,
                                    errMsg = "删除成功！",
                                    retData = ""
                                };
                            }
                        }
                        //根据试题id删除试题
                        else
                        {
                            string QType = context.Request["QType"].SafeToString();
                            //判断session里是否存在该试题篮（不存在便新增，存在修改数据）
                            if (CacheHelper.Contains("Testbasket"))
                            //if (context.Session["Testbasket"] != null)
                            {
                                foreach (DataRow item in Testbasket.Rows)
                                {
                                    if (!item["ID"].SafeToString().Equals(ID.ToString()) || !item["QType"].SafeToString().Equals(QType.ToString()))
                                    {
                                        DataRow newdr = newtestbasket.NewRow();
                                        newdr.ItemArray = item.ItemArray;
                                        newtestbasket.Rows.Add(newdr);
                                    }

                                }
                                CacheHelper.SetCacheHours("Testbasket", newtestbasket, 2);

                                //context.Session["Testbasket"] = newtestbasket;
                                jsonModel = new JsonModel()
                                {
                                    errNum = 0,
                                    errMsg = "删除成功！",
                                    retData = ""
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    jsonModel = new JsonModel()
                    {
                        errNum = 1,
                        errMsg = "删除失败！" + ex.Message,
                        retData = ""
                    };
                    LogService.WriteErrorLog("ES_wp_ManualMakeExam_删除试题蓝|||" + ex.Message);
                }
            }
            string id = "";
            private void AddQToTesstBasket(HttpContext context)
            {
                string errMsg = "";
                int errNum = 1;
                try
                {
                    string ID = context.Request["ID"].SafeToString();
                    string QType = context.Request["QType"].SafeToString();
                    string type = context.Request["Type"].SafeToString();
                    string Score = context.Request["Score"].SafeToString();
                    //判断session里是否存在该试题篮（不存在便新增，存在修改数据）
                    if (CacheHelper.Contains("Testbasket"))
                    //if (context.Session["Testbasket"] != null)
                    {

                        DataTable Testbasket = CacheHelper.GetCache<DataTable>("Testbasket");// context.Session["Testbasket"] as DataTable;
                        bool ishave = false;
                        foreach (DataRow item in Testbasket.Rows)
                        {
                            if (item["ID"].SafeToString().Equals(ID.ToString()) && item["QType"].SafeToString().Equals(QType.ToString()))
                            {
                                ishave = true;
                            }

                        }
                        if (ishave)
                        {
                            errMsg = "alert('该试题已加入了试题篮，请重新选择！');";
                            return;

                        }
                        else
                        {
                            //修改
                            DataRow newdr = Testbasket.NewRow();
                            DataRow dr = Testbasket.NewRow();
                            dr["ID"] = ID;
                            id += ID;
                            id += ",";
                            dr["Type"] = type;
                            dr["QType"] = QType;
                            dr["Score"] = Score;
                            Testbasket.Rows.Add(dr);
                            CacheHelper.SetCacheHours("Testbasket", Testbasket, 2);

                            //context.Session["Testbasket"] = Testbasket;
                            errMsg = "添加成功！";
                            errNum = 0;

                        }
                    }
                    else
                    {
                        //新增
                        DataTable Testbasket = new DataTable();
                        Testbasket = CreateDataTable(new string[] { "ID", "Type", "QType", "Score" });
                        DataRow dr = Testbasket.NewRow();
                        dr["ID"] = ID;
                        dr["Type"] = type;
                        dr["QType"] = QType;
                        dr["Score"] = Score;
                        Testbasket.Rows.Add(dr);
                        CacheHelper.SetCacheHours("Testbasket", Testbasket, 2);
                        //HttpContext.Current.Session["Testbasket"] = Testbasket;
                        //context.Session.Add("Testbasket", Testbasket);
                        //context.Session.Timeout = 20;
                        errMsg = "添加成功！";
                        errNum = 0;
                    }
                    jsonModel = new JsonModel()
                    {
                        errNum = errNum,
                        errMsg = errMsg,
                        retData = ""
                    };
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
            private DataTable CreateDataTable(string[] str)
            {
                DataTable dt = new DataTable();
                foreach (string item in str)
                {
                    dt.Columns.Add(item);
                }
                return dt;
            }
            /// <summary>
            /// 获取试题篮
            /// </summary>
            private void gettestbasket(HttpContext context)
            {
                try
                {
                    //判断session是否存在试题篮并有数据
                    if (CacheHelper.Contains("Testbasket"))

                    //if (context.Session["Testbasket"] != null)
                    {
                        DataTable testbasketdb = CacheHelper.GetCache<DataTable>("Testbasket");// context.Session["Testbasket"] as DataTable;
                        if (testbasketdb != null && testbasketdb.Rows.Count > 0)
                        {

                            //绑定
                            BLLCommon common = new BLLCommon();
                            List<Dictionary<string, object>> mlist = common.DataTableToList(testbasketdb);
                            jsonModel = new JsonModel()
                            {
                                errMsg = "",
                                errNum = 0,
                                retData = mlist
                            };
                        }
                    }

                }
                catch (Exception ex)
                {
                    LogService.WriteErrorLog("绑定试题蓝试题数据|||" + ex.Message);
                }
            }
       

            private void GetExamQPageList(HttpContext context)
            {
                try
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("MajorId", context.Request["MajorID"] ?? "");
                    ht.Add("Book", context.Request["Book"] ?? "");
                    ht.Add("KlpointID", context.Request["KlpointID"] ?? "");
                    ht.Add("Type", context.Request["Type"] ?? "");
                    ht.Add("Title", context.Request["Title"] ?? "");
                    ht.Add("Status", context.Request["Status"] ?? "1");
                    ht.Add("IsRelease", context.Request["IsRelease"] ?? "1");
                    bool ispage = true;
                    if (!string.IsNullOrEmpty(HttpContext.Current.Request["IsPage"]))
                    {
                        ispage = false;
                    }
                    ht.Add("PageIndex", context.Request["PageIndex"].ToString());
                    ht.Add("PageSize", context.Request["PageSize"].ToString());
                    jsonModel = paperservice.GetPage(ht, ispage);
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
            private void GetExamNPageList(HttpContext context)
            {
                try
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("Status", context.Request["Status"] ?? "");
                    ht.Add("Title", context.Request["Title"] ?? "");
                    ht.Add("Type", context.Request["Type"] ?? "");
                    ht.Add("ClassID", context.Request["ClassID"] ?? "");
                    ht.Add("Book", context.Request["Book"] ?? "");
                    ht.Add("noCreateUID", context.Request["noCreateUID"] ?? "");
                    ht.Add("CreateUID", context.Request["CreateUID"] ?? "");
                    ht.Add("tStatus", context.Request["tStatus"] ?? "");
                    bool ispage = true;
                    if (!string.IsNullOrEmpty(HttpContext.Current.Request["IsPage"]))
                    {
                        ispage = false;
                    }
                    ht.Add("PageIndex", context.Request["PageIndex"] ?? "");
                    ht.Add("PageSize", context.Request["PageSize"] ?? "");
                    jsonModel = nationservice.GetPage(ht, ispage);
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
            
            private void GetObjNum(HttpContext context)
            {
                try
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("Title", context.Request["Title"] ?? "");
                    jsonModel = examservice.GetdatarandomEQ(ht);
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
            private void GetSubQNum(HttpContext context)
            {
                try
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("Title", context.Request["Title"] ?? "");
                    jsonModel = examservice.GetdatarandomES(ht);
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
           
            private void GetExamPaper(HttpContext context)
            {
                try
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("ID", context.Request["ID"] ?? "");
                    ht.Add("CreateUID", context.Request["CreateUID"] ?? "");
                    jsonModel = examservice.GetdataEP(ht);
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
            private void addexamlist(HttpContext context)
            {
                try
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("Title", context.Request["Title"] ?? "");
                    ht.Add("ExamTime", context.Request["ExamTime"] ?? "");
                    ht.Add("Difficulty", context.Request["Difficulty"] ?? "");
                    ht.Add("Status", context.Request["Status"] ?? "");
                    ht.Add("Type", context.Request["Type"] ?? "");
                    ht.Add("FullScore", context.Request["FullScore"] ?? "");
                    ht.Add("Klpoint", context.Request["Klpoint"] ?? "");
                    ht.Add("IsRelease", context.Request["IsRelease"] ?? "");
                    ht.Add("Author", context.Request["Author"] ?? "");
                    ht.Add("Book", context.Request["Book"] ?? "");
                    jsonModel = examservice.addexams(ht);
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
            private void GetQNumByTypeObj(HttpContext context)
            {
                try
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("ID", context.Request["ID"] ?? "");
                    jsonModel = examservice.GetdataEQ(ht);
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
            private void GetQNumByTypeSub(HttpContext context)
            {
                try
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("ID", context.Request["ID"] ?? "");
                    jsonModel = examservice.GetdataES(ht);
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
            private void chaxunke(HttpContext context)
            {
                try
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("ID", context.Request["ID"] ?? "");
                    jsonModel = examservice.GetdataEQADD(ht);
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
            private void chaxunzhu(HttpContext context)
            {
                try
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("ID", context.Request["ID"] ?? "");
                    jsonModel = examservice.GetdataESADD(ht);
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
            private void chaxunscore(HttpContext context)
            {
                try
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("hCreateUID", context.Request["hCreateUID"] ?? "");
                    jsonModel = examservice.GetdataEM(ht);
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
            private void GetdataEA(HttpContext context)
            {
                try
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("ExamID", context.Request["ExamID"] ?? "");
                    jsonModel = examservice.GetdataEA(ht);
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
            private void chaxunTitle(HttpContext context)
            {
                try
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("ExampaperID", context.Request["ExampaperID"] ?? "");
                    jsonModel = examservice.chaExamAnswer(ht);
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
            private void upExam_ExamPaperDal(HttpContext context)
            {
                try
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("ID", context.Request["ID"] ?? "");
                    ht.Add("WorkBeginTime", context.Request["WorkBeginTime"] ?? "");
                    ht.Add("WorkEndTime", context.Request["WorkEndTime"] ?? "");
                    ht.Add("ClassID", context.Request["ClassID"] ?? "");
                    ht.Add("IsRelease", context.Request["IsRelease"] ?? "");
                    ht.Add("evaluate", context.Request["evaluate"] ?? "");
                    jsonModel = examservice.upExam_ExamPaperDal(ht);
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

            private void GetQNumByTypePaperObj(HttpContext context)
            {
                try
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("ExampaperID", context.Request["ExampaperID"] ?? "");
                    jsonModel = examservice.GetdataEPQ(ht);
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
            private void GetQNumByTypePaperSub(HttpContext context)
            {
                try
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("ExampaperID", context.Request["ExampaperID"] ?? "");
                    jsonModel = examservice.GetdataEPS(ht);
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
            private void GetQDetailOfPaperObj(HttpContext context)
            {
                try
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("ExampaperID", context.Request["ExampaperID"] ?? "");
                    ht.Add("Title", context.Request["Title"] ?? "");
                    jsonModel = examservice.GetListtimuEPQ(ht);
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
            private void GetQDetailOfPaperSub(HttpContext context)
            {
                try
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("ExampaperID", context.Request["ExampaperID"] ?? "");
                    ht.Add("Title", context.Request["Title"] ?? "");
                    jsonModel = examservice.GetListtimuEPS(ht);
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
            private void GetQDetailOfObj(HttpContext context)
            {
                try
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("ID", context.Request["ID"] ?? "");
                    ht.Add("Title", context.Request["Title"] ?? "");
                    jsonModel = examservice.GetListtimuEQ(ht);
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
            private void GetQDetailOfSub(HttpContext context)
            {
                try
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("ID", context.Request["ID"] ?? "");
                    ht.Add("Title", context.Request["Title"] ?? "");
                    jsonModel = examservice.GetListtimuES(ht);
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
            private void inquirycategory(HttpContext context)
            {
                try
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("Title", context.Request["Title"] ?? "");
                    jsonModel = examservice.GetdatarandomET(ht);
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
            private void inquirytitle(HttpContext context)
            {
                try
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("Type", context.Request["Type"] ?? "");
                    ht.Add("ExamID", context.Request["ExamID"] ?? "");
                    jsonModel = examservice.GetdataEAQ(ht);
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
            private void inquirytitlezhu(HttpContext context)
            {
                try
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("Type", context.Request["Type"] ?? "");
                    ht.Add("ExamID", context.Request["ExamID"] ?? "");
                    jsonModel = examservice.GetdataEAS(ht);
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
            private void addExam_ExamAnswer(HttpContext context)
            {
                try
                {
                    Hashtable ht = new Hashtable();
                    string ExamID = context.Request["ExamID"].SafeToString();
                    ht.Add("ExamID", ExamID);
                    ht.Add("QuestionID", context.Request["QuestionID"] ?? "");
                    ht.Add("ExampaperID", context.Request["ExampaperID"] ?? "");
                    ht.Add("Type", context.Request["Type"] ?? "");
                    ht.Add("Answer", context.Request["Answer"] ?? "");
                    ht.Add("Score", context.Request["Score"] ?? "");
                    jsonModel = examservice.addExamAnswer(ht);
                    if (jsonModel.errNum == 0)
                    {
                        Exam_Examination modol = new Exam_Examination();
                        modol.ID = int.Parse(ExamID);
                        modol.Status = 1;
                        nationservice.Update(modol);
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
            private void upExam_ExamAnswer(HttpContext context)
            {
                try
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("ExamID", context.Request["ExamID"] ?? "");
                    ht.Add("QuestionID", context.Request["QuestionID"] ?? "");
                    ht.Add("Type", context.Request["Type"] ?? "");
                    ht.Add("Score", context.Request["Score"] ?? "");
                    jsonModel = examservice.upExam_ExamAnswer(ht);
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
            private void upExam_Examination(HttpContext context)
            {
                try
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("ID", context.Request["ID"] ?? "");
                    ht.Add("Status", context.Request["Status"] ?? "");
                    jsonModel = examservice.upExam_Examination(ht);
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

            private void addExamination(HttpContext context)
            {
                Hashtable ht1 = new Hashtable();
                ht1.Add("CreateUID", context.Request["CreateUID"] ?? "");
                ht1.Add("ExampaperID", context.Request["ExampaperID"] ?? "");

                JsonModel jModol = nationservice.GetPage(ht1, false);
                if (jModol.errNum == 0)
                {
                    jsonModel = new JsonModel()
                    {
                        errNum = 999,
                        errMsg = "已有数据",
                        retData = ""
                    };
                }
                else
                {
                    try
                    {
                        Hashtable ht = new Hashtable();
                        ht.Add("Title", context.Request["Title"] ?? "");
                        ht.Add("CreateUID", context.Request["CreateUID"] ?? "");
                        ht.Add("UserName", context.Request["UserName"] ?? "");
                        ht.Add("ExampaperID", context.Request["ExampaperID"] ?? "");
                        ht.Add("Score", context.Request["Score"] ?? "");
                        ht.Add("Status", context.Request["Status"] ?? "");
                        ht.Add("Marker", context.Request["Marker"] ?? "");
                        ht.Add("AnswerBeginTime", context.Request["AnswerBeginTime"] ?? "");
                        ht.Add("AnswerEndTime", context.Request["AnswerEndTime"] ?? "");
                        ht.Add("classid", context.Request["classid"] ?? "");
                        jsonModel = examservice.addExamination(ht);
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

            private void addExam_ExamPaperSubQ(HttpContext context)
            {
                try
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("ExampaperID", context.Request["ExampaperID"] ?? "");
                    ht.Add("Type", context.Request["Type"] ?? "");
                    ht.Add("Content", context.Request["Content"] ?? "");
                    ht.Add("Answer", context.Request["Answer"] ?? "");
                    ht.Add("OrderID", context.Request["OrderID"] ?? "");
                    ht.Add("Analysis", context.Request["Analysis"] ?? "");
                    ht.Add("Difficulty", context.Request["Difficulty"] ?? "");
                    ht.Add("IsShowAnalysis", context.Request["IsShowAnalysis"] ?? "");
                    ht.Add("Score", context.Request["Score"] ?? "");
                    jsonModel = examservice.addexamsEPS(ht);
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
            private void addExam_ExamPaperObjQ(HttpContext context)
            {
                try
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("ExampaperID", context.Request["ExampaperID"] ?? "");
                    ht.Add("Type", context.Request["Type"] ?? "");
                    ht.Add("Content", context.Request["Content"] ?? "");
                    ht.Add("OptionA", context.Request["OptionA"] ?? "");
                    ht.Add("OptionB", context.Request["OptionB"] ?? "");
                    ht.Add("OptionC", context.Request["OptionC"] ?? "");
                    ht.Add("OptionD", context.Request["OptionD"] ?? "");
                    ht.Add("OptionE", context.Request["OptionE"] ?? "");
                    ht.Add("OptionF", context.Request["OptionF"] ?? "");
                    ht.Add("Difficulty", context.Request["Difficulty"] ?? "");
                    ht.Add("Answer", context.Request["Answer"] ?? "");
                    ht.Add("Score", context.Request["Score"] ?? "");
                    ht.Add("IsShowAnalysis", context.Request["IsShowAnalysis"] ?? "");
                    ht.Add("Analysis", context.Request["Analysis"] ?? "");
                    ht.Add("OrderID", context.Request["OrderID"] ?? "");
                    jsonModel = examservice.addexamsEPQ(ht);
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
            public DataTable getQList(DataTable examdb, HttpContext context)
            {

                //将datatable转成xml缓存

                //string filePath = XmlHelper.CreateFolder();
                //XmlDocument xDoc = new XmlDocument();
                //XmlDeclaration xmlDec = xDoc.CreateXmlDeclaration("1.0", "utf-8", null);
                //xDoc.AppendChild(xmlDec);
                //XmlElement xmlRoot = xDoc.CreateElement("ExamQ");
                //xDoc.AppendChild(xmlRoot);
                //foreach (DataRow item in examdb.Rows)
                //{
                //    XmlElement xmlQItem = xDoc.CreateElement("QItem");
                //    foreach (DataColumn itemc in examdb.Columns)
                //    {
                //        XmlAttribute xmlAttr = xDoc.CreateAttribute(itemc.ColumnName);
                //        xmlAttr.Value = item[itemc.ColumnName] == null ? "" : item[itemc.ColumnName].SafeToString();
                //        xmlQItem.Attributes.Append(xmlAttr);
                //    }
                //    xmlRoot.AppendChild(xmlQItem);
                //}
                //xDoc.Save(filePath);
                return examdb;
            }
            /// <summary>
            /// 智能选题减试题数量
            /// </summary>
            private void ReduceNum(HttpContext context)
            {
                try
                {
                    string type = context.Request["type"].SafeToString();
                    string id = context.Request["id"].SafeToString();
                    string diff = context.Request["diff"].SafeToString();
                    int chagenum = -1;

                    //判断session是否存在试题篮并有数据
                    if (context.Session["Testbasket"] != null)
                    {
                        DataTable Testbasket = context.Session["Testbasket"] as DataTable;
                        Testbasket = getNewTestbasket(type, id, diff, ref chagenum, context);
                        context.Session["Testbasket"] = Testbasket;
                        jsonModel = new JsonModel()
                        {
                            errNum = 0,
                            errMsg = "",
                            retData = 0
                        };
                    }
                    else
                    {
                        ////新增
                        //DataTable Testbasket = new DataTable();
                        //Testbasket = getNewTestbasket(type, id, diff, ref chagenum);
                        //Session.Add("Testbasket", Testbasket);
                        jsonModel = new JsonModel()
                        {
                            errNum = 1,
                            errMsg = "",
                            retData = 0
                        };
                    }


                }
                catch (Exception ex)
                {
                    jsonModel = new JsonModel()
                    {
                        errNum = 1,
                        errMsg = "",
                        retData = 0
                    };
                    LogService.WriteErrorLog("ES_wp_Intelligence_修改试题类型试题数量||||" + ex.Message);
                }
            }
            /// <summary>
            /// 智能选题加试题数量
            /// </summary>
            private void AddNum(HttpContext context)
            {
                try
                {
                    string type = context.Request["type"].SafeToString();
                    string id = context.Request["id"].SafeToString();
                    string diff = context.Request["diff"].SafeToString();

                    int chagenum = 1;
                    //判断session是否存在试题篮并有数据
                    if (context.Session["Testbasket"] != null)
                    {
                        DataTable Testbasket = context.Session["Testbasket"] as DataTable;
                        Testbasket = getNewTestbasket(type, id, diff, ref chagenum, context);
                        context.Session["Testbasket"] = Testbasket;

                        jsonModel = new JsonModel()
                        {
                            errNum = 0,
                            errMsg = "",
                            retData = chagenum
                        };
                    }
                    else
                    {
                        //新增
                        DataTable Testbasket = new DataTable();
                        Testbasket = getNewTestbasket(type, id, diff, ref chagenum, context);
                        context.Session.Add("Testbasket", Testbasket);
                        jsonModel = new JsonModel()
                        {
                            errNum = 0,
                            errMsg = "",
                            retData = chagenum
                        };

                    }


                }
                catch (Exception ex)
                {
                    jsonModel = new JsonModel()
                    {
                        errNum = 0,
                        errMsg = "",
                        retData = 0
                    };
                    LogService.WriteErrorLog("ES_wp_Intelligence_修改试题类型试题数量|||" + ex.Message);
                }
            }
            /// <summary>
            /// 智能选题改变试题数量
            /// </summary>
            private void ChangeNum(HttpContext context)
            {
                try
                {
                    string oldnum = context.Request["oldnum"].SafeToString();
                    string num = context.Request["num"].SafeToString();
                    string type = context.Request["type"].SafeToString();
                    string id = context.Request["id"].SafeToString();
                    string diff = context.Request["diff"].SafeToString();
                    int chagenum = Convert.ToInt32(num) - Convert.ToInt32(oldnum);
                    Cookie c = new Cookie();
                    //判断session是否存在试题篮并有数据
                    if (context.Session["Testbasket"] != null)
                    {
                        DataTable Testbasket = context.Session["Testbasket"] as DataTable;
                        Testbasket = getNewTestbasket(type, id, diff, ref chagenum, context);
                        context.Session["Testbasket"] = Testbasket;
                        jsonModel = new JsonModel()
                        {
                            errNum = 0,
                            errMsg = "",
                            retData = chagenum
                        };
                    }
                    else
                    {
                        //新增
                        DataTable Testbasket = new DataTable();
                        Testbasket = getNewTestbasket(type, id, diff, ref chagenum, context);
                        context.Session.Add("Testbasket", Testbasket);

                        jsonModel = new JsonModel()
                        {
                            errNum = 0,
                            errMsg = "",
                            retData = chagenum
                        };
                    }


                }
                catch (Exception ex)
                {
                    jsonModel = new JsonModel()
                    {
                        errNum = 1,
                        errMsg = "",
                        retData = "0"
                    };
                    LogService.WriteErrorLog("ES_wp_Intelligence_修改试题类型试题数量||||" + ex.Message);
                }
            }
      
           

            /// <summary>
            /// 上传文件
            /// </summary>
            private void Uploadjson(HttpContext context)
            {
                try
                {
                    String aspxUrl = context.Request.Path.Substring(0, context.Request.Path.LastIndexOf("/") + 1);

                    //文件保存目录路径
                    String savePath = "/attached/";

                    //文件保存目录URL
                    String saveUrl = aspxUrl + "/attached/";

                    //定义允许上传的文件扩展名
                    Hashtable extTable = new Hashtable();
                    extTable.Add("image", "gif,jpg,jpeg,png,bmp");
                    extTable.Add("flash", "swf,flv");
                    extTable.Add("media", "swf,flv,mp3,wav,wma,wmv,mid,avi,mpg,asf,rm,rmvb");
                    extTable.Add("file", "doc,docx,xls,xlsx,ppt,htm,html,txt,zip,rar,gz,bz2");

                    //最大文件大小
                    int maxSize = 1000000;
                    //this.context = context;

                    HttpPostedFile imgFile = context.Request.Files["imgFile"];
                    if (imgFile == null)
                    {
                        showError("请选择文件。", context);
                    }

                    String dirPath = context.Server.MapPath(savePath);
                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                        //showError("上传目录不存在。");
                    }
                    String dirName = context.Request.QueryString["dir"];
                    if (String.IsNullOrEmpty(dirName))
                    {
                        dirName = "image";
                    }
                    if (!extTable.ContainsKey(dirName))
                    {
                        showError("目录名不正确。", context);
                    }

                    String fileName = imgFile.FileName;
                    String fileExt = Path.GetExtension(fileName).ToLower();

                    if (imgFile.InputStream == null || imgFile.InputStream.Length > maxSize)
                    {
                        showError("上传文件大小超过限制。", context);
                    }

                    if (String.IsNullOrEmpty(fileExt) || Array.IndexOf(((String)extTable[dirName]).Split(','), fileExt.Substring(1).ToLower()) == -1)
                    {
                        showError("上传文件扩展名是不允许的扩展名。\n只允许" + ((String)extTable[dirName]) + "格式。", context);
                    }

                    //创建文件夹
                    dirPath += dirName + "/";
                    saveUrl += dirName + "/";
                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                    }
                    String ymd = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
                    dirPath += ymd + "/";
                    saveUrl += ymd + "/";
                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                    }

                    String newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;

                    String filePath = dirPath + newFileName;
                    //string filePath = string.Empty;
                    bool result = false;
                    string msg = string.Empty;
                    //PictureHandle.UploadImage(imgFile, null, out filePath, out result, out msg);
                    imgFile.SaveAs(filePath);
                    if (result)
                    {
                        String fileUrl = saveUrl + newFileName;
                        Hashtable hash = new Hashtable();
                        hash["error"] = 0;
                        hash["url"] = fileUrl.Replace("\\", "/");
                        context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
                        context.Response.Write(JsonMapper.ToJson(hash));
                        context.Response.End();
                    }

                }
                catch (Exception ex)
                {

                    LogService.WriteErrorLog("保存试题时图片文件保存|||" + ex.Message);
                }
            }

            private void showError(string message, HttpContext context)
            {
                Hashtable hash = new Hashtable();
                hash["error"] = 1;
                hash["message"] = message;
                context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
                context.Response.Write(JsonMapper.ToJson(hash));
                context.Response.End();
            }
            /// <summary>
            /// 文件格式判断
            /// </summary>
            private void FileManager(HttpContext context)
            {
                try
                {

                    String aspxUrl = context.Request.Path.Substring(0, context.Request.Path.LastIndexOf("/") + 1);

                    //根目录路径，相对路径
                    String rootPath = "/attached/";
                    //根目录URL，可以指定绝对路径，比如 http://www.yoursite.com/attached/
                    String rootUrl = aspxUrl + "/attached/";
                    //图片扩展名
                    // String fileTypes = "gif,jpg,jpeg,png,bmp";

                    String currentPath = "";
                    String currentUrl = "";
                    String currentDirPath = "";
                    String moveupDirPath = "";

                    String dirPath = context.Server.MapPath(rootPath);
                    String dirName = context.Request.QueryString["dir"];
                    if (!String.IsNullOrEmpty(dirName))
                    {
                        if (Array.IndexOf("image,flash,media,file".Split(','), dirName) == -1)
                        {
                            context.Response.Write("Invalid Directory name.");
                            context.Response.End();
                        }
                        dirPath += dirName + "/";
                        rootUrl += dirName + "/";
                        if (!Directory.Exists(dirPath))
                        {
                            Directory.CreateDirectory(dirPath);
                        }
                    }

                    //根据path参数，设置各路径和URL
                    String path = context.Request.QueryString["path"];
                    path = String.IsNullOrEmpty(path) ? "" : path;
                    if (path == "")
                    {
                        currentPath = dirPath;
                        currentUrl = rootUrl;
                        currentDirPath = "";
                        moveupDirPath = "";
                    }
                    else
                    {
                        currentPath = dirPath + path;
                        currentUrl = rootUrl + path;
                        currentDirPath = path;
                        moveupDirPath = Regex.Replace(currentDirPath, @"(.*?)[^\/]+\/$", "$1");
                    }

                    //排序形式，name or size or type
                    String order = context.Request.QueryString["order"];
                    order = String.IsNullOrEmpty(order) ? "" : order.ToLower();

                    //不允许使用..移动到上一级目录
                    if (Regex.IsMatch(path, @"\.\."))
                    {
                        context.Response.Write("Access is not allowed.");
                        context.Response.End();
                    }
                    //最后一个字符不是/
                    if (path != "" && !path.EndsWith("/"))
                    {
                        context.Response.Write("Parameter is not valid.");
                        context.Response.End();
                    }
                    //目录不存在或不是目录
                    if (!Directory.Exists(currentPath))
                    {
                        context.Response.Write("Directory does not exist.");
                        context.Response.End();
                    }

                    //遍历目录取得文件信息
                    string[] dirList = Directory.GetDirectories(currentPath);
                    string[] fileList = Directory.GetFiles(currentPath);

                    switch (order)
                    {
                        case "size":
                            Array.Sort(dirList, new NameSorter());
                            Array.Sort(fileList, new SizeSorter());
                            break;
                        case "type":
                            Array.Sort(dirList, new NameSorter());
                            Array.Sort(fileList, new TypeSorter());
                            break;
                        case "name":
                        default:
                            Array.Sort(dirList, new NameSorter());
                            Array.Sort(fileList, new NameSorter());
                            break;
                    }
                    Hashtable hash = new Hashtable();
                    hash["error"] = 0;
                    hash["message"] = "格式正确！";
                    context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
                    context.Response.Write(JsonMapper.ToJson(hash));
                    context.Response.End();
                }
                catch (Exception ex)
                {

                    LogService.WriteErrorLog("ES_wp_AddExamQuestion_ES_wp_EditExamQuestion_保存试题时文件处理|||" + ex.Message);
                }
            }

            public class NameSorter : IComparer
            {
                public int Compare(object x, object y)
                {
                    if (x == null && y == null)
                    {
                        return 0;
                    }
                    if (x == null)
                    {
                        return -1;
                    }
                    if (y == null)
                    {
                        return 1;
                    }
                    FileInfo xInfo = new FileInfo(x.ToString());
                    FileInfo yInfo = new FileInfo(y.ToString());

                    return xInfo.FullName.CompareTo(yInfo.FullName);
                }
            }

            public class SizeSorter : IComparer
            {
                public int Compare(object x, object y)
                {
                    if (x == null && y == null)
                    {
                        return 0;
                    }
                    if (x == null)
                    {
                        return -1;
                    }
                    if (y == null)
                    {
                        return 1;
                    }
                    FileInfo xInfo = new FileInfo(x.ToString());
                    FileInfo yInfo = new FileInfo(y.ToString());

                    return xInfo.Length.CompareTo(yInfo.Length);
                }
            }

            public class TypeSorter : IComparer
            {
                public int Compare(object x, object y)
                {
                    if (x == null && y == null)
                    {
                        return 0;
                    }
                    if (x == null)
                    {
                        return -1;
                    }
                    if (y == null)
                    {
                        return 1;
                    }
                    FileInfo xInfo = new FileInfo(x.ToString());
                    FileInfo yInfo = new FileInfo(y.ToString());

                    return xInfo.Extension.CompareTo(yInfo.Extension);
                }
            }

           
            private void GetChildNode(HttpContext context)
            {
                try
                {

                    if (context.Request["pid"] != null && !string.IsNullOrEmpty(context.Request["pid"].ToString()))
                    {
                        int pid = int.Parse(context.Request["pid"].ToString());
                        int nodesid = int.Parse(context.Request["nodes"].SafeToString());
                        DataTable Subjectdt = new DataTable();
                        string[] columns = new string[] { "ID", "Title", "Pid" };
                        foreach (string column in columns)
                        {
                            Subjectdt.Columns.Add(column);
                        }
                        if (pid == 0)
                        {
                            //Subjectdt = ExamQManager.GetMajor();
                        }
                        else if (nodesid == 1)
                        { //Subjectdt = ExamQManager.GetSubject(pid); 
                        }
                        else
                        {
                            // Subjectdt = ExamQManager.GetNodesByPid(pid);
                        }
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < Subjectdt.Rows.Count; i++)
                        {
                            sb.Append("<option value='" + Subjectdt.Rows[i]["ID"] + "'>" + Subjectdt.Rows[i]["Title"] + "</option>");
                        }
                        if (sb != null)
                        {
                            context.Response.Write(sb.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogService.WriteErrorLog("GetChildNode_专业学科联动获取数据|||" + ex.Message);

                }
            }
           

            #region 修改试卷的启用或禁用状态
            /// <summary>
            /// 修改试卷的启用或禁用状态
            /// </summary>
            private void ChangPaperStatus(HttpContext context)
            {
                try
                {
                    string status = context.Request["Status"].SafeToString();
                    string paperID = context.Request["PaperID"].SafeToString();
                    if (!string.IsNullOrEmpty(status) && !string.IsNullOrEmpty(paperID))
                    {
                        Exam_ExamPaper paper = paperservice.GetEntityById(Convert.ToInt32(paperID)).retData as Exam_ExamPaper;
                        paper.Status = Convert.ToInt32(status);
                        jsonModel = paperservice.Update(paper);
                    }
                    else
                    {
                        jsonModel = new JsonModel()
                        {
                            errNum = 1,
                            errMsg = "修改失败！",
                            retData = ""
                        };
                    }
                }
                catch (Exception ex)
                {

                    LogService.WriteErrorLog("ChangPaperStatus_修改试卷的启用或禁用状态|||" + ex.Message);
                    jsonModel = new JsonModel()
                    {
                        errNum = 1,
                        errMsg = "修改失败！",
                        retData = ""
                    };
                }
            }
            #endregion

          
          */
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}