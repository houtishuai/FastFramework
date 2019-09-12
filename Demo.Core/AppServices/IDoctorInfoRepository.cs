using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.AppServices
{
    public interface IDoctorInfoRepository
    {
        /// <summary>
        /// 根据医生id获取医生信息
        /// </summary>
        /// <param name="id">医生id</param>
        /// <returns></returns>
        DoctorInfo GetDoctorInfoById(int id);
    }
}
