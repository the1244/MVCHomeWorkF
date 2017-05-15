using System;
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
    public class 客戶資料Controller : BaseController
    {
        private 客戶資料Entities db = new 客戶資料Entities();

        [HttpPost]
        public ActionResult Index(string strSearch)
        {
            var list = 客戶資料Repository.get客戶資料AllList();
            if (!string.IsNullOrEmpty(strSearch))
            {
                list = 客戶資料Repository.搜尋關鍵字(list, strSearch);
                //list = list.Where(a => a.客戶名稱.Contains(strSearch));
            }
            return View(list);
        }

        // GET: 客戶資料
        public ActionResult Index()
        {
            var list = 客戶資料Repository.get客戶資料AllList();
            return View(list);
        }

        // GET: 客戶資料/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶資料 客戶資料 = db.客戶資料.Find(id);

            客戶資料 客戶資料 = 客戶資料Repository.取得單筆客戶資料byId(id);

            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: 客戶資料/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                客戶資料Repository.Add(客戶資料);
                客戶資料Repository.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(客戶資料);
        }

        // GET: 客戶資料/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = 客戶資料Repository.取得單筆客戶資料byId(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                客戶資料Repository.Update(客戶資料);
                客戶資料Repository.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = 客戶資料Repository.取得單筆客戶資料byId(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶資料 客戶資料 = 客戶資料Repository.取得單筆客戶資料byId(id);
            客戶資料Repository.Deleted(客戶資料);
            客戶資料Repository.UnitOfWork.Commit();

            return RedirectToAction("Index");
        }
    }
}
