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
    ///OrderInfo 的摘要说明：订单实体
    /// </summary>

    public class OrderInfo
    {
        /*订单编号*/
        private string _orderNo;
        public string orderNo
        {
            get { return _orderNo; }
            set { _orderNo = value; }
        }

        /*订购商品*/
        private int _productObj;
        public int productObj
        {
            get { return _productObj; }
            set { _productObj = value; }
        }

        /*订购数量*/
        private int _orderNumber;
        public int orderNumber
        {
            get { return _orderNumber; }
            set { _orderNumber = value; }
        }

        /*订购单价*/
        private float _price;
        public float price
        {
            get { return _price; }
            set { _price = value; }
        }

        /*订购总价*/
        private float _totalPrice;
        public float totalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; }
        }

        /*支付方式*/
        private string _payWay;
        public string payWay
        {
            get { return _payWay; }
            set { _payWay = value; }
        }

        /*订单状态*/
        private int _orderStateObj;
        public int orderStateObj
        {
            get { return _orderStateObj; }
            set { _orderStateObj = value; }
        }

        /*收货人*/
        private string _receiveName;
        public string receiveName
        {
            get { return _receiveName; }
            set { _receiveName = value; }
        }

        /*收货人电话*/
        private string _telephone;
        public string telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        /*收货人地址*/
        private string _address;
        public string address
        {
            get { return _address; }
            set { _address = value; }
        }

        /*订单备注*/
        private string _orderMemo;
        public string orderMemo
        {
            get { return _orderMemo; }
            set { _orderMemo = value; }
        }

        /*下单时间*/
        private string _orderTime;
        public string orderTime
        {
            get { return _orderTime; }
            set { _orderTime = value; }
        }

        /*下单用户*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

    }
}
