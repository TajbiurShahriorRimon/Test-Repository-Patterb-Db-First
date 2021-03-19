using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_Repository_Pattern_Db_First.Models;
using Test_Repository_Pattern_Db_First.Repositories;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Test_Repository_Pattern_Db_First.Controllers
{
    public class CategoryController : Controller
    {
        protected InventoryDbEntities context = new InventoryDbEntities();

        // GET: Category
        public ActionResult Index()
        {
            CategoryRepository category = new CategoryRepository();
            var allCategories = category.GetAll();
            return View(allCategories);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            int i = (int)id;

            HttpCookie cookie = new HttpCookie("categoryInfo");
            cookie["catId"] = i.ToString();
            cookie.Expires = DateTime.Now.AddSeconds(5);
            Response.Cookies.Add(cookie);

            CategoryRepository category = new CategoryRepository();
            var singleCategory = category.Get((int)i);
            return View(singleCategory);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            CategoryRepository categoryRepo = new CategoryRepository();
            categoryRepo.Update(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetTopThree()
        {
            var list = context.Categories.OrderByDescending(x => x.CategoryId).ToList().Take(3);
            return View(list);
        }

        /*[HttpGet]
        public ActionResult Chart()
        {
            List<Product> products = context.Products.Where(x => x.CategoryId == 1).ToList();
            Category category = new Category();
            //return Content("fesfes");
            //return Json(category, JsonRequestBehavior.AllowGet);
            return View(category);
        }*/

        public ActionResult Chart()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();

            /*dataPoints.Add(new DataPoint("USA", 121));
            dataPoints.Add(new DataPoint("Great Britain", 67));
            dataPoints.Add(new DataPoint("China", 70));
            dataPoints.Add(new DataPoint("Russia", 56));
            dataPoints.Add(new DataPoint("Germany", 42));
            dataPoints.Add(new DataPoint("Japan", 41));
            dataPoints.Add(new DataPoint("France", 42));
            dataPoints.Add(new DataPoint("South Korea", 21));*/

            List<DataPoint> dataPoints1 = new List<DataPoint>();

            ProductRepository product = new ProductRepository();
            List<Product> products = product.GetAll().ToList();

            foreach(Product p in products)
            {
                Product p1 = new Product();
                p1.ProductName = p.ProductName;
                p1.CategoryId = p.CategoryId;

                DataPoint dataPoint = new DataPoint(p1.ProductName, p1.CategoryId);
                dataPoints.Add(dataPoint);
                //dataPoint.Label = p1.ProductName;

            }

            //List<Product> data = (Product)product.GetAll().GroupBy(x => x.CategoryId).ToList();
            /*foreach (var d in data)
            {
                DataPoint d1 = new DataPoint();
                d1.Label = d.Key.
            }*/
            //List<Product> products = (Product)context.Products.Select(x => x.ProductName);

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }

        [HttpGet]
        public ActionResult CookieCheck()
        {
            HttpCookie httpCookie = Request.Cookies["categoryInfo"];
            //Cookie Exists and the Edit button is clicked
            if (httpCookie != null) {
                return Content(httpCookie["catId"]);
            }

            //Cookie Time Is Over!!
            return Content("Cookie Time is Over");
        }
    }

    public class CountCategory
    {
        public int Count { get; set; }
        //public int 
    }
}