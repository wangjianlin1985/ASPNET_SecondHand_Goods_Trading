<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Left.aspx.cs" Inherits="WebSystem.Admin.Admin_Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
    <script src="JavaScript/Admin.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="LeftNote">
    <img src="Images/MenuTop.jpg"/><br /><img src="images/menu_topline.gif" alt=""/>
    
        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;用户管理</div>
        <div class="MenuNote" style="display:none;" id="UserInfoDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="UserInfoEdit.aspx" target="main">添加用户</a></li>
                <li><a href="UserInfoList.aspx" target="main">用户查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;商品分类管理</div>
        <div class="MenuNote" style="display:none;" id="ProductClassDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="ProductClassEdit.aspx" target="main">添加商品分类</a></li>
                <li><a href="ProductClassList.aspx" target="main">商品分类查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;商品求购管理</div>
        <div class="MenuNote" style="display:none;" id="ProductSeekDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="ProductSeekEdit.aspx" target="main">添加商品求购</a></li>
                <li><a href="ProductSeekList.aspx" target="main">商品求购查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;商品出售管理</div>
        <div class="MenuNote" style="display:none;" id="ProductSellDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="ProductSellEdit.aspx" target="main">添加商品出售</a></li>
                <li><a href="ProductSellList.aspx" target="main">商品出售查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;商品订单管理</div>
        <div class="MenuNote" style="display:none;" id="ProductOrderDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="ProductOrderEdit.aspx" target="main">添加商品订单</a></li>
                <li><a href="ProductOrderList.aspx" target="main">商品订单查询</a></li> 
            </ul>
        </div>

       

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;留言管理</div>
        <div class="MenuNote" style="display:none;" id="LeavewordDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="LeavewordEdit.aspx" target="main">添加留言</a></li>
                <li><a href="LeavewordList.aspx" target="main">留言查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;新闻公告管理</div>
        <div class="MenuNote" style="display:none;" id="NoticeDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="NoticeEdit.aspx" target="main">添加新闻公告</a></li>
                <li><a href="NoticeList.aspx" target="main">新闻公告查询</a></li> 
            </ul>
        </div>

 
 <!--
         <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;客户信息管理</div>
        <div class="MenuNote" style="display:none;" id="Div2" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
          
                <li><a href="M_CusList.aspx" target="main">客户信息列表</a></li>  
            </ul>
        </div>
        
         <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;新旧程度管理</div>
        <div class="MenuNote" style="display:none;" id="XjcdDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="XjcdEdit.aspx" target="main">添加新旧程度</a></li>
                <li><a href="XjcdList.aspx" target="main">新旧程度查询</a></li> 
            </ul>
        </div>

        -->
        
       <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;系统信息管理</div>
        <div class="MenuNote" style="display:none;" id="sysDiv"  runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
           <li><a href="M_AddUsersInfo.aspx" target="main">添加管理员</a></li>
             <li><a href="M_UsersList.aspx" target="main">管理员列表</a></li>           
            </ul>
        </div>
        <asp:HiddenField ID="Hvalue" runat="server" />
    </div>
    </form>
</body>
</html>
