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
    public partial class OrderInfoList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindproductObj();
                BindorderStateObj();
                BinduserObj();
                string sqlstr = " where 1=1 ";
                if (Request["orderNo"] != null && Request["orderNo"].ToString() != "")
                {
                    sqlstr += "  and orderNo like '%" + Request["orderNo"].ToString() + "%'";
                    orderNo.Text = Request["orderNo"].ToString();
                }
                if (Request["productObj"] != null && Request["productObj"].ToString() != "0")
                {
                    sqlstr += "  and productObj=" + Request["productObj"].ToString();
                    productObj.SelectedValue = Request["productObj"].ToString();
                }
                if (Request["orderStateObj"] != null && Request["orderStateObj"].ToString() != "0")
                {
                    sqlstr += "  and orderStateObj=" + Request["orderStateObj"].ToString();
                    orderStateObj.SelectedValue = Request["orderStateObj"].ToString();
                }
                if (Request["receiveName"] != null && Request["receiveName"].ToString() != "")
                {
                    sqlstr += "  and receiveName like '%" + Request["receiveName"].ToString() + "%'";
                    receiveName.Text = Request["receiveName"].ToString();
                }
                if (Request["telephone"] != null && Request["telephone"].ToString() != "")
                {
                    sqlstr += "  and telephone like '%" + Request["telephone"].ToString() + "%'";
                    telephone.Text = Request["telephone"].ToString();
                }
                if (Request["orderTime"] != null && Request["orderTime"].ToString() != "")
                {
                    sqlstr += "  and orderTime like '%" + Request["orderTime"].ToString() + "%'";
                    orderTime.Text = Request["orderTime"].ToString();
                }
                if (Request["userObj"] != null && Request["userObj"].ToString() != "")
                {
                    sqlstr += "  and userObj='" + Request["userObj"].ToString() + "'";
                    userObj.SelectedValue = Request["userObj"].ToString();
                }
                HWhere.Value = sqlstr;
                BindData("");
            }
        }
        private void BindproductObj()
        {
            ListItem li = new ListItem("不限制", "0");
            productObj.Items.Add(li);
            DataSet productObjDs = BLL.bllProduct.getAllProduct();
            for (int i = 0; i < productObjDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = productObjDs.Tables[0].Rows[i];
                li = new ListItem(dr["productName"].ToString(), dr["productName"].ToString());
                productObj.Items.Add(li);
            }
            productObj.SelectedValue = "0";
        }

        private void BindorderStateObj()
        {
            ListItem li = new ListItem("不限制", "0");
            orderStateObj.Items.Add(li);
            DataSet orderStateObjDs = BLL.bllOrderState.getAllOrderState();
            for (int i = 0; i < orderStateObjDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = orderStateObjDs.Tables[0].Rows[i];
                li = new ListItem(dr["stateName"].ToString(), dr["stateName"].ToString());
                orderStateObj.Items.Add(li);
            }
            orderStateObj.SelectedValue = "0";
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

        protected void BtnOrderInfoAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderInfoEdit.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllOrderInfo.DelOrderInfo(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "信息成功删除..", "OrderInfoList.aspx");
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
            DataTable dsLog = BLL.bllOrderInfo.GetOrderInfo(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
            RpOrderInfo.DataSource = dsLog;
            RpOrderInfo.DataBind();
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
        protected void RpOrderInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllOrderInfo.DelOrderInfo((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除成功...", "OrderInfoList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除失败，请重试或联系管理人员...", "OrderInfoList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "删除失败...", "OrderInfoList.aspx");
                }
            }
        }
        public string GetProductproductObj(string productObj)
        {
            return BLL.bllProduct.getSomeProduct(int.Parse(productObj)).productName;
        }

        public string GetOrderStateorderStateObj(string orderStateObj)
        {
            return BLL.bllOrderState.getSomeOrderState(int.Parse(orderStateObj)).stateName;
        }

        public string GetUserInfouserObj(string userObj)
        {
            return BLL.bllUserInfo.getSomeUserInfo(userObj).name;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderInfoList.aspx?orderNo=" + orderNo.Text.Trim()  + "&&productObj=" + productObj.SelectedValue.Trim() + "&&orderStateObj=" + orderStateObj.SelectedValue.Trim()+ "&&receiveName=" + receiveName.Text.Trim()+ "&&telephone=" + telephone.Text.Trim()+ "&&orderTime=" + orderTime.Text.Trim() + "&&userObj=" + userObj.SelectedValue.Trim());
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet orderInfoDataSet = BLL.bllOrderInfo.GetOrderInfo(HWhere.Value); 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            sb.Append("<table borderColor='black' border='1' >");
            sb.Append("<thead><tr><th colSpan='11'>订单记录</th></tr>");
            sb.Append("<tr class='title'>");
            sb.Append("<th>订单编号</th>");
            sb.Append("<th>订购商品</th>");
            sb.Append("<th>订购数量</th>");
            sb.Append("<th>订购单价</th>");
            sb.Append("<th>订购总价</th>");
            sb.Append("<th>支付方式</th>");
            sb.Append("<th>订单状态</th>");
            sb.Append("<th>收货人</th>");
            sb.Append("<th>收货人电话</th>");
            sb.Append("<th>下单时间</th>");
            sb.Append("<th>下单用户</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");
            for (int i = 0; i < orderInfoDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow dr = orderInfoDataSet.Tables[0].Rows[i];
                sb.Append("<tr class=content>");
                sb.Append("<td>" + dr["orderNo"].ToString() + "</td>");
                sb.Append("<td>" + BLL.bllProduct.getSomeProduct(Convert.ToInt32(dr["productObj"])).productName + "</td>");
                sb.Append("<td>" + dr["orderNumber"].ToString() + "</td>");
                sb.Append("<td>" + dr["price"].ToString() + "</td>");
                sb.Append("<td>" + dr["totalPrice"].ToString() + "</td>");
                sb.Append("<td>" + dr["payWay"].ToString() + "</td>");
                sb.Append("<td>" + BLL.bllOrderState.getSomeOrderState(Convert.ToInt32(dr["orderStateObj"])).stateName + "</td>");
                sb.Append("<td>" + dr["receiveName"].ToString() + "</td>");
                sb.Append("<td>" + dr["telephone"].ToString() + "</td>");
                sb.Append("<td>" + dr["orderTime"].ToString() + "</td>");
                sb.Append("<td>" + BLL.bllUserInfo.getSomeUserInfo(dr["userObj"].ToString()).name + "</td>");
                sb.Append("</tr>");
            } 
           sb.Append("</tbody></table>");
            string content = sb.ToString();
            string css = ".content{color:red;text-align:center;}";
            string filename = "订单记录.xls";
            CommonTool.ExportToExcel(filename, content, css);
        }

        protected string GetBaseUrl()
        {
            return Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/Admin"));
        }
    }
}
