using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Modules
{
    public class Json
    {
        public static String Encode(Object data)
        {
            return JsonConvert.SerializeObject(data, Formatting.None, new JsonSerializerSettings()
            {
                //prevent loop
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            });
        }

        public static T Decode<T>(String json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}