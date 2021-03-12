using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_Repository_Pattern_Db_First.Repositories;
using Test_Repository_Pattern_Db_First.Models;

namespace Test_Repository_Pattern_Db_First.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult AllProducts()
        {
            ProductRepository products = new ProductRepository();
            var allProducts = products.GetAll();
            return View(allProducts);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CategoryRepository categoryList = new CategoryRepository();
            ViewData["categories"] = categoryList.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            ProductRepository addProduct = new ProductRepository();
            addProduct.Insert(product);

            return RedirectToAction("AllProducts");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            CategoryRepository categoryList = new CategoryRepository();
            ViewData["categories"] = categoryList.GetAll();

            ProductRepository product = new ProductRepository();
            var singleProduct = product.Get(id);
            return View(singleProduct);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            /*ProductRepository editProduct = new ProductRepository();
            editProduct.Update(product);

            return RedirectToAction("AllProducts");*/
            return Content(product.ProductName + " " +product.CategoryId+ " " +product.Price);
        }
    }
}