using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*��Ʒ����ҵ���߼���*/
    public class bllProductSell{
        /*�����Ʒ����*/
        public static bool AddProductSell(ENTITY.ProductSell productSell)
        {
            return DAL.dalProductSell.AddProductSell(productSell);
        }

        /*����sellId��ȡĳ����Ʒ���ۼ�¼*/
        public static ENTITY.ProductSell getSomeProductSell(int sellId)
        {
            return DAL.dalProductSell.getSomeProductSell(sellId);
        }

        /*������Ʒ����*/
        public static bool EditProductSell(ENTITY.ProductSell productSell)
        {
            return DAL.dalProductSell.EditProductSell(productSell);
        }

        /*ɾ����Ʒ����*/
        public static bool DelProductSell(string p)
        {
            return DAL.dalProductSell.DelProductSell(p);
        }

        /*��ѯ��Ʒ����*/
        public static System.Data.DataSet GetProductSell(string strWhere)
        {
            return DAL.dalProductSell.GetProductSell(strWhere);
        }

        /*����������ҳ��ѯ��Ʒ����*/
        public static System.Data.DataTable GetProductSell(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalProductSell.GetProductSell(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е���Ʒ����*/
        public static System.Data.DataSet getAllProductSell()
        {
            return DAL.dalProductSell.getAllProductSell();
        }
    }
}
