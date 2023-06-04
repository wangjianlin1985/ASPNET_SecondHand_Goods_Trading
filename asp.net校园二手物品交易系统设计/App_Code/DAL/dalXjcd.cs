using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*新旧程度业务逻辑层实现*/
    public class dalXjcd
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加新旧程度实现*/
        public static bool AddXjcd(ENTITY.Xjcd xjcd)
        {
            string sql = "insert into Xjcd(xjcdName) values(@xjcdName)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@xjcdName",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = xjcd.xjcdName; //新旧程度

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据xjcdId获取某条新旧程度记录*/
        public static ENTITY.Xjcd getSomeXjcd(int xjcdId)
        {
            /*构建查询sql*/
            string sql = "select * from Xjcd where xjcdId=" + xjcdId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Xjcd xjcd = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                xjcd = new ENTITY.Xjcd();
                xjcd.xjcdId = Convert.ToInt32(DataRead["xjcdId"]);
                xjcd.xjcdName = DataRead["xjcdName"].ToString();
            }
            return xjcd;
        }

        /*更新新旧程度实现*/
        public static bool EditXjcd(ENTITY.Xjcd xjcd)
        {
            string sql = "update Xjcd set xjcdName=@xjcdName where xjcdId=@xjcdId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@xjcdName",SqlDbType.VarChar),
             new SqlParameter("@xjcdId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = xjcd.xjcdName;
            parm[1].Value = xjcd.xjcdId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除新旧程度*/
        public static bool DelXjcd(string p)
        {
            string sql = "delete from Xjcd where xjcdId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询新旧程度*/
        public static DataSet GetXjcd(string strWhere)
        {
            try
            {
                string strSql = "select * from Xjcd" + strWhere + " order by xjcdId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询新旧程度*/
        public static System.Data.DataTable GetXjcd(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Xjcd";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "xjcdId", strShow, strSql, strWhere, " xjcdId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllXjcd()
        {
            try
            {
                string strSql = "select * from Xjcd";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
