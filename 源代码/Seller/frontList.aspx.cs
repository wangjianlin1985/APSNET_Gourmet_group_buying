using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Seller_frontList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindareaObj();
            string sqlstr = " where 1=1 ";
            if (Request["sellerUserName"] != null && Request["sellerUserName"].ToString() != "")
            {
                sqlstr += "  and sellerUserName like '%" + Request["sellerUserName"].ToString() + "%'";
                sellerUserName.Text = Request["sellerUserName"].ToString();
            }
            if (Request["sellerName"] != null && Request["sellerName"].ToString() != "")
            {
                sqlstr += "  and sellerName like '%" + Request["sellerName"].ToString() + "%'";
                sellerName.Text = Request["sellerName"].ToString();
            }
            if (Request["bornDate"] != null && Request["bornDate"].ToString() != "")
            {
                sqlstr += "  and Convert(varchar,bornDate,120) like '" + Request["bornDate"].ToString() + "%'";
                bornDate.Text = Request["bornDate"].ToString();
            }
            if (Request["telephone"] != null && Request["telephone"].ToString() != "")
            {
                sqlstr += "  and telephone like '%" + Request["telephone"].ToString() + "%'";
                telephone.Text = Request["telephone"].ToString();
            }
            if (Request["areaObj"] != null && Request["areaObj"].ToString() != "0")
            {
                    sqlstr += "  and areaObj=" + Request["areaObj"].ToString();
                    areaObj.SelectedValue = Request["areaObj"].ToString();
            }
            HWhere.Value = sqlstr;
            BindData("");
       }
    }
    private void BindareaObj()
    {
        ListItem li = new ListItem("������", "0");
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
        DataTable dsLog = BLL.bllSeller.GetSeller(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
        RpSeller.DataSource = dsLog;
        RpSeller.DataBind();
        PageMes.Text = string.Format("[ÿҳ<font color=green>{0}</font>�� ��<font color=red>{1}</font>ҳ����<font color=green>{2}</font>ҳ   ��<font color=green>{3}</font>��]", PageSize, NowPage, AllPage, DataCount);
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
        public string GetAreaareaObj(string areaObj)
        {
            return BLL.bllArea.getSomeArea(int.Parse(areaObj)).areaName;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("frontList.aspx?sellerUserName=" + sellerUserName.Text.Trim() + "&&sellerName=" + sellerName.Text.Trim()+ "&&bornDate=" + bornDate.Text.Trim()+ "&&telephone=" + telephone.Text.Trim() + "&&areaObj=" + areaObj.SelectedValue.Trim());
        }

}
