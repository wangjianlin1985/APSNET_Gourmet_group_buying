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
    public partial class CollectionEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindProductproductObj();
                BindUserInfouserObj();
                if (Request["collectionId"] != null)
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
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "collectionId")))
            {
                ENTITY.Collection collection = BLL.bllCollection.getSomeCollection(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "collectionId")));
                productObj.SelectedValue = collection.productObj.ToString();
                userObj.SelectedValue = collection.userObj;
                collectionTime.Text = collection.collectionTime.ToShortDateString() + " " + collection.collectionTime.ToLongTimeString();
            }
        }

        protected void BtnCollectionSave_Click(object sender, EventArgs e)
        {
            ENTITY.Collection collection = new ENTITY.Collection();
            collection.productObj = int.Parse(productObj.SelectedValue);
            collection.userObj = userObj.SelectedValue;
            collection.collectionTime = Convert.ToDateTime(collectionTime.Text);
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "collectionId")))
            {
                collection.collectionId = int.Parse(Request["collectionId"]);
                if (BLL.bllCollection.EditCollection(collection))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息修改成功，是否继续修改？否则返回信息列表。\")) {location.href=\"CollectionEdit.aspx?collectionId=" + Request["collectionId"] + "\"} else  {location.href=\"CollectionList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息修改失败，请重试或联系管理人员..");
                }
            }
            else
            {
                if (BLL.bllCollection.AddCollection(collection))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息添加成功，是否继续添加？否则返回信息列表。\")) {location.href=\"CollectionEdit.aspx\"} else  {location.href=\"CollectionList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息添加失败，请重试或联系管理人员..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CollectionList.aspx");
        }
    }
}

