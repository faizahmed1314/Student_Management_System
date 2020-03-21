using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        StudentManagementSystemEntities _db=new StudentManagementSystemEntities();
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                using (StudentManagementSystemEntities _db = new StudentManagementSystemEntities())
                {
                    var obj =
                        _db.Users.Where(m => m.username.Equals(user.username) && m.password.Equals(user.password))
                            .FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserId"] = user.id.ToString();
                        Session["UserName"] = user.username.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("","The User Name And Password Is Incorrect!");
                    }
                }
            }
            return View(user);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
	}
}