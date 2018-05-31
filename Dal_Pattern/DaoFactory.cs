using Dal_Pattern.Models;
using Dal_Patterns.Models;
using Model_Patterns;
using Model_Patterns.Abstract;
using Model_Patterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal_Patterns
{
    public class DaoFactory
    {
        private static IDao _IProviderDocument = null;
        private Config _config = null;

        public DaoFactory(Config config)
        {
            _config = config;
        }
        public IDao GetInstance()
        {
            var dbType = (Enumerations.Dao)Enum.Parse(typeof(Enumerations.Dao), _config.DictConfig["DaoType"]);

            if (Enumerations.Dao.Sql == dbType)
            {
                if (_IProviderDocument == null)
                    _IProviderDocument = (IDao)Activator.CreateInstance(typeof(SqlDao));

                _IProviderDocument.Config = new DbSqlConfig(_config.DictConfig["DaoPath"]);

            }
            else if (Enumerations.Dao.WebApi == dbType)
            {
                if (_IProviderDocument == null)
                    _IProviderDocument = (IDao)Activator.CreateInstance(typeof(WebApiDao));

                _IProviderDocument.Config = new WebApiConfig(_config.DictConfig["WebApiPath"]);
            }
            else
            {
                if (_IProviderDocument == null)
                    _IProviderDocument = (IDao)Activator.CreateInstance(typeof(SqlDao));

                _IProviderDocument.Config = new DbSqlConfig(_config.DictConfig["DaoPath"]); ;
            }
            return _IProviderDocument;
        }

    }
}
