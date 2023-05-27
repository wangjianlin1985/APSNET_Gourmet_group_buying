<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="Seller_frontList" %>
<%@ Register Src="../header.ascx" TagName="header" TagPrefix="uc" %>
<%@ Register Src="../footer.ascx" TagName="footer" TagPrefix="uc" %>
<%
    String path = Request.ApplicationPath;
    String basePath = path + "/"; 
%>
<!DOCTYPE html>
<html>
<head>
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1 , user-scalable=no">
<title>商家查询</title>
<link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
<link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
<link href="<%=basePath %>plugins/animate.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
</head>
<body style="margin-top:70px;">
<div class="container">
<uc:header ID="header" runat="server" />
 <form id="form1" runat="server">
	<div class="col-md-9 wow fadeInLeft">
		<ul class="breadcrumb">
  			<li><a href="../index.aspx">首页</a></li>
  			<li><a href="frontList.aspx">商家信息列表</a></li>
  			<li class="active">查询结果显示</li>
  			<a class="pull-right" href="frontAdd.aspx" style="display:none;">添加商家</a>
		</ul>
		<div class="row">
			<asp:Repeater ID="RpSeller" runat="server">
			<ItemTemplate>
			<div class="col-md-3 bottom15" <%#(((Container.ItemIndex+0)%4==0)?"style='clear:left;'":"") %>>
			  <a href="frontshow.aspx?sellerUserName=<%#Eval("sellerUserName")%>"><img class="img-responsive" src="../<%#Eval("sellerPhoto")%>" /></a>
			     <div class="showFields">
			     	<div class="field">
	            		商家用户名: <%#Eval("sellerUserName")%>
			     	</div>
			     	<div class="field">
	            		商家名称: <%#Eval("sellerName")%>
			     	</div>
			     	<div class="field">
	            		成立日期: <%#Eval("bornDate")%>
			     	</div>
			     	<div class="field">
	            		商家电话: <%#Eval("telephone")%>
			     	</div>
			     	<div class="field">
	            		商家邮箱: <%#Eval("email")%>
			     	</div>
			     	<div class="field">
	            		所在区域:<%#GetAreaareaObj(Eval("areaObj").ToString())%>
			     	</div>
			     	<div class="field">
	            		注册时间: <%#Eval("regTime")%>
			     	</div>
			        <a class="btn btn-primary top5" href="frontShow.aspx?sellerUserName=<%#Eval("sellerUserName")%>">详情</a>
			        <a class="btn btn-primary top5" onclick="sellerEdit('<%#Eval("sellerUserName")%>');" style="display:none;">修改</a>
			        <a class="btn btn-primary top5" onclick="sellerDelete('<%#Eval("sellerUserName")%>');" style="display:none;">删除</a>
			     </div>
			</div>
			</ItemTemplate>
			</asp:Repeater>

			<div class="row">
				<div class="col-md-12">
					<nav class="pull-left">
						<ul class="pagination">
 						        <asp:LinkButton ID="LBHome" runat="server" CssClass="pageBtn" 
 						            onclick="LBHome_Click">[首页]</asp:LinkButton>
 						        <asp:LinkButton ID="LBUp" runat="server" CssClass="pageBtn" 
 						            onclick="LBUp_Click">[上一页]</asp:LinkButton>
 						        <asp:LinkButton ID="LBNext" runat="server" CssClass="pageBtn"
 						            onclick="LBNext_Click">[下一页]</asp:LinkButton>
 						        <asp:LinkButton ID="LBEnd" runat="server" CssClass="pageBtn" 
 						            onclick="LBEnd_Click">[尾页]</asp:LinkButton>
 						        <asp:HiddenField ID="HSelectID" runat="server" Value=""/>
 						        <asp:HiddenField ID="HWhere" runat="server" Value=""/>
 						        <asp:HiddenField ID="HNowPage" runat="server" Value="1"/>
 						        <asp:HiddenField ID="HPageSize" runat="server" Value="8"/>
 						        <asp:HiddenField ID="HAllPage" runat="server" Value="0"/>
						</ul>
					</nav>
					<div class="pull-right" style="line-height:75px;" ><asp:Label runat="server" ID="PageMes"></asp:Label></div>
				</div>
			</div>
		</div>
	</div>

	<div class="col-md-3 wow fadeInRight">
		<div class="page-header">
    		<h1>商家查询</h1>
		</div>
			<div class="form-group">
				<label for="sellerUserName">商家用户名:</label>
				<asp:TextBox ID="sellerUserName" runat="server"  CssClass="form-control" placeholder="请输入商家用户名"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="sellerName">商家名称:</label>
				<asp:TextBox ID="sellerName" runat="server"  CssClass="form-control" placeholder="请输入商家名称"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="bornDate">成立日期:</label>
				<asp:TextBox ID="bornDate"  runat="server" CssClass="form-control" placeholder="请选择成立日期" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="telephone">商家电话:</label>
				<asp:TextBox ID="telephone" runat="server"  CssClass="form-control" placeholder="请输入商家电话"></asp:TextBox>
			</div>
            <div class="form-group">
            	<label for="areaObj_areaId">所在区域：</label>
                <asp:DropDownList ID="areaObj" runat="server"  CssClass="form-control" placeholder="请选择所在区域"></asp:DropDownList>
            </div>
        <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>
  </form>
</div>
<div id="sellerEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;商家信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="sellerEditForm" id="sellerEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="seller_sellerUserName_edit" class="col-md-3 text-right">商家用户名:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="seller_sellerUserName_edit" name="seller.sellerUserName" class="form-control" placeholder="请输入商家用户名" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="seller_password_edit" class="col-md-3 text-right">登录密码:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="seller_password_edit" name="seller.password" class="form-control" placeholder="请输入登录密码">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="seller_sellerName_edit" class="col-md-3 text-right">商家名称:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="seller_sellerName_edit" name="seller.sellerName" class="form-control" placeholder="请输入商家名称">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="seller_sellerPhoto_edit" class="col-md-3 text-right">商家照片:</label>
		  	 <div class="col-md-9">
			    <img  class="img-responsive" id="seller_sellerPhotoImg" border="0px"/><br/>
			    <input type="hidden" id="seller_sellerPhoto" name="seller.sellerPhoto"/>
			    <input id="sellerPhotoFile" name="sellerPhotoFile" type="file" size="50" />
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="seller_sellerDesc_edit" class="col-md-3 text-right">商家介绍:</label>
		  	 <div class="col-md-9">
			    <textarea id="seller_sellerDesc_edit" name="seller.sellerDesc" rows="8" class="form-control" placeholder="请输入商家介绍"></textarea>
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="seller_bornDate_edit" class="col-md-3 text-right">成立日期:</label>
		  	 <div class="col-md-9">
                <div class="input-group date seller_bornDate_edit col-md-12" data-link-field="seller_bornDate_edit" data-link-format="yyyy-mm-dd">
                    <input class="form-control" id="seller_bornDate_edit" name="seller.bornDate" size="16" type="text" value="" placeholder="请选择成立日期" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="seller_telephone_edit" class="col-md-3 text-right">商家电话:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="seller_telephone_edit" name="seller.telephone" class="form-control" placeholder="请输入商家电话">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="seller_email_edit" class="col-md-3 text-right">商家邮箱:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="seller_email_edit" name="seller.email" class="form-control" placeholder="请输入商家邮箱">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="seller_areaObj_areaId_edit" class="col-md-3 text-right">所在区域:</label>
		  	 <div class="col-md-9">
			    <select id="seller_areaObj_areaId_edit" name="seller.areaObj.areaId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="seller_address_edit" class="col-md-3 text-right">商家地址:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="seller_address_edit" name="seller.address" class="form-control" placeholder="请输入商家地址">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="seller_regTime_edit" class="col-md-3 text-right">注册时间:</label>
		  	 <div class="col-md-9">
                <div class="input-group date seller_regTime_edit col-md-12" data-link-field="seller_regTime_edit">
                    <input class="form-control" id="seller_regTime_edit" name="seller.regTime" size="16" type="text" value="" placeholder="请选择注册时间" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		</form> 
	    <style>#sellerEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxSellerModify();">提交</button>
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->
<uc:footer ID="footer" runat="server" />
<script src="<%=basePath %>plugins/jquery.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap.js"></script>
<script src="<%=basePath %>plugins/wow.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap-datetimepicker.min.js"></script>
<script src="<%=basePath %>plugins/locales/bootstrap-datetimepicker.zh-CN.js"></script>
<script type="text/javascript" src="<%=basePath %>js/jsdate.js"></script>
<script>
var basePath = "<%=basePath%>";
/*弹出修改商家界面并初始化数据*/
function sellerEdit(sellerUserName) {
	$.ajax({
		url :  basePath + "Seller/SellerController.aspx?action=getSeller&sellerUserName=" + sellerUserName,
		type : "get",
		dataType: "json",
		success : function (seller, response, status) {
			if (seller) {
				$("#seller_sellerUserName_edit").val(seller.sellerUserName);
				$("#seller_password_edit").val(seller.password);
				$("#seller_sellerName_edit").val(seller.sellerName);
				$("#seller_sellerPhoto").val(seller.sellerPhoto);
				$("#seller_sellerPhotoImg").attr("src", basePath +　seller.sellerPhoto);
				$("#seller_sellerDesc_edit").val(seller.sellerDesc);
				$("#seller_bornDate_edit").val(seller.bornDate);
				$("#seller_telephone_edit").val(seller.telephone);
				$("#seller_email_edit").val(seller.email);
				$.ajax({
					url: basePath + "Area/AreaController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(areas,response,status) { 
						$("#seller_areaObj_areaId_edit").empty();
						var html="";
		        		$(areas).each(function(i,area){
		        			html += "<option value='" + area.areaId + "'>" + area.areaName + "</option>";
		        		});
		        		$("#seller_areaObj_areaId_edit").html(html);
		        		$("#seller_areaObj_areaId_edit").val(seller.areaObjPri);
					}
				});
				$("#seller_address_edit").val(seller.address);
				$("#seller_regTime_edit").val(seller.regTime);
				$('#sellerEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除商家信息*/
function sellerDelete(sellerUserName) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "Seller/SellerController.aspx?action=delete",
			data : {
				sellerUserName : sellerUserName,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
                    $("#btnSearch").click();
					//location.href= basePath + "Seller/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交商家信息表单给服务器端修改*/
function ajaxSellerModify() {
	$.ajax({
		url :  basePath + "Seller/SellerController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#sellerEditForm")[0]),
		success : function (obj, response, status) {
            if(obj.success){
                alert("信息修改成功！");
                $("#btnSearch").click();
            }else{
                alert(obj.message);
            } 
		},
		processData: false,
		contentType: false,
	});
}

$(function(){
	/*小屏幕导航点击关闭菜单*/
    $('.navbar-collapse a').click(function(){
        $('.navbar-collapse').collapse('hide');
    });
    new WOW().init();

    /*成立日期组件*/
    $('.seller_bornDate_edit').datetimepicker({
    	language:  'zh-CN',  //语言
    	format: 'yyyy-mm-dd',
    	minView: 2,
    	weekStart: 1,
    	todayBtn:  1,
    	autoclose: 1,
    	minuteStep: 1,
    	todayHighlight: 1,
    	startView: 2,
    	forceParse: 0
    });
    /*注册时间组件*/
    $('.seller_regTime_edit').datetimepicker({
    	language:  'zh-CN',  //语言
    	format: 'yyyy-mm-dd hh:ii:ss',
    	weekStart: 1,
    	todayBtn:  1,
    	autoclose: 1,
    	minuteStep: 1,
    	todayHighlight: 1,
    	startView: 2,
    	forceParse: 0
    });
})
</script>
</body>
</html>

