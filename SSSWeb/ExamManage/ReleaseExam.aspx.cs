﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSSWeb.ExamManage
{
    public partial class ReleaseExam : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                qtype.Value = Request["qtype"];
                hIDCard.Value = UserInfo.UniqueNo;
                QID.Value = Request["Id"];
                name.Value = Request["name"];
            }
        }
    }
}