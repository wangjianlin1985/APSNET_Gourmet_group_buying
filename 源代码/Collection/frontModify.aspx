<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontModify.aspx.cs" Inherits="Collection_frontModify" %>
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
  <TITLE>修改商品收藏信息</TITLE>
  <link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/animate.css" rel="stylesheet"> 
</head>
<body style="margin-top:70px;"> 
<div class="container">
<uc:header ID="header" runat="server" />
	<div class="col-md-9 wow fadeInLeft">
	<ul class="breadcrumb">
  		<li><a href="<%=basePath %>index.aspx">首页</a></li>
  		<li class="active">商品收藏信息修改</li>
	</ul>
		<div class="row"> 
      	<form class="form-horizontal" name="collectionEditForm" id="collectionEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="collection_collectionId_edit" class="col-md-3 text-right">收藏id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="collection_collectionId_edit" name="collection.collectionId" class="form-control" placeholder="请输入收藏id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="collection_productObj_productId_edit" class="col-md-3 text-right">被收藏商品:</label>
		  	 <div class="col-md-9">
			    <select id="collection_productObj_productId_edit" name="collection.productObj.productId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="collection_userObj_user_name_edit" class="col-md-3 text-right">收藏用户:</label>
		  	 <div class="col-md-9">
			    <select id="collection_userObj_user_name_edit" name="collection.userObj.user_name" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="collection_collectionTime_edit" class="col-md-3 text-right">收藏时间:</label>
		  	 <div class="col-md-9">
                <div class="input-group date collection_collectionTime_edit col-md-12" data-link-field="collection_collectionTime_edit">
                    <input class="form-control" id="collection_collectionTime_edit" name="collection.collectionTime" size="16" type="text" value="" placeholder="请选择收藏时间" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
			  <div class="form-group">
			  	<span class="col-md-3""></span>
			  	<span onclick="ajaxCollectionModify();" class="btn btn-primary bottom5 top5">修改</span>
			  </div>
		</form> 
	    <style>#collectionEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
   </div>
</div>


<uc:footer ID="footer" runat="server" />
<script src="<%=basePath %>plugins/jquery.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap.js"></script>
<script src="<%=basePath %>plugins/wow.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap-datetimepicker.min.js"></script>
<script src="<%=basePath %>plugins/locales/bootstrap-datetimepicker.zh-CN.js"></script>
<script type="text/javascript" src="<%=basePath %>js/jsdate.js"></script>
<script>
var basePath = "<%=basePath%>";
/*弹出修改商品收藏界面并初始化数据*/
function collectionEdit(collectionId) {
	$.ajax({
		url :  basePath + "Collection/CollectionController.aspx?action=getCollection&collectionId=" + collectionId,
		type : "get",
		dataType: "json",
		success : function (collection, response, status) {
			if (collection) {
				$("#collection_collectionId_edit").val(collection.collectionId);
				$.ajax({
					url: basePath + "Product/ProductController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(products,response,status) { 
						$("#collection_productObj_productId_edit").empty();
						var html="";
		        		$(products).each(function(i,product){
		        			html += "<option value='" + product.productId + "'>" + product.productName + "</option>";
		        		});
		        		$("#collection_productObj_productId_edit").html(html);
		        		$("#collection_productObj_productId_edit").val(collection.productObjPri);
					}
				});
				$.ajax({
					url: basePath + "UserInfo/UserInfoController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(userInfos,response,status) { 
						$("#collection_userObj_user_name_edit").empty();
						var html="";
		        		$(userInfos).each(function(i,userInfo){
		        			html += "<option value='" + userInfo.user_name + "'>" + userInfo.name + "</option>";
		        		});
		        		$("#collection_userObj_user_name_edit").html(html);
		        		$("#collection_userObj_user_name_edit").val(collection.userObjPri);
					}
				});
				$("#collection_collectionTime_edit").val(collection.collectionTime);
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*ajax方式提交商品收藏信息表单给服务器端修改*/
function ajaxCollectionModify() {
	$.ajax({
		url :  basePath + "Collection/CollectionController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#collectionEditForm")[0]),
		success : function (obj, response, status) {
            if(obj.success){
                alert("信息修改成功！");
                location.reload(true);
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
    /*收藏时间组件*/
    $('.collection_collectionTime_edit').datetimepicker({
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
    collectionEdit('<%=Request["collectionId"] %>');
 })
 </script> 
</body>
</html>

