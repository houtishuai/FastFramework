using System;

namespace Demo.Application.Authorization.Dto
{
    public class TokenResult
    {
        /// <summary>
        /// token字符串
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// token类型
        /// </summary>
        public string TokenType { get; set; }

        /// <summary>
        /// token过期时间（秒）
        /// </summary>
        public int ExpiresIn { get; set; }
    }
}
