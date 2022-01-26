﻿using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace PaintEquipment.Infrastructure
{
    public static class SessionExtensions
    {
        public static void SetJson(this ISession session, string key, object value)
        {

            session.SetString(key, JsonSerializer.Serialize(value));

        }

        public static T GetJson<T>(this ISession session, string key)
        {
            var sessiondta = session.GetString(key);
            return sessiondta == null ? default(T) : JsonSerializer.Deserialize<T>(sessiondta);
        }

    }
}
