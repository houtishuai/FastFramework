using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Autofac;
using System.Web.Mvc;
using System.Web.Http;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Demo.Core;
using Demo.Dapper;

namespace Demo.WebApi.App_Start
{
    public class AutofacUtil
    {
        /// <summary>
        /// Autofac容器对象
        /// </summary>
        private static IContainer _container;

        /// <summary>
        /// 初始化autofac
        /// </summary>
        public static void InitAutofac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetCallingAssembly());
            builder.RegisterApiControllers(Assembly.GetCallingAssembly());

            //配置接口依赖
            builder.RegisterGeneric(typeof(DapperRepository<>)).As(typeof(IRepository<>));

            //注入service
            builder.RegisterAssemblyTypes(Assembly.Load("Demo.Application"), Assembly.Load("Demo.Application"))
                   .Where(x => x.Name.EndsWith("Service"))
                   .AsImplementedInterfaces();
            //注入repository
            builder.RegisterAssemblyTypes(Assembly.Load("Demo.Core"), Assembly.Load("Demo.Dapper"))
                   .Where(x => x.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces();

            _container = builder.Build();

            //设置MVC依赖注入
            DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));

            //设置WebApi依赖注入
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)_container);
        }

        /// <summary>
        /// 从Autofac容器获取对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetFromFac<T>()
        {
            return _container.Resolve<T>();
        }
    }
}