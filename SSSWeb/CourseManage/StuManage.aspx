﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StuManage.aspx.cs" Inherits="SSSWeb.CourseManage.StuManage" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8" />
    <title>进度查看</title>
    <!--图标样式-->
    <link rel="stylesheet" type="text/css" href="/css/font-awesome.min.css" />
    <link rel="stylesheet" type="text/css" href="/css/reset.css" />
    <link rel="stylesheet" type="text/css" href="/css/common.css" />
    <link rel="stylesheet" type="text/css" href="/css/repository.css" />
    <link rel="stylesheet" type="text/css" href="/css/onlinetest.css" />

    <script type="text/javascript" src="/js/jquery-1.8.3.min.js"></script>
    <script src="/Scripts/jquery-1.11.2.min.js"></script>
    <script src="/Scripts/layer/layer.js"></script>
    <script src="/Scripts/jquery.cookie.js"></script>
    <script src="/Scripts/Common.js?parm=1.01"></script>
    <script src="/Scripts/jquery.tmpl.js"></script>
    <script src="/Scripts/PageBar.js"></script>
    <script type="text/javascript" src="/js/menu_top.js"></script>
    <script src="/CourseManage/Term.js"></script>
    <script src="/CourseMenu.js"></script>
    <style type="text/css">
        .h-ico {
            display: inline-block;
        }
    </style>
    <!--[if IE]>
			<script src="js/html5.js"></script>
		<![endif]-->
    <script id="tr_User" type="text/x-jquery-tmpl">
        <tr>
            <td>${CreateName}</td>
            <td>${Name}</td>
            <td>${BatchUserName}</td>
            <td>${OrgName}</td>
            <td>${CalculatePercent(CoStatistics)}</td>
            <td>${DateTimeConvert(LastStudyTime,"yyyy-MM-dd HH:mm:ss")}</td>
        </tr>
    </script>
</head>
<body>

    <input type="hidden" id="HUserIdCard" value="<%=UserInfo.UniqueNo%>" />
    <input type="hidden" id="HUserName" value="<%=UserInfo.Name %>" />
    <input type="hidden" id="HPId" />
    <form id="form1" runat="server">
        <input id="option" type="hidden" value=">" />
        <!--header-->
        <header class="repository_header_wrap manage_header">
            <div class="width repository_header clearfix">
                <a class="logo fl" href="/AppManage/Index.aspx">
                    <img src="/images/logo.png" /></a>
                <div class="wenzi_tips fl">
                    <img src="/images/coursesystem.png" />
                </div>
                <nav class="navbar menu_mid fl">
                    <ul class="none" id="Title1">
                        <li><a href="/CourseManage/CourceManage.aspx">课程管理</a></li>
                        <li class="active"><a href="/CourseManage/StuManage.aspx">进度查看</a></li>
                    </ul>
                    <ul class="none" id="Title2">
                        <li id="All"><a href="/PersonalSpace/PersonalSpace_Student.aspx#course-1" onclick="geCoursetData(1,10,'')">全部课程</a></li>
                        <li id="Study"><a href="/PersonalSpace/PersonalSpace_Student.aspx#course-2" onclick="geCoursetData(1,10,'0')">在学课程</a></li>
                        <li class="active" id="My"><a href="/PersonalSpace/PersonalSpace_Student.aspx#course-3" onclick="geCoursetData(1,10,'2')">我负责的课程</a></li>
                        <li><a href="/PersonalSpace/ApplyCerty.aspx">证书申请</a></li>
                    </ul>
                </nav>
                <div class="search_account fr clearfix">
                    <ul class="account_area fl">

                        <li>
                            <a href="javascript:;" class="login_area clearfix">
                                <div class="avatar">
                                    <img src="<%=UserInfo.AbsHeadPic%>" />
                                </div>
                                <h2><%=UserInfo.Name%></h2>
                            </a>
                        </li>
                    </ul>
                    <div class="settings fl pr ">
                        <a href="javascript:;">
                            <i class="icon icon-cog"></i>
                        </a>
                        <div class="setting_none">
                            <span onclick="logOut()">退出</span>
                        </div>
                    </div>
                </div>
            </div>
        </header>
        <div class="onlinetest_item width pt90">
            <div class="course_manage bordshadrad">
                <div class="stytem_select clearfix">
                    <div class="stytem_select_left fl">
                        <a href="/PersonalSpace/PersonalSpace_Student.aspx#course-3">课程数据</a>
                        <a href="/CourseManage/StuManage.aspx?Type=2" class="on">学生数据</a>
                    </div>
                    <div class="stytem_select_right fr clearfix">
                        <div class="search_exam fl pr">
                            <input type="text" name="" id="CourseName_my" value="" placeholder="请输入课程名称">
                            <i class="icon  icon-search" onclick="geCoursetData(1,10,'2')"></i>
                        </div>
                    </div>
                </div>
                <div class="newcourse_select clearfix" id="CourseSel">
                    <div class="stytem_select_right fl" style="margin-left: 10px;">

                        <div class="search_exam fl pr">
                            <%--<select name="" class="select" id="IsFinishi" onchange="getData(1, 10)" style="height: 30px; margin: 0px 5px">
                                <option value="0">==学员分类==</option>
                                <option value="0">当前学员</option>
                                <option value="1">历史学员</option>
                            </select>--%>                            
                            <select class="select" id="sel_AllCourse" onchange="getData(1, 10)" style="height: 30px; margin: 0px 5px"></select>
                            <input type="text" name="" id="CourseName" value="" placeholder="请输入课程名称">
                            <%--<input type="text" id="txt_StuName" name="txt_StuName" value="" placeholder="请输入学员姓名">--%>
                            <i class="icon  icon-search" onclick="SearchCondition();"></i>
                        </div>
                    </div>
                    <div class="stytem_select_right fr">
                    </div>
                </div>
                <div class="wrap">
                    <table id="Course">
                        <thead>
                            <tr>
                                <th>学员姓名</th>
                                <th class="pr checkall">课程名称</th>
                                <th>讲师</th>
                                <th>部门</th>
                                <th>学习完成情况</th>
                                <th>最后学习时间</th>
                            </tr>
                        </thead>
                        <tbody id="tb_Manage">
                        </tbody>
                    </table>
                </div>
                <!--分页-->
                <div class="page">
                    <span id="pageBar"></span>
                </div>
            </div>
        </div>
        <footer id="footer"></footer>
    </form>
</body>
<script type="text/javascript" src="/js/common.js"></script>
<script>
    var UrlDate = new GetUrlDate();
    $(function () {
        if (UrlDate.Type == "2") {
            $("#Title2").show();
        }
        else {
            $("#Title1").show();
            $(".stytem_select").hide();
        }
    })
</script>
<script type="text/javascript">
    //function Finish(id, StuNo, Per) {
    //    if (Per == "100%") {
    //        $.ajax({
    //            url: "/Common.ashx",
    //            type: "post",
    //            async: false,
    //            dataType: "json",
    //            data: {
    //                PageName: "/CourseManage/CourceManage.ashx",
    //                Func: "SetStuCourseFinish",
    //                CourseID: id,
    //                StuNo: StuNo,
    //                IsFinish: 1
    //            },
    //            success: function (json) {
    //                if (json.result.errNum.toString() == "0") {
    //                    layer.msg("操作成功");
    //                    getData(1, 10);
    //                }
    //                else {
    //                    layer.msg(json.result.errMsg);
    //                }
    //            },
    //            error: function (errMsg) {
    //                layer.msg(errMsg);
    //            }
    //        });
    //    }
    //    else {
    //        layer.msg("课程未完成不能强制完成");
    //    }
    //}
    $(document).ready(function () {
        $('#footer').load('/footer.html');
        BindAllCourse();
        getData(1, 10);
    });
    //var txt_StuName = $("#txt_StuName").val().trim();
    var courseName = $("#CourseName").val().trim();
    function SearchCondition() {
        //txt_StuName = $("#txt_StuName").val().trim();
        courseName = $("#CourseName").val().trim();
        getData(1, 10);
    }
    //获取数据
    function getData(startIndex, pageSize) {
        //初始化序号 
        pageNum = (startIndex - 1) * pageSize + 1;
        var StudyTerm = $("#StudyTerm").val();

        $.ajax({
            url: "/Common.ashx",
            type: "post",
            async: false,
            dataType: "json",
            data: {
                PageName: "/OnlineLearning/MyLessonsHandler.ashx",
                Func: "GetMyLessonsDataPage",
                PageIndex: startIndex,
                pageSize: pageSize,
                ispage: true,
                Name: courseName,
                //StuName: txt_StuName,
                TeaID: UrlDate.TeaID,
                IsPercent: 1,
                CourseID: $("#sel_AllCourse").val()
            },
            success: function (json) {
                if (json.result.errNum.toString() == "0") {
                    $(".page").show();
                    $("#tb_Manage").html('');
                    $("#tr_User").tmpl(json.result.retData.PagedData).appendTo("#tb_Manage");
                    //ButtonList($("#HPId").val());
                    makePageBar(getData, document.getElementById("pageBar"), json.result.retData.PageIndex, json.result.retData.PageCount, pageSize, json.result.retData.RowCount);
                }
                else {
                    var html = '<tr><td colspan="1000"><div style="background:#fff url(/images/error.png) no-repeat center center; height: 500px;"></div></td></tr>';
                    $("#tb_Manage").html(html);
                    $(".page").hide();
                }
            },
            error: function (errMsg) {
                layer.msg(errMsg);
            }
        });
    }
    function BindAllCourse() {
        var $sel_AllCourse = $("#sel_AllCourse");
        $sel_AllCourse.html('<option value="">==选择课程==</option>');
        $.ajax({
            url: "/Common.ashx",//random" + Math.random(),//方法所在页面和方法名
            type: "post",
            dataType: "json",
            data: {
                PageName: "CourseManage/CourceManage.ashx", Func: "GetPageList", Ispage: false
            },
            success: function (json) {
                if (json.result.errNum.toString() == "0") {
                    $(json.result.retData).each(function () {
                        $sel_AllCourse.append('<option value="' + this.ID + '">' + this.Name + '</option>');
                    });
                }
            },
            error: function (errMsg) {
                layer.msg(errMsg);
            }
        });
    }
    function CalculatePercent(perinfo) {
        var allwidth = 0;
        var oneArray = perinfo.split(',');
        for (var i = 0; i < oneArray.length; i++) {
            var twoArray = oneArray[i].split('|');
            if (twoArray[2].toString() != "0") {
                allwidth += Math.round((twoArray[3] / twoArray[2]) * (twoArray[1] / 100) * 10000) / 100.00;
            }
        }
        return allwidth + "%";
    }
</script>
</html>
