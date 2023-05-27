using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*商品收藏业务逻辑层*/
    public class bllCollection{
        /*添加商品收藏*/
        public static bool AddCollection(ENTITY.Collection collection)
        {
            return DAL.dalCollection.AddCollection(collection);
        }

        /*根据collectionId获取某条商品收藏记录*/
        public static ENTITY.Collection getSomeCollection(int collectionId)
        {
            return DAL.dalCollection.getSomeCollection(collectionId);
        }

        /*更新商品收藏*/
        public static bool EditCollection(ENTITY.Collection collection)
        {
            return DAL.dalCollection.EditCollection(collection);
        }

        /*删除商品收藏*/
        public static bool DelCollection(string p)
        {
            return DAL.dalCollection.DelCollection(p);
        }

        /*查询商品收藏*/
        public static System.Data.DataSet GetCollection(string strWhere)
        {
            return DAL.dalCollection.GetCollection(strWhere);
        }

        /*根据条件分页查询商品收藏*/
        public static System.Data.DataTable GetCollection(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalCollection.GetCollection(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的商品收藏*/
        public static System.Data.DataSet getAllCollection()
        {
            return DAL.dalCollection.getAllCollection();
        }
    }
}
