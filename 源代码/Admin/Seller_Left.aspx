<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Seller_Left.aspx.cs" Inherits="WebSystem.Admin.Admin_Left" %>

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
    
        

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;商家管理</div>
        <div class="MenuNote" style="display:none;" id="SellerDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="SellerSelfEdit.aspx" target="main">修改商家信息</a></li> 
            </ul>
        </div>

        

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;商品管理</div>
        <div class="MenuNote" style="display:none;" id="ProductClassDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="ProductClassEdit.aspx" target="main">添加商品类别</a></li>
                <li><a href="ProductClassList.aspx" target="main">商品类别查询</a></li> 
                <li><a href="ProductSellerEdit.aspx" target="main">发布新商品</a></li>
                <li><a href="ProductSellerList.aspx" target="main">我的商品查询</a></li>
               
            </ul>
        </div>

       

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;订单管理</div>
        <div class="MenuNote" style="display:none;" id="OrderInfoDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="OrderInfoSellerList.aspx" target="main">订单处理</a></li> 
                 
            </ul> 
            </ul>
        </div>

         
        <asp:HiddenField ID="Hvalue" runat="server" />
    </div>
    </form>
</body>
</html>
