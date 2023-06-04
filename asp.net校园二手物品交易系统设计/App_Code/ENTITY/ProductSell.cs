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
    ///ProductSell 的摘要说明：商品出售实体
    /// </summary>

    public class ProductSell
    {
        /*出售id*/
        private int _sellId;
        public int sellId
        {
            get { return _sellId; }
            set { _sellId = value; }
        }

        /*商品名称*/
        private string _productName;
        public string productName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        /*商品分类*/
        private int _productClassObj;
        public int productClassObj
        {
            get { return _productClassObj; }
            set { _productClassObj = value; }
        }

        /*图书主图*/
        private string _productPhoto;
        public string productPhoto
        {
            get { return _productPhoto; }
            set { _productPhoto = value; }
        }

        /*出售价格*/
        private float _sellPrice;
        public float sellPrice
        {
            get { return _sellPrice; }
            set { _sellPrice = value; }
        }

        /*新旧程度*/
        private int _xjcdObj;
        public int xjcdObj
        {
            get { return _xjcdObj; }
            set { _xjcdObj = value; }
        }

        /*出售说明*/
        private string _sellDesc;
        public string sellDesc
        {
            get { return _sellDesc; }
            set { _sellDesc = value; }
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
