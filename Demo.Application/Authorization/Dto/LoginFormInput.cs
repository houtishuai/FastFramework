using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Authorization.Dto
{
    /// <summary>
    /// 登录平台类型
    /// </summary>
    public enum PlatForm
    {
        /// <summary>
        /// PC
        /// </summary>
        PC = 1,
        /// <summary>
        /// App
        /// </summary>
        App = 2
    }

    /// <summary>
    /// 登录表单信息
    /// </summary>
    public class LoginFormInput
    {
        /// <summary>
        /// 账号名称
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 账号密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 登录平台类型( PC:1 App:2)
        /// </summary>
        public PlatForm Platform { get; set; }

        /// <summary>
        /// 数组
        /// </summary>
        public List<LoginFormInput> FormInputList { get; set; }
    }
}
