using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Common
{
    public class MD5Helper
    {
        public static string GetMD5(string txt)
        {
            MD5 md5 = MD5.Create();
            byte[] bs = Encoding.UTF8.GetBytes(txt);
            byte[] bs2=md5.ComputeHash(bs);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bs2.Length; i++)
            {
                sb.Append(bs2[i].ToString("x2").ToLower());
            }
            return sb.ToString();
        }
    }
}
