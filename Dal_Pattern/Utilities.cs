using Dal_Pattern.Models;
using Dal_Patterns.Models;
using Model_Patterns;
using Model_Patterns.Abstract;
using Model_Patterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal_Pattern
{
    internal class Utilities
    {

        private static Utilities instance;
        private Utilities()
        {
            if (instance == null)
                instance = new Utilities();
        }
        public static Utilities GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new Utilities();
                return instance;
            }
        }
        internal static IDao GetDaoProvider(IDao iProviderDocument, Enumerations.Dao dbType)
        {
            switch (dbType)
            {
                case Enumerations.Dao.Sql:
                    if (iProviderDocument == null)
                        iProviderDocument = (IDao)Activator.CreateInstance(typeof(SqlDao));
                    break;
                case Enumerations.Dao.WebApi:
                    if (iProviderDocument == null)
                        iProviderDocument = (IDao)Activator.CreateInstance(typeof(WebApiDao));
                    break;
                default:
                    if (iProviderDocument == null)
                        iProviderDocument = (IDao)Activator.CreateInstance(typeof(SqlDao));
                    break;
            }

            //if (Enumerations.Dao.Sql == dbType)
            //{
            //    if(iProviderDocument == null)
            //        iProviderDocument = (IDao)Activator.CreateInstance(typeof(SqlDao));
            //}
            //else if (Enumerations.Dao.WebApi == dbType)
            //{
            //    if (iProviderDocument == null)
            //        iProviderDocument = (IDao)Activator.CreateInstance(typeof(WebApiDao));
            //}
            //else
            //{
            //    if (iProviderDocument == null)
            //        iProviderDocument = (IDao)Activator.CreateInstance(typeof(SqlDao));
            //}

            return iProviderDocument;
        }
        internal static Config GetConfigForIDaoProvider(Enumerations.Dao dbType, Config config)
        {
            switch (dbType)
            {
                case Enumerations.Dao.Sql:
                    return new DbSqlConfig(config.DictConfig["DaoPath"]);
                case Enumerations.Dao.WebApi:
                    return new WebApiConfig(config.DictConfig["WebApiPath"]);
                default:
                    return new DbSqlConfig(config.DictConfig["DaoPath"]);
            }
        }
    }
}
