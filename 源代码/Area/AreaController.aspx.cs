using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using com.force.json;

public partial class Area_AreaController : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["action"];
        if (action == "add") addArea();
        if (action == "delete") deleteArea();
        if (action == "update") updateArea();
        if (action == "getArea") getArea();
        if (action == "listAll") listAll();
    }
    //处理添加区域控制层方法
    protected void addArea()
    {
        int success = 0;
        string message = "";
        ENTITY.Area area = new ENTITY.Area();
        area.areaName = Request["area.areaName"];
        if (!BLL.bllArea.AddArea(area))
        {
            message = "添加区域发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //处理删除区域控制层方法
    protected void deleteArea()
    {
        int success = 0;
        string message = "";
        string areaId = Request["areaId"];
        try {
            BLL.bllArea.DelArea(areaId);
            success = 1;
        } catch {
            message = "区域删除失败";
        }
        writeResult(success, message);
    }

    //处理更新区域控制层方法
    protected void updateArea()
    {
        int success = 0;
        string message = "";
        ENTITY.Area area = new ENTITY.Area();
        area.areaId = int.Parse(Request["Area.areaId"]);
        area.areaName = Request["area.areaName"];
        if (!BLL.bllArea.EditArea(area))
        {
            message = "更新区域发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //获取单个区域对象，返回json格式
    protected void getArea()
    {
        int areaId = int.Parse(Request.QueryString["areaId"]);
        ENTITY.Area area = BLL.bllArea.getSomeArea(areaId);
        JSONObject jsonArea = new JSONObject();
        jsonArea.Put("areaId", area.areaId);
        jsonArea.Put("areaName", area.areaName);
        Response.Write(jsonArea.ToString());
    }

    protected void listAll()
    {
        DataSet areaDs = BLL.bllArea.getAllArea();
        JSONArray areaArray = new JSONArray();
        for (int i = 0; i < areaDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = areaDs.Tables[0].Rows[i];
            JSONObject jsonArea = new JSONObject();
            jsonArea.Put("areaId", Convert.ToInt32(dr["areaId"]));
            jsonArea.Put("areaName", dr["areaName"].ToString());
            areaArray.Put(jsonArea);
        }
        Response.Write(areaArray.ToString());
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
