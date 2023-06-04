using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*商品求购业务逻辑层实现*/
    public class dalProductSeek
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加商品求购实现*/
        public static bool AddProductSeek(ENTITY.ProductSeek productSeek)
        {
            string sql = "insert into ProductSeek(productName,productClassObj,productPhoto,price,xjcdObj,seekDesc,userObj,addTime) values(@productName,@productClassObj,@productPhoto,@price,@xjcdObj,@seekDesc,@userObj,@addTime)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@productName",SqlDbType.VarChar),
             new SqlParameter("@productClassObj",SqlDbType.Int),
             new SqlParameter("@productPhoto",SqlDbType.VarChar),
             new SqlParameter("@price",SqlDbType.Float),
             new SqlParameter("@xjcdObj",SqlDbType.Int),
             new SqlParameter("@seekDesc",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime)
            };
            /*给参数赋值*/
            parm[0].Value = productSeek.productName; //商品名称
            parm[1].Value = productSeek.productClassObj; //商品类别
            parm[2].Value = productSeek.productPhoto; //商品主图
            parm[3].Value = productSeek.price; //求购价格
            parm[4].Value = productSeek.xjcdObj; //新旧程度
            parm[5].Value = productSeek.seekDesc; //求购说明
            parm[6].Value = productSeek.userObj; //发布用户
            parm[7].Value = productSeek.addTime; //发布时间

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据seekId获取某条商品求购记录*/
        public static ENTITY.ProductSeek getSomeProductSeek(int seekId)
        {
            /*构建查询sql*/
            string sql = "select * from ProductSeek where seekId=" + seekId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.ProductSeek productSeek = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                productSeek = new ENTITY.ProductSeek();
                productSeek.seekId = Convert.ToInt32(DataRead["seekId"]);
                productSeek.productName = DataRead["productName"].ToString();
                productSeek.productClassObj = Convert.ToInt32(DataRead["productClassObj"]);
                productSeek.productPhoto = DataRead["productPhoto"].ToString();
                productSeek.price = float.Parse(DataRead["price"].ToString());
                productSeek.xjcdObj = Convert.ToInt32(DataRead["xjcdObj"]);
                productSeek.seekDesc = DataRead["seekDesc"].ToString();
                productSeek.userObj = DataRead["userObj"].ToString();
                productSeek.addTime = Convert.ToDateTime(DataRead["addTime"].ToString());
            }
            return productSeek;
        }

        /*更新商品求购实现*/
        public static bool EditProductSeek(ENTITY.ProductSeek productSeek)
        {
            string sql = "update ProductSeek set productName=@productName,productClassObj=@productClassObj,productPhoto=@productPhoto,price=@price,xjcdObj=@xjcdObj,seekDesc=@seekDesc,userObj=@userObj,addTime=@addTime where seekId=@seekId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@productName",SqlDbType.VarChar),
             new SqlParameter("@productClassObj",SqlDbType.Int),
             new SqlParameter("@productPhoto",SqlDbType.VarChar),
             new SqlParameter("@price",SqlDbType.Float),
             new SqlParameter("@xjcdObj",SqlDbType.Int),
             new SqlParameter("@seekDesc",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime),
             new SqlParameter("@seekId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = productSeek.productName;
            parm[1].Value = productSeek.productClassObj;
            parm[2].Value = productSeek.productPhoto;
            parm[3].Value = productSeek.price;
            parm[4].Value = productSeek.xjcdObj;
            parm[5].Value = productSeek.seekDesc;
            parm[6].Value = productSeek.userObj;
            parm[7].Value = productSeek.addTime;
            parm[8].Value = productSeek.seekId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除商品求购*/
        public static bool DelProductSeek(string p)
        {
            string sql = "delete from ProductSeek where seekId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询商品求购*/
        public static DataSet GetProductSeek(string strWhere)
        {
            try
            {
                string strSql = "select * from ProductSeek" + strWhere + " order by seekId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询商品求购*/
        public static System.Data.DataTable GetProductSeek(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from ProductSeek";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "seekId", strShow, strSql, strWhere, " seekId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllProductSeek()
        {
            try
            {
                string strSql = "select * from ProductSeek";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
