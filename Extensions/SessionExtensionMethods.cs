﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using MvcWebUI.Extensions;


namespace MvcWebUI.Extensions
{
    public static class SessionExtensionMethods
    {
        public static void SetObject<T>(this ISession session, string key, object value)
        {
            string objectString = System.Text.Json.JsonSerializer.Serialize(value);
            session.SetString(key, objectString);
        }
        public static T GetObject<T>(this ISession session, string key) where T : class
        {
            string objectString = session.GetString(key);
            if (string.IsNullOrEmpty(objectString))
            {
                return null;
            }
            else
            {
                T value = JsonConvert.DeserializeObject<T>(objectString);
                return value;
            }
        }
    }
}
