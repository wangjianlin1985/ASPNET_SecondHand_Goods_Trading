using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*商品求购业务逻辑层*/
    public class bllProductSeek{
        /*添加商品求购*/
        public static bool AddProductSeek(ENTITY.ProductSeek productSeek)
        {
            return DAL.dalProductSeek.AddProductSeek(productSeek);
        }

        /*根据seekId获取某条商品求购记录*/
        public static ENTITY.ProductSeek getSomeProductSeek(int seekId)
        {
            return DAL.dalProductSeek.getSomeProductSeek(seekId);
        }

        /*更新商品求购*/
        public static bool EditProductSeek(ENTITY.ProductSeek productSeek)
        {
            return DAL.dalProductSeek.EditProductSeek(productSeek);
        }

        /*删除商品求购*/
        public static bool DelProductSeek(string p)
        {
            return DAL.dalProductSeek.DelProductSeek(p);
        }

        /*查询商品求购*/
        public static System.Data.DataSet GetProductSeek(string strWhere)
        {
            return DAL.dalProductSeek.GetProductSeek(strWhere);
        }

        /*根据条件分页查询商品求购*/
        public static System.Data.DataTable GetProductSeek(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalProductSeek.GetProductSeek(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的商品求购*/
        public static System.Data.DataSet getAllProductSeek()
        {
            return DAL.dalProductSeek.getAllProductSeek();
        }
    }
}
