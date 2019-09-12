using System.Collections.Generic;
using Demo.Application.Authorization.Dto;
using Demo.Core;
using Demo.Core.AppServices;
using Demo.Core.Utils;
using Demo.Core.Extensions;

namespace Demo.Application.Authorization
{
    /// <summary>
    /// 登录相关api服务
    /// </summary>
    public class LoginService : ApplicationServiceBase, ILoginService
    {
        private readonly IRepository<DoctorInfo> _doctorInfoRepository;
        public LoginService(IRepository<DoctorInfo> doctorInfoRepository)
        {
            _doctorInfoRepository = doctorInfoRepository;
        }

        /// <summary>
        /// 获取token
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public TokenResult GetToken(string userName, string password)
        {
            TokenResult tokenResult = null;

            var parameters = new Dictionary<string, string>();
            parameters.Add("username", userName);
            parameters.Add("password", password);
            parameters.Add("grant_type", "password");

            try
            {
                //获取oauth2服务的api地址
                var tokenApiUrl = ConfigManager.GetAppSettingString("tokenApiUrl");
                //获取oauth2服务api返回的token字符串
                var tokenString = HttpManager.Post(tokenApiUrl, parameters);
                //将json字符串转为json对象,获取参数
                var jsonObj = JsonManager.Deserialize<Newtonsoft.Json.Linq.JObject>(tokenString);

                if (jsonObj != null)
                {
                    tokenResult = new TokenResult();
                    tokenResult.AccessToken = jsonObj["access_token"].ToString();
                    tokenResult.TokenType = jsonObj["token_type"].ToString();
                    tokenResult.ExpiresIn = int.Parse(jsonObj["expires_in"].ToString());
                }
                return tokenResult;
            }
            catch (System.Exception)
            {
                return tokenResult;
            }
        }
    }
}
