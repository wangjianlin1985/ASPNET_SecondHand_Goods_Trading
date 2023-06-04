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
    public class dalProductClass
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*�����Ʒ����ʵ��*/
        public static bool AddProductClass(ENTITY.ProductClass productClass)
        {
            string sql = "insert into ProductClass(productClassName) values(@productClassName)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@productClassName",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = productClass.productClassName; //�������

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����productClassId��ȡĳ����Ʒ�����¼*/
        public static ENTITY.ProductClass getSomeProductClass(int productClassId)
        {
            /*������ѯsql*/
            string sql = "select * from ProductClass where productClassId=" + productClassId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.ProductClass productClass = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                productClass = new ENTITY.ProductClass();
                productClass.productClassId = Convert.ToInt32(DataRead["productClassId"]);
                productClass.productClassName = DataRead["productClassName"].ToString();
            }
            return productClass;
        }

        /*������Ʒ����ʵ��*/
        public static bool EditProductClass(ENTITY.ProductClass productClass)
        {
            string sql = "update ProductClass set productClassName=@productClassName where productClassId=@productClassId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@productClassName",SqlDbType.VarChar),
             new SqlParameter("@productClassId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = productClass.productClassName;
            parm[1].Value = productClass.productClassId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ����Ʒ����*/
        public static bool DelProductClass(string p)
        {
            string sql = "delete from ProductClass where productClassId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ��Ʒ����*/
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

        /*��ѯ��Ʒ����*/
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
