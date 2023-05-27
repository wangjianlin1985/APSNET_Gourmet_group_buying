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

        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
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
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"CollectionEdit.aspx?collectionId=" + Request["collectionId"] + "\"} else  {location.href=\"CollectionList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllCollection.AddCollection(collection))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"CollectionEdit.aspx\"} else  {location.href=\"CollectionList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CollectionList.aspx");
        }
    }
}

