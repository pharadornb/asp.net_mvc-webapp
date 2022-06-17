using asp.net_mvc_webapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp.net_mvc_webapp.Controllers
{
    public class Exam1Controller : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var model = new List<Exam1>();

            model.Add(new Exam1 { Name = "John Smith" });
            model.Add(new Exam1 { Name = "Mary Williams" });
            
            return View(model);
        }

        public ActionResult Details(int id)
        {
            return Content("id=" + id);
        }        
    }
}