using System;
using System.Collections.Generic;
using System.Linq;

namespace Model_Patterns.Interfaces
{
    public interface ICache
    {
        ICacheDependency CacheDependency { get; set; }
        void Remove(string key);
        void Store(string key, object o);
        T Retreive<T>(string key);
    }

    public interface ICacheDependency
    {
        string CacheRefresh { get; set; }

        string CacheFile { get; set; }

    }
}