using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using com.force.json;

public partial class ProductClass_ProductClassController : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["action"];
        if (action == "add") addProductClass();
        if (action == "delete") deleteProductClass();
        if (action == "update") updateProductClass();
        if (action == "getProductClass") getProductClass();
        if (action == "listAll") listAll();
    }
    //处理添加商品类别控制层方法
    protected void addProductClass()
    {
        int success = 0;
        string message = "";
        ENTITY.ProductClass productClass = new ENTITY.ProductClass();
        productClass.className = Request["productClass.className"];
        productClass.classDesc = Request["productClass.classDesc"];
        if (!BLL.bllProductClass.AddProductClass(productClass))
        {
            message = "添加商品类别发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //处理删除商品类别控制层方法
    protected void deleteProductClass()
    {
        int success = 0;
        string message = "";
        string classId = Request["classId"];
        try {
            BLL.bllProductClass.DelProductClass(classId);
            success = 1;
        } catch {
            message = "商品类别删除失败";
        }
        writeResult(success, message);
    }

    //处理更新商品类别控制层方法
    protected void updateProductClass()
    {
        int success = 0;
        string message = "";
        ENTITY.ProductClass productClass = new ENTITY.ProductClass();
        productClass.classId = int.Parse(Request["ProductClass.classId"]);
        productClass.className = Request["productClass.className"];
        productClass.classDesc = Request["productClass.classDesc"];
        if (!BLL.bllProductClass.EditProductClass(productClass))
        {
            message = "更新商品类别发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //获取单个商品类别对象，返回json格式
    protected void getProductClass()
    {
        int classId = int.Parse(Request.QueryString["classId"]);
        ENTITY.ProductClass productClass = BLL.bllProductClass.getSomeProductClass(classId);
        JSONObject jsonProductClass = new JSONObject();
        jsonProductClass.Put("classId", productClass.classId);
        jsonProductClass.Put("className", productClass.className);
        jsonProductClass.Put("classDesc", productClass.classDesc);
        Response.Write(jsonProductClass.ToString());
    }

    protected void listAll()
    {
        DataSet productClassDs = BLL.bllProductClass.getAllProductClass();
        JSONArray productClassArray = new JSONArray();
        for (int i = 0; i < productClassDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = productClassDs.Tables[0].Rows[i];
            JSONObject jsonProductClass = new JSONObject();
            jsonProductClass.Put("classId", Convert.ToInt32(dr["classId"]));
            jsonProductClass.Put("className", dr["className"].ToString());
            productClassArray.Put(jsonProductClass);
        }
        Response.Write(productClassArray.ToString());
    }

    //把处理结果返回给界面层
    protected void writeResult(int success, string message)
    {
        JSONObject resultObj = new JSONObject();
        resultObj.Put("success", success);
        resultObj.Put("message", message);
        Response.Write(resultObj.ToString());
    }

}
