using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;

namespace GXP.Common
{
    public class UnityHelper
    {
        public static T UnityResolve<T>()
        {
            UnityContainer dacontainer = (UnityContainer)CacheHelper.GetCacheItem("IOC");
            return (T)dacontainer.Resolve<T>();
        }  
    }
}
