<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SellerList.aspx.cs" Inherits="chengxusheji.Admin.SellerList" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>商家列表</title>
    <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
   <script src="JavaScript/Admin.js" type="text/javascript"></script>
   <script type="text/javascript" src="../js/jsdate.js"></script>
</head>
<body>
   <form id="form1" runat="server">
    <div class="div_All">
    <div class="Body_Title">商家管理 》》商家列表</div>
     <div class="Body_Search">
        商家用户名&nbsp;&nbsp;<asp:TextBox ID="sellerUserName" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        商家名称&nbsp;&nbsp;<asp:TextBox ID="sellerName" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        成立日期&nbsp;&nbsp; <asp:TextBox ID="bornDate"  runat="server" Width="112px" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>&nbsp;&nbsp;
        商家电话&nbsp;&nbsp;<asp:TextBox ID="telephone" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        所在区域&nbsp;&nbsp;<asp:DropDownList ID="areaObj" runat="server"></asp:DropDownList>  &nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" Text="查询" onclick="btnSearch_Click" /> 
        &nbsp;&nbsp;&nbsp;<asp:Button ID="btnExport" runat="server" Text="导出excel" OnClick="btnExport_Click" />
    <asp:Repeater ID="RpSeller" runat="server" onitemcommand="RpSeller_ItemCommand">
        <HeaderTemplate>
            <table cellpadding="2" cellspacing="1" class="Admin_Table">
                <thead>
                    <tr class="Admin_Table_Title">
                        <th>选择</th> 
                        <th>商家用户名</th>
                        <th>商家名称</th>
                        <th>商家照片</th>
                        <th>成立日期</th>
                        <th>商家电话</th>
                        <th>商家邮箱</th>
                        <th>所在区域</th>
                        <th>注册时间</th>
                        <th>操作</th> 
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td align="center"><input type="checkbox" value='<%#Eval("sellerUserName") %>' name="CheckMes" id="DelChecked"/></td>
                <td align="center"><%#Eval("sellerUserName")%> </td>
                <td align="center"><%#Eval("sellerName")%> </td>
                <td align="center"><img src="../<%#Eval("sellerPhoto")%>" width=50 height=50 />
                  <td align="center"><%# Convert.ToDateTime(Eval("bornDate")).ToShortDateString() %></td>
                <td align="center"><%#Eval("telephone")%> </td>
                <td align="center"><%#Eval("email")%> </td>
                  <td align="center"><%#GetAreaareaObj(Eval("areaObj").ToString())%></td>
                  <td align="center"><%# Convert.ToDateTime(Eval("regTime")).ToShortDateString() + " " + Convert.ToDateTime(Eval("regTime")).ToLongTimeString() %></td>
                <td align="center"><a href="SellerEdit.aspx?sellerUserName=<%#Eval("sellerUserName") %>"><img src="Images/MillMes_ICO.gif" alt="修改信息..." /></a><asp:ImageButton class="DelClass" ID="IBDelClass" runat="server" CommandArgument='<%#Eval("sellerUserName")%>' CommandName="Del" ImageUrl="Images/Delete.gif"  ToolTip="删除该信息..."/></td>
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
