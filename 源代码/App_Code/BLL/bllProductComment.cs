using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*��Ʒ����ҵ���߼���*/
    public class bllProductComment{
        /*�����Ʒ����*/
        public static bool AddProductComment(ENTITY.ProductComment productComment)
        {
            return DAL.dalProductComment.AddProductComment(productComment);
        }

        /*����commentId��ȡĳ����Ʒ���ۼ�¼*/
        public static ENTITY.ProductComment getSomeProductComment(int commentId)
        {
            return DAL.dalProductComment.getSomeProductComment(commentId);
        }

        /*������Ʒ����*/
        public static bool EditProductComment(ENTITY.ProductComment productComment)
        {
            return DAL.dalProductComment.EditProductComment(productComment);
        }

        /*ɾ����Ʒ����*/
        public static bool DelProductComment(string p)
        {
            return DAL.dalProductComment.DelProductComment(p);
        }

        /*��ѯ��Ʒ����*/
        public static System.Data.DataSet GetProductComment(string strWhere)
        {
            return DAL.dalProductComment.GetProductComment(strWhere);
        }

        /*����������ҳ��ѯ��Ʒ����*/
        public static System.Data.DataTable GetProductComment(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalProductComment.GetProductComment(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е���Ʒ����*/
        public static System.Data.DataSet getAllProductComment()
        {
            return DAL.dalProductComment.getAllProductComment();
        }
    }
}
