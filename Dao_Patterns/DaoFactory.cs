using Dao_Patterns.DaoModels;
using Model_Patterns;
using Model_Patterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dao_Patterns
{
    public class DaoFactory
    {
        private static IDao _IProviderDocument = null;
        private IConfiguration _config = null;

        public DaoFactory(IConfiguration config)
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

            }
            else if (Enumerations.Dao.WebApi == dbType)
            {
                if (_IProviderDocument == null)
                    _IProviderDocument = (IDao)Activator.CreateInstance(typeof(WebApiDao));
            }
            else
            {
                if (_IProviderDocument == null)
                    _IProviderDocument = (IDao)Activator.CreateInstance(typeof(SqlDao));
            }
            return _IProviderDocument;
        }

    }
}
