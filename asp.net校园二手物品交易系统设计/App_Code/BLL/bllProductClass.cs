using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*��Ʒ����ҵ���߼���*/
    public class bllProductClass{
        /*�����Ʒ����*/
        public static bool AddProductClass(ENTITY.ProductClass productClass)
        {
            return DAL.dalProductClass.AddProductClass(productClass);
        }

        /*����productClassId��ȡĳ����Ʒ�����¼*/
        public static ENTITY.ProductClass getSomeProductClass(int productClassId)
        {
            return DAL.dalProductClass.getSomeProductClass(productClassId);
        }

        /*������Ʒ����*/
        public static bool EditProductClass(ENTITY.ProductClass productClass)
        {
            return DAL.dalProductClass.EditProductClass(productClass);
        }

        /*ɾ����Ʒ����*/
        public static bool DelProductClass(string p)
        {
            return DAL.dalProductClass.DelProductClass(p);
        }

        /*��ѯ��Ʒ����*/
        public static System.Data.DataSet GetProductClass(string strWhere)
        {
            return DAL.dalProductClass.GetProductClass(strWhere);
        }

        /*����������ҳ��ѯ��Ʒ����*/
        public static System.Data.DataTable GetProductClass(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalProductClass.GetProductClass(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е���Ʒ����*/
        public static System.Data.DataSet getAllProductClass()
        {
            return DAL.dalProductClass.getAllProductClass();
        }
    }
}
