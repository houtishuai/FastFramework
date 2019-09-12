using System;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.Generic;

namespace Demo.Core.Utils
{
    public class HttpManager
    {
        /// <summary>
        /// 指定Post地址使用Get 方式获取全部字符串
        /// </summary>
        /// <param name="url">请求后台地址</param>
        /// <returns></returns>
        public static string Post(string url)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentLength = 0;//这是由于IIS7中POST请求限制的原因造成的,在IIS7中站点被以POST方式请求时,必须要求传递参数,如果调用的API无须传递参数,那么请加上一句即可解决411异常
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        /// <summary>
        /// 指定Post地址使用Get 方式获取全部字符串
        /// </summary>
        /// <param name="url">请求后台地址</param>
        /// <returns></returns>
        public static string Post(string url, Dictionary<string, string> dic)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            #region 添加Post 参数
            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (var item in dic)
            {
                if (i > 0)
                    builder.Append("&");
                builder.AppendFormat("{0}={1}", item.Key, item.Value);
                i++;
            }
            byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            #endregion
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        /// <summary>
        /// 指定Post地址使用Get 方式获取全部字符串
        /// </summary>
        /// <param name="url">请求后台地址</param>
        /// <param name="content">Post提交数据内容(utf-8编码的)</param>
        /// <returns></returns>
        public static string Post(string url, string content)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";

            #region 添加Post 参数
            byte[] data = Encoding.UTF8.GetBytes(content);
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            #endregion

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }
    }
}
