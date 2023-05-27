using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using com.force.json;

public partial class Collection_CollectionController : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["action"];
        if (action == "userAdd") userAddCollection();
        if (action == "add") addCollection();
        if (action == "delete") deleteCollection();
        if (action == "update") updateCollection();
        if (action == "getCollection") getCollection();
        if (action == "listAll") listAll();
    }
    //处理添加商品收藏控制层方法
    protected void addCollection()
    {
        int success = 0;
        string message = "";
        ENTITY.Collection collection = new ENTITY.Collection();
        collection.productObj = int.Parse(Request["collection.productObj.productId"]);
        collection.userObj = Request["collection.userObj.user_name"];
        collection.collectionTime = Convert.ToDateTime(Request["collection.collectionTime"]);
        if (!BLL.bllCollection.AddCollection(collection))
        {
            message = "添加商品收藏发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //处理用户商品收藏控制层方法
    protected void userAddCollection()
    {
        int success = 0;
        string message = "";
        if (Session["user_name"] == null)
        {
            message = "请先登录网站!";
            writeResult(success, message);
            return;
        }

        ENTITY.Collection collection = new ENTITY.Collection();
        collection.productObj = int.Parse(Request["collection.productObj.productId"]);
        collection.userObj = Session["user_name"].ToString();
        collection.collectionTime = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());

        string sqlstr = " where 1=1 ";
        sqlstr += " and productObj=" + collection.productObj;
        sqlstr += " and userObj='" + collection.userObj + "'";

        if (BLL.bllCollection.GetCollection(sqlstr).Tables[0].Rows.Count > 0)
        {
            message = "你已经收藏过这个宝贝了!";
            writeResult(success, message);
            return;
        }

        if (!BLL.bllCollection.AddCollection(collection))
        {
            message = "添加商品收藏发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }


    //处理删除商品收藏控制层方法
    protected void deleteCollection()
    {
        int success = 0;
        string message = "";
        string collectionId = Request["collectionId"];
        try {
            BLL.bllCollection.DelCollection(collectionId);
            success = 1;
        } catch {
            message = "商品收藏删除失败";
        }
        writeResult(success, message);
    }

    //处理更新商品收藏控制层方法
    protected void updateCollection()
    {
        int success = 0;
        string message = "";
        ENTITY.Collection collection = new ENTITY.Collection();
        collection.collectionId = int.Parse(Request["Collection.collectionId"]);
        collection.productObj = int.Parse(Request["collection.productObj.productId"]);
        collection.userObj = Request["collection.userObj.user_name"];
        collection.collectionTime = Convert.ToDateTime(Request["collection.collectionTime"]);
        if (!BLL.bllCollection.EditCollection(collection))
        {
            message = "更新商品收藏发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //获取单个商品收藏对象，返回json格式
    protected void getCollection()
    {
        int collectionId = int.Parse(Request.QueryString["collectionId"]);
        ENTITY.Collection collection = BLL.bllCollection.getSomeCollection(collectionId);
        JSONObject jsonCollection = new JSONObject();
        jsonCollection.Put("collectionId", collection.collectionId);
        jsonCollection.Put("productObj", BLL.bllProduct.getSomeProduct(collection.productObj).productName);
        jsonCollection.Put("productObjPri", collection.productObj);
        jsonCollection.Put("userObj", BLL.bllUserInfo.getSomeUserInfo(collection.userObj).name);
        jsonCollection.Put("userObjPri", collection.userObj);
        jsonCollection.Put("collectionTime", collection.collectionTime.ToShortDateString() + " " + collection.collectionTime.ToLongTimeString());
        Response.Write(jsonCollection.ToString());
    }

    protected void listAll()
    {
        DataSet collectionDs = BLL.bllCollection.getAllCollection();
        JSONArray collectionArray = new JSONArray();
        for (int i = 0; i < collectionDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = collectionDs.Tables[0].Rows[i];
            JSONObject jsonCollection = new JSONObject();
            jsonCollection.Put("collectionId", Convert.ToInt32(dr["collectionId"]));
            jsonCollection.Put("collectionId", Convert.ToInt32(dr["collectionId"]));
            collectionArray.Put(jsonCollection);
        }
        Response.Write(collectionArray.ToString());
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
