using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*商品评论业务逻辑层*/
    public class bllProductComment{
        /*添加商品评论*/
        public static bool AddProductComment(ENTITY.ProductComment productComment)
        {
            return DAL.dalProductComment.AddProductComment(productComment);
        }

        /*根据commentId获取某条商品评论记录*/
        public static ENTITY.ProductComment getSomeProductComment(int commentId)
        {
            return DAL.dalProductComment.getSomeProductComment(commentId);
        }

        /*更新商品评论*/
        public static bool EditProductComment(ENTITY.ProductComment productComment)
        {
            return DAL.dalProductComment.EditProductComment(productComment);
        }

        /*删除商品评论*/
        public static bool DelProductComment(string p)
        {
            return DAL.dalProductComment.DelProductComment(p);
        }

        /*查询商品评论*/
        public static System.Data.DataSet GetProductComment(string strWhere)
        {
            return DAL.dalProductComment.GetProductComment(strWhere);
        }

        /*根据条件分页查询商品评论*/
        public static System.Data.DataTable GetProductComment(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalProductComment.GetProductComment(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的商品评论*/
        public static System.Data.DataSet getAllProductComment()
        {
            return DAL.dalProductComment.getAllProductComment();
        }
    }
}
