using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class quanliController : Controller
    {
        private ExpenditureEntities db = new ExpenditureEntities();

        // GET: /quanli/
        public ActionResult Index()
        {
            var model = db.Quanlichitieux.ToList();
            return View(model);
        }

        // GET: /quanli/Details/5
        public ActionResult Details(int? id)
        {
            var model = db.Quanlichitieux.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: /quanli/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /quanli/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Quanlichitieu model)
        {
            ValidateModel(model);
            if (ModelState.IsValid)
            {
                model.Date = DateTime.Today;
                db.Quanlichitieux.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }
        private void ValidateModel(Quanlichitieu model)
        {
            if (model.Total <= 0)
            {
                ModelState.AddModelError("Total", "Số tiền quá ít!");
            }
        }
        // GET: /quanli/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quanlichitieu quanlichitieu = db.Quanlichitieux.Find(id);
            if (quanlichitieu == null)
            {
                return HttpNotFound();
            }
            return View(quanlichitieu);
        }

        // POST: /quanli/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,Date,Total,Detail")] Quanlichitieu quanlichitieu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quanlichitieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quanlichitieu);
        }

        // GET: /quanli/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quanlichitieu quanlichitieu = db.Quanlichitieux.Find(id);
            if (quanlichitieu == null)
            {
                return HttpNotFound();
            }
            return View(quanlichitieu);
        }

        // POST: /quanli/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quanlichitieu quanlichitieu = db.Quanlichitieux.Find(id);
            db.Quanlichitieux.Remove(quanlichitieu);
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
