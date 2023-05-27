using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*商家业务逻辑层实现*/
    public class dalSeller
    {
        /*待执行的sql语句*/
        public static string sql = "";


        public static bool ulogin(string sellerUserName,string password)
        {
            string sql = @"select sellerUserName from Seller where sellerUserName =@sellerUserName and password =@password";
            SqlParameter[] para = new SqlParameter[] { 
             new SqlParameter("@sellerUserName",SqlDbType.VarChar),
             new SqlParameter("@password",SqlDbType.VarChar)
           };
            para[0].Value = sellerUserName;
            para[1].Value = password;
            return (DBHelp.ExecuteScalar(sql, para) != null) ? true : false;
        }


        /*添加商家实现*/
        public static bool AddSeller(ENTITY.Seller seller)
        {
            string sql = "insert into Seller(sellerUserName,password,sellerName,sellerPhoto,sellerDesc,bornDate,telephone,email,areaObj,address,regTime) values(@sellerUserName,@password,@sellerName,@sellerPhoto,@sellerDesc,@bornDate,@telephone,@email,@areaObj,@address,@regTime)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@sellerUserName",SqlDbType.VarChar),
             new SqlParameter("@password",SqlDbType.VarChar),
             new SqlParameter("@sellerName",SqlDbType.VarChar),
             new SqlParameter("@sellerPhoto",SqlDbType.VarChar),
             new SqlParameter("@sellerDesc",SqlDbType.VarChar),
             new SqlParameter("@bornDate",SqlDbType.DateTime),
             new SqlParameter("@telephone",SqlDbType.VarChar),
             new SqlParameter("@email",SqlDbType.VarChar),
             new SqlParameter("@areaObj",SqlDbType.Int),
             new SqlParameter("@address",SqlDbType.VarChar),
             new SqlParameter("@regTime",SqlDbType.DateTime)
            };
            /*给参数赋值*/
            parm[0].Value = seller.sellerUserName; //商家用户名
            parm[1].Value = seller.password; //登录密码
            parm[2].Value = seller.sellerName; //商家名称
            parm[3].Value = seller.sellerPhoto; //商家照片
            parm[4].Value = seller.sellerDesc; //商家介绍
            parm[5].Value = seller.bornDate; //成立日期
            parm[6].Value = seller.telephone; //商家电话
            parm[7].Value = seller.email; //商家邮箱
            parm[8].Value = seller.areaObj; //所在区域
            parm[9].Value = seller.address; //商家地址
            parm[10].Value = seller.regTime; //注册时间

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据sellerUserName获取某条商家记录*/
        public static ENTITY.Seller getSomeSeller(string sellerUserName)
        {
            /*构建查询sql*/
            string sql = "select * from Seller where sellerUserName='" + sellerUserName + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Seller seller = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                seller = new ENTITY.Seller();
                seller.sellerUserName = DataRead["sellerUserName"].ToString();
                seller.password = DataRead["password"].ToString();
                seller.sellerName = DataRead["sellerName"].ToString();
                seller.sellerPhoto = DataRead["sellerPhoto"].ToString();
                seller.sellerDesc = DataRead["sellerDesc"].ToString();
                seller.bornDate = Convert.ToDateTime(DataRead["bornDate"].ToString());
                seller.telephone = DataRead["telephone"].ToString();
                seller.email = DataRead["email"].ToString();
                seller.areaObj = Convert.ToInt32(DataRead["areaObj"]);
                seller.address = DataRead["address"].ToString();
                seller.regTime = Convert.ToDateTime(DataRead["regTime"].ToString());
            }
            return seller;
        }

        /*更新商家实现*/
        public static bool EditSeller(ENTITY.Seller seller)
        {
            string sql = "update Seller set password=@password,sellerName=@sellerName,sellerPhoto=@sellerPhoto,sellerDesc=@sellerDesc,bornDate=@bornDate,telephone=@telephone,email=@email,areaObj=@areaObj,address=@address,regTime=@regTime where sellerUserName=@sellerUserName";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@password",SqlDbType.VarChar),
             new SqlParameter("@sellerName",SqlDbType.VarChar),
             new SqlParameter("@sellerPhoto",SqlDbType.VarChar),
             new SqlParameter("@sellerDesc",SqlDbType.VarChar),
             new SqlParameter("@bornDate",SqlDbType.DateTime),
             new SqlParameter("@telephone",SqlDbType.VarChar),
             new SqlParameter("@email",SqlDbType.VarChar),
             new SqlParameter("@areaObj",SqlDbType.Int),
             new SqlParameter("@address",SqlDbType.VarChar),
             new SqlParameter("@regTime",SqlDbType.DateTime),
             new SqlParameter("@sellerUserName",SqlDbType.VarChar)
            };
            /*为参数赋值*/
            parm[0].Value = seller.password;
            parm[1].Value = seller.sellerName;
            parm[2].Value = seller.sellerPhoto;
            parm[3].Value = seller.sellerDesc;
            parm[4].Value = seller.bornDate;
            parm[5].Value = seller.telephone;
            parm[6].Value = seller.email;
            parm[7].Value = seller.areaObj;
            parm[8].Value = seller.address;
            parm[9].Value = seller.regTime;
            parm[10].Value = seller.sellerUserName;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除商家*/
        public static bool DelSeller(string p)
        {
            string sql = "";
            string[] ids = p.Split(',');
            for(int i=0;i<ids.Length;i++)
            {
                if(i != ids.Length-1)
                  sql += "'" + ids[i] + "',";
                else
                  sql += "'" + ids[i] + "'";
            }
            sql = "delete from Seller where sellerUserName in (" + sql + ")";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询商家*/
        public static DataSet GetSeller(string strWhere)
        {
            try
            {
                string strSql = "select * from Seller" + strWhere + " order by sellerUserName asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询商家*/
        public static System.Data.DataTable GetSeller(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Seller";
                string strShow = "*";
                return DAL.DBHelp.ExecutePagerWhenPrimaryIsString(PageIndex, PageSize, "sellerUserName", strShow, strSql, strWhere, " sellerUserName asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllSeller()
        {
            try
            {
                string strSql = "select * from Seller";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
