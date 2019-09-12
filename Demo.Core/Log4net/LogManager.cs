using System;
using System.Text;
using System.Reflection;
using log4net;
using log4net.Config;

namespace Demo.Core.Log4net
{
    public class LogManager
    {
        private static readonly ILog _infoLog = log4net.LogManager.GetLogger("loginfo");
        private static readonly ILog _errorLog = log4net.LogManager.GetLogger("logerror");

        /// <summary>
        /// 初始化log4net
        /// </summary>
        /// <param name="logConfigPath">log4net配置文件存放地址</param>
        public static void InitLog4Net(string logConfigPath)
        {
            XmlConfigurator.Configure(new System.IO.FileInfo(logConfigPath));
        }

        /// <summary>
        /// 记录系统信息
        /// </summary>
        /// <param name="message">记录信息</param>
        public static void WriteInfo(string message)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\r\n***********************************************************************************************");
            sb.Append("\r\n" + message);
            sb.Append("\r\n===============================================================================================\r\n\r\n");
            if (_infoLog.IsInfoEnabled)
            {
                _infoLog.Info(sb);
            }
        }

        /// <summary>
        /// 记录系统错误信息
        /// </summary>
        /// <param name="message">错误信息描述</param>
        /// <param name="ex">若传入错误信息对象,将记录错误信息的详细内容</param>
        public static void WriteError(string message, Exception ex = null)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\r\n***********************************************************************************************");
            sb.Append("\r\n系统错误信息描述：" + message);
            if (ex != null)
            {
                sb.Append("\r\n系统记录错误信息：" + ex.Message);
                sb.Append("\r\n系统记录错误源：" + ex.Source);
                sb.Append("\r\n系统记录异常方法：" + ex.TargetSite);
                sb.Append("\r\n系统记录堆栈信息：" + ex.StackTrace);
            }
            sb.Append("\r\n===============================================================================================\r\n\r\n");
            if (_errorLog.IsErrorEnabled)
            {
                _errorLog.Error(sb);
            }
        }
    }
}
