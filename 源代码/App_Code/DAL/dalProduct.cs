using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*��Ʒҵ���߼���ʵ��*/
    public class dalProduct
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*�����Ʒʵ��*/
        public static bool AddProduct(ENTITY.Product product)
        {
            string sql = "insert into Product(productClassObj,productName,mainPhoto,price,productCount,productDesc,sellerObj,areaObj,addTime) values(@productClassObj,@productName,@mainPhoto,@price,@productCount,@productDesc,@sellerObj,@areaObj,@addTime)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@productClassObj",SqlDbType.Int),
             new SqlParameter("@productName",SqlDbType.VarChar),
             new SqlParameter("@mainPhoto",SqlDbType.VarChar),
             new SqlParameter("@price",SqlDbType.Float),
             new SqlParameter("@productCount",SqlDbType.Int),
             new SqlParameter("@productDesc",SqlDbType.VarChar),
             new SqlParameter("@sellerObj",SqlDbType.VarChar),
             new SqlParameter("@areaObj",SqlDbType.Int),
             new SqlParameter("@addTime",SqlDbType.DateTime)
            };
            /*��������ֵ*/
            parm[0].Value = product.productClassObj; //��Ʒ���
            parm[1].Value = product.productName; //��Ʒ����
            parm[2].Value = product.mainPhoto; //��Ʒ��ͼ
            parm[3].Value = product.price; //��Ʒ�۸�
            parm[4].Value = product.productCount; //��Ʒ���
            parm[5].Value = product.productDesc; //��Ʒ����
            parm[6].Value = product.sellerObj; //�������̼�
            parm[7].Value = product.areaObj; //��������
            parm[8].Value = product.addTime; //����ʱ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����productId��ȡĳ����Ʒ��¼*/
        public static ENTITY.Product getSomeProduct(int productId)
        {
            /*������ѯsql*/
            string sql = "select * from Product where productId=" + productId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Product product = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                product = new ENTITY.Product();
                product.productId = Convert.ToInt32(DataRead["productId"]);
                product.productClassObj = Convert.ToInt32(DataRead["productClassObj"]);
                product.productName = DataRead["productName"].ToString();
                product.mainPhoto = DataRead["mainPhoto"].ToString();
                product.price = float.Parse(DataRead["price"].ToString());
                product.productCount = Convert.ToInt32(DataRead["productCount"]);
                product.productDesc = DataRead["productDesc"].ToString();
                product.sellerObj = DataRead["sellerObj"].ToString();
                product.areaObj = Convert.ToInt32(DataRead["areaObj"]);
                product.addTime = Convert.ToDateTime(DataRead["addTime"].ToString());
            }
            return product;
        }

        /*������Ʒʵ��*/
        public static bool EditProduct(ENTITY.Product product)
        {
            string sql = "update Product set productClassObj=@productClassObj,productName=@productName,mainPhoto=@mainPhoto,price=@price,productCount=@productCount,productDesc=@productDesc,sellerObj=@sellerObj,areaObj=@areaObj,addTime=@addTime where productId=@productId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@productClassObj",SqlDbType.Int),
             new SqlParameter("@productName",SqlDbType.VarChar),
             new SqlParameter("@mainPhoto",SqlDbType.VarChar),
             new SqlParameter("@price",SqlDbType.Float),
             new SqlParameter("@productCount",SqlDbType.Int),
             new SqlParameter("@productDesc",SqlDbType.VarChar),
             new SqlParameter("@sellerObj",SqlDbType.VarChar),
             new SqlParameter("@areaObj",SqlDbType.Int),
             new SqlParameter("@addTime",SqlDbType.DateTime),
             new SqlParameter("@productId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = product.productClassObj;
            parm[1].Value = product.productName;
            parm[2].Value = product.mainPhoto;
            parm[3].Value = product.price;
            parm[4].Value = product.productCount;
            parm[5].Value = product.productDesc;
            parm[6].Value = product.sellerObj;
            parm[7].Value = product.areaObj;
            parm[8].Value = product.addTime;
            parm[9].Value = product.productId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ����Ʒ*/
        public static bool DelProduct(string p)
        {
            string sql = "delete from Product where productId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ��Ʒ*/
        public static DataSet GetProduct(string strWhere)
        {
            try
            {
                string strSql = "select * from Product" + strWhere + " order by productId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ��Ʒ*/
        public static System.Data.DataTable GetProduct(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Product";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "productId", strShow, strSql, strWhere, " productId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllProduct()
        {
            try
            {
                string strSql = "select * from Product";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
