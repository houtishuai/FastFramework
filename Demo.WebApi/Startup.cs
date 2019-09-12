using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;

[assembly: OwinStartup(typeof(Demo.WebApi.Startup))]

namespace Demo.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var options = new OAuthAuthorizationServerOptions()
            {
                TokenEndpointPath = new PathString("/oauth2/token"),//获取token访问路径
                Provider = new Demo.WebApi.App_Start.OAuthServerProvider(),//oauth2服务配置
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),//token有效期 14天
                AllowInsecureHttp = true
            };
            app.UseOAuthBearerTokens(options);
        }
    }
}
