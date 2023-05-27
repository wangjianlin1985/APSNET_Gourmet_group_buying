using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*��Ʒ�ղ�ҵ���߼���ʵ��*/
    public class dalCollection
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*�����Ʒ�ղ�ʵ��*/
        public static bool AddCollection(ENTITY.Collection collection)
        {
            string sql = "insert into Collection(productObj,userObj,collectionTime) values(@productObj,@userObj,@collectionTime)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@productObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@collectionTime",SqlDbType.DateTime)
            };
            /*��������ֵ*/
            parm[0].Value = collection.productObj; //���ղ���Ʒ
            parm[1].Value = collection.userObj; //�ղ��û�
            parm[2].Value = collection.collectionTime; //�ղ�ʱ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����collectionId��ȡĳ����Ʒ�ղؼ�¼*/
        public static ENTITY.Collection getSomeCollection(int collectionId)
        {
            /*������ѯsql*/
            string sql = "select * from Collection where collectionId=" + collectionId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Collection collection = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                collection = new ENTITY.Collection();
                collection.collectionId = Convert.ToInt32(DataRead["collectionId"]);
                collection.productObj = Convert.ToInt32(DataRead["productObj"]);
                collection.userObj = DataRead["userObj"].ToString();
                collection.collectionTime = Convert.ToDateTime(DataRead["collectionTime"].ToString());
            }
            return collection;
        }

        /*������Ʒ�ղ�ʵ��*/
        public static bool EditCollection(ENTITY.Collection collection)
        {
            string sql = "update Collection set productObj=@productObj,userObj=@userObj,collectionTime=@collectionTime where collectionId=@collectionId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@productObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@collectionTime",SqlDbType.DateTime),
             new SqlParameter("@collectionId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = collection.productObj;
            parm[1].Value = collection.userObj;
            parm[2].Value = collection.collectionTime;
            parm[3].Value = collection.collectionId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ����Ʒ�ղ�*/
        public static bool DelCollection(string p)
        {
            string sql = "delete from Collection where collectionId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ��Ʒ�ղ�*/
        public static DataSet GetCollection(string strWhere)
        {
            try
            {
                string strSql = "select * from Collection" + strWhere + " order by collectionId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ��Ʒ�ղ�*/
        public static System.Data.DataTable GetCollection(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Collection";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "collectionId", strShow, strSql, strWhere, " collectionId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllCollection()
        {
            try
            {
                string strSql = "select * from Collection";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
