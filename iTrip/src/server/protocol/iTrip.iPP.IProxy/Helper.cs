﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTrip.iPP.IProxy
{
    public static class Extensions
    {
        /// <summary>
        /// 将数字转成字符串，并从低位开始截取指定长度
        /// </summary>
        /// <param name="num"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string ToLitString(this int num, int len = 6)
        {
            if (num < Math.Pow(10, len))
                return num.ToString("D" + len);
            var ns = num.ToString();
            return ns.Substring(ns.Length - len, len);
        }

        public static byte[] ToiTripByteArray(this Guid guid, Encoding encoding)
        {
            return encoding.GetBytes(Convert.ToBase64String(guid.ToByteArray()));
        }
        public static Guid FromiTripByteArray(this byte[] bytes, Encoding encoding)
        {
            if (bytes.Length != 24) return Guid.Empty;
            return new Guid(Convert.FromBase64String(encoding.GetString(bytes)));
        }
    }
}
