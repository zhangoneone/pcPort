using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utilHelper
{
    class utilHelper
    {
        /// <summary>
        /// 字符串转成字符数组，返回字符数组
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static byte[] str2byte(string s)
        {
            byte[] buf = ASCIIEncoding.ASCII.GetBytes(s.ToArray());
            //if (s == "") return buf;
            //byte[] buff = new byte[buf.Length - 1];
            //for (int i = 0; i < buf.Length-1; i++)
            //{
            //    buff[i] = buf[i];
            //}
            return buf;
        }
        /// <summary>
        /// byte数组copy到list，并返回原来的list
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<byte> byte2list(byte[] buf, ref List<byte> list)
        {
            foreach (var item in buf)
            {
                list.Add(item);
            }
            return list;
        }
        /// <summary>
        /// byte转string
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        public static string byte2str(byte[] buf)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Encoding.Default.GetString(buf));
            return builder.ToString();
        }
        /// <summary>
        /// 16进制转成ascii字符串 format:0d 0a 0c
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        public static string hex2ascii(string s)
        {
            byte[] buff = new byte[s.Length/2+1];
            int index = 0;
            
            for (int i = 0; i < s.Length; i += 3)
            {
                buff[index++] = Convert.ToByte(s.Substring(i, 2), 16);
            }
            return Encoding.Default.GetString(buff);
        }
        /// <summary>
        /// ascii转成16进制字符串
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        public static string ascii2hex(string s)
        {
            string ss = "";
            byte[] buf =str2byte(s);
            foreach (var item in buf)
            {
                ss += item.ToString("X2") + " ";
            }
            return ss;
        }
    }
}
