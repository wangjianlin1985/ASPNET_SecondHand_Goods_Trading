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
    ///ProductClass 的摘要说明：商品分类实体
    /// </summary>

    public class ProductClass
    {
        /*类别编号*/
        private int _productClassId;
        public int productClassId
        {
            get { return _productClassId; }
            set { _productClassId = value; }
        }

        /*类别名称*/
        private string _productClassName;
        public string productClassName
        {
            get { return _productClassName; }
            set { _productClassName = value; }
        }

    }
}
