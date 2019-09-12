using Demo.Core;
using Demo.Core.Utils;
using Demo.Core.Extensions;
using Demo.Core.AppServices;
using Demo.Application.AppServices.Dto;

namespace Demo.Application.AppServices
{
    /// <summary>
    /// 医生相关服务
    /// </summary>
    public class DoctorService : AppServiceBase, IDoctorService
    {
        private readonly IRepository<DoctorInfo> _doctorInfoRepository;
        public DoctorService() { }
        public DoctorService(IRepository<DoctorInfo> doctorInfoRepository)
        {
            _doctorInfoRepository = doctorInfoRepository;
        }

        /// <summary>
        /// 根据医生账号密码获取医生信息
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <returns>医生账号信息</returns>
        public DoctorInfo GetDoctorInfoByAccount(string account, string password)
        {
            if (account.IsNullOrEmpty() ||
                password.IsNullOrEmpty())
                return null;

            var selectSql = "";
            var doctorInfoEntity = _doctorInfoRepository.QueryFirstOrDefault<DoctorInfo>(selectSql, new { Account = account, Password = password });
            return doctorInfoEntity;
        }
    }
}
