using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication14.Models;

namespace WebApplication14.Controllers
{
    public class ModelController : Controller
    {
        // GET: Model
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult admin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult admin(string name, string image, string price) {

            try
            {
                var products = Session["Products"] as List<Class1.admin>;
                if (products == null)
                {
                    products = new List<Class1.admin>();
                }
                var product = new Class1.admin
                {
                   
                    name = name,
                    price = price,
                    image = image
                };

                products.Add(product);

                Session["Products"] = products;
                return RedirectToAction("cart");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult cart()
        {
            var products = Session["Products"] as List<Class1.admin>;

            ViewBag.Products = products;

            return View(products);
        }
    }
}