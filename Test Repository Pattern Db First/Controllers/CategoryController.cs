using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_Repository_Pattern_Db_First.Models;
using Test_Repository_Pattern_Db_First.Repositories;

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
}