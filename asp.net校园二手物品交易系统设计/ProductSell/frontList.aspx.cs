using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class ProductSell_frontList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
            li = new ListItem(dr["productClassName"].ToString(),dr["productClassId"].ToString());
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
            li = new ListItem(dr["xjcdName"].ToString(),dr["xjcdId"].ToString());
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
            li = new ListItem(dr["name"].ToString(),dr["user_name"].ToString());
            userObj.Items.Add(li);
        }
        userObj.SelectedValue = "";
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
            Response.Redirect("frontList.aspx?productName=" + productName.Text.Trim()  + "&&productClassObj=" + productClassObj.SelectedValue.Trim() + "&&xjcdObj=" + xjcdObj.SelectedValue.Trim() + "&&userObj=" + userObj.SelectedValue.Trim()+ "&&addTime=" + addTime.Text.Trim());
        }

}
