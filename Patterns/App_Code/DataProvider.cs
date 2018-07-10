using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Patterns.Models;
using Model_Patterns;
using Model_Patterns.Interfaces;
using Model_Patterns.Models;
using Model_Patterns.Models.Exceptions;
using Model_Patterns.Models.Content;
using Model_Patterns.Abstract;
using Patterns.Aspects;

namespace Patterns.App_Code
{
    public class DataProvider
    {
        private IDao _dataLayer;
        private ICache _cacheProvider;
        private AppConfig _config;

        [ExceptionHandlerAspect(AspectPriority = 0)]
        public DataProvider()
        {
            //Pattern: Singleton
            _config = Utilities.GetConfig();
            var cacheType = (Enumerations.Cache)Enum.Parse(typeof(Enumerations.Cache), _config.DictConfig["CacheType"]);
            //Pattern: Factory
            _dataLayer = new Dal_Patterns.DaoFactory(_config).GetInstance();
            _cacheProvider = new CacheProvider().GetInstance(cacheType);
        }

        [ExceptionHandlerAspect(AspectPriority = 0)]
        public IDocument GetDocumentByKey(string sopi)
        {
            IDocument document = null;
            string sCacheId = string.Format("GetDocument");
            if (Utilities.IsCacheAvailableForRetrive(sCacheId))
            {
                document = _cacheProvider.Retreive<IDocument>(sCacheId);
            }
            else
            {
                document = _dataLayer.GetDocument(sopi);
                if(Utilities.IsCacheAvailableForStorage(document))
                {
                    _cacheProvider.Store(sCacheId, document);
                }
            }
            return document;
        }

        [ExceptionHandlerAspect(AspectPriority = 0)]
        public List<IDocument> GetDocuments()
        {
            List<IDocument> groupOfDocuments = new List<IDocument>();
            string sCacheId = string.Format("GetDocuments");
            if (Utilities.IsCacheAvailableForRetrive(sCacheId))
            {
                groupOfDocuments = _cacheProvider.Retreive<List<IDocument>>(sCacheId);
            }
            else
            {
                groupOfDocuments = _dataLayer.GetDocuments();
                if (Utilities.IsCacheAvailableForStorage(groupOfDocuments))
                {
                    _cacheProvider.Store(sCacheId, groupOfDocuments);
                }
            }
            return groupOfDocuments;
        }

        [ObjectNullArgumentAspect(AspectPriority = 0)]
        [ExceptionHandlerAspect(AspectPriority = 1)]
        public IUser GetUserModelData(string username, string password)
        {
            return _dataLayer.GetUserModelData(username, password);
        }
    }
}