using Model_Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Xml.Linq;
using Model_Patterns.Interfaces;
using Model_Patterns.Abstract;
using Patterns.Models.Cache;
using Model_Patterns.Models;

namespace Patterns.Models
{
    public class Utilities
    {
        private static Utilities instance;
        private static AppConfig _config = null;
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
        #region AppConfig
        public static AppConfig GetConfig()
        {

            if (_config == null)
                _config = new AppConfig(Utilities.ConfigPath);

            return _config;
        }
        #endregion
        #region WebConfig
        /// <summary>
        /// Cache for documents
        /// </summary>
        public static bool CacheEnabledDocument
        {
            get 
            {
                if (ConfigurationManager.AppSettings.Get("CACHE_ENABLED_DOCUMENT").ToLower() == "yes")
                    return true;
                else
                    return false;
            }
        }
        /// <summary>
        /// File, which triggers nullify the cach
        /// </summary>
        public static string CacheFile
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("CACHE_FILE_DEPENDENCY");
            }
        }
        /// <summary>
        /// The period of Cache validity in hours
        /// </summary>
        public static string CacheRefresh
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("CACHE_TIME_REFRESH");
            }
        }

        public static string ConfigPath
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("CONFIG_PATH");
            }
        }
        #endregion
        #region Providers
        public static ICache GetCacheProvider(ICache iProviderDocument, Enumerations.Cache cacheType)
        {
            ICacheDependency dependency = new HttpCacheDependency();
            dependency.CacheFile = CacheFile;
            dependency.CacheRefresh = CacheRefresh;
            switch (cacheType)
            {
                case Enumerations.Cache.Http:
                    if (iProviderDocument == null)
                    {
                        iProviderDocument = (ICache)Activator.CreateInstance(typeof(HttpCacheAdapter));
                        iProviderDocument.CacheDependency = dependency;
                    }
                    break;
                default:
                    if (iProviderDocument == null)
                    {
                        iProviderDocument = (ICache)Activator.CreateInstance(typeof(HttpCacheAdapter));
                        iProviderDocument.CacheDependency = dependency;
                    }
                    break;
            }
            return iProviderDocument;
        }
        #endregion
        #region Cache
        public static Boolean IsCacheAvailableForRetrive(string sCacheId)
        {
            return ((Utilities.CacheEnabledDocument) && (HttpContext.Current.Cache[sCacheId] != null));
        }
        public static Boolean IsCacheAvailableForStorage(object objForComparison)
        {
            return ((Utilities.CacheEnabledDocument) && (objForComparison != null));
        }
        #endregion
        #region User
        public static Boolean IsUserEnabled(int value)
        {
            return value == 1;
        }
        public static Boolean IsUserOverUsedByDocuments(int numberOfDocuments, int numberOfMaxDocuments)
        {
            if (numberOfMaxDocuments == -1)
                return false;
            return numberOfMaxDocuments < numberOfDocuments;
        }
        public static Boolean IsUserOverUsedByPoints(int numberOfPoints, int numberOfMaxPoints)
        {
            if (numberOfMaxPoints == -1)
                return false;
            return numberOfMaxPoints <= numberOfPoints;
        }
        public static Boolean IsUserIpRestricted(string userIpAddress, string locationIpAddress)
        {
            if (String.IsNullOrEmpty(userIpAddress))
                return false;
            else
                return !(userIpAddress == locationIpAddress);
        }
        public static Boolean IsUserInPackage(List<Package> userPackages, List<Package> documentPackages)
        {
            return userPackages.Where(n => documentPackages.Select(n1 => n1.Id).Contains(n.Id)).Count() > 0;            
        }
        #endregion
    }
}