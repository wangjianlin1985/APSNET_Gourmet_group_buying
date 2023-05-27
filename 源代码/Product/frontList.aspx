<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="Product_frontList" %>
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
<title>商品查询</title>
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
  			<li><a href="frontList.aspx">商品信息列表</a></li>
  			<li class="active">查询结果显示</li>
  			<a class="pull-right" href="frontAdd.aspx" style="display:none;">添加商品</a>
		</ul>
		<div class="row">
			<asp:Repeater ID="RpProduct" runat="server">
			<ItemTemplate>
			<div class="col-md-3 bottom15" <%#(((Container.ItemIndex+0)%4==0)?"style='clear:left;'":"") %>>
			  <a href="frontshow.aspx?productId=<%#Eval("productId")%>"><img class="img-responsive" src="../<%#Eval("mainPhoto")%>" /></a>
			     <div class="showFields">
			     	<div class="field">
	            		商品id: <%#Eval("productId")%>
			     	</div>
			     	<div class="field">
	            		商品类别:<%#GetProductClassproductClassObj(Eval("productClassObj").ToString())%>
			     	</div>
			     	<div class="field">
	            		商品名称: <%#Eval("productName")%>
			     	</div>
			     	<div class="field">
	            		商品价格: <%#Eval("price")%>
			     	</div>
			     	<div class="field">
	            		商品库存: <%#Eval("productCount")%>
			     	</div>
			     	<div class="field">
	            		发布的商家:<%#GetSellersellerObj(Eval("sellerObj").ToString())%>
			     	</div>
			     	<div class="field">
	            		所在区域:<%#GetAreaareaObj(Eval("areaObj").ToString())%>
			     	</div>
			     	<div class="field">
	            		发布时间: <%#Eval("addTime")%>
			     	</div>
			        <a class="btn btn-primary top5" href="frontShow.aspx?productId=<%#Eval("productId")%>">详情</a>
			        <a class="btn btn-primary top5" onclick="productEdit('<%#Eval("productId")%>');" style="display:none;">修改</a>
			        <a class="btn btn-primary top5" onclick="productDelete('<%#Eval("productId")%>');" style="display:none;">删除</a>
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
    		<h1>商品查询</h1>
		</div>
            <div class="form-group">
            	<label for="productClassObj_classId">商品类别：</label>
                <asp:DropDownList ID="productClassObj" runat="server"  CssClass="form-control" placeholder="请选择商品类别"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="productName">商品名称:</label>
				<asp:TextBox ID="productName" runat="server"  CssClass="form-control" placeholder="请输入商品名称"></asp:TextBox>
			</div>
            <div class="form-group">
            	<label for="sellerObj_sellerUserName">发布的商家：</label>
                <asp:DropDownList ID="sellerObj" runat="server"  CssClass="form-control" placeholder="请选择发布的商家"></asp:DropDownList>
            </div>
            <div class="form-group">
            	<label for="areaObj_areaId">所在区域：</label>
                <asp:DropDownList ID="areaObj" runat="server"  CssClass="form-control" placeholder="请选择所在区域"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="addTime">发布时间:</label>
				<asp:TextBox ID="addTime"  runat="server" CssClass="form-control" placeholder="请选择发布时间" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
        <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>
  </form>
</div>
<div id="productEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;商品信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="productEditForm" id="productEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="product_productId_edit" class="col-md-3 text-right">商品id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="product_productId_edit" name="product.productId" class="form-control" placeholder="请输入商品id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="product_productClassObj_classId_edit" class="col-md-3 text-right">商品类别:</label>
		  	 <div class="col-md-9">
			    <select id="product_productClassObj_classId_edit" name="product.productClassObj.classId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="product_productName_edit" class="col-md-3 text-right">商品名称:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="product_productName_edit" name="product.productName" class="form-control" placeholder="请输入商品名称">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="product_mainPhoto_edit" class="col-md-3 text-right">商品主图:</label>
		  	 <div class="col-md-9">
			    <img  class="img-responsive" id="product_mainPhotoImg" border="0px"/><br/>
			    <input type="hidden" id="product_mainPhoto" name="product.mainPhoto"/>
			    <input id="mainPhotoFile" name="mainPhotoFile" type="file" size="50" />
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="product_price_edit" class="col-md-3 text-right">商品价格:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="product_price_edit" name="product.price" class="form-control" placeholder="请输入商品价格">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="product_productCount_edit" class="col-md-3 text-right">商品库存:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="product_productCount_edit" name="product.productCount" class="form-control" placeholder="请输入商品库存">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="product_productDesc_edit" class="col-md-3 text-right">商品描述:</label>
		  	 <div class="col-md-9">
			    <textarea id="product_productDesc_edit" name="product.productDesc" rows="8" class="form-control" placeholder="请输入商品描述"></textarea>
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="product_sellerObj_sellerUserName_edit" class="col-md-3 text-right">发布的商家:</label>
		  	 <div class="col-md-9">
			    <select id="product_sellerObj_sellerUserName_edit" name="product.sellerObj.sellerUserName" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="product_areaObj_areaId_edit" class="col-md-3 text-right">所在区域:</label>
		  	 <div class="col-md-9">
			    <select id="product_areaObj_areaId_edit" name="product.areaObj.areaId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="product_addTime_edit" class="col-md-3 text-right">发布时间:</label>
		  	 <div class="col-md-9">
                <div class="input-group date product_addTime_edit col-md-12" data-link-field="product_addTime_edit">
                    <input class="form-control" id="product_addTime_edit" name="product.addTime" size="16" type="text" value="" placeholder="请选择发布时间" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		</form> 
	    <style>#productEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxProductModify();">提交</button>
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
/*弹出修改商品界面并初始化数据*/
function productEdit(productId) {
	$.ajax({
		url :  basePath + "Product/ProductController.aspx?action=getProduct&productId=" + productId,
		type : "get",
		dataType: "json",
		success : function (product, response, status) {
			if (product) {
				$("#product_productId_edit").val(product.productId);
				$.ajax({
					url: basePath + "ProductClass/ProductClassController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(productClasss,response,status) { 
						$("#product_productClassObj_classId_edit").empty();
						var html="";
		        		$(productClasss).each(function(i,productClass){
		        			html += "<option value='" + productClass.classId + "'>" + productClass.className + "</option>";
		        		});
		        		$("#product_productClassObj_classId_edit").html(html);
		        		$("#product_productClassObj_classId_edit").val(product.productClassObjPri);
					}
				});
				$("#product_productName_edit").val(product.productName);
				$("#product_mainPhoto").val(product.mainPhoto);
				$("#product_mainPhotoImg").attr("src", basePath +　product.mainPhoto);
				$("#product_price_edit").val(product.price);
				$("#product_productCount_edit").val(product.productCount);
				$("#product_productDesc_edit").val(product.productDesc);
				$.ajax({
					url: basePath + "Seller/SellerController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(sellers,response,status) { 
						$("#product_sellerObj_sellerUserName_edit").empty();
						var html="";
		        		$(sellers).each(function(i,seller){
		        			html += "<option value='" + seller.sellerUserName + "'>" + seller.sellerName + "</option>";
		        		});
		        		$("#product_sellerObj_sellerUserName_edit").html(html);
		        		$("#product_sellerObj_sellerUserName_edit").val(product.sellerObjPri);
					}
				});
				$.ajax({
					url: basePath + "Area/AreaController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(areas,response,status) { 
						$("#product_areaObj_areaId_edit").empty();
						var html="";
		        		$(areas).each(function(i,area){
		        			html += "<option value='" + area.areaId + "'>" + area.areaName + "</option>";
		        		});
		        		$("#product_areaObj_areaId_edit").html(html);
		        		$("#product_areaObj_areaId_edit").val(product.areaObjPri);
					}
				});
				$("#product_addTime_edit").val(product.addTime);
				$('#productEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除商品信息*/
function productDelete(productId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "Product/ProductController.aspx?action=delete",
			data : {
				productId : productId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
                    $("#btnSearch").click();
					//location.href= basePath + "Product/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交商品信息表单给服务器端修改*/
function ajaxProductModify() {
	$.ajax({
		url :  basePath + "Product/ProductController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#productEditForm")[0]),
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

    /*发布时间组件*/
    $('.product_addTime_edit').datetimepicker({
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

