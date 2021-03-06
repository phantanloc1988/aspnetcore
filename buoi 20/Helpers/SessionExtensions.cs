﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace buoi_20.Helpers
{
    public static class SessionExtensions
    {
        public static void SetSession<NN>(this ISession session, string key, NN value)
        {
            var jsonObj = JsonSerializer.Serialize(value);
            session.SetString(key, jsonObj);
        }

        public static NN GetSession<NN>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<NN>(value);
        }
    }
}
