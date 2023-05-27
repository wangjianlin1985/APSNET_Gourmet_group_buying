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
    ///OrderInfo ��ժҪ˵��������ʵ��
    /// </summary>

    public class OrderInfo
    {
        /*�������*/
        private string _orderNo;
        public string orderNo
        {
            get { return _orderNo; }
            set { _orderNo = value; }
        }

        /*������Ʒ*/
        private int _productObj;
        public int productObj
        {
            get { return _productObj; }
            set { _productObj = value; }
        }

        /*��������*/
        private int _orderNumber;
        public int orderNumber
        {
            get { return _orderNumber; }
            set { _orderNumber = value; }
        }

        /*��������*/
        private float _price;
        public float price
        {
            get { return _price; }
            set { _price = value; }
        }

        /*�����ܼ�*/
        private float _totalPrice;
        public float totalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; }
        }

        /*֧����ʽ*/
        private string _payWay;
        public string payWay
        {
            get { return _payWay; }
            set { _payWay = value; }
        }

        /*����״̬*/
        private int _orderStateObj;
        public int orderStateObj
        {
            get { return _orderStateObj; }
            set { _orderStateObj = value; }
        }

        /*�ջ���*/
        private string _receiveName;
        public string receiveName
        {
            get { return _receiveName; }
            set { _receiveName = value; }
        }

        /*�ջ��˵绰*/
        private string _telephone;
        public string telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        /*�ջ��˵�ַ*/
        private string _address;
        public string address
        {
            get { return _address; }
            set { _address = value; }
        }

        /*������ע*/
        private string _orderMemo;
        public string orderMemo
        {
            get { return _orderMemo; }
            set { _orderMemo = value; }
        }

        /*�µ�ʱ��*/
        private string _orderTime;
        public string orderTime
        {
            get { return _orderTime; }
            set { _orderTime = value; }
        }

        /*�µ��û�*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

    }
}
