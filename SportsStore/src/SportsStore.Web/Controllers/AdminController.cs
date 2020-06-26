using SportsStore.Domain.Abstraction;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductRepo repository;

        public AdminController(IProductRepo repo)
        {
            repository = repo;
        }


        // GET: Admin
        public ViewResult Index()
        {
            return View(repository.Products);
        }

        public ViewResult Edit(int productId)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase image=null)
        {
            if (ModelState.IsValid)
            {
                if(image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    //读取流：将数据从流传输到数据结构（如字节数组）中
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
                repository.SaveProduct(product);
                TempData["message"] = $"{product.Name}已经被保存！";
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ViewResult Create()
        {
            return View("Edit", new Product());
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product deletedP = repository.DeleteProduct(productId);
            if (deletedP != null)
            {
                TempData["message"] = $"{deletedP.Name}已经被删除！";
            }
            return RedirectToAction("Index");
        }
    }
}