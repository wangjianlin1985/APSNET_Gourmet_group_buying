using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*商品评论业务逻辑层实现*/
    public class dalProductComment
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加商品评论实现*/
        public static bool AddProductComment(ENTITY.ProductComment productComment)
        {
            string sql = "insert into ProductComment(productObj,content,userObj,commentTime) values(@productObj,@content,@userObj,@commentTime)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@productObj",SqlDbType.Int),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@commentTime",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = productComment.productObj; //被评商品
            parm[1].Value = productComment.content; //评论内容
            parm[2].Value = productComment.userObj; //评论用户
            parm[3].Value = productComment.commentTime; //评论时间

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据commentId获取某条商品评论记录*/
        public static ENTITY.ProductComment getSomeProductComment(int commentId)
        {
            /*构建查询sql*/
            string sql = "select * from ProductComment where commentId=" + commentId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.ProductComment productComment = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                productComment = new ENTITY.ProductComment();
                productComment.commentId = Convert.ToInt32(DataRead["commentId"]);
                productComment.productObj = Convert.ToInt32(DataRead["productObj"]);
                productComment.content = DataRead["content"].ToString();
                productComment.userObj = DataRead["userObj"].ToString();
                productComment.commentTime = DataRead["commentTime"].ToString();
            }
            return productComment;
        }

        /*更新商品评论实现*/
        public static bool EditProductComment(ENTITY.ProductComment productComment)
        {
            string sql = "update ProductComment set productObj=@productObj,content=@content,userObj=@userObj,commentTime=@commentTime where commentId=@commentId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@productObj",SqlDbType.Int),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@commentTime",SqlDbType.VarChar),
             new SqlParameter("@commentId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = productComment.productObj;
            parm[1].Value = productComment.content;
            parm[2].Value = productComment.userObj;
            parm[3].Value = productComment.commentTime;
            parm[4].Value = productComment.commentId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除商品评论*/
        public static bool DelProductComment(string p)
        {
            string sql = "delete from ProductComment where commentId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询商品评论*/
        public static DataSet GetProductComment(string strWhere)
        {
            try
            {
                string strSql = "select * from ProductComment" + strWhere + " order by commentId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询商品评论*/
        public static System.Data.DataTable GetProductComment(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from ProductComment";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "commentId", strShow, strSql, strWhere, " commentId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllProductComment()
        {
            try
            {
                string strSql = "select * from ProductComment";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
