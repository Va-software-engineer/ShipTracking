using Microsoft.AspNetCore.Http;
using ShipTracking.Generic.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ShipTracking.Generic.Infrastructure
{
    public static class Common
    {
        #region Serialize/Deserialize Object

        public static string SerializeObject<T>(T objectData)
        {
            string defaultJson = JsonConvert.SerializeObject(objectData);
            return defaultJson;
        }

        public static T DeserializeObject<T>(string json)
        {
            T obj = default(T);
            obj = JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return obj;
        }

        #endregion
    }
}
