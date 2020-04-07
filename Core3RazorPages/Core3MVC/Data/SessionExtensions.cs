using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Core3MVC.Data
{
    public static class SessionExtensions
    {
        public static void SetByteArray(this ISession session, string key, byte[] value)
        {
            session.Set(key, value);
        }

        public static byte[] GetByteArray(this ISession session, string key)
        {
            var value = session.Get(key);

            return value == null ? default(byte[]) :value;
        }
    }
}
