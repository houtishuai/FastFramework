using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.WebApi.Controllers
{
    /// <summary>
    /// 首页控制器
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}
