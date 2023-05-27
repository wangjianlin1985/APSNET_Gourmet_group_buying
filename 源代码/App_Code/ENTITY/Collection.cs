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
    ///Collection 的摘要说明：商品收藏实体
    /// </summary>

    public class Collection
    {
        /*收藏id*/
        private int _collectionId;
        public int collectionId
        {
            get { return _collectionId; }
            set { _collectionId = value; }
        }

        /*被收藏商品*/
        private int _productObj;
        public int productObj
        {
            get { return _productObj; }
            set { _productObj = value; }
        }

        /*收藏用户*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*收藏时间*/
        private DateTime _collectionTime;
        public DateTime collectionTime
        {
            get { return _collectionTime; }
            set { _collectionTime = value; }
        }

    }
}
