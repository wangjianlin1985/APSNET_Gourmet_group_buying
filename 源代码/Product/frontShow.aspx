﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontShow.aspx.cs" Inherits="Product_frontShow" %>
<%@ Register Src="../header.ascx" TagName="header" TagPrefix="uc" %>
<%@ Register Src="../footer.ascx" TagName="footer" TagPrefix="uc" %>
<%
    String path = Request.ApplicationPath;
    String basePath = path + "/";
    ENTITY.Product product = BLL.bllProduct.getSomeProduct(int.Parse(Request.QueryString["productId"]));
    System.Data.DataSet commentDs = BLL.bllProductComment.GetProductComment(" where productObj=" + product.productId);
%>
<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1 , user-scalable=no">
  <TITLE>查看商品详情</TITLE>
  <link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/animate.css" rel="stylesheet"> 
</head>
<body style="margin-top:70px;"> 
<uc:header ID="header" runat="server" />
<div class="container">
	<ul class="breadcrumb">
  		<li><a href="<%=basePath %>index.aspx">首页</a></li>
  		<li><a href="<%=basePath %>Product/frontList.aspx">商品信息</a></li>
  		<li class="active">详情查看</li>
	</ul>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">商品id:</div>
		<div class="col-md-10 col-xs-6"><%=product.productId%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">商品类别:</div>
		<div class="col-md-10 col-xs-6"><%=BLL.bllProductClass.getSomeProductClass(product.productClassObj).className %></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">商品名称:</div>
		<div class="col-md-10 col-xs-6"><%=product.productName%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">商品主图:</div>
		<div class="col-md-10 col-xs-6"><img class="img-responsive" src="<%=basePath %><%=product.mainPhoto %>"  border="0px"/></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">商品价格:</div>
		<div class="col-md-10 col-xs-6"><%=product.price%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">商品库存:</div>
		<div class="col-md-10 col-xs-6"><%=product.productCount%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">商品描述:</div>
		<div class="col-md-10 col-xs-6"><%=product.productDesc%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">发布的商家:</div>
		<div class="col-md-10 col-xs-6"><%=BLL.bllSeller.getSomeSeller(product.sellerObj).sellerName %></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">所在区域:</div>
		<div class="col-md-10 col-xs-6"><%=BLL.bllArea.getSomeArea(product.areaObj).areaName %></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">发布时间:</div>
		<div class="col-md-10 col-xs-6"><%=product.addTime%></div>
	</div>

    <div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">回复内容:</div>
		<div class="col-md-10 col-xs-6">
			<textarea id="content" style="width:100%" rows=8></textarea>
		</div>
	</div>

	<div class="row bottom15">
		<div class="col-md-2 col-xs-4"></div>
		<div class="col-md-6 col-xs-6">
			<button onclick="userReply();" class="btn btn-primary">发布评论</button>
            <button onclick="userCollect();" class="btn btn-primary">我要收藏</button>
            <button onclick="userBuy();" class="btn btn-primary" style="color:pink;font-weight:bold;">我要团购</button>
            <button onclick="history.back();" class="btn btn-info">返回</button>
		</div>
	</div>

 

    <div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold"></div>
		<div class="col-md-8 col-xs-7">
			<% for (int i = 0; i < commentDs.Tables[0].Rows.Count; i++)
      {
          System.Data.DataRow answerRow = commentDs.Tables[0].Rows[i];
                ENTITY.UserInfo userInfo = BLL.bllUserInfo.getSomeUserInfo(answerRow["userObj"].ToString());
			%>
			<div class="row" style="margin-top: 20px;">
				<div class="col-md-2 col-xs-3">
					<div class="row text-center"><img src="<%=basePath %><%=userInfo.userPhoto %>" style="border: none;width:60px;height:60px;border-radius: 50%;" /></div>
					<div class="row text-center" style="margin: 5px 0px;"><%=userInfo.user_name %></div>
				</div>
				<div class="col-md-7 col-xs-5"><%=answerRow["content"].ToString()%></div>
				<div class="col-md-3 col-xs-4" ><%=answerRow["commentTime"].ToString()%></div>
			</div>
		
			<% } %> 
		</div>
	</div>


</div> 
<uc:footer ID="footer" runat="server" />
<script src="<%=basePath %>plugins/jquery.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap.js"></script>
<script src="<%=basePath %>plugins/wow.min.js"></script>
<script>
    var basePath = "<%=basePath%>";


function userReply() {
	var content = $("#content").val();
	if(content == "") {
		alert("请输入回复内容");
		return;
	}

	$.ajax({
		url : basePath + "ProductComment/ProductCommentController.aspx?action=userAdd",
		type : "post",
		dataType: "json",
		data: {
			"productComment.productObj.productId": <%=product.productId %>,
			"productComment.content": content
		},
		success : function (data, response, status) {
			//var obj = jQuery.parseJSON(data);
			if(data.success){
				alert("评论成功~");
				location.reload();
			}else{
				alert(data.message);
			}
		}
	});
}



function userCollect() {
    $.ajax({
		url : basePath + "Collection/CollectionController.aspx?action=userAdd",
		type : "post",
		dataType: "json",
		data: {
			"collection.productObj.productId": <%=product.productId %>, 
		},
		success : function (data, response, status) {
			//var obj = jQuery.parseJSON(data);
			if(data.success){
				alert("收藏成功~");
				location.reload();
			}else{
				alert(data.message);
			}
		}
	});
}

function userBuy() {

    location.href = basePath + "OrderInfo/frontUserAdd.aspx?productId=<%=product.productId %>";
}

$(function(){
        /*小屏幕导航点击关闭菜单*/
        $('.navbar-collapse a').click(function(){
            $('.navbar-collapse').collapse('hide');
        });
        new WOW().init();
 })
 </script> 
</body>
</html>

