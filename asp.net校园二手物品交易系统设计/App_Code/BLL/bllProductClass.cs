using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*商品分类业务逻辑层*/
    public class bllProductClass{
        /*添加商品分类*/
        public static bool AddProductClass(ENTITY.ProductClass productClass)
        {
            return DAL.dalProductClass.AddProductClass(productClass);
        }

        /*根据productClassId获取某条商品分类记录*/
        public static ENTITY.ProductClass getSomeProductClass(int productClassId)
        {
            return DAL.dalProductClass.getSomeProductClass(productClassId);
        }

        /*更新商品分类*/
        public static bool EditProductClass(ENTITY.ProductClass productClass)
        {
            return DAL.dalProductClass.EditProductClass(productClass);
        }

        /*删除商品分类*/
        public static bool DelProductClass(string p)
        {
            return DAL.dalProductClass.DelProductClass(p);
        }

        /*查询商品分类*/
        public static System.Data.DataSet GetProductClass(string strWhere)
        {
            return DAL.dalProductClass.GetProductClass(strWhere);
        }

        /*根据条件分页查询商品分类*/
        public static System.Data.DataTable GetProductClass(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalProductClass.GetProductClass(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的商品分类*/
        public static System.Data.DataSet getAllProductClass()
        {
            return DAL.dalProductClass.getAllProductClass();
        }
    }
}
