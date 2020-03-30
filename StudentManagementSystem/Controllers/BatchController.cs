using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    public class BatchController : Controller
    {
        private StudentManagementSystemEntities db = new StudentManagementSystemEntities();

        // GET: /Batch/
        public ActionResult Index()
        {
            return View(db.Batches.ToList());
        }
        [HttpPost]
        public ActionResult Index(string searchTerm)
        {
            List<Batch> datalist;

            if (string.IsNullOrEmpty(searchTerm))
            {
                datalist = db.Batches.ToList();
            }
            else
            {
                datalist = db.Batches.Where(x => x.batch1.StartsWith(searchTerm)).ToList();
            }
            return View(datalist);
        }

        
        public JsonResult GetBatches(string searchTerm)
        {
            //In the search text box we dont want batch object, we just want to return list of string that will contain the name of the batch

            var datalist = db.Batches.Where(x => x.batch1.StartsWith(searchTerm)).Select(x => x.batch1).ToList();
            return Json(datalist, JsonRequestBehavior.AllowGet);

            //List<BatchModel> datalist = db.Batches.Where(x => x.batch1.Contains(searchTerm)).Select(x => new BatchModel
            //{
            //    id = x.id,
            //    batch1 = x.batch1
            //}).ToList();
            //return new JsonResult{Data = datalist,JsonRequestBehavior =JsonRequestBehavior.AllowGet};
        }

        // GET: /Batch/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Batch batch = db.Batches.Find(id);
            if (batch == null)
            {
                return HttpNotFound();
            }
            return View(batch);
        }

        // GET: /Batch/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Batch/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,batch1,year")] Batch batch)
        {
            if (ModelState.IsValid)
            {
                db.Batches.Add(batch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(batch);
        }

        // GET: /Batch/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Batch batch = db.Batches.Find(id);
            if (batch == null)
            {
                return HttpNotFound();
            }
            return View(batch);
        }

        // POST: /Batch/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,batch1,year")] Batch batch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(batch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(batch);
        }

        // GET: /Batch/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Batch batch = db.Batches.Find(id);
            if (batch == null)
            {
                return HttpNotFound();
            }
            return View(batch);
        }

        // POST: /Batch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Batch batch = db.Batches.Find(id);
            db.Batches.Remove(batch);
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
