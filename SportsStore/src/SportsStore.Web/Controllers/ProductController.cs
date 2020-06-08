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
        public int PageSize { get; set; } = 4;
        public ProductController(IProductRepo r)
        {
            repo = r;
        }

        // GET: Product
        public ViewResult List(int page =1)
        {
            return View(repo.Products.OrderBy(p => p.ProductID).Skip((page - 1) * PageSize).Take(PageSize));
        }
    }
}