using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;
using WebApplication1.DAO;
using Microsoft.AspNet.Identity;

namespace WebApplication1.Controllers
{
    
    public class DoctorController : Controller
    {
        readonly DoctorDAO Doctor = new DoctorDAO();
        // GET: Doctor
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                var sql = @"SELECT * FROM Doctors";
                var result = context.Database.SqlQuery<DoctorModels>(sql).ToList();
                return View(result);
            }

        }
        [Authorize(Roles = "Admin, Doctor")]
        public ActionResult Create(string Id)
        {
            return View();
        }
        [Authorize(Roles = "Admin, Doctor")]
        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "")] DoctorModels DoctorModel)
        {
            try
            {
                if (Doctor.Create(DoctorModel))
                    return RedirectToAction("Index");
                else
                    return View("Create");
            }
            catch
            {
                return View("Create");
            }
        }
        [Authorize(Roles = "Admin, Doctor")]
        public ActionResult Edit(string Idr)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "")] DoctorModels DoctorModel)
        {
            try
            {
                if (Doctor.Edit(DoctorModel))
                    return RedirectToAction("Index");
                else
                    return View("Edit");
            }
            catch
            {
                return View("Edit");
            }
        }
        [Authorize(Roles = "Doctor")]
        public ActionResult Detali(int? Id)
        {
            using (var context = new ApplicationDbContext())
            {
                var sql = @"SELECT * FROM Doctors WHERE EmailD = '" + User.Identity.GetUserName() + "'";
                var result = context.Database.SqlQuery<DoctorModels>(sql).ToList();
                return View(result);
            }

        }

        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int Idr, DoctorModels DoctorModel)
        {
            int records1 = DoctorModel.Delete(Idr);
            if (records1 > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Can Not Delete");
                return View("Index");
            }
        }

    }
}
    
