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
    ///Product ��ժҪ˵������Ʒʵ��
    /// </summary>

    public class Product
    {
        /*��Ʒid*/
        private int _productId;
        public int productId
        {
            get { return _productId; }
            set { _productId = value; }
        }

        /*��Ʒ���*/
        private int _productClassObj;
        public int productClassObj
        {
            get { return _productClassObj; }
            set { _productClassObj = value; }
        }

        /*��Ʒ����*/
        private string _productName;
        public string productName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        /*��Ʒ��ͼ*/
        private string _mainPhoto;
        public string mainPhoto
        {
            get { return _mainPhoto; }
            set { _mainPhoto = value; }
        }

        /*��Ʒ�۸�*/
        private float _price;
        public float price
        {
            get { return _price; }
            set { _price = value; }
        }

        /*��Ʒ���*/
        private int _productCount;
        public int productCount
        {
            get { return _productCount; }
            set { _productCount = value; }
        }

        /*��Ʒ����*/
        private string _productDesc;
        public string productDesc
        {
            get { return _productDesc; }
            set { _productDesc = value; }
        }

        /*�������̼�*/
        private string _sellerObj;
        public string sellerObj
        {
            get { return _sellerObj; }
            set { _sellerObj = value; }
        }

        /*��������*/
        private int _areaObj;
        public int areaObj
        {
            get { return _areaObj; }
            set { _areaObj = value; }
        }

        /*����ʱ��*/
        private DateTime _addTime;
        public DateTime addTime
        {
            get { return _addTime; }
            set { _addTime = value; }
        }

    }
}
