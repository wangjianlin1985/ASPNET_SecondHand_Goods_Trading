using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*��Ʒ����ҵ���߼���ʵ��*/
    public class dalProductOrder
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*�����Ʒ����ʵ��*/
        public static bool AddProductOrder(ENTITY.ProductOrder productOrder)
        {
            string sql = "insert into ProductOrder(bookSellObj,userObj,price,orderMemo,addTime) values(@bookSellObj,@userObj,@price,@orderMemo,@addTime)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@bookSellObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@price",SqlDbType.Float),
             new SqlParameter("@orderMemo",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime)
            };
            /*��������ֵ*/
            parm[0].Value = productOrder.bookSellObj; //��Ʒ��Ϣ
            parm[1].Value = productOrder.userObj; //�����û�
            parm[2].Value = productOrder.price; //�������
            parm[3].Value = productOrder.orderMemo; //�û���ע
            parm[4].Value = productOrder.addTime; //�µ�ʱ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����orderId��ȡĳ����Ʒ������¼*/
        public static ENTITY.ProductOrder getSomeProductOrder(int orderId)
        {
            /*������ѯsql*/
            string sql = "select * from ProductOrder where orderId=" + orderId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.ProductOrder productOrder = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                productOrder = new ENTITY.ProductOrder();
                productOrder.orderId = Convert.ToInt32(DataRead["orderId"]);
                productOrder.bookSellObj = Convert.ToInt32(DataRead["bookSellObj"]);
                productOrder.userObj = DataRead["userObj"].ToString();
                productOrder.price = float.Parse(DataRead["price"].ToString());
                productOrder.orderMemo = DataRead["orderMemo"].ToString();
                productOrder.addTime = Convert.ToDateTime(DataRead["addTime"].ToString());
            }
            return productOrder;
        }

        /*������Ʒ����ʵ��*/
        public static bool EditProductOrder(ENTITY.ProductOrder productOrder)
        {
            string sql = "update ProductOrder set bookSellObj=@bookSellObj,userObj=@userObj,price=@price,orderMemo=@orderMemo,addTime=@addTime where orderId=@orderId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@bookSellObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@price",SqlDbType.Float),
             new SqlParameter("@orderMemo",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime),
             new SqlParameter("@orderId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = productOrder.bookSellObj;
            parm[1].Value = productOrder.userObj;
            parm[2].Value = productOrder.price;
            parm[3].Value = productOrder.orderMemo;
            parm[4].Value = productOrder.addTime;
            parm[5].Value = productOrder.orderId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ����Ʒ����*/
        public static bool DelProductOrder(string p)
        {
            string sql = "delete from ProductOrder where orderId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ��Ʒ����*/
        public static DataSet GetProductOrder(string strWhere)
        {
            try
            {
                string strSql = "select * from ProductOrder" + strWhere + " order by orderId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ��Ʒ����*/
        public static System.Data.DataTable GetProductOrder(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from ProductOrder";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "orderId", strShow, strSql, strWhere, " orderId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllProductOrder()
        {
            try
            {
                string strSql = "select * from ProductOrder";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
