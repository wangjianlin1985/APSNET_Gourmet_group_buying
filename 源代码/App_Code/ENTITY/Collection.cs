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
    ///Collection ��ժҪ˵������Ʒ�ղ�ʵ��
    /// </summary>

    public class Collection
    {
        /*�ղ�id*/
        private int _collectionId;
        public int collectionId
        {
            get { return _collectionId; }
            set { _collectionId = value; }
        }

        /*���ղ���Ʒ*/
        private int _productObj;
        public int productObj
        {
            get { return _productObj; }
            set { _productObj = value; }
        }

        /*�ղ��û�*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*�ղ�ʱ��*/
        private DateTime _collectionTime;
        public DateTime collectionTime
        {
            get { return _collectionTime; }
            set { _collectionTime = value; }
        }

    }
}
