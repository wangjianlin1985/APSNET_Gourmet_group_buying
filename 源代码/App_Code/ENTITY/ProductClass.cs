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
    ///ProductClass ��ժҪ˵������Ʒ���ʵ��
    /// </summary>

    public class ProductClass
    {
        /*���id*/
        private int _classId;
        public int classId
        {
            get { return _classId; }
            set { _classId = value; }
        }

        /*�������*/
        private string _className;
        public string className
        {
            get { return _className; }
            set { _className = value; }
        }

        /*�������*/
        private string _classDesc;
        public string classDesc
        {
            get { return _classDesc; }
            set { _classDesc = value; }
        }

    }
}
