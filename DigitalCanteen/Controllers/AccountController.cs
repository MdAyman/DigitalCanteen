using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DigitalCanteen.Models.Entities;
using DigitalCanteen.Data;

namespace DigitalCanteen.Controllers
{
    public class AccountController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /Account/
        public ActionResult Index()
        {
            var currentuser = (UserDetail)Session["User"];

            var accountdetails = db.AccountDetails.Include(r => r.UserDetail).Where(r => r.UserDetail.UserId == currentuser.UserId);
            
            return View(accountdetails.ToList());
        }

        public ActionResult RefilBalance()
        {
            return View();
        }

        //public ActionResult RefilBalance(FormCollection form)
        //{
        //    var param1 = Convert.ToDouble(Collection["param1"]);
        //    var find = db.RandomNoes.FirstOrDefault( c => c.RandomNumber == form.param1);
        //}

        [HttpPost]
        public ActionResult RefilBalance(RandomNo model)
        {
            var find = db.RandomNoes.FirstOrDefault(c => c.RandomNumber == model.RandomNumber && c.IsCheck.Equals(false));


            if (find != null)
            {
                var currentuser = (UserDetail) Session["User"]; //current logged in user
                // var taka = db.AccountDetails.Include(r => r.UserDetail).Where(c => c.UserDetail.UserId == currentuser.UserId);
                int amount = find.Amount; //amount from model

                //var query = from usr in db.AccountDetails
                //    where usr.UserId == currentuser.UserId
                //    select User;

                var res =
                    db.AccountDetails.Include(r => r.UserDetail)
                        .FirstOrDefault(r => r.UserDetail.UserId == currentuser.UserId);
                if (res.Balance != null)
                {
                    res.Balance += amount;

                }
                
                //var res =
                //    db.AccountDetails.Include(r => r.UserDetail).Where(r => r.UserDetail.UserId == currentuser.UserId)
                //        .Select(r => r.Balance);



                //foreach (var value in res)
                //{
                //    value.Balance = amount;
                //}
                try
                {
                    find.IsCheck = true;
                    db.SaveChanges();
                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                }
                

                //ViewData["msg"] = res;
                return RedirectToAction("Success", "Account");

            }
            else
            {
                return RedirectToAction("Error", "Account");
            }
            return View(model);
        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        // GET: /Account/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountDetail accountdetail = db.AccountDetails.Find(id);
            if (accountdetail == null)
            {
                return HttpNotFound();
            }
            return View(accountdetail);
        }

        // GET: /Account/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.UserDetails, "UserId", "FullName");
            return View();
        }

        // POST: /Account/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="UserId,InitialBalance,Balance,Refil")] AccountDetail accountdetail)
        {
            if (ModelState.IsValid)
            {
                db.AccountDetails.Add(accountdetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UserDetails, "UserId", "FullName", accountdetail.UserId);
            return View(accountdetail);
        }

        // GET: /Account/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountDetail accountdetail = db.AccountDetails.Find(id);
            if (accountdetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserDetails, "UserId", "FullName", accountdetail.UserId);
            return View(accountdetail);
        }

        // POST: /Account/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="UserId,InitialBalance,Balance,Refil")] AccountDetail accountdetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountdetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.UserDetails, "UserId", "FullName", accountdetail.UserId);
            return View(accountdetail);
        }

        // GET: /Account/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountDetail accountdetail = db.AccountDetails.Find(id);
            if (accountdetail == null)
            {
                return HttpNotFound();
            }
            return View(accountdetail);
        }

        // POST: /Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccountDetail accountdetail = db.AccountDetails.Find(id);
            db.AccountDetails.Remove(accountdetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
