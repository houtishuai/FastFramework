using System;

namespace Demo.Core.ApiModels
{
    /// <summary>
    /// webapi响应参数类
    /// </summary>
    public class ApiResult
    {
        public ApiResult()
        {
            this.Code = 200;
        }

        public ApiResult(bool isSuccess, string message = null, Object data = null)
        {
            this.Code = isSuccess ? 200 : 500;
            this.Message = string.IsNullOrEmpty(message) ? isSuccess ? "操作成功!" : "操作失败!" : message;
            this.Data = data;
        }

        /// <summary>
        /// httpstatus 状态码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public Object Data { get; set; }
    }
}
