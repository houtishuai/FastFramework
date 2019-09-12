using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.Extensions
{
    /// <summary>
    /// 值类型扩展方法
    /// </summary>
    public static class ValueExtension
    {
        /// <summary>
        ///  指示指定的字符串是null还是空字符串("")
        /// </summary>
        /// <param name="value">要测试的字符串</param>
        /// <returns>如果value参数为null或空字符串(""),则为 true;否则为 false</returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// 将数字的字符串表示形式转换为它的等效32位有符号整数,一个指示转换是否成功的返回值
        /// </summary>
        /// <param name="value">要转换的字符串</param>
        /// <returns>如果成功转换了value,则为true;否则为false</returns>
        public static bool IsInt(this string value)
        {
            int i;
            return int.TryParse(value, out i);
        }

        /// <summary>
        /// 将数字的字符串表示形式转换为它的等效32位有符号整数
        /// </summary>
        /// <param name="value">要转换的字符串</param>
        /// <returns>与value中包含的数字等效的32位有符号整数</returns>
        public static int ToInt32(this string value)
        {
            if (!IsInt(value)) return 0;
            else return Int32.Parse(value);
        }

        /// <summary>
        /// 判断两个字符串是否相等,忽略大小写
        /// </summary>
        /// <param name="source">要比较的第一个字符串,或null。</param>
        /// <param name="value">要比较的第二个字符串,或null。</param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase(this string source, string value)
        {
            if (!string.IsNullOrEmpty(source))
                return source.Equals(value, StringComparison.OrdinalIgnoreCase);
            else
                return false;
        }
    }
}
