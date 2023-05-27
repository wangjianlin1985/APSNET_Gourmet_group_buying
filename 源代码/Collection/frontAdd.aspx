<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontAdd.aspx.cs" Inherits="Collection_frontAdd" %>
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
<title>商品收藏添加</title>
<link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
<link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
<link href="<%=basePath %>plugins/animate.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
</head>
<body style="margin-top:70px;">
<div class="container">
<uc:header ID="header" runat="server" />
	<div class="col-md-12 wow fadeInLeft">
		<ul class="breadcrumb">
  			<li><a href="<%=basePath %>index.aspx">首页</a></li>
  			<li><a href="<%=basePath %>Collection/frontList.aspx">商品收藏管理</a></li>
  			<li class="active">添加商品收藏</li>
		</ul>
		<div class="row">
			<div class="col-md-10">
		      	<form class="form-horizontal" name="collectionAddForm" id="collectionAddForm" enctype="multipart/form-data" method="post"  class="mar_t15">
				  <div class="form-group">
				  	 <label for="collection_productObj_productId" class="col-md-2 text-right">被收藏商品:</label>
				  	 <div class="col-md-8">
					    <select id="collection_productObj_productId" name="collection.productObj.productId" class="form-control">
					    </select>
				  	 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="collection_userObj_user_name" class="col-md-2 text-right">收藏用户:</label>
				  	 <div class="col-md-8">
					    <select id="collection_userObj_user_name" name="collection.userObj.user_name" class="form-control">
					    </select>
				  	 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="collection_collectionTimeDiv" class="col-md-2 text-right">收藏时间:</label>
				  	 <div class="col-md-8">
		                <div id="collection_collectionTimeDiv" class="input-group date collection_collectionTime col-md-12" data-link-field="collection_collectionTime">
		                    <input class="form-control" id="collection_collectionTime" name="collection.collectionTime" size="16" type="text" value="" placeholder="请选择收藏时间" readonly>
		                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
		                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
		                </div>
				  	 </div>
				  </div>
		          <div class="form-group">
		             <span class="col-md-2""></span>
		             <span onclick="ajaxCollectionAdd();" class="btn btn-primary bottom5 top5">添加</span>
		          </div> 
		          <style>#collectionAddForm .form-group {margin:5px;}  </style>  
				</form> 
			</div>
			<div class="col-md-2"></div> 
	    </div>
	</div>
</div>
<uc:footer ID="footer" runat="server" />
<script src="<%=basePath %>plugins/jquery.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap.js"></script>
<script src="<%=basePath %>plugins/wow.min.js"></script>
<script src="<%=basePath %>plugins/bootstrapvalidator/js/bootstrapValidator.min.js"></script>
<script type="text/javascript" src="<%=basePath %>plugins/bootstrap-datetimepicker.min.js" charset="UTF-8"></script>
<script type="text/javascript" src="<%=basePath %>plugins/locales/bootstrap-datetimepicker.zh-CN.js" charset="UTF-8"></script>
<script>
var basePath = "<%=basePath%>";
	//提交添加商品收藏信息
	function ajaxCollectionAdd() { 
		//提交之前先验证表单
		$("#collectionAddForm").data('bootstrapValidator').validate();
		if(!$("#collectionAddForm").data('bootstrapValidator').isValid()){
			return;
		}
		jQuery.ajax({
			type : "post",
			url : basePath + "Collection/CollectionController.aspx?action=add",
			dataType : "json" , 
			data: new FormData($("#collectionAddForm")[0]),
			success : function(obj) {
				if(obj.success){ 
					alert("保存成功！");
					$("#collectionAddForm").find("input").val("");
					$("#collectionAddForm").find("textarea").val("");
				} else {
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
	//验证商品收藏添加表单字段
	$('#collectionAddForm').bootstrapValidator({
		feedbackIcons: {
			valid: 'glyphicon glyphicon-ok',
			invalid: 'glyphicon glyphicon-remove',
			validating: 'glyphicon glyphicon-refresh'
		},
		fields: {
			"collection.collectionTime": {
				validators: {
					notEmpty: {
						message: "收藏时间不能为空",
					}
				}
			},
		}
	}); 
	//初始化被收藏商品下拉框值 
	$.ajax({
		url: basePath + "Product/ProductController.aspx?action=listAll",
		type: "get",
		dataType: "json",
		success: function(products,response,status) { 
			$("#collection_productObj_productId").empty();
			var html="";
    		$(products).each(function(i,product){
    			html += "<option value='" + product.productId + "'>" + product.productName + "</option>";
    		});
    		$("#collection_productObj_productId").html(html);
    	}
	});
	//初始化收藏用户下拉框值 
	$.ajax({
		url: basePath + "UserInfo/UserInfoController.aspx?action=listAll",
		type: "get",
		dataType: "json",
		success: function(userInfos,response,status) { 
			$("#collection_userObj_user_name").empty();
			var html="";
    		$(userInfos).each(function(i,userInfo){
    			html += "<option value='" + userInfo.user_name + "'>" + userInfo.name + "</option>";
    		});
    		$("#collection_userObj_user_name").html(html);
    	}
	});
	//收藏时间组件
	$('#collection_collectionTimeDiv').datetimepicker({
		language:  'zh-CN',  //显示语言
		format: 'yyyy-mm-dd hh:ii:ss',
		weekStart: 1,
		todayBtn:  1,
		autoclose: 1,
		minuteStep: 1,
		todayHighlight: 1,
		startView: 2,
		forceParse: 0
	}).on('hide',function(e) {
		//下面这行代码解决日期组件改变日期后不验证的问题
		$('#collectionAddForm').data('bootstrapValidator').updateStatus('collection.collectionTime', 'NOT_VALIDATED',null).validateField('collection.collectionTime');
	});
})
</script>
</body>
</html>
