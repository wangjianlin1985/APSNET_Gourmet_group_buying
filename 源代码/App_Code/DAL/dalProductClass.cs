using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*��Ʒ���ҵ���߼���ʵ��*/
    public class dalProductClass
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*�����Ʒ���ʵ��*/
        public static bool AddProductClass(ENTITY.ProductClass productClass)
        {
            string sql = "insert into ProductClass(className,classDesc) values(@className,@classDesc)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@className",SqlDbType.VarChar),
             new SqlParameter("@classDesc",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = productClass.className; //�������
            parm[1].Value = productClass.classDesc; //�������

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����classId��ȡĳ����Ʒ����¼*/
        public static ENTITY.ProductClass getSomeProductClass(int classId)
        {
            /*������ѯsql*/
            string sql = "select * from ProductClass where classId=" + classId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.ProductClass productClass = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                productClass = new ENTITY.ProductClass();
                productClass.classId = Convert.ToInt32(DataRead["classId"]);
                productClass.className = DataRead["className"].ToString();
                productClass.classDesc = DataRead["classDesc"].ToString();
            }
            return productClass;
        }

        /*������Ʒ���ʵ��*/
        public static bool EditProductClass(ENTITY.ProductClass productClass)
        {
            string sql = "update ProductClass set className=@className,classDesc=@classDesc where classId=@classId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@className",SqlDbType.VarChar),
             new SqlParameter("@classDesc",SqlDbType.VarChar),
             new SqlParameter("@classId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = productClass.className;
            parm[1].Value = productClass.classDesc;
            parm[2].Value = productClass.classId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ����Ʒ���*/
        public static bool DelProductClass(string p)
        {
            string sql = "delete from ProductClass where classId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ��Ʒ���*/
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

        /*��ѯ��Ʒ���*/
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
