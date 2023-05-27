<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderInfoEdit.aspx.cs" Inherits="chengxusheji.Admin.OrderInfoEdit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
    <script type="text/javascript" src="JavaScript/Admin.js"></script>
    <script type="text/javascript" src="../js/jsdate.js"></script>
    <script type="text/javascript">
        function CheckIn() {
            var re = /^[0-9]+.?[0-9]*$/;
            var resc=/^[1-9]+[0-9]*]*$/ ;
            var orderNo = document.getElementById("orderNo").value;
            if (orderNo == "") {
                alert("请输入订单编号...");
                document.getElementById("orderNo").focus();
                return false;
            }

            var orderNumber = document.getElementById("orderNumber").value;
            if(orderNumber == ""){
                alert("请输入订购数量...");
                document.getElementById("orderNumber").focus();
                return false;
            }
            else if (!resc.test(orderNumber))
            {
                alert("订购数量请输入数字");
                document.getElementById("orderNumber").focus();
                //input.rate.focus();
                return false;
            }

            var price = document.getElementById("price").value;
            if(price == ""){
                alert("请输入订购单价...");
                document.getElementById("price").focus();
                return false;
            }
            else if (!re.test(price))
            {
                alert("订购单价请输入数字");
                document.getElementById("price").focus();
                //input.rate.focus();
                return false;
            }

            var totalPrice = document.getElementById("totalPrice").value;
            if(totalPrice == ""){
                alert("请输入订购总价...");
                document.getElementById("totalPrice").focus();
                return false;
            }
            else if (!re.test(totalPrice))
            {
                alert("订购总价请输入数字");
                document.getElementById("totalPrice").focus();
                //input.rate.focus();
                return false;
            }

            var payWay = document.getElementById("payWay").value;
            if (payWay == "") {
                alert("请输入支付方式...");
                document.getElementById("payWay").focus();
                return false;
            }

            var receiveName = document.getElementById("receiveName").value;
            if (receiveName == "") {
                alert("请输入收货人...");
                document.getElementById("receiveName").focus();
                return false;
            }

            var telephone = document.getElementById("telephone").value;
            if (telephone == "") {
                alert("请输入收货人电话...");
                document.getElementById("telephone").focus();
                return false;
            }

            var address = document.getElementById("address").value;
            if (address == "") {
                alert("请输入收货人地址...");
                document.getElementById("address").focus();
                return false;
            }

            return true;
       } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">订单管理 》》编辑订单</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   订单编号：</td>
                    <td width="650px;">
                         <input id="orderNo" type="text"   style="width:300px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入订单编号！</td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    订购商品：</td>
                    <td width="650px;">
                         <asp:DropDownList ID="productObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   订购数量：</td>
                    <td width="650px;">
                         <input id="orderNumber" type="text"   style="width:74px;" runat="server"
                             maxlength="25"/><span class="WarnMes">*</span>请输入订购数量！</td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   订购单价：</td>
                    <td width="650px;">
                         <input id="price" type="text"   style="width:74px;" runat="server"
                             maxlength="25"/><span class="WarnMes">*</span>请输入订购单价！</td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   订购总价：</td>
                    <td width="650px;">
                         <input id="totalPrice" type="text"   style="width:74px;" runat="server"
                             maxlength="25"/><span class="WarnMes">*</span>请输入订购总价！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   支付方式：</td>
                    <td width="650px;">
                         <input id="payWay" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入支付方式！</td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    订单状态：</td>
                    <td width="650px;">
                         <asp:DropDownList ID="orderStateObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   收货人：</td>
                    <td width="650px;">
                         <input id="receiveName" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入收货人！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   收货人电话：</td>
                    <td width="650px;">
                         <input id="telephone" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入收货人电话！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   收货人地址：</td>
                    <td width="650px;">
                         <input id="address" type="text"   style="width:800px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入收货人地址！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   订单备注：</td>
                    <td width="650px;">
                        <textarea id="orderMemo" rows=6 cols=80 runat="server"></textarea></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   下单时间：</td>
                    <td width="650px;">
                         <input id="orderTime" type="text"   style="width:200px;" runat="server" maxlength="25"/></td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    下单用户：</td>
                    <td width="650px;">
                         <asp:DropDownList ID="userObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnOrderInfoSave" runat="server" Text=" 保存信息 "
                            OnClientClick="return CheckIn()" onclick="BtnOrderInfoSave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="取消" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

