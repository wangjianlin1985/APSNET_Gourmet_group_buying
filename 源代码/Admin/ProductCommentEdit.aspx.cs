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
    public partial class ProductCommentEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindProductproductObj();
                BindUserInfouserObj();
                if (Request["commentId"] != null)
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
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "commentId")))
            {
                ENTITY.ProductComment productComment = BLL.bllProductComment.getSomeProductComment(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "commentId")));
                productObj.SelectedValue = productComment.productObj.ToString();
                content.Value = productComment.content;
                userObj.SelectedValue = productComment.userObj;
                commentTime.Value = productComment.commentTime;
            }
        }

        protected void BtnProductCommentSave_Click(object sender, EventArgs e)
        {
            ENTITY.ProductComment productComment = new ENTITY.ProductComment();
            productComment.productObj = int.Parse(productObj.SelectedValue);
            productComment.content = content.Value;
            productComment.userObj = userObj.SelectedValue;
            productComment.commentTime = commentTime.Value;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "commentId")))
            {
                productComment.commentId = int.Parse(Request["commentId"]);
                if (BLL.bllProductComment.EditProductComment(productComment))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"ProductCommentEdit.aspx?commentId=" + Request["commentId"] + "\"} else  {location.href=\"ProductCommentList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllProductComment.AddProductComment(productComment))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"ProductCommentEdit.aspx\"} else  {location.href=\"ProductCommentList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductCommentList.aspx");
        }
    }
}

