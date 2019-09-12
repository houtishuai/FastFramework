using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Demo.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //配置跨域
            config.EnableCors(new System.Web.Http.Cors.EnableCorsAttribute(origins: "*", headers: "*", methods: "*")
            {
                SupportsCredentials = true
            });

            //webApi路由
            config.MapHttpAttributeRoutes();

            //设置webapi路由规则
            //config.Routes.MapHttpRoute(
            //    name: "AreaApi",
            //    routeTemplate: "api/{area}/{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
            config.Routes.MapHttpRoute(
                name: "WebApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //移除xml返回格式数据
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            //配置返回的时间类型数据格式  
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.Converters.Add(
                new Newtonsoft.Json.Converters.IsoDateTimeConverter()
                {
                    DateTimeFormat = "yyyy-MM-dd HH:mm:ss"
                }
            );

            //添加webapi全局异常处理
            config.Filters.Add(new Demo.WebApi.App_Start.WebApiExceptionFilterAttribute());
        }
    }
}
