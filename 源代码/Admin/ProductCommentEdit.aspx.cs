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

        /*如果是需要对记录进行编辑需要在界面初始化显示数据*/
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
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息修改成功，是否继续修改？否则返回信息列表。\")) {location.href=\"ProductCommentEdit.aspx?commentId=" + Request["commentId"] + "\"} else  {location.href=\"ProductCommentList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息修改失败，请重试或联系管理人员..");
                }
            }
            else
            {
                if (BLL.bllProductComment.AddProductComment(productComment))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息添加成功，是否继续添加？否则返回信息列表。\")) {location.href=\"ProductCommentEdit.aspx\"} else  {location.href=\"ProductCommentList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息添加失败，请重试或联系管理人员..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductCommentList.aspx");
        }
    }
}

