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
using System.Net;
using System.Web.Security;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace WebApplication1.Controllers
{
    
    public class PatientController : Controller
    {
        PatientModels PatientModel = new PatientModels();
        private ApplicationDbContext db = new ApplicationDbContext();
        readonly PatietnDAO Patietn = new PatietnDAO();

        [Authorize(Roles = "User, Patient")]
        public ActionResult Reg()
        {
            return View();
        }


        [Authorize(Roles = "Admin, Doctor")]
        // GET: Patient
        public ActionResult Index(int? Id)
        {
            using (var context = new ApplicationDbContext())
            {
                var sql = @"SELECT * FROM Patient";
                var result = context.Database.SqlQuery<PatientModels>(sql).ToList();
                return View(result);
            }

        }
        [Authorize(Roles = "Admin, Doctor, Patient")]
        public ActionResult Create(int? Id, string Email)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "")] PatientModels PatientModel)
        {
            using (var context = new ApplicationDbContext())
            {
                var copy = @"Update AspNetUserRoles SET RoleId='3' WHERE AspNetUserRoles.UserId ='"+ User.Identity.GetUserId() + "'";
                var resultcopy = context.Database.SqlQuery<ZayavkiModels>(copy).ToList();
            }
            try
            {
                if (Patietn.Create(PatientModel))
                    return RedirectToAction("Index");
                else
                    return View("Create");
            }
            catch
            {
                return View("Create");
            }
        }

        [Authorize(Roles = "Admin, Doctor, Patient")]
        public ActionResult Edit(int? Id)
        {
            return View();
        }
        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "")] PatientModels PatientModel)
        {
            try
            {
                if (Patietn.Edit(PatientModel))
                    return RedirectToAction("Index");
                else
                    return View("Edit");
            }
            catch
            {
                return View("Edit");
            }
        }
        [Authorize(Roles = "Admin, Doctor, Patient")]
        public ActionResult Detali(int? Id)
        {
            using (var context = new ApplicationDbContext())
            {
                var sql = @"SELECT * FROM Patient WHERE Email = '" + User.Identity.GetUserName() + "'";
                var result = context.Database.SqlQuery<PatientModels>(sql).ToList();
                return View(result);
            }
        }
    }
}