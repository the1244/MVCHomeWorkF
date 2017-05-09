﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCHomeWorkF.Models;

namespace MVCHomeWorkF.Controllers
{
    public class 客戶資料ViewController : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();

        // GET: 客戶資料View
        public ActionResult Index()
        {
            return View(db.客戶資料View.ToList());
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
