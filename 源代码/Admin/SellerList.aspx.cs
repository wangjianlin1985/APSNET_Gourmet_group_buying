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
    public partial class SellerList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
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
            ListItem li = new ListItem("不限制", "0");
            areaObj.Items.Add(li);
            DataSet areaObjDs = BLL.bllArea.getAllArea();
            for (int i = 0; i < areaObjDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = areaObjDs.Tables[0].Rows[i];
                li = new ListItem(dr["areaName"].ToString(), dr["areaName"].ToString());
                areaObj.Items.Add(li);
            }
            areaObj.SelectedValue = "0";
        }

        protected void BtnSellerAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("SellerEdit.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllSeller.DelSeller(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "信息成功删除..", "SellerList.aspx");
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
        protected void RpSeller_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllSeller.DelSeller((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除成功...", "SellerList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除失败，请重试或联系管理人员...", "SellerList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "删除失败...", "SellerList.aspx");
                }
            }
        }
        public string GetAreaareaObj(string areaObj)
        {
            return BLL.bllArea.getSomeArea(int.Parse(areaObj)).areaName;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("SellerList.aspx?sellerUserName=" + sellerUserName.Text.Trim() + "&&sellerName=" + sellerName.Text.Trim()+ "&&bornDate=" + bornDate.Text.Trim()+ "&&telephone=" + telephone.Text.Trim() + "&&areaObj=" + areaObj.SelectedValue.Trim());
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet sellerDataSet = BLL.bllSeller.GetSeller(HWhere.Value); 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            sb.Append("<table borderColor='black' border='1' >");
            sb.Append("<thead><tr><th colSpan='8'>商家记录</th></tr>");
            sb.Append("<tr class='title'>");
            sb.Append("<th>商家用户名</th>");
            sb.Append("<th>商家名称</th>");
            sb.Append("<th>商家照片</th>");
            sb.Append("<th>成立日期</th>");
            sb.Append("<th>商家电话</th>");
            sb.Append("<th>商家邮箱</th>");
            sb.Append("<th>所在区域</th>");
            sb.Append("<th>注册时间</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");
            for (int i = 0; i < sellerDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow dr = sellerDataSet.Tables[0].Rows[i];
                sb.Append("<tr height='60' class=content>");
                sb.Append("<td>" + dr["sellerUserName"].ToString() + "</td>");
                sb.Append("<td>" + dr["sellerName"].ToString() + "</td>");
                sb.Append("<td width=80><span align='center'><img width='80' height='60' border='0' src='" + GetBaseUrl() + "/" +  dr["sellerPhoto"].ToString() + "'/></span></td>");
                sb.Append("<td>" + Convert.ToDateTime(dr["bornDate"]).ToShortDateString() + "</td>");
                sb.Append("<td>" + dr["telephone"].ToString() + "</td>");
                sb.Append("<td>" + dr["email"].ToString() + "</td>");
                sb.Append("<td>" + BLL.bllArea.getSomeArea(Convert.ToInt32(dr["areaObj"])).areaName + "</td>");
                sb.Append("<td>" + Convert.ToDateTime(dr["regTime"]).ToShortDateString() + "</td>");
                sb.Append("</tr>");
            } 
           sb.Append("</tbody></table>");
            string content = sb.ToString();
            string css = ".content{color:red;text-align:center;}";
            string filename = "商家记录.xls";
            CommonTool.ExportToExcel(filename, content, css);
        }

        protected string GetBaseUrl()
        {
            return Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/Admin"));
        }
    }
}
