using System;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Demo.Dapper
{
    /// <summary>
    /// 操作数据库类型
    /// </summary>
    public enum Providers
    {
        SqlServer,
        Sqlite,
        MySql
    }

    public class DBFactory
    {
        public static IDbConnection CreateConnection()
        {
            return CreateConnection("connString", Providers.SqlServer);
        }

        public static IDbConnection CreateConnection(string nameOrConnectionString, Providers providers)
        {
            IDbConnection connection = null;
            //获取连接字符串
            string connectionString = TryGetConnectionString(nameOrConnectionString);

            switch (providers)
            {
                case Providers.SqlServer:
                    connection = new SqlConnection(connectionString);
                    break;
                case Providers.Sqlite:
                    break;
                case Providers.MySql:
                    connection = new MySqlConnection(connectionString);
                    break;
                default:
                    break;
            }
            return connection;
        }

        private static string TryGetConnectionString(string nameOrConnectionString)
        {
            var connString = string.Empty;
            try
            {
                connString = System.Configuration.ConfigurationManager.ConnectionStrings[nameOrConnectionString].ToString();
                return string.IsNullOrEmpty(connString) ? nameOrConnectionString : connString;
            }
            catch
            {
                return nameOrConnectionString;
            }
        }
    }
}
