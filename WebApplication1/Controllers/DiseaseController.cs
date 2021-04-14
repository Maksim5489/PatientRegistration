using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Doctor, Patient")]
    public class DiseaseController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                var sql = @"SELECT Disease.Id,Doctors.Qualification, PA.Policy_number, Disease, Recept, Date, Doctors.DocFIO, Disease.Doctor, Disease.FIOp AS FIO  FROM Disease
                LEFT JOIN Patient AS PA ON Disease.EmailZ = PA.Email
                LEFT JOIN Doctors ON  Disease.Doctor = Doctors.EmailD
                WHERE Disease.EmailZ = '" + User.Identity.GetUserName() + "'";
                var result = context.Database.SqlQuery<DiseaseModels>(sql).ToList();
                return View(result);
            }

        }
        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int Id, DiseaseModels DiseaseModel)
        {
            int records1 = DiseaseModel.Delete(Id);
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