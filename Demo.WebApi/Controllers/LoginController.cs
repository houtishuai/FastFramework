using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Demo.Application.Authorization;
using Demo.Application.Authorization.Dto;
using Demo.Core.ApiModels;
using Demo.Core.Extensions;

namespace Demo.WebApi.Controllers
{
    /// <summary>
    /// 登录控制器
    /// </summary>
    [AllowAnonymous]
    public class LoginController : BaseApiController
    {
        private readonly ILoginService _loginService;

        /// <summary>
        /// 登录控制器类构造函数
        /// </summary>
        /// <param name="loginService">登录服务</param>
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        /// <summary>
        /// 登录检查
        /// </summary>
        /// <param name="loginFormInput">登录表单信息</param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult CheckLogin(LoginFormInput loginFormInput)
        {
            var tokenResult = _loginService.GetToken(loginFormInput.Account, loginFormInput.Password);
            if (tokenResult == null)
                return new ApiResult(false, "账户名或密码错误!");
            return new ApiResult(true, "登录成功!", tokenResult);
        }
    }
}
