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
    ///Xjcd 的摘要说明：新旧程度实体
    /// </summary>

    public class Xjcd
    {
        /*新旧程度id*/
        private int _xjcdId;
        public int xjcdId
        {
            get { return _xjcdId; }
            set { _xjcdId = value; }
        }

        /*新旧程度*/
        private string _xjcdName;
        public string xjcdName
        {
            get { return _xjcdName; }
            set { _xjcdName = value; }
        }

    }
}
