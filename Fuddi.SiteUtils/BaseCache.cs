using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;

namespace Fuddi.SiteUtils
{
    public class BaseCache
    {
        ObjectCache cache = MemoryCache.Default;

        protected object GetCacheValue(string key)
        {
            return cache.Get(key);
        }

        protected void SetCacheValue(string key, object value)
        {
            SetCacheValue(key, value, new CacheItemPolicy());
        }

        protected void SetCacheValue(string key, object value, int seconds)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now.AddSeconds(seconds);
            SetCacheValue(key, value, policy);
        }

        protected void SetCacheValue(string key, object value, CacheItemPolicy policy)
        {
            cache.Add(key, value, policy);
        }

        protected void RemoveCacheValue(string key)
        {
            cache.Remove(key);
        }
    }
}
