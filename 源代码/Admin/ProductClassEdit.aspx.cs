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
    public partial class ProductClassEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                if (Request["classId"] != null)
                {
                    LoadData();
                }
            }
        }
        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "classId")))
            {
                ENTITY.ProductClass productClass = BLL.bllProductClass.getSomeProductClass(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "classId")));
                className.Value = productClass.className;
                classDesc.Value = productClass.classDesc;
            }
        }

        protected void BtnProductClassSave_Click(object sender, EventArgs e)
        {
            ENTITY.ProductClass productClass = new ENTITY.ProductClass();
            productClass.className = className.Value;
            productClass.classDesc = classDesc.Value;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "classId")))
            {
                productClass.classId = int.Parse(Request["classId"]);
                if (BLL.bllProductClass.EditProductClass(productClass))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"ProductClassEdit.aspx?classId=" + Request["classId"] + "\"} else  {location.href=\"ProductClassList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllProductClass.AddProductClass(productClass))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"ProductClassEdit.aspx\"} else  {location.href=\"ProductClassList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductClassList.aspx");
        }
    }
}

