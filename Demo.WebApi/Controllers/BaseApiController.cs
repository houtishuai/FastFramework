using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Claims;

namespace Demo.WebApi.Controllers
{
    [Authorize]
    public class BaseApiController : ApiController
    {
        /// <summary>
        /// 医生ID
        /// </summary>
        public int DoctorID { get; set; }

        /// <summary>
        /// 医生姓名
        /// </summary>
        public string DoctorName { get; set; }

        protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext)
        {
            //获取身份验证信息
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userClaim = claimsIdentity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            if (userClaim != null)
            {
                this.DoctorID = int.Parse(userClaim.Value);
                this.DoctorName = claimsIdentity.Name;
            }
            base.Initialize(controllerContext);
        }
    }
}
