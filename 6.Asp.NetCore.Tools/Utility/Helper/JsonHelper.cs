using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Helper
{
    public class JsonHelper
    {
        private static IsoDateTimeConverter timeFormat;

        static JsonHelper()
        {
            timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.000zz00";
        }

        public static string EntityToJson(object entity)
        {
            return JsonConvert.SerializeObject(entity, timeFormat);           
        }

        public static T JsonToEntity<T>(string json)
        {
            T entity;
            try
            {
                entity = JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception e)
            {
                throw new Exception(json);
            }
            return entity;
        }
    }
}
