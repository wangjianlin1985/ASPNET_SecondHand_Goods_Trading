using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*��Ʒ��ҵ���߼���ʵ��*/
    public class dalProductSeek
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*�����Ʒ��ʵ��*/
        public static bool AddProductSeek(ENTITY.ProductSeek productSeek)
        {
            string sql = "insert into ProductSeek(productName,productClassObj,productPhoto,price,xjcdObj,seekDesc,userObj,addTime) values(@productName,@productClassObj,@productPhoto,@price,@xjcdObj,@seekDesc,@userObj,@addTime)";
            /*����sql����*/
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
            /*��������ֵ*/
            parm[0].Value = productSeek.productName; //��Ʒ����
            parm[1].Value = productSeek.productClassObj; //��Ʒ���
            parm[2].Value = productSeek.productPhoto; //��Ʒ��ͼ
            parm[3].Value = productSeek.price; //�󹺼۸�
            parm[4].Value = productSeek.xjcdObj; //�¾ɳ̶�
            parm[5].Value = productSeek.seekDesc; //��˵��
            parm[6].Value = productSeek.userObj; //�����û�
            parm[7].Value = productSeek.addTime; //����ʱ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����seekId��ȡĳ����Ʒ�󹺼�¼*/
        public static ENTITY.ProductSeek getSomeProductSeek(int seekId)
        {
            /*������ѯsql*/
            string sql = "select * from ProductSeek where seekId=" + seekId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.ProductSeek productSeek = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*������Ʒ��ʵ��*/
        public static bool EditProductSeek(ENTITY.ProductSeek productSeek)
        {
            string sql = "update ProductSeek set productName=@productName,productClassObj=@productClassObj,productPhoto=@productPhoto,price=@price,xjcdObj=@xjcdObj,seekDesc=@seekDesc,userObj=@userObj,addTime=@addTime where seekId=@seekId";
            /*����sql������Ϣ*/
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
            /*Ϊ������ֵ*/
            parm[0].Value = productSeek.productName;
            parm[1].Value = productSeek.productClassObj;
            parm[2].Value = productSeek.productPhoto;
            parm[3].Value = productSeek.price;
            parm[4].Value = productSeek.xjcdObj;
            parm[5].Value = productSeek.seekDesc;
            parm[6].Value = productSeek.userObj;
            parm[7].Value = productSeek.addTime;
            parm[8].Value = productSeek.seekId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ����Ʒ��*/
        public static bool DelProductSeek(string p)
        {
            string sql = "delete from ProductSeek where seekId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ��Ʒ��*/
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

        /*��ѯ��Ʒ��*/
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
