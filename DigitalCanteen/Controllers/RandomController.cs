using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DigitalCanteen.Models.Entities;
using DigitalCanteen.Data;


namespace DigitalCanteen.Controllers
{
    public class RandomController : Controller
    {

        private DataContext db = new DataContext();
        //
        // GET: /Random/
        //public static Random random;
        [HttpGet]
        public ActionResult RandomIndex()
        {
            Random rnd = new Random();
            RandomNo r = new RandomNo
            {

                RandomNumber = rnd.Next(999,1000000),
            };
           // ViewBag.Message = r;
            return View(r);
        }

        [HttpPost]
        public ActionResult RandomIndex(RandomNo model)
        {
            if (ModelState.IsValid)
            {
                db.RandomNoes.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index", "User");
            }
            return View();
        }
       

	}
}