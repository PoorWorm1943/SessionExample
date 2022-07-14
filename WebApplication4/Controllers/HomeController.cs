using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string acc, string pwd)
        {
            // 假設成功

            DateTime dt = DateTime.Now;

            // 現在開始時間
            string startTime = dt.ToString("yyyy-MM-dd HH:mm:ss");
            string endTime = dt.AddSeconds(600).ToString("yyyy-MM-dd HH:mm:ss");


            this.Request.HttpContext.Session.SetString("startTime", startTime);
            this.Request.HttpContext.Session.SetString("endTime", endTime);


            return Content("Ok");
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult CheckLeftTime()
        {
            
            string endTimeStr = this.Request.HttpContext.Session.GetString("endTime");
            if(endTimeStr == null)
            {
                return Content("");
            }

            var endTime = DateTime.ParseExact(endTimeStr, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            var timeSpan = endTime.Subtract(DateTime.Now);

            string leftTime = $@"{timeSpan.TotalSeconds}";


            return Content(leftTime);
        }

    }
}