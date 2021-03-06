﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DigitalCanteen.Data;
using DigitalCanteen.Models.Entities;

namespace DigitalCanteen.Controllers
{
    public class UserController : Controller
    {
        private DataContext _context;
        // GET: User
        public ActionResult Index()
        {
            if (Session["USER"] != null)
            {
                var user = Session["USER"] as UserDetail;
                if (user != null) ViewBag.Username = user.FullName;
                return View();
            }
            return RedirectToAction("Login", "Home");
        }

        public ActionResult UserIndex()
        {
            if (Session["USER"] != null)
            {
                var user = Session["USER"] as UserDetail;
                if (user != null)
                {
                    ViewBag.Username = user.FullName;
                    ViewBag.UserType = user.UserCredential.UserType;
                }

                return View();
            }
            return RedirectToAction("Login", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserDetail model)
        {
            if (ModelState.IsValid)
            {
                _context = new DataContext();

                var regi = _context.UserCredentials.FirstOrDefault(p => p.Username == model.UserCredential.Username);

                if (regi == null)
                {
                    try
                    {
                        _context.UserDetails.Add(model);
                        var accDetail = new AccountDetail();
                        accDetail.UserId = model.UserId;
                        accDetail.Balance = 0;
                        _context.AccountDetails.Add(accDetail);

                        _context.SaveChanges();
                    }

                    catch
                        (Exception exception)
                    {
                        ModelState.AddModelError("", exception.ToString());
                        return View(model);
                    }

                    return RedirectToAction("Login", "Home");
                }

                else
                {
                    return RedirectToAction("Register", "User");
                }
                // If we got this far, something failed, redisplay form
              //  return View(model);
            }
            return View(model);
        }
    }
}