using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*商品类别业务逻辑层实现*/
    public class dalProductClass
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加商品类别实现*/
        public static bool AddProductClass(ENTITY.ProductClass productClass)
        {
            string sql = "insert into ProductClass(className,classDesc) values(@className,@classDesc)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@className",SqlDbType.VarChar),
             new SqlParameter("@classDesc",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = productClass.className; //类别名称
            parm[1].Value = productClass.classDesc; //类别描述

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据classId获取某条商品类别记录*/
        public static ENTITY.ProductClass getSomeProductClass(int classId)
        {
            /*构建查询sql*/
            string sql = "select * from ProductClass where classId=" + classId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.ProductClass productClass = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                productClass = new ENTITY.ProductClass();
                productClass.classId = Convert.ToInt32(DataRead["classId"]);
                productClass.className = DataRead["className"].ToString();
                productClass.classDesc = DataRead["classDesc"].ToString();
            }
            return productClass;
        }

        /*更新商品类别实现*/
        public static bool EditProductClass(ENTITY.ProductClass productClass)
        {
            string sql = "update ProductClass set className=@className,classDesc=@classDesc where classId=@classId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@className",SqlDbType.VarChar),
             new SqlParameter("@classDesc",SqlDbType.VarChar),
             new SqlParameter("@classId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = productClass.className;
            parm[1].Value = productClass.classDesc;
            parm[2].Value = productClass.classId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除商品类别*/
        public static bool DelProductClass(string p)
        {
            string sql = "delete from ProductClass where classId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询商品类别*/
        public static DataSet GetProductClass(string strWhere)
        {
            try
            {
                string strSql = "select * from ProductClass" + strWhere + " order by classId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询商品类别*/
        public static System.Data.DataTable GetProductClass(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from ProductClass";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "classId", strShow, strSql, strWhere, " classId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllProductClass()
        {
            try
            {
                string strSql = "select * from ProductClass";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
