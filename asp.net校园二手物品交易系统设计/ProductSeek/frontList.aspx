<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="ProductSeek_frontList" %>
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
<title>商品求购查询</title>
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
  			<li><a href="frontList.aspx">商品求购信息列表</a></li>
  			<li class="active">查询结果显示</li>
  			<a class="pull-right" href="frontAdd.aspx" style="display:none;">添加商品求购</a>
		</ul>
		<div class="row">
			<asp:Repeater ID="RpProductSeek" runat="server">
			<ItemTemplate>
			<div class="col-md-3 bottom15" <%#(((Container.ItemIndex+0)%4==0)?"style='clear:left;'":"") %>>
			  <a href="frontshow.aspx?seekId=<%#Eval("seekId")%>"><img class="img-responsive" src="../<%#Eval("productPhoto")%>" /></a>
			     <div class="showFields">
			     	<div class="field">
	            		求购id: <%#Eval("seekId")%>
			     	</div>
			     	<div class="field">
	            		商品名称: <%#Eval("productName")%>
			     	</div>
			     	<div class="field">
	            		商品类别:<%#GetProductClassproductClassObj(Eval("productClassObj").ToString())%>
			     	</div>
			     	<div class="field">
	            		求购价格: <%#Eval("price")%>
			     	</div>
			     	<div class="field">
	            		新旧程度:<%#GetXjcdxjcdObj(Eval("xjcdObj").ToString())%>
			     	</div>
			     	<div class="field">
	            		发布用户:<%#GetUserInfouserObj(Eval("userObj").ToString())%>
			     	</div>
			     	<div class="field">
	            		发布时间: <%#Eval("addTime")%>
			     	</div>
			        <a class="btn btn-primary top5" href="frontShow.aspx?seekId=<%#Eval("seekId")%>">详情</a>
			        <a class="btn btn-primary top5" onclick="productSeekEdit('<%#Eval("seekId")%>');" style="display:none;">修改</a>
			        <a class="btn btn-primary top5" onclick="productSeekDelete('<%#Eval("seekId")%>');" style="display:none;">删除</a>
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
    		<h1>商品求购查询</h1>
		</div>
			<div class="form-group">
				<label for="productName">商品名称:</label>
				<asp:TextBox ID="productName" runat="server"  CssClass="form-control" placeholder="请输入商品名称"></asp:TextBox>
			</div>
            <div class="form-group">
            	<label for="productClassObj_productClassId">商品类别：</label>
                <asp:DropDownList ID="productClassObj" runat="server"  CssClass="form-control" placeholder="请选择商品类别"></asp:DropDownList>
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
<div id="productSeekEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;商品求购信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="productSeekEditForm" id="productSeekEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="productSeek_seekId_edit" class="col-md-3 text-right">求购id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="productSeek_seekId_edit" name="productSeek.seekId" class="form-control" placeholder="请输入求购id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="productSeek_productName_edit" class="col-md-3 text-right">商品名称:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="productSeek_productName_edit" name="productSeek.productName" class="form-control" placeholder="请输入商品名称">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="productSeek_productClassObj_productClassId_edit" class="col-md-3 text-right">商品类别:</label>
		  	 <div class="col-md-9">
			    <select id="productSeek_productClassObj_productClassId_edit" name="productSeek.productClassObj.productClassId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="productSeek_productPhoto_edit" class="col-md-3 text-right">商品主图:</label>
		  	 <div class="col-md-9">
			    <img  class="img-responsive" id="productSeek_productPhotoImg" border="0px"/><br/>
			    <input type="hidden" id="productSeek_productPhoto" name="productSeek.productPhoto"/>
			    <input id="productPhotoFile" name="productPhotoFile" type="file" size="50" />
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="productSeek_price_edit" class="col-md-3 text-right">求购价格:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="productSeek_price_edit" name="productSeek.price" class="form-control" placeholder="请输入求购价格">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="productSeek_xjcdObj_xjcdId_edit" class="col-md-3 text-right">新旧程度:</label>
		  	 <div class="col-md-9">
			    <select id="productSeek_xjcdObj_xjcdId_edit" name="productSeek.xjcdObj.xjcdId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="productSeek_seekDesc_edit" class="col-md-3 text-right">求购说明:</label>
		  	 <div class="col-md-9">
			    <textarea id="productSeek_seekDesc_edit" name="productSeek.seekDesc" rows="8" class="form-control" placeholder="请输入求购说明"></textarea>
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="productSeek_userObj_user_name_edit" class="col-md-3 text-right">发布用户:</label>
		  	 <div class="col-md-9">
			    <select id="productSeek_userObj_user_name_edit" name="productSeek.userObj.user_name" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="productSeek_addTime_edit" class="col-md-3 text-right">发布时间:</label>
		  	 <div class="col-md-9">
                <div class="input-group date productSeek_addTime_edit col-md-12" data-link-field="productSeek_addTime_edit">
                    <input class="form-control" id="productSeek_addTime_edit" name="productSeek.addTime" size="16" type="text" value="" placeholder="请选择发布时间" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		</form> 
	    <style>#productSeekEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxProductSeekModify();">提交</button>
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
/*弹出修改商品求购界面并初始化数据*/
function productSeekEdit(seekId) {
	$.ajax({
		url :  basePath + "ProductSeek/ProductSeekController.aspx?action=getProductSeek&seekId=" + seekId,
		type : "get",
		dataType: "json",
		success : function (productSeek, response, status) {
			if (productSeek) {
				$("#productSeek_seekId_edit").val(productSeek.seekId);
				$("#productSeek_productName_edit").val(productSeek.productName);
				$.ajax({
					url: basePath + "ProductClass/ProductClassController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(productClasss,response,status) { 
						$("#productSeek_productClassObj_productClassId_edit").empty();
						var html="";
		        		$(productClasss).each(function(i,productClass){
		        			html += "<option value='" + productClass.productClassId + "'>" + productClass.productClassName + "</option>";
		        		});
		        		$("#productSeek_productClassObj_productClassId_edit").html(html);
		        		$("#productSeek_productClassObj_productClassId_edit").val(productSeek.productClassObjPri);
					}
				});
				$("#productSeek_productPhoto").val(productSeek.productPhoto);
				$("#productSeek_productPhotoImg").attr("src", basePath +　productSeek.productPhoto);
				$("#productSeek_price_edit").val(productSeek.price);
				$.ajax({
					url: basePath + "Xjcd/XjcdController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(xjcds,response,status) { 
						$("#productSeek_xjcdObj_xjcdId_edit").empty();
						var html="";
		        		$(xjcds).each(function(i,xjcd){
		        			html += "<option value='" + xjcd.xjcdId + "'>" + xjcd.xjcdName + "</option>";
		        		});
		        		$("#productSeek_xjcdObj_xjcdId_edit").html(html);
		        		$("#productSeek_xjcdObj_xjcdId_edit").val(productSeek.xjcdObjPri);
					}
				});
				$("#productSeek_seekDesc_edit").val(productSeek.seekDesc);
				$.ajax({
					url: basePath + "UserInfo/UserInfoController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(userInfos,response,status) { 
						$("#productSeek_userObj_user_name_edit").empty();
						var html="";
		        		$(userInfos).each(function(i,userInfo){
		        			html += "<option value='" + userInfo.user_name + "'>" + userInfo.name + "</option>";
		        		});
		        		$("#productSeek_userObj_user_name_edit").html(html);
		        		$("#productSeek_userObj_user_name_edit").val(productSeek.userObjPri);
					}
				});
				$("#productSeek_addTime_edit").val(productSeek.addTime);
				$('#productSeekEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除商品求购信息*/
function productSeekDelete(seekId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "ProductSeek/ProductSeekController.aspx?action=delete",
			data : {
				seekId : seekId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
                    $("#btnSearch").click();
					//location.href= basePath + "ProductSeek/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交商品求购信息表单给服务器端修改*/
function ajaxProductSeekModify() {
	$.ajax({
		url :  basePath + "ProductSeek/ProductSeekController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#productSeekEditForm")[0]),
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
    $('.productSeek_addTime_edit').datetimepicker({
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

