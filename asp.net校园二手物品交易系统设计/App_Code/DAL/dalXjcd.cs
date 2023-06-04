using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*�¾ɳ̶�ҵ���߼���ʵ��*/
    public class dalXjcd
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*����¾ɳ̶�ʵ��*/
        public static bool AddXjcd(ENTITY.Xjcd xjcd)
        {
            string sql = "insert into Xjcd(xjcdName) values(@xjcdName)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@xjcdName",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = xjcd.xjcdName; //�¾ɳ̶�

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����xjcdId��ȡĳ���¾ɳ̶ȼ�¼*/
        public static ENTITY.Xjcd getSomeXjcd(int xjcdId)
        {
            /*������ѯsql*/
            string sql = "select * from Xjcd where xjcdId=" + xjcdId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Xjcd xjcd = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                xjcd = new ENTITY.Xjcd();
                xjcd.xjcdId = Convert.ToInt32(DataRead["xjcdId"]);
                xjcd.xjcdName = DataRead["xjcdName"].ToString();
            }
            return xjcd;
        }

        /*�����¾ɳ̶�ʵ��*/
        public static bool EditXjcd(ENTITY.Xjcd xjcd)
        {
            string sql = "update Xjcd set xjcdName=@xjcdName where xjcdId=@xjcdId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@xjcdName",SqlDbType.VarChar),
             new SqlParameter("@xjcdId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = xjcd.xjcdName;
            parm[1].Value = xjcd.xjcdId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ���¾ɳ̶�*/
        public static bool DelXjcd(string p)
        {
            string sql = "delete from Xjcd where xjcdId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ�¾ɳ̶�*/
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

        /*��ѯ�¾ɳ̶�*/
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
