using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*商品订单业务逻辑层实现*/
    public class dalProductOrder
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加商品订单实现*/
        public static bool AddProductOrder(ENTITY.ProductOrder productOrder)
        {
            string sql = "insert into ProductOrder(bookSellObj,userObj,price,orderMemo,addTime) values(@bookSellObj,@userObj,@price,@orderMemo,@addTime)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@bookSellObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@price",SqlDbType.Float),
             new SqlParameter("@orderMemo",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime)
            };
            /*给参数赋值*/
            parm[0].Value = productOrder.bookSellObj; //商品信息
            parm[1].Value = productOrder.userObj; //意向用户
            parm[2].Value = productOrder.price; //意向出价
            parm[3].Value = productOrder.orderMemo; //用户备注
            parm[4].Value = productOrder.addTime; //下单时间

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据orderId获取某条商品订单记录*/
        public static ENTITY.ProductOrder getSomeProductOrder(int orderId)
        {
            /*构建查询sql*/
            string sql = "select * from ProductOrder where orderId=" + orderId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.ProductOrder productOrder = null;
            /*如果查询存在记录，就包装到对象中返回*/
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

        /*更新商品订单实现*/
        public static bool EditProductOrder(ENTITY.ProductOrder productOrder)
        {
            string sql = "update ProductOrder set bookSellObj=@bookSellObj,userObj=@userObj,price=@price,orderMemo=@orderMemo,addTime=@addTime where orderId=@orderId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@bookSellObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@price",SqlDbType.Float),
             new SqlParameter("@orderMemo",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime),
             new SqlParameter("@orderId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = productOrder.bookSellObj;
            parm[1].Value = productOrder.userObj;
            parm[2].Value = productOrder.price;
            parm[3].Value = productOrder.orderMemo;
            parm[4].Value = productOrder.addTime;
            parm[5].Value = productOrder.orderId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除商品订单*/
        public static bool DelProductOrder(string p)
        {
            string sql = "delete from ProductOrder where orderId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询商品订单*/
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

        /*查询商品订单*/
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
