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
    ///ProductClass ��ժҪ˵������Ʒ����ʵ��
    /// </summary>

    public class ProductClass
    {
        /*�����*/
        private int _productClassId;
        public int productClassId
        {
            get { return _productClassId; }
            set { _productClassId = value; }
        }

        /*�������*/
        private string _productClassName;
        public string productClassName
        {
            get { return _productClassName; }
            set { _productClassName = value; }
        }

    }
}
