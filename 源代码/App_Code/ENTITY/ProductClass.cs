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
    ///ProductClass 的摘要说明：商品类别实体
    /// </summary>

    public class ProductClass
    {
        /*类别id*/
        private int _classId;
        public int classId
        {
            get { return _classId; }
            set { _classId = value; }
        }

        /*类别名称*/
        private string _className;
        public string className
        {
            get { return _className; }
            set { _className = value; }
        }

        /*类别描述*/
        private string _classDesc;
        public string classDesc
        {
            get { return _classDesc; }
            set { _classDesc = value; }
        }

    }
}
