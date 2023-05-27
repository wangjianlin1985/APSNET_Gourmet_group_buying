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
    ///Seller ��ժҪ˵�����̼�ʵ��
    /// </summary>

    public class Seller
    {
        /*�̼��û���*/
        private string _sellerUserName;
        public string sellerUserName
        {
            get { return _sellerUserName; }
            set { _sellerUserName = value; }
        }

        /*��¼����*/
        private string _password;
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        /*�̼�����*/
        private string _sellerName;
        public string sellerName
        {
            get { return _sellerName; }
            set { _sellerName = value; }
        }

        /*�̼���Ƭ*/
        private string _sellerPhoto;
        public string sellerPhoto
        {
            get { return _sellerPhoto; }
            set { _sellerPhoto = value; }
        }

        /*�̼ҽ���*/
        private string _sellerDesc;
        public string sellerDesc
        {
            get { return _sellerDesc; }
            set { _sellerDesc = value; }
        }

        /*��������*/
        private DateTime _bornDate;
        public DateTime bornDate
        {
            get { return _bornDate; }
            set { _bornDate = value; }
        }

        /*�̼ҵ绰*/
        private string _telephone;
        public string telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        /*�̼�����*/
        private string _email;
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

        /*��������*/
        private int _areaObj;
        public int areaObj
        {
            get { return _areaObj; }
            set { _areaObj = value; }
        }

        /*�̼ҵ�ַ*/
        private string _address;
        public string address
        {
            get { return _address; }
            set { _address = value; }
        }

        /*ע��ʱ��*/
        private DateTime _regTime;
        public DateTime regTime
        {
            get { return _regTime; }
            set { _regTime = value; }
        }

    }
}
