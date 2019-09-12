using System.Web.Http;
using WebActivatorEx;
using Demo.WebApi;
using Swashbuckle.Application;
using Swashbuckle.Swagger;
using System.Web.Http.Description;
using System.Collections.Generic;
using System.Linq;
using Demo.WebApi.App_Start;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Demo.WebApi
{
    /// <summary>
    /// swagger文档配置信息
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// 注册swagger相关配置信息
        /// </summary>
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    //设置swagger显示的版本号和标题
                    c.SingleApiVersion("v1", "Api描述文档");

                    //设置接口描述xml路径地址
                    var webApiXmlPath = string.Format("{0}/bin/Demo.WebApi.xml", System.AppDomain.CurrentDomain.BaseDirectory);
                    c.IncludeXmlComments(webApiXmlPath);

                    //设置接口描述xml路径地址
                    var applicationXmlPath = string.Format("{0}/bin/Demo.Application.xml", System.AppDomain.CurrentDomain.BaseDirectory);
                    c.IncludeXmlComments(applicationXmlPath);

                    //设置接口描述xml路径地址
                    var coreXmlPath = string.Format("{0}/bin/Demo.Core.xml", System.AppDomain.CurrentDomain.BaseDirectory);
                    c.IncludeXmlComments(coreXmlPath);

                    //加入控制器描述
                    c.CustomProvider((defaultProvider) => new SwaggerControllerDescProvider(defaultProvider, webApiXmlPath));
                })
                .EnableSwaggerUi(c =>
                {
                    //加载汉化的js文件，注意 swagger_lang_cn.js 文件属性必须设置为“嵌入的资源”。
                    c.InjectJavaScript(System.Reflection.Assembly.GetExecutingAssembly(), "Demo.WebApi.Scripts.swagger_lang_cn.js");
                    //加载添加token至请求头js文件
                    c.InjectJavaScript(System.Reflection.Assembly.GetExecutingAssembly(), "Demo.WebApi.Scripts.token.js");
                });
        }
    }
}
