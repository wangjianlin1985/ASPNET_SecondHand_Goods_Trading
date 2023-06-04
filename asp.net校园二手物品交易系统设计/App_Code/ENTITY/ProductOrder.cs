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
    ///ProductOrder 的摘要说明：商品订单实体
    /// </summary>

    public class ProductOrder
    {
        /*订单id*/
        private int _orderId;
        public int orderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }

        /*商品信息*/
        private int _bookSellObj;
        public int bookSellObj
        {
            get { return _bookSellObj; }
            set { _bookSellObj = value; }
        }

        /*意向用户*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*意向出价*/
        private float _price;
        public float price
        {
            get { return _price; }
            set { _price = value; }
        }

        /*用户备注*/
        private string _orderMemo;
        public string orderMemo
        {
            get { return _orderMemo; }
            set { _orderMemo = value; }
        }

        /*下单时间*/
        private DateTime _addTime;
        public DateTime addTime
        {
            get { return _addTime; }
            set { _addTime = value; }
        }

    }
}
