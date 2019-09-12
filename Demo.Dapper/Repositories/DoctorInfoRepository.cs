using Demo.Core.AppServices;

namespace Demo.Dapper.Repositories
{
    public class DoctorInfoRepository : DapperRepository<DoctorInfo>, IDoctorInfoRepository
    {
        /// <summary>
        /// 根据医生id获取医生信息
        /// </summary>
        /// <param name="id">医生id</param>
        /// <returns></returns>
        public DoctorInfo GetDoctorInfoById(int id)
        {
            return this.Get(id);
        }
    }
}
