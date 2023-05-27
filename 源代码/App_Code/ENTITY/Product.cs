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
    ///Product 的摘要说明：商品实体
    /// </summary>

    public class Product
    {
        /*商品id*/
        private int _productId;
        public int productId
        {
            get { return _productId; }
            set { _productId = value; }
        }

        /*商品类别*/
        private int _productClassObj;
        public int productClassObj
        {
            get { return _productClassObj; }
            set { _productClassObj = value; }
        }

        /*商品名称*/
        private string _productName;
        public string productName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        /*商品主图*/
        private string _mainPhoto;
        public string mainPhoto
        {
            get { return _mainPhoto; }
            set { _mainPhoto = value; }
        }

        /*商品价格*/
        private float _price;
        public float price
        {
            get { return _price; }
            set { _price = value; }
        }

        /*商品库存*/
        private int _productCount;
        public int productCount
        {
            get { return _productCount; }
            set { _productCount = value; }
        }

        /*商品描述*/
        private string _productDesc;
        public string productDesc
        {
            get { return _productDesc; }
            set { _productDesc = value; }
        }

        /*发布的商家*/
        private string _sellerObj;
        public string sellerObj
        {
            get { return _sellerObj; }
            set { _sellerObj = value; }
        }

        /*所在区域*/
        private int _areaObj;
        public int areaObj
        {
            get { return _areaObj; }
            set { _areaObj = value; }
        }

        /*发布时间*/
        private DateTime _addTime;
        public DateTime addTime
        {
            get { return _addTime; }
            set { _addTime = value; }
        }

    }
}
