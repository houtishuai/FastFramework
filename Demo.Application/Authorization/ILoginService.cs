using Demo.Application.Authorization.Dto;

namespace Demo.Application.Authorization
{
    public interface ILoginService
    {
        /// <summary>
        /// 获取token
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        TokenResult GetToken(string userName, string password);
    }
}
