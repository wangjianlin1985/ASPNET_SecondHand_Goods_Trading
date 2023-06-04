using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class ProductOrder_frontList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindbookSellObj();
            
            string sqlstr = " where 1=1 ";
            if (Request["bookSellObj"] != null && Request["bookSellObj"].ToString() != "0")
            {
                    sqlstr += "  and bookSellObj=" + Request["bookSellObj"].ToString();
                    bookSellObj.SelectedValue = Request["bookSellObj"].ToString();
            }
            
            sqlstr += "  and userObj='" + Session["user_name"].ToString() + "'";

            if (Request["addTime"] != null && Request["addTime"].ToString() != "")
            {
                sqlstr += "  and Convert(varchar,addTime,120) like '" + Request["addTime"].ToString() + "%'";
                addTime.Text = Request["addTime"].ToString();
            }
            HWhere.Value = sqlstr;
            BindData("");
       }
    }
    private void BindbookSellObj()
    {
        ListItem li = new ListItem("不限制", "0");
        bookSellObj.Items.Add(li);
        DataSet bookSellObjDs = BLL.bllProductSell.getAllProductSell();
        for (int i = 0; i < bookSellObjDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = bookSellObjDs.Tables[0].Rows[i];
            li = new ListItem(dr["productName"].ToString(),dr["sellId"].ToString());
            bookSellObj.Items.Add(li);
        }
        bookSellObj.SelectedValue = "0";
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
        DataTable dsLog = BLL.bllProductOrder.GetProductOrder(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
        RpProductOrder.DataSource = dsLog;
        RpProductOrder.DataBind();
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
        public string GetProductSellbookSellObj(string bookSellObj)
        {
            return BLL.bllProductSell.getSomeProductSell(int.Parse(bookSellObj)).productName;
        }

        public string GetUserInfouserObj(string userObj)
        {
            return BLL.bllUserInfo.getSomeUserInfo(userObj).name;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("userFrontList.aspx?bookSellObj=" + bookSellObj.SelectedValue.Trim() + "&&userObj=" + Session["user_name"].ToString() + "&&addTime=" + addTime.Text.Trim());
        }

}
