using Microsoft.AspNetCore.Http;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace Buoi14_DatabaseFirst.Helpers
{
    public static class SessionExtensions
    {
        //kiểu T là kiểu đại diện chung khi nào dugn2 mới hiện cụ thể
        public static void SetSession<T>(this ISession session, string key, T value)
        {
            var jsonObj = JsonSerializer.Serialize(value);
            session.SetString(key, jsonObj);
        }

        public static T GetSession<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}
