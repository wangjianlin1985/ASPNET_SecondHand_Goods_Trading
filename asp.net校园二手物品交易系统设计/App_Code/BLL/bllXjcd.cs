using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*�¾ɳ̶�ҵ���߼���*/
    public class bllXjcd{
        /*����¾ɳ̶�*/
        public static bool AddXjcd(ENTITY.Xjcd xjcd)
        {
            return DAL.dalXjcd.AddXjcd(xjcd);
        }

        /*����xjcdId��ȡĳ���¾ɳ̶ȼ�¼*/
        public static ENTITY.Xjcd getSomeXjcd(int xjcdId)
        {
            return DAL.dalXjcd.getSomeXjcd(xjcdId);
        }

        /*�����¾ɳ̶�*/
        public static bool EditXjcd(ENTITY.Xjcd xjcd)
        {
            return DAL.dalXjcd.EditXjcd(xjcd);
        }

        /*ɾ���¾ɳ̶�*/
        public static bool DelXjcd(string p)
        {
            return DAL.dalXjcd.DelXjcd(p);
        }

        /*��ѯ�¾ɳ̶�*/
        public static System.Data.DataSet GetXjcd(string strWhere)
        {
            return DAL.dalXjcd.GetXjcd(strWhere);
        }

        /*����������ҳ��ѯ�¾ɳ̶�*/
        public static System.Data.DataTable GetXjcd(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalXjcd.GetXjcd(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е��¾ɳ̶�*/
        public static System.Data.DataSet getAllXjcd()
        {
            return DAL.dalXjcd.getAllXjcd();
        }
    }
}
