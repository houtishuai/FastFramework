using Demo.Application.AppServices.Dto;
using Demo.Core.AppServices;

namespace Demo.Application.AppServices
{
    /// <summary>
    /// 医生相关服务接口
    /// </summary>
    public interface IDoctorService
    {
        /// <summary>
        /// 根据医生账号密码获取医生信息
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <returns>医生账号信息</returns>
        DoctorInfo GetDoctorInfoByAccount(string account, string password);
    }
}
