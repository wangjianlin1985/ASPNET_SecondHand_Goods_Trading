using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*商品分类业务逻辑层实现*/
    public class dalProductClass
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加商品分类实现*/
        public static bool AddProductClass(ENTITY.ProductClass productClass)
        {
            string sql = "insert into ProductClass(productClassName) values(@productClassName)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@productClassName",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = productClass.productClassName; //类别名称

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据productClassId获取某条商品分类记录*/
        public static ENTITY.ProductClass getSomeProductClass(int productClassId)
        {
            /*构建查询sql*/
            string sql = "select * from ProductClass where productClassId=" + productClassId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.ProductClass productClass = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                productClass = new ENTITY.ProductClass();
                productClass.productClassId = Convert.ToInt32(DataRead["productClassId"]);
                productClass.productClassName = DataRead["productClassName"].ToString();
            }
            return productClass;
        }

        /*更新商品分类实现*/
        public static bool EditProductClass(ENTITY.ProductClass productClass)
        {
            string sql = "update ProductClass set productClassName=@productClassName where productClassId=@productClassId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@productClassName",SqlDbType.VarChar),
             new SqlParameter("@productClassId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = productClass.productClassName;
            parm[1].Value = productClass.productClassId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除商品分类*/
        public static bool DelProductClass(string p)
        {
            string sql = "delete from ProductClass where productClassId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询商品分类*/
        public static DataSet GetProductClass(string strWhere)
        {
            try
            {
                string strSql = "select * from ProductClass" + strWhere + " order by productClassId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询商品分类*/
        public static System.Data.DataTable GetProductClass(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from ProductClass";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "productClassId", strShow, strSql, strWhere, " productClassId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllProductClass()
        {
            try
            {
                string strSql = "select * from ProductClass";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
