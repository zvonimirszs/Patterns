using Dal_Pattern;
using Dal_Pattern.Models;
using Dal_Patterns.Models;
using Model_Patterns;
using Model_Patterns.Abstract;
using Model_Patterns.Interfaces;
using Model_Patterns.Models.Exceptions;
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
            try
            {
                var dbType = (Enumerations.Dao)Enum.Parse(typeof(Enumerations.Dao), _config.DictConfig["DaoType"]);
                _IProviderDocument = Utilities.GetDaoProvider(_IProviderDocument, dbType);
                _IProviderDocument.Config = Utilities.GetConfigForIDaoProvider(dbType, _config);

                return _IProviderDocument;
            }
            catch (Exception e)
            {
                throw new DataProviderException("Error in GetInstance method", e);
            }
        }

    }
}
