using System;
using Dapper.Contrib.Extensions;

namespace Demo.Core.AppServices
{
    [Table("DoctorInfo")]
    public class DoctorInfo
    {

        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 账号名称
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 账号密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// 医生名称
        /// </summary>
        public string DoctorName { get; set; }

        /// <summary>
        /// 医生简称
        /// </summary>
        public string DoctorShortName { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public string UpdateBy { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// 医生等级
        /// </summary>
        public int? DoctorLevel { get; set; }

        /// <summary>
        /// 医生星标
        /// </summary>
        public int? DoctorStar { get; set; }
    }
}
