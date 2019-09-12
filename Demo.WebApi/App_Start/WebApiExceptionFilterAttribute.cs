using System;
using System.Net.Http;
using System.Web.Http.Filters;
using Demo.Core.ApiModels;

namespace Demo.WebApi.App_Start
{
    public class WebApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// WebApi拦截到有异常发生时处理逻辑
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {

            if (actionExecutedContext.Response == null)
            {
                actionExecutedContext.Response = GetResponse((int)System.Net.HttpStatusCode.InternalServerError, "服务器出现异常,操作失败!");
            }

            Demo.Core.Log4net.LogManager.WriteError("控制器:", actionExecutedContext.Exception);

            base.OnException(actionExecutedContext);
        }

        /// <summary>
        /// 设置拦截到异常的响应信息
        /// </summary>
        /// <param name="httpStatusCode">httpstatus状态码</param>
        /// <param name="message">返回信息</param>
        /// <returns></returns>
        private HttpResponseMessage GetResponse(int httpStatusCode, string message)
        {
            var resultModel = new ApiResult() { Code = httpStatusCode, Message = message };
            return new HttpResponseMessage()
            {
                Content = new ObjectContent<ApiResult>(resultModel, new System.Net.Http.Formatting.JsonMediaTypeFormatter(), "application/json")
            };
        }
    }
}