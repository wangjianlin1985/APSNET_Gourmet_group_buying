using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ENTITY
{
    /// <summary>
    ///Seller 的摘要说明：商家实体
    /// </summary>

    public class Seller
    {
        /*商家用户名*/
        private string _sellerUserName;
        public string sellerUserName
        {
            get { return _sellerUserName; }
            set { _sellerUserName = value; }
        }

        /*登录密码*/
        private string _password;
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        /*商家名称*/
        private string _sellerName;
        public string sellerName
        {
            get { return _sellerName; }
            set { _sellerName = value; }
        }

        /*商家照片*/
        private string _sellerPhoto;
        public string sellerPhoto
        {
            get { return _sellerPhoto; }
            set { _sellerPhoto = value; }
        }

        /*商家介绍*/
        private string _sellerDesc;
        public string sellerDesc
        {
            get { return _sellerDesc; }
            set { _sellerDesc = value; }
        }

        /*成立日期*/
        private DateTime _bornDate;
        public DateTime bornDate
        {
            get { return _bornDate; }
            set { _bornDate = value; }
        }

        /*商家电话*/
        private string _telephone;
        public string telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        /*商家邮箱*/
        private string _email;
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

        /*所在区域*/
        private int _areaObj;
        public int areaObj
        {
            get { return _areaObj; }
            set { _areaObj = value; }
        }

        /*商家地址*/
        private string _address;
        public string address
        {
            get { return _address; }
            set { _address = value; }
        }

        /*注册时间*/
        private DateTime _regTime;
        public DateTime regTime
        {
            get { return _regTime; }
            set { _regTime = value; }
        }

    }
}
