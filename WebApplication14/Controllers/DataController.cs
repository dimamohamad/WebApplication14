using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication14.Models;

namespace WebApplication14.Controllers
{
    public class DataController : Controller
    {  private productEntities db =new productEntities();
        // GET: Data
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult admin() {
          return View();
        }
        [HttpPost]
        public ActionResult admin(item it )
        {   
           
              
                db.items.Add(it);
                db.SaveChanges();
                return RedirectToAction("cart");
          
     
        }
        public ActionResult cart(int? id)
        {
              List<item> items;
            if (id == null)
            {
               items = db.items.ToList();
            }
            else
            {
                items = db.items.Where(p => p.ID == id).ToList();
            }
            return View(items);
        }
    }
}