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
    ///ProductOrder ��ժҪ˵������Ʒ����ʵ��
    /// </summary>

    public class ProductOrder
    {
        /*����id*/
        private int _orderId;
        public int orderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }

        /*��Ʒ��Ϣ*/
        private int _bookSellObj;
        public int bookSellObj
        {
            get { return _bookSellObj; }
            set { _bookSellObj = value; }
        }

        /*�����û�*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*�������*/
        private float _price;
        public float price
        {
            get { return _price; }
            set { _price = value; }
        }

        /*�û���ע*/
        private string _orderMemo;
        public string orderMemo
        {
            get { return _orderMemo; }
            set { _orderMemo = value; }
        }

        /*�µ�ʱ��*/
        private DateTime _addTime;
        public DateTime addTime
        {
            get { return _addTime; }
            set { _addTime = value; }
        }

    }
}
