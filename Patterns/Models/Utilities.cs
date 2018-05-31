using Model_Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Xml.Linq;
using Model_Patterns.Interfaces;
using Model_Patterns.Abstract;

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

        public static AppConfig GetConfig()
        {

            if (_config == null)
                _config = new AppConfig(Utilities.ConfigPath);

            return _config;
        }
        #region web.config
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
    }
}