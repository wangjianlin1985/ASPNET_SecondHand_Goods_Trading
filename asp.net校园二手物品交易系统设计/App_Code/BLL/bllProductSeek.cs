using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*��Ʒ��ҵ���߼���*/
    public class bllProductSeek{
        /*�����Ʒ��*/
        public static bool AddProductSeek(ENTITY.ProductSeek productSeek)
        {
            return DAL.dalProductSeek.AddProductSeek(productSeek);
        }

        /*����seekId��ȡĳ����Ʒ�󹺼�¼*/
        public static ENTITY.ProductSeek getSomeProductSeek(int seekId)
        {
            return DAL.dalProductSeek.getSomeProductSeek(seekId);
        }

        /*������Ʒ��*/
        public static bool EditProductSeek(ENTITY.ProductSeek productSeek)
        {
            return DAL.dalProductSeek.EditProductSeek(productSeek);
        }

        /*ɾ����Ʒ��*/
        public static bool DelProductSeek(string p)
        {
            return DAL.dalProductSeek.DelProductSeek(p);
        }

        /*��ѯ��Ʒ��*/
        public static System.Data.DataSet GetProductSeek(string strWhere)
        {
            return DAL.dalProductSeek.GetProductSeek(strWhere);
        }

        /*����������ҳ��ѯ��Ʒ��*/
        public static System.Data.DataTable GetProductSeek(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalProductSeek.GetProductSeek(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е���Ʒ��*/
        public static System.Data.DataSet getAllProductSeek()
        {
            return DAL.dalProductSeek.getAllProductSeek();
        }
    }
}
