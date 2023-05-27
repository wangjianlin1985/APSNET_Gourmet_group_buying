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
    public partial class SellerEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindAreaareaObj();
                /*进入本信息添加页显示无图的图片*/
                this.SellerPhotoImage.ImageUrl = "../FileUpload/NoImage.jpg";
                if (Session["Customername"] != null)
                {
                    LoadData();
                }
            }
        }
        private void BindAreaareaObj()
        {
            areaObj.DataSource = BLL.bllArea.getAllArea();
            areaObj.DataTextField = "areaName";
            areaObj.DataValueField = "areaId";
            areaObj.DataBind();
        }

        /*如果是需要对记录进行编辑需要在界面初始化显示数据*/
        private void LoadData()
        {

            ENTITY.Seller seller = BLL.bllSeller.getSomeSeller(Session["Customername"].ToString());
                sellerUserName.Value = seller.sellerUserName;
                password.Value = seller.password;
                sellerName.Value = seller.sellerName;
                sellerPhoto.Text = seller.sellerPhoto;
                if (seller.sellerPhoto != "") this.SellerPhotoImage.ImageUrl = "../" + seller.sellerPhoto;
                sellerDesc.Value = seller.sellerDesc;
                bornDate.Text = seller.bornDate.ToShortDateString();
                telephone.Value = seller.telephone;
                email.Value = seller.email;
                areaObj.SelectedValue = seller.areaObj.ToString();
                address.Value = seller.address;
                regTime.Text = seller.regTime.ToShortDateString() + " " + seller.regTime.ToLongTimeString();
            
        }

        protected void BtnSellerSave_Click(object sender, EventArgs e)
        {
            ENTITY.Seller seller = new ENTITY.Seller();
            seller.sellerUserName = this.sellerUserName.Value;
            seller.password = password.Value;
            seller.sellerName = sellerName.Value;
            if (sellerPhoto.Text == "") sellerPhoto.Text = "FileUpload/NoImage.jpg";
            seller.sellerPhoto = sellerPhoto.Text;
            seller.sellerDesc = sellerDesc.Value;
            seller.bornDate = Convert.ToDateTime(bornDate.Text);
            seller.telephone = telephone.Value;
            seller.email = email.Value;
            seller.areaObj = int.Parse(areaObj.SelectedValue);
            seller.address = address.Value;
            seller.regTime = Convert.ToDateTime(regTime.Text);

            seller.sellerUserName = Session["Customername"].ToString();
            if (BLL.bllSeller.EditSeller(seller))
            {
                Common.ShowMessage.myScriptMes(Page, "Suess", "alert(\"信息修改成功!\");");
            }
             
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("SellerList.aspx");
        }
        protected void Btn_SellerPhotoUpload_Click(object sender, EventArgs e)
        {
            /*如果用户上传了文件*/
            if (this.SellerPhotoUpload.PostedFile.ContentLength > 0)
            {
                /*验证上传的文件格式，只能为gif和jpeg格式*/
                string mimeType = this.SellerPhotoUpload.PostedFile.ContentType;
                if (String.Compare(mimeType, "image/gif", true) == 0 || String.Compare(mimeType, "image/pjpeg", true) == 0 || String.Compare(mimeType, "image/jpeg", true) == 0)
                {
                    this.sellerPhoto.Text = "上传文件中....";
                    string extFileString = System.IO.Path.GetExtension(this.SellerPhotoUpload.PostedFile.FileName); /*获取文件扩展名*/
                    string saveFileName = DAL.Function.MakeFileName(extFileString); /*根据扩展名生成文件名*/
                    string imagePath = "FileUpload/" + saveFileName;/*图片路径*/
                    this.SellerPhotoUpload.PostedFile.SaveAs(Server.MapPath("../" + imagePath));
                    this.SellerPhotoImage.ImageUrl = "../" + imagePath;
                    this.sellerPhoto.Text = imagePath;
                }
                else
                {
                    Response.Write("<script>alert('上传文件格式不正确!');</script>");
                }
            }
        }
    }
}

