using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;

namespace GXP.Common
{
    public static class CacheHelper
    {
        /// <summary>
        /// 获取缓存项
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public static object GetCacheItem(string key)
        {
            ICacheManager cache = CacheFactory.GetCacheManager("CacheManager");
            return cache[key];
        }

        /// <summary>
        /// 把值放到缓存里
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public static void SetCacheItem(string key, object value)
        {
            ICacheManager cache = CacheFactory.GetCacheManager("CacheManager");
            cache.Add(key, value);
        }

        /// <summary>
        /// 把值放到缓存里
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="cacheItemPriority">缓存优先级</param>
        public static void SetCacheItem(string key, object value, CacheItemPriority cacheItemPriority)
        {
            ICacheManager cache = CacheFactory.GetCacheManager("CacheManager");
            cache.Add(key, value, cacheItemPriority, null, null);
        }

        /// <summary>
        /// 把值放到缓存里，并指定依赖文件的路径
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="path">依赖文件的路径</param>
        public static void SetCacheItem(string key, object value, string path)
        {
            ICacheManager cache = CacheFactory.GetCacheManager("CacheManager");
            FileDependency fd = new FileDependency(path);
            cache.Add(key, value, CacheItemPriority.Normal, null, new ICacheItemExpiration[] { fd });
        }        
    }
}
