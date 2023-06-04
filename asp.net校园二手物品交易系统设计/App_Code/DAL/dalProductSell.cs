using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*商品出售业务逻辑层实现*/
    public class dalProductSell
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加商品出售实现*/
        public static bool AddProductSell(ENTITY.ProductSell productSell)
        {
            string sql = "insert into ProductSell(productName,productClassObj,productPhoto,sellPrice,xjcdObj,sellDesc,userObj,addTime) values(@productName,@productClassObj,@productPhoto,@sellPrice,@xjcdObj,@sellDesc,@userObj,@addTime)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@productName",SqlDbType.VarChar),
             new SqlParameter("@productClassObj",SqlDbType.Int),
             new SqlParameter("@productPhoto",SqlDbType.VarChar),
             new SqlParameter("@sellPrice",SqlDbType.Float),
             new SqlParameter("@xjcdObj",SqlDbType.Int),
             new SqlParameter("@sellDesc",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime)
            };
            /*给参数赋值*/
            parm[0].Value = productSell.productName; //商品名称
            parm[1].Value = productSell.productClassObj; //商品分类
            parm[2].Value = productSell.productPhoto; //图书主图
            parm[3].Value = productSell.sellPrice; //出售价格
            parm[4].Value = productSell.xjcdObj; //新旧程度
            parm[5].Value = productSell.sellDesc; //出售说明
            parm[6].Value = productSell.userObj; //发布用户
            parm[7].Value = productSell.addTime; //发布时间

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据sellId获取某条商品出售记录*/
        public static ENTITY.ProductSell getSomeProductSell(int sellId)
        {
            /*构建查询sql*/
            string sql = "select * from ProductSell where sellId=" + sellId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.ProductSell productSell = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                productSell = new ENTITY.ProductSell();
                productSell.sellId = Convert.ToInt32(DataRead["sellId"]);
                productSell.productName = DataRead["productName"].ToString();
                productSell.productClassObj = Convert.ToInt32(DataRead["productClassObj"]);
                productSell.productPhoto = DataRead["productPhoto"].ToString();
                productSell.sellPrice = float.Parse(DataRead["sellPrice"].ToString());
                productSell.xjcdObj = Convert.ToInt32(DataRead["xjcdObj"]);
                productSell.sellDesc = DataRead["sellDesc"].ToString();
                productSell.userObj = DataRead["userObj"].ToString();
                productSell.addTime = Convert.ToDateTime(DataRead["addTime"].ToString());
            }
            return productSell;
        }

        /*更新商品出售实现*/
        public static bool EditProductSell(ENTITY.ProductSell productSell)
        {
            string sql = "update ProductSell set productName=@productName,productClassObj=@productClassObj,productPhoto=@productPhoto,sellPrice=@sellPrice,xjcdObj=@xjcdObj,sellDesc=@sellDesc,userObj=@userObj,addTime=@addTime where sellId=@sellId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@productName",SqlDbType.VarChar),
             new SqlParameter("@productClassObj",SqlDbType.Int),
             new SqlParameter("@productPhoto",SqlDbType.VarChar),
             new SqlParameter("@sellPrice",SqlDbType.Float),
             new SqlParameter("@xjcdObj",SqlDbType.Int),
             new SqlParameter("@sellDesc",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime),
             new SqlParameter("@sellId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = productSell.productName;
            parm[1].Value = productSell.productClassObj;
            parm[2].Value = productSell.productPhoto;
            parm[3].Value = productSell.sellPrice;
            parm[4].Value = productSell.xjcdObj;
            parm[5].Value = productSell.sellDesc;
            parm[6].Value = productSell.userObj;
            parm[7].Value = productSell.addTime;
            parm[8].Value = productSell.sellId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除商品出售*/
        public static bool DelProductSell(string p)
        {
            string sql = "delete from ProductSell where sellId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询商品出售*/
        public static DataSet GetProductSell(string strWhere)
        {
            try
            {
                string strSql = "select * from ProductSell" + strWhere + " order by sellId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询商品出售*/
        public static System.Data.DataTable GetProductSell(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from ProductSell";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "sellId", strShow, strSql, strWhere, " sellId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllProductSell()
        {
            try
            {
                string strSql = "select * from ProductSell";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
