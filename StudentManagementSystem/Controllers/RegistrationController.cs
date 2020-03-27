using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    public class RegistrationController : Controller
    {
        private StudentManagementSystemEntities db = new StudentManagementSystemEntities();

        // GET: /Registration/
        public ActionResult Index(string searchBy, string search,int? page, string sortBy)
        {
            //Sorting by name and gender
            ViewBag.SortNamePerameter = string.IsNullOrEmpty(sortBy) ? "Name Desc" : "";
            ViewBag.SortGenderPerameter = sortBy=="Gender" ? "Gender Desc" : "Gender";

            var registrations = db.Registrations.AsQueryable();
            

            if (searchBy == "Gender")
            {
                registrations = registrations.Where(x => x.gender == search || search == null);
               
            }
            else
            {
                registrations = registrations.Where(x => x.firstname.StartsWith(search) || search == null);
            }
            switch (sortBy)
            {
                case "Name Desc":
                    registrations = registrations.OrderByDescending(x => x.firstname);
                    break;
                case "Gender Desc":
                    registrations = registrations.OrderByDescending(x => x.gender);
                    break;
                case "Gender":
                    registrations = registrations.OrderBy(x => x.gender);
                    break;
                    //By default the index action method sorted by name with ascending order
                    default:
                    registrations = registrations.OrderBy(x => x.firstname);
                    break;
            }
            //include paging to show the index value

            return View(registrations.ToPagedList(page ?? 1, 3));

            //var registrations = db.Registrations.Include(r => r.Batch).Include(r => r.Course);
            //return View(registrations.ToList());
        }

        // GET: /Registration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.Registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // GET: /Registration/Create
        public ActionResult Create()
        {
            List<SelectListItem> coursSelectListItems=new List<SelectListItem>();
            foreach (Course course in db.Courses)
            {
                SelectListItem selectListItem = new SelectListItem()
                {
                    Text = course.course1,
                    Value = course.id.ToString(),
                    Selected = course.IsSelected.HasValue ? course.IsSelected.Value : false
                };
                coursSelectListItems.Add(selectListItem);
            }
            
            ViewBag.course_id = coursSelectListItems;

            //db data--key--value--selected Item value

            ViewBag.batch_id = new SelectList(db.Batches, "id", "batch1", "1");

            return View();
        }

        // POST: /Registration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,firstname,lastname,nic,Date,batch_id,course_id,phone")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                db.Registrations.Add(registration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.batch_id = new SelectList(db.Batches, "id", "batch1",registration.batch_id);
            ViewBag.course_id = new SelectList(db.Courses, "id", "course1", registration.course_id);
            return View(registration);
        }

        // GET: /Registration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.Registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            ViewBag.batch_id = new SelectList(db.Batches, "id", "batch1", registration.batch_id);
            ViewBag.course_id = new SelectList(db.Courses, "id", "course1", registration.course_id);
            return View(registration);
        }

        // POST: /Registration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,firstname,lastname,nic,Date,batch_id,course_id,phone,email,gender,salary")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.batch_id = new SelectList(db.Batches, "id", "batch1", registration.batch_id);
            ViewBag.course_id = new SelectList(db.Courses, "id", "course1", registration.course_id);
            return View(registration);
        }

        // GET: /Registration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.Registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // POST: /Registration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registration registration = db.Registrations.Find(id);
            db.Registrations.Remove(registration);
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
