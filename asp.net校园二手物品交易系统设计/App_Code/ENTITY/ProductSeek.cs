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
    ///ProductSeek 的摘要说明：商品求购实体
    /// </summary>

    public class ProductSeek
    {
        /*求购id*/
        private int _seekId;
        public int seekId
        {
            get { return _seekId; }
            set { _seekId = value; }
        }

        /*商品名称*/
        private string _productName;
        public string productName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        /*商品类别*/
        private int _productClassObj;
        public int productClassObj
        {
            get { return _productClassObj; }
            set { _productClassObj = value; }
        }

        /*商品主图*/
        private string _productPhoto;
        public string productPhoto
        {
            get { return _productPhoto; }
            set { _productPhoto = value; }
        }

        /*求购价格*/
        private float _price;
        public float price
        {
            get { return _price; }
            set { _price = value; }
        }

        /*新旧程度*/
        private int _xjcdObj;
        public int xjcdObj
        {
            get { return _xjcdObj; }
            set { _xjcdObj = value; }
        }

        /*求购说明*/
        private string _seekDesc;
        public string seekDesc
        {
            get { return _seekDesc; }
            set { _seekDesc = value; }
        }

        /*发布用户*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*发布时间*/
        private DateTime _addTime;
        public DateTime addTime
        {
            get { return _addTime; }
            set { _addTime = value; }
        }

    }
}
