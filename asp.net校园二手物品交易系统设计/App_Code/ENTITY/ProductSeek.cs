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
    ///ProductSeek ��ժҪ˵������Ʒ��ʵ��
    /// </summary>

    public class ProductSeek
    {
        /*��id*/
        private int _seekId;
        public int seekId
        {
            get { return _seekId; }
            set { _seekId = value; }
        }

        /*��Ʒ����*/
        private string _productName;
        public string productName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        /*��Ʒ���*/
        private int _productClassObj;
        public int productClassObj
        {
            get { return _productClassObj; }
            set { _productClassObj = value; }
        }

        /*��Ʒ��ͼ*/
        private string _productPhoto;
        public string productPhoto
        {
            get { return _productPhoto; }
            set { _productPhoto = value; }
        }

        /*�󹺼۸�*/
        private float _price;
        public float price
        {
            get { return _price; }
            set { _price = value; }
        }

        /*�¾ɳ̶�*/
        private int _xjcdObj;
        public int xjcdObj
        {
            get { return _xjcdObj; }
            set { _xjcdObj = value; }
        }

        /*��˵��*/
        private string _seekDesc;
        public string seekDesc
        {
            get { return _seekDesc; }
            set { _seekDesc = value; }
        }

        /*�����û�*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*����ʱ��*/
        private DateTime _addTime;
        public DateTime addTime
        {
            get { return _addTime; }
            set { _addTime = value; }
        }

    }
}
