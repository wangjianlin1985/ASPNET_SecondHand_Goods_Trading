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
    public class dalProductSell
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*�����Ʒ����ʵ��*/
        public static bool AddProductSell(ENTITY.ProductSell productSell)
        {
            string sql = "insert into ProductSell(productName,productClassObj,productPhoto,sellPrice,xjcdObj,sellDesc,userObj,addTime) values(@productName,@productClassObj,@productPhoto,@sellPrice,@xjcdObj,@sellDesc,@userObj,@addTime)";
            /*����sql����*/
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
            /*��������ֵ*/
            parm[0].Value = productSell.productName; //��Ʒ����
            parm[1].Value = productSell.productClassObj; //��Ʒ����
            parm[2].Value = productSell.productPhoto; //ͼ����ͼ
            parm[3].Value = productSell.sellPrice; //���ۼ۸�
            parm[4].Value = productSell.xjcdObj; //�¾ɳ̶�
            parm[5].Value = productSell.sellDesc; //����˵��
            parm[6].Value = productSell.userObj; //�����û�
            parm[7].Value = productSell.addTime; //����ʱ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����sellId��ȡĳ����Ʒ���ۼ�¼*/
        public static ENTITY.ProductSell getSomeProductSell(int sellId)
        {
            /*������ѯsql*/
            string sql = "select * from ProductSell where sellId=" + sellId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.ProductSell productSell = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*������Ʒ����ʵ��*/
        public static bool EditProductSell(ENTITY.ProductSell productSell)
        {
            string sql = "update ProductSell set productName=@productName,productClassObj=@productClassObj,productPhoto=@productPhoto,sellPrice=@sellPrice,xjcdObj=@xjcdObj,sellDesc=@sellDesc,userObj=@userObj,addTime=@addTime where sellId=@sellId";
            /*����sql������Ϣ*/
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
            /*Ϊ������ֵ*/
            parm[0].Value = productSell.productName;
            parm[1].Value = productSell.productClassObj;
            parm[2].Value = productSell.productPhoto;
            parm[3].Value = productSell.sellPrice;
            parm[4].Value = productSell.xjcdObj;
            parm[5].Value = productSell.sellDesc;
            parm[6].Value = productSell.userObj;
            parm[7].Value = productSell.addTime;
            parm[8].Value = productSell.sellId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ����Ʒ����*/
        public static bool DelProductSell(string p)
        {
            string sql = "delete from ProductSell where sellId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ��Ʒ����*/
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

        /*��ѯ��Ʒ����*/
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
