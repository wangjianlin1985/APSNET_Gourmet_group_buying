using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*��Ʒ�ղ�ҵ���߼���*/
    public class bllCollection{
        /*�����Ʒ�ղ�*/
        public static bool AddCollection(ENTITY.Collection collection)
        {
            return DAL.dalCollection.AddCollection(collection);
        }

        /*����collectionId��ȡĳ����Ʒ�ղؼ�¼*/
        public static ENTITY.Collection getSomeCollection(int collectionId)
        {
            return DAL.dalCollection.getSomeCollection(collectionId);
        }

        /*������Ʒ�ղ�*/
        public static bool EditCollection(ENTITY.Collection collection)
        {
            return DAL.dalCollection.EditCollection(collection);
        }

        /*ɾ����Ʒ�ղ�*/
        public static bool DelCollection(string p)
        {
            return DAL.dalCollection.DelCollection(p);
        }

        /*��ѯ��Ʒ�ղ�*/
        public static System.Data.DataSet GetCollection(string strWhere)
        {
            return DAL.dalCollection.GetCollection(strWhere);
        }

        /*����������ҳ��ѯ��Ʒ�ղ�*/
        public static System.Data.DataTable GetCollection(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalCollection.GetCollection(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е���Ʒ�ղ�*/
        public static System.Data.DataSet getAllCollection()
        {
            return DAL.dalCollection.getAllCollection();
        }
    }
}
