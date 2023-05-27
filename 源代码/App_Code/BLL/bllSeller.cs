using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*商家业务逻辑层*/
    public class bllSeller{
        /*添加商家*/
        public static bool AddSeller(ENTITY.Seller seller)
        {
            return DAL.dalSeller.AddSeller(seller);
        }

        /*根据sellerUserName获取某条商家记录*/
        public static ENTITY.Seller getSomeSeller(string sellerUserName)
        {
            return DAL.dalSeller.getSomeSeller(sellerUserName);
        }

        /*更新商家*/
        public static bool EditSeller(ENTITY.Seller seller)
        {
            return DAL.dalSeller.EditSeller(seller);
        }

        /*删除商家*/
        public static bool DelSeller(string p)
        {
            return DAL.dalSeller.DelSeller(p);
        }

        /*查询商家*/
        public static System.Data.DataSet GetSeller(string strWhere)
        {
            return DAL.dalSeller.GetSeller(strWhere);
        }

        /*根据条件分页查询商家*/
        public static System.Data.DataTable GetSeller(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalSeller.GetSeller(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的商家*/
        public static System.Data.DataSet getAllSeller()
        {
            return DAL.dalSeller.getAllSeller();
        }
    }
}
