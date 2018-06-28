using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ShoppingCartASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartASP.Extensions
{
    public static class SessionExtensions
    {
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        public static void SetObjectAsJson(this ISession session, string key, ShoppingCart value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
    }
}
