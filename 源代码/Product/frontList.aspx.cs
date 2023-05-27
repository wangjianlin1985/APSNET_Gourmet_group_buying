using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Product_frontList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindproductClassObj();
            BindsellerObj();
            BindareaObj();
            string sqlstr = " where 1=1 ";
            if (Request["productClassObj"] != null && Request["productClassObj"].ToString() != "0")
            {
                    sqlstr += "  and productClassObj=" + Request["productClassObj"].ToString();
                    productClassObj.SelectedValue = Request["productClassObj"].ToString();
            }
            if (Request["productName"] != null && Request["productName"].ToString() != "")
            {
                sqlstr += "  and productName like '%" + Request["productName"].ToString() + "%'";
                productName.Text = Request["productName"].ToString();
            }
            if (Request["sellerObj"] != null && Request["sellerObj"].ToString() != "")
            {
                sqlstr += "  and sellerObj='" + Request["sellerObj"].ToString() + "'";
                sellerObj.SelectedValue = Request["sellerObj"].ToString();
            }
            if (Request["areaObj"] != null && Request["areaObj"].ToString() != "0")
            {
                    sqlstr += "  and areaObj=" + Request["areaObj"].ToString();
                    areaObj.SelectedValue = Request["areaObj"].ToString();
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
            li = new ListItem(dr["className"].ToString(),dr["classId"].ToString());
            productClassObj.Items.Add(li);
        }
        productClassObj.SelectedValue = "0";
    }

    private void BindsellerObj()
    {
        ListItem li = new ListItem("不限制", "");
        sellerObj.Items.Add(li);
        DataSet sellerObjDs = BLL.bllSeller.getAllSeller();
        for (int i = 0; i < sellerObjDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = sellerObjDs.Tables[0].Rows[i];
            li = new ListItem(dr["sellerName"].ToString(),dr["sellerUserName"].ToString());
            sellerObj.Items.Add(li);
        }
        sellerObj.SelectedValue = "";
    }

    private void BindareaObj()
    {
        ListItem li = new ListItem("不限制", "0");
        areaObj.Items.Add(li);
        DataSet areaObjDs = BLL.bllArea.getAllArea();
        for (int i = 0; i < areaObjDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = areaObjDs.Tables[0].Rows[i];
            li = new ListItem(dr["areaName"].ToString(),dr["areaId"].ToString());
            areaObj.Items.Add(li);
        }
        areaObj.SelectedValue = "0";
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
        DataTable dsLog = BLL.bllProduct.GetProduct(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
        RpProduct.DataSource = dsLog;
        RpProduct.DataBind();
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
            return BLL.bllProductClass.getSomeProductClass(int.Parse(productClassObj)).className;
        }

        public string GetSellersellerObj(string sellerObj)
        {
            return BLL.bllSeller.getSomeSeller(sellerObj).sellerName;
        }

        public string GetAreaareaObj(string areaObj)
        {
            return BLL.bllArea.getSomeArea(int.Parse(areaObj)).areaName;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("frontList.aspx?productClassObj=" + productClassObj.SelectedValue.Trim()+ "&&productName=" + productName.Text.Trim() + "&&sellerObj=" + sellerObj.SelectedValue.Trim() + "&&areaObj=" + areaObj.SelectedValue.Trim()+ "&&addTime=" + addTime.Text.Trim());
        }

}
