using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*商品收藏业务逻辑层实现*/
    public class dalCollection
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加商品收藏实现*/
        public static bool AddCollection(ENTITY.Collection collection)
        {
            string sql = "insert into Collection(productObj,userObj,collectionTime) values(@productObj,@userObj,@collectionTime)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@productObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@collectionTime",SqlDbType.DateTime)
            };
            /*给参数赋值*/
            parm[0].Value = collection.productObj; //被收藏商品
            parm[1].Value = collection.userObj; //收藏用户
            parm[2].Value = collection.collectionTime; //收藏时间

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据collectionId获取某条商品收藏记录*/
        public static ENTITY.Collection getSomeCollection(int collectionId)
        {
            /*构建查询sql*/
            string sql = "select * from Collection where collectionId=" + collectionId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Collection collection = null;
            /*如果查询存在记录，就包装到对象中返回*/
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

        /*更新商品收藏实现*/
        public static bool EditCollection(ENTITY.Collection collection)
        {
            string sql = "update Collection set productObj=@productObj,userObj=@userObj,collectionTime=@collectionTime where collectionId=@collectionId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@productObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@collectionTime",SqlDbType.DateTime),
             new SqlParameter("@collectionId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = collection.productObj;
            parm[1].Value = collection.userObj;
            parm[2].Value = collection.collectionTime;
            parm[3].Value = collection.collectionId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除商品收藏*/
        public static bool DelCollection(string p)
        {
            string sql = "delete from Collection where collectionId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询商品收藏*/
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

        /*查询商品收藏*/
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
