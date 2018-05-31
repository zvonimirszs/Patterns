using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Patterns.Models;
using Model_Patterns;
using Model_Patterns.Interfaces;
using Model_Patterns.Models;
using Model_Patterns.Models.Content;
using Model_Patterns.Abstract;

namespace Patterns.App_Code
{
    public class DataProvider
    {
        private IDao _dao;
        private ICache _cache;
        private AppConfig _config;
        public DataProvider()
        {
            //Pattern: Singleton
            _config = Utilities.GetConfig();
            var cacheType = (Enumerations.Cache)Enum.Parse(typeof(Enumerations.Cache), _config.DictConfig["CacheType"]);
            //Pattern: Factory
            _dao = new Dal_Patterns.DaoFactory(_config).GetInstance();
            _cache = new CacheProvider().GetInstance(cacheType);
        }
        public IDocument GetDocument(string sopi)
        {
            IDocument dtDocument = null;
            try
            {
                string sCacheId = string.Format("GetDocument");
                if ((Utilities.CacheEnabledDocument) && (HttpContext.Current.Cache[sCacheId] != null))
                {
                    dtDocument = _cache.Retreive<IDocument>(sCacheId);
                }
                else
                {
                    List<string> listDocNum = new List<string>();
                    dtDocument = _dao.GetDocument(sopi);
                    if ((Utilities.CacheEnabledDocument) && (dtDocument != null))
                    {
                        _cache.Store(sCacheId, dtDocument);
                    }
                }
            }
            catch (Exception ex)
            {
                // insert into log error- 
            }
            return dtDocument;

        }

        public List<IDocument> GetDocuments()
        {
            List<IDocument> listDocNum = new List<IDocument>();
            try
            {
                string sCacheId = string.Format("GetDocuments");
                if ((Utilities.CacheEnabledDocument) && (HttpContext.Current.Cache[sCacheId] != null))
                {
                    listDocNum = _cache.Retreive<List<IDocument>>(sCacheId);
                }
                else
                {
                    listDocNum = _dao.GetDocuments();
                    if ((Utilities.CacheEnabledDocument) && (listDocNum != null))
                    {
                        _cache.Store(sCacheId, listDocNum);
                    }
                }
            }
            catch (Exception ex)
            {
                // insert into log error- 
            }
            return listDocNum;

        }

        public IUser UserAutorization(string username, string password)
        {
            try
            {
                return _dao.UserAutorization(username, password);
            }
            catch (Exception ex)
            {
                // insert into log error- 
            }
            return null;

        }
    }
}