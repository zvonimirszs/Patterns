﻿using Model_Patterns;
using Model_Patterns.Interfaces;
using Patterns.Aspects;
using Patterns.Models;
using Patterns.Models.Cache;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns.App_Code
{
    public class CacheProvider
    {
        private ICache _IProviderCache = null;

        [ExceptionHandlerAspect(AspectPriority = 0)]
        public ICache GetInstance(Enumerations.Cache cacheType)
        {
            _IProviderCache = Utilities.GetCacheProvider(_IProviderCache, cacheType);
            return _IProviderCache;
        }
    }
}
