<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SellerSelfEdit.aspx.cs" Inherits="chengxusheji.Admin.SellerEdit" %>
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
            var sellerUserName = document.getElementById("sellerUserName").value;
            if (sellerUserName == "") {
                alert("�������̼��û���...");
                document.getElementById("sellerUserName").focus();
                return false;
            }

            var password = document.getElementById("password").value;
            if (password == "") {
                alert("�������¼����...");
                document.getElementById("password").focus();
                return false;
            }

            var sellerName = document.getElementById("sellerName").value;
            if (sellerName == "") {
                alert("�������̼�����...");
                document.getElementById("sellerName").focus();
                return false;
            }

            var sellerDesc = document.getElementById("sellerDesc").value;
            if (sellerDesc == "") {
                alert("�������̼ҽ���...");
                document.getElementById("sellerDesc").focus();
                return false;
            }

            var bornDate = document.getElementById("bornDate").value;
            if (bornDate == "") {
                alert("�������������...");
                document.getElementById("bornDate").focus();
                return false;
            }

            var telephone = document.getElementById("telephone").value;
            if (telephone == "") {
                alert("�������̼ҵ绰...");
                document.getElementById("telephone").focus();
                return false;
            }

            var email = document.getElementById("email").value;
            if (email == "") {
                alert("�������̼�����...");
                document.getElementById("email").focus();
                return false;
            }

            var regTime = document.getElementById("regTime").value;
            if (regTime == "") {
                alert("������ע��ʱ��...");
                document.getElementById("regTime").focus();
                return false;
            }

            return true;
       } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">�̼ҹ��� �����༭�̼�</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �̼��û�����</td>
                    <td width="650px;">
                         <input id="sellerUserName" type="text"   style="width:300px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>�������̼��û�����</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��¼���룺</td>
                    <td width="650px;">
                         <input id="password" type="text"   style="width:300px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>�������¼���룡</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �̼����ƣ�</td>
                    <td width="650px;">
                         <input id="sellerName" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>�������̼����ƣ�</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �̼���Ƭ��</td>
                    <td width="650px;">
                       <table cellpadding="0px" cellspacing="0px" width="90%">
                        <tr><td width="400px">
                         ͼƬ·����<asp:TextBox ID="sellerPhoto" runat="server" ReadOnly="True" Width="228px" Enabled="False"></asp:TextBox> &nbsp; &nbsp; &nbsp
                         <br />
                         <br />
                         �ϴ�ͼƬ��<asp:FileUpload ID="SellerPhotoUpload" runat="server" Width="237px" />&nbsp;
                         <asp:Button ID="Btn_SellerPhotoUpload" runat="server" Text="�ϴ�" OnClick="Btn_SellerPhotoUpload_Click" /></td><td>
                         <asp:Image ID="SellerPhotoImage" runat="server" Height="90px" Width="99px" />
                         </td></tr>
                       </table>
                    </td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �̼ҽ��ܣ�</td>
                    <td width="650px;">
                        <textarea id="sellerDesc" rows=6 cols=80 runat="server"></textarea><span class="WarnMes">*</span>�������̼ҽ��ܣ�</td>
                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  �������ڣ�</td>
                    <td width="650px;">
                          <asp:TextBox ID="bornDate"  runat="server" Width="150px"
                              onclick="javascript:SelectDate(this,'yyyy-MM-dd');"></asp:TextBox></td>                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �̼ҵ绰��</td>
                    <td width="650px;">
                         <input id="telephone" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>�������̼ҵ绰��</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �̼����䣺</td>
                    <td width="650px;">
                         <input id="email" type="text"   style="width:500px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>�������̼����䣡</td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    ��������</td>
                    <td width="650px;">
                         <asp:DropDownList ID="areaObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �̼ҵ�ַ��</td>
                    <td width="650px;">
                         <input id="address" type="text"   style="width:800px;" runat="server" maxlength="25"/></td>
                </tr>

                  <tr style="display:none;">
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  ע��ʱ�䣺</td>
                    <td width="650px;">
                          <asp:TextBox ID="regTime"  runat="server" Width="150px"
                              onclick="javascript:SelectDate(this,'yyyy-MM-dd hh:mm:ss');"></asp:TextBox></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnSellerSave" runat="server" Text=" ������Ϣ "
                            OnClientClick="return CheckIn()" onclick="BtnSellerSave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="ȡ��" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

