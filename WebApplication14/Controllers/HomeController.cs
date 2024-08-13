using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication14.Controllers
{
    public class HomeController : Controller
    {
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
        public ActionResult admin(string name, string image, string price)
        {

            if (Session["name"] == null)
            {
                Session["name"] = new List<string>();
            }
            if (Session["image"] == null)
            {
                Session["image"] = new List<string>();
            }
            if (Session["price"] == null)
            {
                Session["price"] = new List<string>();
            }
            //List<string> list = new List<string>();
            var names = Session["name"] as List<string>;
            names.Add(name);
            Session["name"] = names;
            var images = Session["image"] as List<string>;
            images.Add(image);
            Session["image"] = images;
            var prices = Session["price"] as List<string>;
            prices.Add(price);
            Session["price"] = prices;

            return RedirectToAction("cart");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ClearSession()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }







        [HttpGet]
        public ActionResult cart()
        {


            return View()
                    ;
        }
        [HttpPost]
        [ActionName("cart")]
        public ActionResult cart1()
        {


            return RedirectToAction("admin");
            ;
        }
    }
}