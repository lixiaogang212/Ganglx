using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;

namespace Mvc.Models
{
    public class ExampleApplication:HttpApplication
    {
        public static readonly Configuration Configuration;
        public static readonly ISessionFactory SessionFactory;

        static ExampleApplication()
        {
            //log4net.Config.XmlConfigurator.Configure();
            //Configuration = new Configuration();
            //string nhConfigPath = HostingEnvironment.MapPath("~/App_Data/hibernate.cfg.xml");
            //if (File.Exists(nhConfigPath))
            //{
            //    Configuration.Configure(nhConfigPath);
            //}
            SessionFactory = Configuration.Configure().BuildSessionFactory();
        }

        public static ISession GetCurrentSession()
        {
            return SessionFactory.GetCurrentSession();
        }  
    }
}