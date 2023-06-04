using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace chengxusheji.Admin
{
    public partial class ProductSellList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindproductClassObj();
                BindxjcdObj();
                BinduserObj();
                string sqlstr = " where 1=1 ";
                if (Request["productName"] != null && Request["productName"].ToString() != "")
                {
                    sqlstr += "  and productName like '%" + Request["productName"].ToString() + "%'";
                    productName.Text = Request["productName"].ToString();
                }
                if (Request["productClassObj"] != null && Request["productClassObj"].ToString() != "0")
                {
                    sqlstr += "  and productClassObj=" + Request["productClassObj"].ToString();
                    productClassObj.SelectedValue = Request["productClassObj"].ToString();
                }
                if (Request["xjcdObj"] != null && Request["xjcdObj"].ToString() != "0")
                {
                    sqlstr += "  and xjcdObj=" + Request["xjcdObj"].ToString();
                    xjcdObj.SelectedValue = Request["xjcdObj"].ToString();
                }
                if (Request["userObj"] != null && Request["userObj"].ToString() != "")
                {
                    sqlstr += "  and userObj='" + Request["userObj"].ToString() + "'";
                    userObj.SelectedValue = Request["userObj"].ToString();
                }
                if (Request["addTime"] != null && Request["addTime"].ToString() != "")
                {
                    sqlstr += "  and Convert(varchar,addTime,120) like '" + Request["addTime"].ToString() + "%'";
                    addTime.Text = Request["addTime"].ToString();
                }
                HWhere.Value = sqlstr;
                BindData("");
            }
        }
        private void BindproductClassObj()
        {
            ListItem li = new ListItem("不限制", "0");
            productClassObj.Items.Add(li);
            DataSet productClassObjDs = BLL.bllProductClass.getAllProductClass();
            for (int i = 0; i < productClassObjDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = productClassObjDs.Tables[0].Rows[i];
                li = new ListItem(dr["productClassName"].ToString(), dr["productClassName"].ToString());
                productClassObj.Items.Add(li);
            }
            productClassObj.SelectedValue = "0";
        }

        private void BindxjcdObj()
        {
            ListItem li = new ListItem("不限制", "0");
            xjcdObj.Items.Add(li);
            DataSet xjcdObjDs = BLL.bllXjcd.getAllXjcd();
            for (int i = 0; i < xjcdObjDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = xjcdObjDs.Tables[0].Rows[i];
                li = new ListItem(dr["xjcdName"].ToString(), dr["xjcdName"].ToString());
                xjcdObj.Items.Add(li);
            }
            xjcdObj.SelectedValue = "0";
        }

        private void BinduserObj()
        {
            ListItem li = new ListItem("不限制", "");
            userObj.Items.Add(li);
            DataSet userObjDs = BLL.bllUserInfo.getAllUserInfo();
            for (int i = 0; i < userObjDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = userObjDs.Tables[0].Rows[i];
                li = new ListItem(dr["name"].ToString(), dr["name"].ToString());
                userObj.Items.Add(li);
            }
            userObj.SelectedValue = "";
        }

        protected void BtnProductSellAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductSellEdit.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllProductSell.DelProductSell(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "信息成功删除..", "ProductSellList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "error", "信息删除失败，请重试或联系管理人员..");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "error", "删除失败..");
                }
            }
        }

        private void BindData(string strClass)
        {
            int DataCount = 0;
            int NowPage = 1;
            int AllPage = 0;
            int PageSize = Convert.ToInt32(HPageSize.Value);
            switch (strClass)
            {
                case "next":
                    NowPage = Convert.ToInt32(HNowPage.Value) + 1;
                    break;
                case "up":
                    NowPage = Convert.ToInt32(HNowPage.Value) - 1;
                    break;
                case "end":
                    NowPage = Convert.ToInt32(HAllPage.Value);
                    break;
                default:
                    break;
            }
            DataTable dsLog = BLL.bllProductSell.GetProductSell(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
            if (dsLog.Rows.Count == 0 || AllPage == 1)
            {
                LBEnd.Enabled = false;
                LBHome.Enabled = false;
                LBNext.Enabled = false;
                LBUp.Enabled = false;
            }
            else if (NowPage == 1)
            {
                LBHome.Enabled = false;
                LBUp.Enabled = false;
                LBNext.Enabled = true;
                LBEnd.Enabled = true;
            }
            else if (NowPage == AllPage)
            {
                LBHome.Enabled = true;
                LBUp.Enabled = true;
                LBNext.Enabled = false;
                LBEnd.Enabled = false;
            }
            else
            {
                LBEnd.Enabled = true;
                LBHome.Enabled = true;
                LBNext.Enabled = true;
                LBUp.Enabled = true;
            }
            RpProductSell.DataSource = dsLog;
            RpProductSell.DataBind();
            PageMes.Text = string.Format("[每页<font color=green>{0}</font>条 第<font color=red>{1}</font>页／共<font color=green>{2}</font>页   共<font color=green>{3}</font>条]", PageSize, NowPage, AllPage, DataCount);
            HNowPage.Value = Convert.ToString(NowPage++);
            HAllPage.Value = AllPage.ToString();
        }

        protected void LBHome_Click(object sender, EventArgs e)
        {
            BindData("");
        }
        protected void LBUp_Click(object sender, EventArgs e)
        {
            BindData("up");
        }
        protected void LBNext_Click(object sender, EventArgs e)
        {
            BindData("next");
        }
        protected void LBEnd_Click(object sender, EventArgs e)
        {
            BindData("end");
        }
        protected void RpProductSell_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllProductSell.DelProductSell((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除成功...", "ProductSellList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除失败，请重试或联系管理人员...", "ProductSellList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "删除失败...", "ProductSellList.aspx");
                }
            }
        }
        public string GetProductClassproductClassObj(string productClassObj)
        {
            return BLL.bllProductClass.getSomeProductClass(int.Parse(productClassObj)).productClassName;
        }

        public string GetXjcdxjcdObj(string xjcdObj)
        {
            return BLL.bllXjcd.getSomeXjcd(int.Parse(xjcdObj)).xjcdName;
        }

        public string GetUserInfouserObj(string userObj)
        {
            return BLL.bllUserInfo.getSomeUserInfo(userObj).name;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductSellList.aspx?productName=" + productName.Text.Trim()  + "&&productClassObj=" + productClassObj.SelectedValue.Trim() + "&&xjcdObj=" + xjcdObj.SelectedValue.Trim() + "&&userObj=" + userObj.SelectedValue.Trim()+ "&&addTime=" + addTime.Text.Trim());
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet productSellDataSet = BLL.bllProductSell.GetProductSell(HWhere.Value); 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            sb.Append("<table borderColor='black' border='1' >");
            sb.Append("<thead><tr><th colSpan='9'>商品出售记录</th></tr>");
            sb.Append("<tr class='title'>");
            sb.Append("<th>出售id</th>");
            sb.Append("<th>商品名称</th>");
            sb.Append("<th>商品分类</th>");
            sb.Append("<th>图书主图</th>");
            sb.Append("<th>出售价格</th>");
            sb.Append("<th>新旧程度</th>");
            sb.Append("<th>出售说明</th>");
            sb.Append("<th>发布用户</th>");
            sb.Append("<th>发布时间</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");
            for (int i = 0; i < productSellDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow dr = productSellDataSet.Tables[0].Rows[i];
                sb.Append("<tr height='60' class=content>");
                sb.Append("<td>" + dr["sellId"].ToString() + "</td>");
                sb.Append("<td>" + dr["productName"].ToString() + "</td>");
                sb.Append("<td>" + BLL.bllProductClass.getSomeProductClass(Convert.ToInt32(dr["productClassObj"])).productClassName + "</td>");
                sb.Append("<td width=80><span align='center'><img width='80' height='60' border='0' src='" + GetBaseUrl() + "/" +  dr["productPhoto"].ToString() + "'/></span></td>");
                sb.Append("<td>" + dr["sellPrice"].ToString() + "</td>");
                sb.Append("<td>" + BLL.bllXjcd.getSomeXjcd(Convert.ToInt32(dr["xjcdObj"])).xjcdName + "</td>");
                sb.Append("<td>" + dr["sellDesc"].ToString() + "</td>");
                sb.Append("<td>" + BLL.bllUserInfo.getSomeUserInfo(dr["userObj"].ToString()).name + "</td>");
                sb.Append("<td>" + Convert.ToDateTime(dr["addTime"]).ToShortDateString() + "</td>");
                sb.Append("</tr>");
            } 
           sb.Append("</tbody></table>");
            string content = sb.ToString();
            string css = ".content{color:red;text-align:center;}";
            string filename = "商品出售记录.xls";
            CommonTool.ExportToExcel(filename, content, css);
        }

        protected string GetBaseUrl()
        {
            return Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/Admin"));
        }
    }
}
