using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using Microsoft.Owin.Security;

namespace Demo.WebApi.App_Start
{
    public class OAuthServerProvider : OAuthAuthorizationServerProvider
    {
        /// <summary>
        /// 验证Token请求,限制授权模式
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task ValidateTokenRequest(OAuthValidateTokenRequestContext context)
        {
            //设置暂时只支持密码模式
            if (context.TokenRequest.IsResourceOwnerPasswordCredentialsGrantType)
            {
                context.Validated();
            }
            else
            {
                context.Rejected();
                return Task.FromResult<object>(null);
            }
            return base.ValidateTokenRequest(context);
        }

        /// <summary>
        /// 验证OAuth请求
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId;
            string clientSecret;

            //获取客户端凭证
            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
                context.TryGetFormCredentials(out clientId, out clientSecret);

            //保存客户端凭证
            context.OwinContext.Set<string>("clientId", clientId);
            context.OwinContext.Set<string>("clientSecret", clientSecret);
            //验证通过
            context.Validated(clientId);

            return base.ValidateClientAuthentication(context);
        }

        /// <summary>
        /// 密码模式验证
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //配置跨域
            var allowedOrigin = context.OwinContext.Get<string>("clientAllowedOrigin");
            if (string.IsNullOrEmpty(allowedOrigin))
                allowedOrigin = "*";
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new string[] { allowedOrigin });

            //验证用户是否合法
            CheckUser(context);

            return base.GrantResourceOwnerCredentials(context);
        }

        /// <summary>
        /// 校验用户是否合法
        /// </summary>
        /// <param name="context"></param>
        public void CheckUser(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //获取用户详细信息
            var doctorService = AutofacUtil.GetFromFac<Demo.Application.AppServices.IDoctorService>();
            var doctorEntity = doctorService.GetDoctorInfoByAccount(context.UserName, context.Password);

            if (doctorEntity != null)
            {
                var claimsIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, doctorEntity.DoctorName));
                claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, doctorEntity.Id.ToString()));

                var ticket = new AuthenticationTicket(claimsIdentity, new AuthenticationProperties());
                //替换上下文中票证信息，并将其标记为已验证
                context.Validated(ticket);
            }
            else
            {
                context.SetError("invalid_grant", "The username or password is incorrect.");
            }
        }
    }
}