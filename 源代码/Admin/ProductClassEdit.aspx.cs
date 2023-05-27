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
        /*如果是需要对记录进行编辑需要在界面初始化显示数据*/
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
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息修改成功，是否继续修改？否则返回信息列表。\")) {location.href=\"ProductClassEdit.aspx?classId=" + Request["classId"] + "\"} else  {location.href=\"ProductClassList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息修改失败，请重试或联系管理人员..");
                }
            }
            else
            {
                if (BLL.bllProductClass.AddProductClass(productClass))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息添加成功，是否继续添加？否则返回信息列表。\")) {location.href=\"ProductClassEdit.aspx\"} else  {location.href=\"ProductClassList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息添加失败，请重试或联系管理人员..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductClassList.aspx");
        }
    }
}

