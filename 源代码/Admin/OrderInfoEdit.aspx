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
                alert("�����붩�����...");
                document.getElementById("orderNo").focus();
                return false;
            }

            var orderNumber = document.getElementById("orderNumber").value;
            if(orderNumber == ""){
                alert("�����붩������...");
                document.getElementById("orderNumber").focus();
                return false;
            }
            else if (!resc.test(orderNumber))
            {
                alert("������������������");
                document.getElementById("orderNumber").focus();
                //input.rate.focus();
                return false;
            }

            var price = document.getElementById("price").value;
            if(price == ""){
                alert("�����붩������...");
                document.getElementById("price").focus();
                return false;
            }
            else if (!re.test(price))
            {
                alert("������������������");
                document.getElementById("price").focus();
                //input.rate.focus();
                return false;
            }

            var totalPrice = document.getElementById("totalPrice").value;
            if(totalPrice == ""){
                alert("�����붩���ܼ�...");
                document.getElementById("totalPrice").focus();
                return false;
            }
            else if (!re.test(totalPrice))
            {
                alert("�����ܼ�����������");
                document.getElementById("totalPrice").focus();
                //input.rate.focus();
                return false;
            }

            var payWay = document.getElementById("payWay").value;
            if (payWay == "") {
                alert("������֧����ʽ...");
                document.getElementById("payWay").focus();
                return false;
            }

            var receiveName = document.getElementById("receiveName").value;
            if (receiveName == "") {
                alert("�������ջ���...");
                document.getElementById("receiveName").focus();
                return false;
            }

            var telephone = document.getElementById("telephone").value;
            if (telephone == "") {
                alert("�������ջ��˵绰...");
                document.getElementById("telephone").focus();
                return false;
            }

            var address = document.getElementById("address").value;
            if (address == "") {
                alert("�������ջ��˵�ַ...");
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
    <div class="Body_Title">�������� �����༭����</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ������ţ�</td>
                    <td width="650px;">
                         <input id="orderNo" type="text"   style="width:300px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>�����붩����ţ�</td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    ������Ʒ��</td>
                    <td width="650px;">
                         <asp:DropDownList ID="productObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ����������</td>
                    <td width="650px;">
                         <input id="orderNumber" type="text"   style="width:74px;" runat="server"
                             maxlength="25"/><span class="WarnMes">*</span>�����붩��������</td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �������ۣ�</td>
                    <td width="650px;">
                         <input id="price" type="text"   style="width:74px;" runat="server"
                             maxlength="25"/><span class="WarnMes">*</span>�����붩�����ۣ�</td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �����ܼۣ�</td>
                    <td width="650px;">
                         <input id="totalPrice" type="text"   style="width:74px;" runat="server"
                             maxlength="25"/><span class="WarnMes">*</span>�����붩���ܼۣ�</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ֧����ʽ��</td>
                    <td width="650px;">
                         <input id="payWay" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>������֧����ʽ��</td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    ����״̬��</td>
                    <td width="650px;">
                         <asp:DropDownList ID="orderStateObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �ջ��ˣ�</td>
                    <td width="650px;">
                         <input id="receiveName" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>�������ջ��ˣ�</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �ջ��˵绰��</td>
                    <td width="650px;">
                         <input id="telephone" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>�������ջ��˵绰��</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �ջ��˵�ַ��</td>
                    <td width="650px;">
                         <input id="address" type="text"   style="width:800px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>�������ջ��˵�ַ��</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ������ע��</td>
                    <td width="650px;">
                        <textarea id="orderMemo" rows=6 cols=80 runat="server"></textarea></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �µ�ʱ�䣺</td>
                    <td width="650px;">
                         <input id="orderTime" type="text"   style="width:200px;" runat="server" maxlength="25"/></td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    �µ��û���</td>
                    <td width="650px;">
                         <asp:DropDownList ID="userObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnOrderInfoSave" runat="server" Text=" ������Ϣ "
                            OnClientClick="return CheckIn()" onclick="BtnOrderInfoSave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="ȡ��" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

