using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Linq;
using System.Text;

namespace ConsoleNhibernateDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Configuration config = new Configuration();
            Configuration cfg = new Configuration();
            try
            {
                //config.AddAssembly(typeof(Product).Assembly);
                //ISessionFactory sessionFactory = config.BuildSessionFactory();
                //var schema = new SchemaExport(config);
                //schema.Create(true, true);


                cfg.AddAssembly("ConsoleNhibernateDemo");

                ISessionFactory factory = cfg.BuildSessionFactory();
                ISession session = factory.OpenSession();
                ITransaction transaction = session.BeginTransaction();
                Product pt = new Product();
                //pt.ProductId = 4;
                Console.WriteLine("请输入：");
                string pName = Console.ReadLine();
                if (!string.IsNullOrEmpty(pName))
                {
                    pt.ProductName = pName;
                    session.Save(pt);
                    //session.Delete(pt);
                    //pt.ProductName = "卫生用品";
                    //session.Update("Product", pt, 3);
                    transaction.Commit();//才会执行
                }
                //           Product pro = (Product)session.Get<Product>(1);
                //Console.WriteLine(pro.ProductName.ToString());
                //           var hqlQuery = session.CreateQuery("from Product p where p.ProductId >0 ? order by p.ProductId")
                //               //set the parameter
                //.SetInt32(0, 2)
                //               //second page of 10
                //.SetFirstResult(10).SetMaxResults(10);

                //           var list = hqlQuery.List<Product>();
                Console.WriteLine("-------------------1--------------------");
                //获取前十条数据
                IList<Product> Lits = session.CreateCriteria<Product>().SetMaxResults(10).List<Product>();
                foreach (Product i in Lits)
                {
                    Console.WriteLine(i.ProductId + "---" + i.ProductName);
                }
                Console.WriteLine("-------------------2--------------------");
                IList<Product> List2 = session.CreateCriteria<Product>()
                           .Add(Restrictions.Eq("ProductName", "体育用品"))
                           .Add(Restrictions.Eq("ProductId", 1))
                           .List<Product>();
                foreach (Product i in List2)
                {
                    Console.WriteLine(i.ProductId + "---" + i.ProductName);
                }
                Console.WriteLine("-------------------3--------------------");
                var List3 = session.QueryOver<Product>()
                           .Where(p => p.ProductId > 1)
                           .List();
                foreach (Product i in List3)
                {
                    Console.WriteLine(i.ProductId + "---" + i.ProductName);
                }
                IList<Product> List4 = session.QueryOver<Product>().List<Product>();
                Console.WriteLine("-------------------4--------------------");
                foreach (Product i in List4)
                {
                    Console.WriteLine(i.ProductId + "---" + i.ProductName);
                }
                Console.WriteLine("-------------------5--------------------");
                //Linq查询
                var List5 = (from p in session.Query<Product>()
                             where p.ProductName.IndexOf("用品") > 0
                             select p).ToList();
                foreach (Product i in List5)
                {
                    Console.WriteLine(i.ProductId + "---" + i.ProductName);
                }
                session.Close();
                Console.ReadKey();
                //transaction.Commit();

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
