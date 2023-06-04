<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="ProductSell_frontList" %>
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
<title>商品出售查询</title>
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
  			<li><a href="frontList.aspx">商品出售信息列表</a></li>
  			<li class="active">查询结果显示</li>
  			<a class="pull-right" href="frontAdd.aspx" style="display:none;">添加商品出售</a>
		</ul>
		<div class="row">
			<asp:Repeater ID="RpProductSell" runat="server">
			<ItemTemplate>
			<div class="col-md-3 bottom15" <%#(((Container.ItemIndex+0)%4==0)?"style='clear:left;'":"") %>>
			  <a href="frontshow.aspx?sellId=<%#Eval("sellId")%>"><img class="img-responsive" src="../<%#Eval("productPhoto")%>" /></a>
			     <div class="showFields">
			     	<div class="field">
	            		出售id: <%#Eval("sellId")%>
			     	</div>
			     	<div class="field">
	            		商品名称: <%#Eval("productName")%>
			     	</div>
			     	<div class="field">
	            		商品分类:<%#GetProductClassproductClassObj(Eval("productClassObj").ToString())%>
			     	</div>
			     	<div class="field">
	            		出售价格: <%#Eval("sellPrice")%>
			     	</div>
			     	<div class="field">
	            		新旧程度:<%#GetXjcdxjcdObj(Eval("xjcdObj").ToString())%>
			     	</div>
			     	<div class="field">
	            		出售说明: <%#Eval("sellDesc")%>
			     	</div>
			     	<div class="field">
	            		发布用户:<%#GetUserInfouserObj(Eval("userObj").ToString())%>
			     	</div>
			     	<div class="field">
	            		发布时间: <%#Eval("addTime")%>
			     	</div>
			        <a class="btn btn-primary top5" href="frontShow.aspx?sellId=<%#Eval("sellId")%>">详情</a>
			        <a class="btn btn-primary top5" onclick="productSellEdit('<%#Eval("sellId")%>');" style="display:none;">修改</a>
			        <a class="btn btn-primary top5" onclick="productSellDelete('<%#Eval("sellId")%>');" style="display:none;">删除</a>
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
    		<h1>商品出售查询</h1>
		</div>
			<div class="form-group">
				<label for="productName">商品名称:</label>
				<asp:TextBox ID="productName" runat="server"  CssClass="form-control" placeholder="请输入商品名称"></asp:TextBox>
			</div>
            <div class="form-group">
            	<label for="productClassObj_productClassId">商品分类：</label>
                <asp:DropDownList ID="productClassObj" runat="server"  CssClass="form-control" placeholder="请选择商品分类"></asp:DropDownList>
            </div>
            <div class="form-group">
            	<label for="xjcdObj_xjcdId">新旧程度：</label>
                <asp:DropDownList ID="xjcdObj" runat="server"  CssClass="form-control" placeholder="请选择新旧程度"></asp:DropDownList>
            </div>
            <div class="form-group">
            	<label for="userObj_user_name">发布用户：</label>
                <asp:DropDownList ID="userObj" runat="server"  CssClass="form-control" placeholder="请选择发布用户"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="addTime">发布时间:</label>
				<asp:TextBox ID="addTime"  runat="server" CssClass="form-control" placeholder="请选择发布时间" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
        <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>
  </form>
</div>
<div id="productSellEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;商品出售信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="productSellEditForm" id="productSellEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="productSell_sellId_edit" class="col-md-3 text-right">出售id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="productSell_sellId_edit" name="productSell.sellId" class="form-control" placeholder="请输入出售id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="productSell_productName_edit" class="col-md-3 text-right">商品名称:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="productSell_productName_edit" name="productSell.productName" class="form-control" placeholder="请输入商品名称">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="productSell_productClassObj_productClassId_edit" class="col-md-3 text-right">商品分类:</label>
		  	 <div class="col-md-9">
			    <select id="productSell_productClassObj_productClassId_edit" name="productSell.productClassObj.productClassId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="productSell_productPhoto_edit" class="col-md-3 text-right">图书主图:</label>
		  	 <div class="col-md-9">
			    <img  class="img-responsive" id="productSell_productPhotoImg" border="0px"/><br/>
			    <input type="hidden" id="productSell_productPhoto" name="productSell.productPhoto"/>
			    <input id="productPhotoFile" name="productPhotoFile" type="file" size="50" />
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="productSell_sellPrice_edit" class="col-md-3 text-right">出售价格:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="productSell_sellPrice_edit" name="productSell.sellPrice" class="form-control" placeholder="请输入出售价格">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="productSell_xjcdObj_xjcdId_edit" class="col-md-3 text-right">新旧程度:</label>
		  	 <div class="col-md-9">
			    <select id="productSell_xjcdObj_xjcdId_edit" name="productSell.xjcdObj.xjcdId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="productSell_sellDesc_edit" class="col-md-3 text-right">出售说明:</label>
		  	 <div class="col-md-9">
			    <textarea id="productSell_sellDesc_edit" name="productSell.sellDesc" rows="8" class="form-control" placeholder="请输入出售说明"></textarea>
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="productSell_userObj_user_name_edit" class="col-md-3 text-right">发布用户:</label>
		  	 <div class="col-md-9">
			    <select id="productSell_userObj_user_name_edit" name="productSell.userObj.user_name" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="productSell_addTime_edit" class="col-md-3 text-right">发布时间:</label>
		  	 <div class="col-md-9">
                <div class="input-group date productSell_addTime_edit col-md-12" data-link-field="productSell_addTime_edit">
                    <input class="form-control" id="productSell_addTime_edit" name="productSell.addTime" size="16" type="text" value="" placeholder="请选择发布时间" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		</form> 
	    <style>#productSellEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxProductSellModify();">提交</button>
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
/*弹出修改商品出售界面并初始化数据*/
function productSellEdit(sellId) {
	$.ajax({
		url :  basePath + "ProductSell/ProductSellController.aspx?action=getProductSell&sellId=" + sellId,
		type : "get",
		dataType: "json",
		success : function (productSell, response, status) {
			if (productSell) {
				$("#productSell_sellId_edit").val(productSell.sellId);
				$("#productSell_productName_edit").val(productSell.productName);
				$.ajax({
					url: basePath + "ProductClass/ProductClassController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(productClasss,response,status) { 
						$("#productSell_productClassObj_productClassId_edit").empty();
						var html="";
		        		$(productClasss).each(function(i,productClass){
		        			html += "<option value='" + productClass.productClassId + "'>" + productClass.productClassName + "</option>";
		        		});
		        		$("#productSell_productClassObj_productClassId_edit").html(html);
		        		$("#productSell_productClassObj_productClassId_edit").val(productSell.productClassObjPri);
					}
				});
				$("#productSell_productPhoto").val(productSell.productPhoto);
				$("#productSell_productPhotoImg").attr("src", basePath +　productSell.productPhoto);
				$("#productSell_sellPrice_edit").val(productSell.sellPrice);
				$.ajax({
					url: basePath + "Xjcd/XjcdController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(xjcds,response,status) { 
						$("#productSell_xjcdObj_xjcdId_edit").empty();
						var html="";
		        		$(xjcds).each(function(i,xjcd){
		        			html += "<option value='" + xjcd.xjcdId + "'>" + xjcd.xjcdName + "</option>";
		        		});
		        		$("#productSell_xjcdObj_xjcdId_edit").html(html);
		        		$("#productSell_xjcdObj_xjcdId_edit").val(productSell.xjcdObjPri);
					}
				});
				$("#productSell_sellDesc_edit").val(productSell.sellDesc);
				$.ajax({
					url: basePath + "UserInfo/UserInfoController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(userInfos,response,status) { 
						$("#productSell_userObj_user_name_edit").empty();
						var html="";
		        		$(userInfos).each(function(i,userInfo){
		        			html += "<option value='" + userInfo.user_name + "'>" + userInfo.name + "</option>";
		        		});
		        		$("#productSell_userObj_user_name_edit").html(html);
		        		$("#productSell_userObj_user_name_edit").val(productSell.userObjPri);
					}
				});
				$("#productSell_addTime_edit").val(productSell.addTime);
				$('#productSellEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除商品出售信息*/
function productSellDelete(sellId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "ProductSell/ProductSellController.aspx?action=delete",
			data : {
				sellId : sellId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
                    $("#btnSearch").click();
					//location.href= basePath + "ProductSell/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交商品出售信息表单给服务器端修改*/
function ajaxProductSellModify() {
	$.ajax({
		url :  basePath + "ProductSell/ProductSellController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#productSellEditForm")[0]),
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
    $('.productSell_addTime_edit').datetimepicker({
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

