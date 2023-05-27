using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*��Ʒ����ҵ���߼���ʵ��*/
    public class dalProductComment
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*�����Ʒ����ʵ��*/
        public static bool AddProductComment(ENTITY.ProductComment productComment)
        {
            string sql = "insert into ProductComment(productObj,content,userObj,commentTime) values(@productObj,@content,@userObj,@commentTime)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@productObj",SqlDbType.Int),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@commentTime",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = productComment.productObj; //������Ʒ
            parm[1].Value = productComment.content; //��������
            parm[2].Value = productComment.userObj; //�����û�
            parm[3].Value = productComment.commentTime; //����ʱ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����commentId��ȡĳ����Ʒ���ۼ�¼*/
        public static ENTITY.ProductComment getSomeProductComment(int commentId)
        {
            /*������ѯsql*/
            string sql = "select * from ProductComment where commentId=" + commentId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.ProductComment productComment = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*������Ʒ����ʵ��*/
        public static bool EditProductComment(ENTITY.ProductComment productComment)
        {
            string sql = "update ProductComment set productObj=@productObj,content=@content,userObj=@userObj,commentTime=@commentTime where commentId=@commentId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@productObj",SqlDbType.Int),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@commentTime",SqlDbType.VarChar),
             new SqlParameter("@commentId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = productComment.productObj;
            parm[1].Value = productComment.content;
            parm[2].Value = productComment.userObj;
            parm[3].Value = productComment.commentTime;
            parm[4].Value = productComment.commentId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ����Ʒ����*/
        public static bool DelProductComment(string p)
        {
            string sql = "delete from ProductComment where commentId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ��Ʒ����*/
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

        /*��ѯ��Ʒ����*/
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
