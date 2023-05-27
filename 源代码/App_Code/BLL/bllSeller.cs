using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*�̼�ҵ���߼���*/
    public class bllSeller{
        /*����̼�*/
        public static bool AddSeller(ENTITY.Seller seller)
        {
            return DAL.dalSeller.AddSeller(seller);
        }

        /*����sellerUserName��ȡĳ���̼Ҽ�¼*/
        public static ENTITY.Seller getSomeSeller(string sellerUserName)
        {
            return DAL.dalSeller.getSomeSeller(sellerUserName);
        }

        /*�����̼�*/
        public static bool EditSeller(ENTITY.Seller seller)
        {
            return DAL.dalSeller.EditSeller(seller);
        }

        /*ɾ���̼�*/
        public static bool DelSeller(string p)
        {
            return DAL.dalSeller.DelSeller(p);
        }

        /*��ѯ�̼�*/
        public static System.Data.DataSet GetSeller(string strWhere)
        {
            return DAL.dalSeller.GetSeller(strWhere);
        }

        /*����������ҳ��ѯ�̼�*/
        public static System.Data.DataTable GetSeller(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalSeller.GetSeller(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е��̼�*/
        public static System.Data.DataSet getAllSeller()
        {
            return DAL.dalSeller.getAllSeller();
        }
    }
}
