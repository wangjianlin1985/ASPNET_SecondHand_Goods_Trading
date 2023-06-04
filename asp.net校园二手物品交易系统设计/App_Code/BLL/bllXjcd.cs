using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*新旧程度业务逻辑层*/
    public class bllXjcd{
        /*添加新旧程度*/
        public static bool AddXjcd(ENTITY.Xjcd xjcd)
        {
            return DAL.dalXjcd.AddXjcd(xjcd);
        }

        /*根据xjcdId获取某条新旧程度记录*/
        public static ENTITY.Xjcd getSomeXjcd(int xjcdId)
        {
            return DAL.dalXjcd.getSomeXjcd(xjcdId);
        }

        /*更新新旧程度*/
        public static bool EditXjcd(ENTITY.Xjcd xjcd)
        {
            return DAL.dalXjcd.EditXjcd(xjcd);
        }

        /*删除新旧程度*/
        public static bool DelXjcd(string p)
        {
            return DAL.dalXjcd.DelXjcd(p);
        }

        /*查询新旧程度*/
        public static System.Data.DataSet GetXjcd(string strWhere)
        {
            return DAL.dalXjcd.GetXjcd(strWhere);
        }

        /*根据条件分页查询新旧程度*/
        public static System.Data.DataTable GetXjcd(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalXjcd.GetXjcd(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的新旧程度*/
        public static System.Data.DataSet getAllXjcd()
        {
            return DAL.dalXjcd.getAllXjcd();
        }
    }
}
