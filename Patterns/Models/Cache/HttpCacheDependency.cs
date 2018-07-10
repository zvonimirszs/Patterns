using Model_Patterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Patterns.Models.Cache
{
    public class HttpCacheDependency : ICacheDependency
    {
        public string CacheRefresh { get; set; }
        public string CacheFile { get; set; }
    }
}