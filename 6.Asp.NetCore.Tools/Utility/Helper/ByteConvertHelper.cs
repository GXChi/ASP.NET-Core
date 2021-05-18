using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Helper
{
    public class ByteConvertHelper
    {
        /// <summary>
        /// 将对象转换为byte数组
        /// </summary>
        /// <param name="obj">被转换对象</param>
        /// <returns>转换后byte数组</returns>
        public static byte[] ObjectToBytes(object obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            return Encoding.UTF8.GetBytes(json); ;
        }

        /// <summary>
        /// 将byte数组转换成对象
        /// </summary>
        /// <param name="buff">被转换byte数组</param>
        /// <returns>转换完成后的对象</returns>
        public static object BytesToObject(byte[] bt)
        {
            var json = Encoding.UTF8.GetString(bt);
            return JsonConvert.DeserializeObject<object>(json);
        }

        /// <summary>
        /// 将byte数组转换成对象
        /// </summary>
        /// <param name="buff">被转换byte数组</param>
        /// <returns>转换完成后的对象</returns>
        public static T Bytes2Object<T>(byte[] buff)
        {
            string json = Encoding.UTF8.GetString(buff);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
