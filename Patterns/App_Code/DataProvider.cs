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

namespace Patterns.App_Code
{
    public class DataProvider
    {
        private IDao _dataLayer;
        private ICache _cacheProvider;
        private AppConfig _config;
        public DataProvider()
        {
            //Pattern: Singleton
            _config = Utilities.GetConfig();
            var cacheType = (Enumerations.Cache)Enum.Parse(typeof(Enumerations.Cache), _config.DictConfig["CacheType"]);
            //Pattern: Factory
            _dataLayer = new Dal_Patterns.DaoFactory(_config).GetInstance();
            _cacheProvider = new CacheProvider().GetInstance(cacheType);
        }
        public IDocument GetDocumentByKey(string sopi)
        {
            IDocument document = null;
            try
            {
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
            }
            catch (CacheProviderException e)
            {
                // insert into log error- 
                document = null;
            }
            catch (DataProviderException e)
            {
                // insert into log error- 
                document = null;
            }
            catch (Exception e)
            {
                // insert into log error- 
                document = null;
            }
            finally
            {

            }
            return document;
        }

        public List<IDocument> GetDocuments()
        {
            List<IDocument> groupOfDocuments = new List<IDocument>();
            try
            {
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
            }
            catch (CacheProviderException e)
            {
                // insert into log error- 
                groupOfDocuments = null;
            }
            catch (DataProviderException e)
            {
                // insert into log error- 
                groupOfDocuments = null;
            }
            catch (Exception e)
            {
                // insert into log error- 
                groupOfDocuments = null;
            }
            finally
            {

            }
            return groupOfDocuments;
        }

        public IUser GetUserModelData(string username, string password)
        {
            try
            {
                return _dataLayer.GetUserModelData(username, password);
            }
            catch (CacheProviderException e)
            {
                // insert into log error- 
                return null;
            }
            catch (DataProviderException e)
            {
                // insert into log error- 
                return null;
            }
            catch (Exception e)
            {
                // insert into log error- 
                return null;
            }
            finally
            {

            }
        }
    }
}