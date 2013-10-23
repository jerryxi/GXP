<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="GXP.SysManage.Users" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../../Content/jquery-easyui/themes/icon.css" rel="stylesheet" />
    <link href="../../Content/jquery-easyui/themes/default/easyui.css" rel="stylesheet" />
    <link href="../../Content/Site.css" rel="stylesheet" />
    <script src="../../Content/jquery-easyui/jquery.min.js"></script>
    <script src="../../Content/jquery-easyui/jquery.easyui.min.js"></script>
    <script src="../../Content/jquery-easyui/locale/easyui-lang-zh_CN.js"></script>
    <%--@*修改时间格式的Js文件*@--%>
    <script src="../../Content/jquery-easyui/datapattern2.js"></script>
    <script type="text/javascript">
    $(function () {
            //初始化弹出窗体
            initTable();    
        });

    //初始化表格 
        function initTable(queryData) {
            $('#test').datagrid({
                title: '用户管理',
                iconCls: 'icon-save',
                height: 400,
                nowrap: true,
                autoRowHeight: false,
                striped: true,
                collapsible: true,
                url: '/SysManage/Users.aspx?action=GetAllUserInfos',
                sortName: 'ID',
                sortOrder: 'asc',
                border: true,
                remoteSort: false,
                idField: 'ID',
                pagination: true,
                rownumbers: true,
                queryParams: queryData,
                columns: [[
                    //ID, UName, Pwd, Phone, Mail, SubTime, LastModifiedOn, DelFlag
                    { field: 'ck', checkbox: true },
					{ field: 'UserCode', title: '用户代码', width: 50, sortable: true },
					{ field: 'UserName', title: '姓名', width: 100, sortable: true },
                    { field: 'LoginPwd', title: "密码", width: 150, sortable: true, },
                    { field: 'Sex', title: "性别", width: 150, sortable: true, },
                    { field: 'Age', title: "年龄", width: 150, sortable: true, },
                    {
                        field: 'CreatedDate', title: "创建时间", width: 150, sortable: true,
                        formatter: function (value, row, index) {
                            return (eval(value.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"))).pattern("yyyy-M-d h:m:s");
                        }
                    }
                ]],
                toolbar: [{
                    id: 'btnadd',
                    text: '添加用户',
                    iconCls: 'icon-add',
                    handler: function () {
                        //实现弹出添加用户信息的层
                        ShowCreateUserDialog();
                    }
                }, '-', {
                    id: 'btncut',
                    text: '修改用户',
                    iconCls: 'icon-cut',
                    handler: function () {
                        //实现弹出修改用户信息的层
                        ShowUpdateUserDialog();
                    }
                }, '-', {
                    id: 'btnsave',
                    text: '删除用户',
                    iconCls: 'icon-remove',
                    handler: function () {
                        //确认只删除一条用户信息
                        DeleteUserInfoByClick();
                    }
                }]
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <fieldset>
        <legend>用户信息查询</legend>
    <div>
        <label for="txtSerachName">姓名：</label>
        <input type="text" ID="txtSerachName" name="txtSerachName"  />&nbsp;&nbsp;
         
        <label for="txtSerachName">邮箱：</label>
        <input type="text" ID="txtSerachMail" name="txtSerachMail"  />

        <%--@*<input type="button" id="btnSerach" name="btnSerach" value="搜索" />*@--%>
        <a href="#" class="easyui-linkbutton" iconcls="icon-search" id="A1"  name="btnSerach">模糊搜索</a>
    </div>
    </fieldset>

    <div>
        <table id="test"></table>
    </div>

    </div>
    </form>
</body>
</html>
