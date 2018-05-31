using Model_Patterns;
using Model_Patterns.Interfaces;
using Patterns.Models.Cache;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns.App_Code
{
    public class CacheProvider
    {
        private ICache _IProviderCache = null;
        public ICache GetInstance(Enumerations.Cache cacheType)
        {
            if (cacheType == Enumerations.Cache.Http)
            {
                if (_IProviderCache == null)
                    _IProviderCache = (ICache)Activator.CreateInstance(typeof(HttpCacheAdapter));

            }
            else
            {
                if (_IProviderCache == null)
                    _IProviderCache = (ICache)Activator.CreateInstance(typeof(HttpCacheAdapter));
            }
            return _IProviderCache;
        }
    }
}
