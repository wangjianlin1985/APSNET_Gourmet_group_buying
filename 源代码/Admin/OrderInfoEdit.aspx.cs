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
    public partial class OrderInfoEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindProductproductObj();
                BindOrderStateorderStateObj();
                BindUserInfouserObj();
                if (Request["orderNo"] != null)
                {
                    LoadData();
                }
            }
        }
        private void BindProductproductObj()
        {
            productObj.DataSource = BLL.bllProduct.getAllProduct();
            productObj.DataTextField = "productName";
            productObj.DataValueField = "productId";
            productObj.DataBind();
        }

        private void BindOrderStateorderStateObj()
        {
            orderStateObj.DataSource = BLL.bllOrderState.getAllOrderState();
            orderStateObj.DataTextField = "stateName";
            orderStateObj.DataValueField = "stateId";
            orderStateObj.DataBind();
        }

        private void BindUserInfouserObj()
        {
            userObj.DataSource = BLL.bllUserInfo.getAllUserInfo();
            userObj.DataTextField = "name";
            userObj.DataValueField = "user_name";
            userObj.DataBind();
        }

        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "orderNo")))
            {
                ENTITY.OrderInfo orderInfo = BLL.bllOrderInfo.getSomeOrderInfo(Common.GetMes.GetRequestQuery(Request, "orderNo"));
                orderNo.Value = orderInfo.orderNo;
                productObj.SelectedValue = orderInfo.productObj.ToString();
                orderNumber.Value = orderInfo.orderNumber.ToString();
                price.Value = orderInfo.price.ToString("0.00");
                totalPrice.Value = orderInfo.totalPrice.ToString("0.00");
                payWay.Value = orderInfo.payWay;
                orderStateObj.SelectedValue = orderInfo.orderStateObj.ToString();
                receiveName.Value = orderInfo.receiveName;
                telephone.Value = orderInfo.telephone;
                address.Value = orderInfo.address;
                orderMemo.Value = orderInfo.orderMemo;
                orderTime.Value = orderInfo.orderTime;
                userObj.SelectedValue = orderInfo.userObj;
            }
        }

        protected void BtnOrderInfoSave_Click(object sender, EventArgs e)
        {
            ENTITY.OrderInfo orderInfo = new ENTITY.OrderInfo();
            orderInfo.orderNo = this.orderNo.Value;
            orderInfo.productObj = int.Parse(productObj.SelectedValue);
            orderInfo.orderNumber = int.Parse(orderNumber.Value);
            orderInfo.price = float.Parse(float.Parse(price.Value).ToString("0.00"));
            orderInfo.totalPrice = float.Parse(float.Parse(totalPrice.Value).ToString("0.00"));
            orderInfo.payWay = payWay.Value;
            orderInfo.orderStateObj = int.Parse(orderStateObj.SelectedValue);
            orderInfo.receiveName = receiveName.Value;
            orderInfo.telephone = telephone.Value;
            orderInfo.address = address.Value;
            orderInfo.orderMemo = orderMemo.Value;
            orderInfo.orderTime = orderTime.Value;
            orderInfo.userObj = userObj.SelectedValue;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "orderNo")))
            {
                orderInfo.orderNo = Request["orderNo"];
                if (BLL.bllOrderInfo.EditOrderInfo(orderInfo))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"OrderInfoEdit.aspx?orderNo=" + Request["orderNo"] + "\"} else  {location.href=\"OrderInfoList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllOrderInfo.AddOrderInfo(orderInfo))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"OrderInfoEdit.aspx\"} else  {location.href=\"OrderInfoList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderInfoList.aspx");
        }
    }
}

