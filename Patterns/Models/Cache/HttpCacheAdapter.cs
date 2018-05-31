using Model_Patterns.Interfaces;
using Model_Patterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace Patterns.Models.Cache
{
    public class HttpCacheAdapter : ICache

    {
        public void Remove(string key)
        {
            HttpContext.Current.Cache.Remove(key);
        }

        public void Store(string key, object o)
        {
            CacheDependency cacheDependency = new CacheDependency(HttpContext.Current.Server.MapPath(Utilities.CacheFile));

            HttpContext.Current.Cache.Insert(key, o, cacheDependency, DateTime.UtcNow.AddHours(int.Parse(Utilities.CacheRefresh)), System.Web.Caching.Cache.NoSlidingExpiration);
        }

        public T Retreive<T>(string key)
        {

            T itemStored = (T)HttpContext.Current.Cache.Get(key);

            if (itemStored == null)
                itemStored = default(T);

            return itemStored;
        }
    }
}