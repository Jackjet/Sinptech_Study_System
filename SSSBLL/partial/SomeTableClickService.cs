﻿using SSSDAL;
using SSSIBLL;
using SSSModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSSBLL
{
    public partial class SomeTableClickService : BaseService<SomeTableClick>, ISomeTableClickService
    {
        SomeTableClickDal dal = new SomeTableClickDal();
        public virtual JsonModel OperSomeTableClick(SomeTableClick entity, Hashtable ht)
        {
            JsonModel jsonModel = null;
            try
            {
                int result = dal.OperSomeTableClick(entity, ht);
                if (result > 0)
                {
                    jsonModel = new JsonModel()
                    {
                        errNum = 0,
                        errMsg = "success",
                        retData = result
                    };
                }
                else
                {
                    jsonModel = new JsonModel()
                    {
                        errNum = 1,
                        errMsg = "操作失败！",
                        retData = ""
                    };
                }
                return jsonModel;
            }
            catch (Exception ex)
            {
                jsonModel = new JsonModel()
                {
                    errNum = 400,
                    errMsg = ex.Message,
                    retData = ""
                };
                return jsonModel;
            }

        }
    }
}
