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

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;商家管理</div>
        <div class="MenuNote" style="display:none;" id="SellerDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="SellerEdit.aspx" target="main">添加商家</a></li>
                <li><a href="SellerList.aspx" target="main">商家查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;区域管理</div>
        <div class="MenuNote" style="display:none;" id="AreaDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="AreaEdit.aspx" target="main">添加区域</a></li>
                <li><a href="AreaList.aspx" target="main">区域查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;商品管理</div>
        <div class="MenuNote" style="display:none;" id="ProductClassDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="ProductClassEdit.aspx" target="main">添加商品类别</a></li>
                <li><a href="ProductClassList.aspx" target="main">商品类别查询</a></li> 
                <li><a href="ProductEdit.aspx" target="main">添加商品</a></li>
                <li><a href="ProductList.aspx" target="main">商品查询</a></li>
               
            </ul>
        </div>

       

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;订单管理</div>
        <div class="MenuNote" style="display:none;" id="OrderInfoDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="OrderInfoEdit.aspx" target="main">添加订单</a></li>
                <li><a href="OrderInfoList.aspx" target="main">订单查询</a></li>
                 
                <li><a href="OrderStateEdit.aspx" target="main">添加订单状态</a></li>
                <li><a href="OrderStateList.aspx" target="main">订单状态查询</a></li> 
            </ul> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;收藏评论管理</div>
        <div class="MenuNote" style="display:none;" id="CollectionDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="ProductCommentEdit.aspx" target="main">添加商品评论</a></li>
                <li><a href="ProductCommentList.aspx" target="main">商品评论查询</a></li>  
                <li><a href="CollectionEdit.aspx" target="main">添加商品收藏</a></li>
                <li><a href="CollectionList.aspx" target="main">商品收藏查询</a></li> 
            </ul>
        </div>

        
 
 <!--
         <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;客户信息管理</div>
        <div class="MenuNote" style="display:none;" id="Div2" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
          
                <li><a href="M_CusList.aspx" target="main">客户信息列表</a></li>  
            </ul>
        </div> -->
        
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
