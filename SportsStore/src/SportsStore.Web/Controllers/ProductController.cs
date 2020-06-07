using SportsStore.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepo repo;
        public ProductController(IProductRepo r)
        {
            repo = r;
        }

        // GET: Product
        public ViewResult List()
        {
            return View(repo.Products);
        }
    }
}