using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*商品出售业务逻辑层*/
    public class bllProductSell{
        /*添加商品出售*/
        public static bool AddProductSell(ENTITY.ProductSell productSell)
        {
            return DAL.dalProductSell.AddProductSell(productSell);
        }

        /*根据sellId获取某条商品出售记录*/
        public static ENTITY.ProductSell getSomeProductSell(int sellId)
        {
            return DAL.dalProductSell.getSomeProductSell(sellId);
        }

        /*更新商品出售*/
        public static bool EditProductSell(ENTITY.ProductSell productSell)
        {
            return DAL.dalProductSell.EditProductSell(productSell);
        }

        /*删除商品出售*/
        public static bool DelProductSell(string p)
        {
            return DAL.dalProductSell.DelProductSell(p);
        }

        /*查询商品出售*/
        public static System.Data.DataSet GetProductSell(string strWhere)
        {
            return DAL.dalProductSell.GetProductSell(strWhere);
        }

        /*根据条件分页查询商品出售*/
        public static System.Data.DataTable GetProductSell(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalProductSell.GetProductSell(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的商品出售*/
        public static System.Data.DataSet getAllProductSell()
        {
            return DAL.dalProductSell.getAllProductSell();
        }
    }
}
