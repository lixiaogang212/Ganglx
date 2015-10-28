using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class NhTestBll
    {
        public IList<NhTestModel> GetAllItems()
        {
            return ExampleApplication.GetCurrentSession().CreateQuery("from Test").List<NhTestModel>();
        }
        //public void UpdateItem(NhTestModel item)
        //{
        //    ExampleApplication.GetCurrentSession().SaveOrUpdateCopy(NhTestModel);
        //}

        public void DeleteItem(NhTestModel item)
        {
            ISession session = ExampleApplication.GetCurrentSession();
            session.Delete(session.Load(typeof(NhTestModel), item.Id));
        }

        public void InsertItem(NhTestModel item)
        {
            ExampleApplication.GetCurrentSession().Save(item);
        }  
    }
}