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
            return View();
        }

        //返回一个重定向结果
        public ActionResult Items()
        {
            return new RedirectResult("Index");
        }

        
    }
}