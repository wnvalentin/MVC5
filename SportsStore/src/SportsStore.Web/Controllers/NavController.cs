using SportsStore.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.Web.Controllers
{
    public class NavController : Controller
    {
        private IProductRepo repository;
        public NavController(IProductRepo repo)
        {
            repository = repo;
        }
        //public PartialViewResult Menu(string category=null, bool horizontalLayout=false)
        //{
        //    ViewBag.SelectedCategory = category;

        //    IEnumerable<string> categories = repository.Products
        //    .Select(x => x.Category)
        //    .Distinct()
        //    .OrderBy(x => x);

        //    string viewName = horizontalLayout ? "MenuHorizontal" : "Menu";
        //    return PartialView(viewName, categories);
        //}
        //合并视图
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.Products
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x);

            return PartialView("FlexMenu", categories);
        }
    }
}