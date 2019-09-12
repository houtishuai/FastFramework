using System.Collections.Generic;

namespace Demo.Core.ApiModels
{
    /// <summary>
    /// 分页返回结果类
    /// </summary>
    /// <typeparam name="T">查询返回数据类型</typeparam>
    public class PageResult<T> where T : class,new()
    {
        /// <summary>
        /// 数据总条数
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// 查询返回数据
        /// </summary>
        public List<T> Rows { get; set; }
    }
}
