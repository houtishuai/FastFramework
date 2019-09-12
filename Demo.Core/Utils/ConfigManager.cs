using System;
using System.Configuration;

namespace Demo.Core.Utils
{
    /// <summary>
    /// web.config配置获取帮助类
    /// </summary>
    public sealed class ConfigManager
    {
        /// <summary>
        /// 得到AppSettings中的配置字符串信息
        /// </summary>
        /// <param name="key">AppSettings节点add的name值</param>
        /// <returns></returns>
        public static string GetAppSettingString(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }

        /// <summary>
        /// 得到ConnectionStrings中的配置字符串信息
        /// </summary>
        /// <param name="key">ConnectionString节点add的name值</param>
        /// <returns></returns>
        public static string GetConnectionString(string key)
        {
            return ConfigurationManager.ConnectionStrings[key].ToString();
        }
    }
}
