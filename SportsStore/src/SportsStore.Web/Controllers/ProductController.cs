using SportsStore.Domain.Abstraction;
using SportsStore.Domain.Entities;
using SportsStore.Web.Models;
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
        public int PageSize { get; set; } = 3;
        public ProductController(IProductRepo r)
        {
            repo = r;
        }

        // GET: Product
        public ViewResult List(string category, int page =1)
        {
            //return View(repo.Products.OrderBy(p => p.ProductID).Skip((page - 1) * PageSize).Take(PageSize));
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repo.Products.Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems =  category==null? repo.Products.Count():repo.Products.Where(p=>p.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }

        public FileContentResult GetImage(int productId)
        {
            Product p = repo.Products.FirstOrDefault(a => a.ProductID == productId);
            if (p != null)
            {
                return File(p.ImageData, p.ImageMimeType);
            }
            return null;
        }
    }
}