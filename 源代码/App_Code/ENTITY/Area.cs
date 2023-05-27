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
    ///Area 的摘要说明：区域实体
    /// </summary>

    public class Area
    {
        /*区域id*/
        private int _areaId;
        public int areaId
        {
            get { return _areaId; }
            set { _areaId = value; }
        }

        /*区域名称*/
        private string _areaName;
        public string areaName
        {
            get { return _areaName; }
            set { _areaName = value; }
        }

    }
}
