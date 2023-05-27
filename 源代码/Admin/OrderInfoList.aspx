<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderInfoList.aspx.cs" Inherits="chengxusheji.Admin.OrderInfoList" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>订单列表</title>
    <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
   <script src="JavaScript/Admin.js" type="text/javascript"></script>
   <script type="text/javascript" src="../js/jsdate.js"></script>
</head>
<body>
   <form id="form1" runat="server">
    <div class="div_All">
    <div class="Body_Title">订单管理 》》订单列表</div>
     <div class="Body_Search">
        订单编号&nbsp;&nbsp;<asp:TextBox ID="orderNo" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        订购商品&nbsp;&nbsp;<asp:DropDownList ID="productObj" runat="server"></asp:DropDownList>  &nbsp;&nbsp;
        订单状态&nbsp;&nbsp;<asp:DropDownList ID="orderStateObj" runat="server"></asp:DropDownList>  &nbsp;&nbsp;
        收货人&nbsp;&nbsp;<asp:TextBox ID="receiveName" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        收货人电话&nbsp;&nbsp;<asp:TextBox ID="telephone" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        下单时间&nbsp;&nbsp;<asp:TextBox ID="orderTime" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        下单用户&nbsp;&nbsp;<asp:DropDownList ID="userObj" runat="server"></asp:DropDownList>  &nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" Text="查询" onclick="btnSearch_Click" /> 
        &nbsp;&nbsp;&nbsp;<asp:Button ID="btnExport" runat="server" Text="导出excel" OnClick="btnExport_Click" />
    <asp:Repeater ID="RpOrderInfo" runat="server" onitemcommand="RpOrderInfo_ItemCommand">
        <HeaderTemplate>
            <table cellpadding="2" cellspacing="1" class="Admin_Table">
                <thead>
                    <tr class="Admin_Table_Title">
                        <th>选择</th> 
                        <th>订单编号</th>
                        <th>订购商品</th>
                        <th>订购数量</th>
                        <th>订购单价</th>
                        <th>订购总价</th>
                        <th>支付方式</th>
                        <th>订单状态</th>
                        <th>收货人</th>
                        <th>收货人电话</th>
                        <th>下单时间</th>
                        <th>下单用户</th>
                        <th>操作</th> 
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td align="center"><input type="checkbox" value='<%#Eval("orderNo") %>' name="CheckMes" id="DelChecked"/></td>
                <td align="center"><%#Eval("orderNo")%> </td>
                  <td align="center"><%#GetProductproductObj(Eval("productObj").ToString())%></td>
                <td align="center"><%#Eval("orderNumber")%> </td>
                <td align="center"><%#Eval("price")%> </td>
                <td align="center"><%#Eval("totalPrice")%> </td>
                <td align="center"><%#Eval("payWay")%> </td>
                  <td align="center"><%#GetOrderStateorderStateObj(Eval("orderStateObj").ToString())%></td>
                <td align="center"><%#Eval("receiveName")%> </td>
                <td align="center"><%#Eval("telephone")%> </td>
                <td align="center"><%#Eval("orderTime")%> </td>
                  <td align="center"><%#GetUserInfouserObj(Eval("userObj").ToString())%></td>
                <td align="center"><a href="OrderInfoEdit.aspx?orderNo=<%#Eval("orderNo") %>"><img src="Images/MillMes_ICO.gif" alt="修改信息..." /></a><asp:ImageButton class="DelClass" ID="IBDelClass" runat="server" CommandArgument='<%#Eval("orderNo")%>' CommandName="Del" ImageUrl="Images/Delete.gif"  ToolTip="删除该信息..."/></td>
             </tr>
        </ItemTemplate>
        <FooterTemplate></table></FooterTemplate>
    </asp:Repeater>

    <div class="Body_Search">
        <div class="page_Left">
            <input id="BtnAllSelect" type="button" value="全选" />&nbsp;
            <asp:Button ID="BtnAllDel" runat="server" Text=" 删除选中 " onclick="BtnAllDel_Click" />
        </div>
        <div class="page_Right">
        <span class="pageBtn">   <asp:Label runat="server" ID="PageMes"></asp:Label></span>
            <asp:LinkButton ID="LBHome" runat="server" CssClass="pageBtn" 
                onclick="LBHome_Click">[首页]</asp:LinkButton>
            <asp:LinkButton ID="LBUp" runat="server" CssClass="pageBtn" 
                onclick="LBUp_Click">[上一页]</asp:LinkButton>
            <asp:LinkButton ID="LBNext" runat="server" CssClass="pageBtn" 
                onclick="LBNext_Click">[下一页]</asp:LinkButton>
            <asp:LinkButton ID="LBEnd" runat="server" CssClass="pageBtn" 
                onclick="LBEnd_Click">[尾页]</asp:LinkButton>
        </div>
    </div>
    </div>
    <asp:HiddenField ID="HSelectID" runat="server" Value=""/>
    <asp:HiddenField ID="HWhere" runat="server" Value=""/>
    <asp:HiddenField ID="HNowPage" runat="server" Value="1"/>
    <asp:HiddenField ID="HPageSize" runat="server" Value="5"/>
    <asp:HiddenField ID="HAllPage" runat="server" Value="0"/>
    </form>
</body>
</html>
