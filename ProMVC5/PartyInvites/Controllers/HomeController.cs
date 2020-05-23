using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ViewResult Index()
        {
            DateTime dt = DateTime.Now;
            ViewBag.Time = dt.ToString($"现在是北京时间{dt.Year}年{dt.Month}月{dt.Day}日{dt.Hour}点{dt.Minute}分，" +
                $"星期{(int)dt.DayOfWeek}。");
            ViewBag.Greeting = dt.Hour < 12 ? "早上好！" : "下午好！";
            return View();
        }

        //返回一个重定向结果
        public ActionResult Items()
        {
            return new RedirectResult("Index");
        }

        
    }
}