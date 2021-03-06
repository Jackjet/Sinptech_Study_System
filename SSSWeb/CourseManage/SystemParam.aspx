﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemParam.aspx.cs" Inherits="SSSWeb.CourseManage.SystemParam" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8" />
    <title>系统参数</title>
    <!--图标样式-->
    <link rel="stylesheet" type="text/css" href="/css/font-awesome.min.css" />
    <link rel="stylesheet" type="text/css" href="/css/reset.css" />
    <link rel="stylesheet" type="text/css" href="/css/common.css" />
    <link href="/css/plan.css" rel="stylesheet" />
    <script type="text/javascript" src="/js/jquery-1.8.3.min.js"></script>
    <link href="/Scripts/Uploadyfy/uploadify/uploadify.css" rel="stylesheet" />
    <script src="/Scripts/jquery-1.11.2.min.js"></script>
    <script src="/Scripts/jquery.cookie.js"></script>
    <script src="/Scripts/Common.js?parm=1.01"></script>
    <script src="/Scripts/Uploadyfy/uploadify/jquery.uploadify-3.1.min.js"></script>
    <style type="text/css">
        .h-ico {
            display: inline-block;
        }

        .change_picture .uploadify-button {
            font-size: 14px;
            border: none;
            background: #00a1ec;
            color: #fff;
        }
    </style>
    <!--[if IE]>
			<script src="js/html5.js"></script>
		<![endif]-->

</head>
<body>

    <input type="hidden" id="HUserIdCard" value="<%=UserInfo.UniqueNo%>" />
    <form id="form1" runat="server">
        <input id="option" type="hidden" value=">" />
        <!--header-->
        <header class="repository_header_wrap manage_header">
            <div class="width repository_header clearfix">
                <a class="logo fl" href="/AppManage/Index.aspx">
                    <img src="/images/logo.png" />
                </a><div class="wenzi_tips fl">
                    <img src="/images/xitongcanshu.png" />
                </div>
                <nav class="navbar menu_mid fl">
                    <ul>
                        
                        <li><a href="/CourseManage/Power.aspx">权限设置</a></li>
                        <li class="active"><a href="#">系统参数</a></li>
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
            <div id="officeResource">
                <div class="MenuDiv">
                    <table class="tbEdit bordshadrad" >
                        <tbody>

                            <tr>
                                <td class="mi">logo：
                                </td>
                                <td class="ku">
                                    <img id="img_Pic" alt="" src="/images/logo.png" style="width: 255px; height: auto; background: #0C6FC0" />
                                    <div class="change_picture">
                                        <input type="file" id="uploadify" name="uploadify" />
                                    </div>
                                </td>
                            </tr>
                            <%--<tr>
                                <td class="mi">底部logo：
                                </td>
                                <td class="ku">
                                    <img id="img_Pic1" alt="" src="/images/footer_logo.png" style="width: 255px; height: auto; background: #0C6FC0" />
                                    <div class="change_picture">
                                        <input type="file" id="uploadify1" name="uploadify" />
                                    </div>
                                </td>
                            </tr>--%>

                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </form>
</body>
<script type="text/javascript" src="/js/common.js"></script>

<script type="text/javascript">
    $(function () {

        $("#uploadify").uploadify({
            'auto': true,                      //是否自动上传
            'swf': '/Scripts/Uploadyfy/uploadify/uploadify.swf',
            'uploader': 'Uploade.ashx',
            'formData': { Func: "UplodLogo", Name: "logo.png" }, //参数
            //'fileTypeDesc': '',
            'fileTypeExts': '*.jpg;*.jpeg;*.png',   //文件类型限制,默认不受限制
            'buttonText': '点击更换logo',//按钮文字
            // 'cancelimg': 'uploadify/uploadify-cancel.png',
            'width':120,
            'height': 24,
            //最大文件数量'uploadLimit':
            'multi': false,//单选            
            'fileSizeLimit': '20MB',//最大文档限制
            'queueSizeLimit': 1,  //队列限制
            'removeCompleted': true, //上传完成自动清空
            'removeTimeout': 0, //清空时间间隔
            //'overrideEvents': ['onDialogClose', 'onUploadSuccess', 'onUploadError', 'onSelectError'],
            'onUploadSuccess': function (file, data, response) {
                var json = $.parseJSON(data);
                window.location.reload();
                //$("#img_Pic").attr("src", decodeURIComponent(json.url));
                //$("#img_Pic").val(data);
            },

        });
        $("#uploadify1").uploadify({
            'auto': true,                      //是否自动上传
            'swf': '/Scripts/Uploadyfy/uploadify/uploadify.swf',
            'uploader': 'Uploade.ashx',
            'formData': { Func: "UplodLogo", Name: "footer_logo.png" }, //参数
            'fileTypeExts': '*.jpg;*.jpeg;*.png',
            'buttonText': '点击更换底部logo',//按钮文字
            // 'cancelimg': 'uploadify/uploadify-cancel.png',
            'width': 120,
            'height': 24,
            //最大文件数量'uploadLimit':
            'multi': false,//单选            
            'fileSizeLimit': '1024MB',//最大文档限制
            'queueSizeLimit': 1,  //队列限制
            'removeCompleted': true, //上传完成自动清空
            'removeTimeout': 0, //清空时间间隔
            //'overrideEvents': ['onDialogClose', 'onUploadSuccess', 'onUploadError', 'onSelectError'],
            'onUploadSuccess': function (file, data, response) {
                var json = $.parseJSON(data);
                window.location.reload();

                //$("#img_Pic1").attr("src", decodeURIComponent(json.url));

                //$("#img_Pic").val(data);
            },

        });
    });
</script>
</html>
