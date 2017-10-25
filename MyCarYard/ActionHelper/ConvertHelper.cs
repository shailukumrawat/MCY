using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarYard.ActionHelper
{
    public static class ConvertHelper
    {
        public static string Encode(string encodeMe)
        {
            byte[] encoded = System.Text.Encoding.UTF8.GetBytes(encodeMe);

            return Convert.ToBase64String(encoded).Replace("=", "").Replace('+', '-').Replace('/', '_');
            // return encodeMe;
        }

        public static string Decode(string decodeMe)
        {
            decodeMe = decodeMe.Replace('-', '+').Replace('_', '/');
            string padding = new String('=', 3 - (decodeMe.Length + 3) % 4);
            decodeMe += padding;
            byte[] encoded = Convert.FromBase64String(decodeMe);
            return System.Text.Encoding.UTF8.GetString(encoded);
            // return decodeMe;
        }
    }
}