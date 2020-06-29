using ControllerExtensibility.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllerExtensibility.Controllers
{
    public class ActionInvokerController : Controller
    {
        public ActionInvokerController()
        {
            //不同的Controller可以使用不同的 action invoker
            this.ActionInvoker = new CustomActionInvoker();
        }

        // GET: ActionInvoker
        public ActionResult Index()
        {
            return View();
        }
    }
}