<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontUserList.aspx.cs" Inherits="ProductOrder_frontList" %>
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
<title>商品订单查询</title>
<link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
<link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
<link href="<%=basePath %>plugins/animate.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
</head>
<body style="margin-top:70px;">
<div class="container">
<uc:header ID="header" runat="server" />
 <form id="form2" runat="server">
	<div class="row"> 
		<div class="col-md-9 wow fadeInDown" data-wow-duration="0.5s">
			<div>
				<!-- Nav tabs -->
				<ul class="nav nav-tabs" role="tablist">
			    	<li><a href="../index.aspx">首页</a></li>
			    	<li role="presentation" class="active"><a href="#productOrderListPanel" aria-controls="productOrderListPanel" role="tab" data-toggle="tab">商品订单列表</a></li>
			    	<li role="presentation" ><a href="frontAdd.aspx" style="display:none;">添加商品订单</a></li>
				</ul>
			  	<!-- Tab panes -->
			  	<div class="tab-content">
				    <div role="tabpanel" class="tab-pane active" id="productOrderListPanel">
				    		<div class="row">
				    			<div class="col-md-12 top5">
				    				<div class="table-responsive">
				    				<table class="table table-condensed table-hover">
				    					<tr class="success bold"><td>序号</td><td>订单id</td><td>商品信息</td><td>意向出价</td><td>用户备注</td><td>下单时间</td><td>操作</td></tr>
				    					<asp:Repeater ID="RpProductOrder" runat="server">
 										<ItemTemplate>
 										<tr>
 											<td><%#(Container.ItemIndex + 1)%></td>
 											<td><%#Eval("orderId")%></td>
 											<td><%#GetProductSellbookSellObj(Eval("bookSellObj").ToString())%></td> 
 											<td><%#Eval("price")%></td>
 											<td><%#Eval("orderMemo")%></td>
 											<td><%#Eval("addTime")%></td>
 											<td>
 												<a href="frontshow.aspx?orderId=<%#Eval("orderId")%>"><i class="fa fa-info"></i>&nbsp;查看</a>&nbsp;
 												<a href="#" onclick="productOrderEdit('<%#Eval("orderId")%>');" style="display:none;"><i class="fa fa-pencil fa-fw"></i>编辑</a>&nbsp;
 												<a href="#" onclick="productOrderDelete('<%#Eval("orderId")%>');" ><i class="fa fa-trash-o fa-fw"></i>删除</a>
 											</td> 
 										</tr>
 										</ItemTemplate>
 										</asp:Repeater>
				    				</table>
				    				</div>
				    			</div>
				    		</div>

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
			</div>
		</div>
	<div class="col-md-3 wow fadeInRight">
		<div class="page-header">
    		<h1>商品订单查询</h1>
		</div>
            <div class="form-group">
            	<label for="bookSellObj_orderId">商品信息：</label>
                <asp:DropDownList ID="bookSellObj" runat="server"  CssClass="form-control" placeholder="请选择商品信息"></asp:DropDownList>
            </div>
            
			<div class="form-group">
				<label for="addTime">下单时间:</label>
				<asp:TextBox ID="addTime"  runat="server" CssClass="form-control" placeholder="请选择下单时间" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
            <input type=hidden name=currentPage value="" />
            <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>

	</div>
 </form>
</div> 
<div id="productOrderEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;商品订单信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="productOrderEditForm" id="productOrderEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="productOrder_orderId_edit" class="col-md-3 text-right">订单id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="productOrder_orderId_edit" name="productOrder.orderId" class="form-control" placeholder="请输入订单id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="productOrder_bookSellObj_sellId_edit" class="col-md-3 text-right">商品信息:</label>
		  	 <div class="col-md-9">
			    <select id="productOrder_bookSellObj_sellId_edit" name="productOrder.bookSellObj.sellId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="productOrder_userObj_user_name_edit" class="col-md-3 text-right">意向用户:</label>
		  	 <div class="col-md-9">
			    <select id="productOrder_userObj_user_name_edit" name="productOrder.userObj.user_name" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="productOrder_price_edit" class="col-md-3 text-right">意向出价:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="productOrder_price_edit" name="productOrder.price" class="form-control" placeholder="请输入意向出价">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="productOrder_orderMemo_edit" class="col-md-3 text-right">用户备注:</label>
		  	 <div class="col-md-9">
			    <textarea id="productOrder_orderMemo_edit" name="productOrder.orderMemo" rows="8" class="form-control" placeholder="请输入用户备注"></textarea>
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="productOrder_addTime_edit" class="col-md-3 text-right">下单时间:</label>
		  	 <div class="col-md-9">
                <div class="input-group date productOrder_addTime_edit col-md-12" data-link-field="productOrder_addTime_edit">
                    <input class="form-control" id="productOrder_addTime_edit" name="productOrder.addTime" size="16" type="text" value="" placeholder="请选择下单时间" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		</form> 
	    <style>#productOrderEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxProductOrderModify();">提交</button>
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
/*弹出修改商品订单界面并初始化数据*/
function productOrderEdit(orderId) {
	$.ajax({
		url :  basePath + "ProductOrder/ProductOrderController.aspx?action=getProductOrder&orderId=" + orderId,
		type : "get",
		dataType: "json",
		success : function (productOrder, response, status) {
			if (productOrder) {
				$("#productOrder_orderId_edit").val(productOrder.orderId);
				$.ajax({
					url: basePath + "ProductSell/ProductSellController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(productSells,response,status) { 
						$("#productOrder_bookSellObj_sellId_edit").empty();
						var html="";
		        		$(productSells).each(function(i,productSell){
		        			html += "<option value='" + productSell.sellId + "'>" + productSell.productName + "</option>";
		        		});
		        		$("#productOrder_bookSellObj_sellId_edit").html(html);
		        		$("#productOrder_bookSellObj_sellId_edit").val(productOrder.bookSellObjPri);
					}
				});
				$.ajax({
					url: basePath + "UserInfo/UserInfoController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(userInfos,response,status) { 
						$("#productOrder_userObj_user_name_edit").empty();
						var html="";
		        		$(userInfos).each(function(i,userInfo){
		        			html += "<option value='" + userInfo.user_name + "'>" + userInfo.name + "</option>";
		        		});
		        		$("#productOrder_userObj_user_name_edit").html(html);
		        		$("#productOrder_userObj_user_name_edit").val(productOrder.userObjPri);
					}
				});
				$("#productOrder_price_edit").val(productOrder.price);
				$("#productOrder_orderMemo_edit").val(productOrder.orderMemo);
				$("#productOrder_addTime_edit").val(productOrder.addTime);
				$('#productOrderEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除商品订单信息*/
function productOrderDelete(orderId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "ProductOrder/ProductOrderController.aspx?action=delete",
			data : {
				orderId : orderId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
					$("#btnSearch").click();
					//location.href= basePath + "ProductOrder/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交商品订单信息表单给服务器端修改*/
function ajaxProductOrderModify() {
	$.ajax({
		url :  basePath + "ProductOrder/ProductOrderController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#productOrderEditForm")[0]),
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

    /*下单时间组件*/
    $('.productOrder_addTime_edit').datetimepicker({
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

