using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*��Ʒ����ҵ���߼���*/
    public class bllProductOrder{
        /*�����Ʒ����*/
        public static bool AddProductOrder(ENTITY.ProductOrder productOrder)
        {
            return DAL.dalProductOrder.AddProductOrder(productOrder);
        }

        /*����orderId��ȡĳ����Ʒ������¼*/
        public static ENTITY.ProductOrder getSomeProductOrder(int orderId)
        {
            return DAL.dalProductOrder.getSomeProductOrder(orderId);
        }

        /*������Ʒ����*/
        public static bool EditProductOrder(ENTITY.ProductOrder productOrder)
        {
            return DAL.dalProductOrder.EditProductOrder(productOrder);
        }

        /*ɾ����Ʒ����*/
        public static bool DelProductOrder(string p)
        {
            return DAL.dalProductOrder.DelProductOrder(p);
        }

        /*��ѯ��Ʒ����*/
        public static System.Data.DataSet GetProductOrder(string strWhere)
        {
            return DAL.dalProductOrder.GetProductOrder(strWhere);
        }

        /*����������ҳ��ѯ��Ʒ����*/
        public static System.Data.DataTable GetProductOrder(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalProductOrder.GetProductOrder(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е���Ʒ����*/
        public static System.Data.DataSet getAllProductOrder()
        {
            return DAL.dalProductOrder.getAllProductOrder();
        }
    }
}
