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
    ///Area ��ժҪ˵��������ʵ��
    /// </summary>

    public class Area
    {
        /*����id*/
        private int _areaId;
        public int areaId
        {
            get { return _areaId; }
            set { _areaId = value; }
        }

        /*��������*/
        private string _areaName;
        public string areaName
        {
            get { return _areaName; }
            set { _areaName = value; }
        }

    }
}
