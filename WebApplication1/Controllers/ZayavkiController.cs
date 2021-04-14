using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAO;
using WebApplication1.Models;
using Microsoft.AspNet.Identity;
using System.Data.SqlClient;
using System.Security.Claims;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Patient, Doctor")]
    public class ZayavkiController : Controller
    {
        readonly ZayavkiDAO Zayavki = new ZayavkiDAO();

        // GET: Zayavki
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                var sql = @"SELECT Doctors.Qualification, PA.Policy_number, Disease, Recept, Date, Doctors.DocFIO, Zayavki.Doctor, Zayavki.FIOp AS FIO  FROM Zayavki
                LEFT JOIN Patient AS PA ON Zayavki.EmailZ = PA.Email
                LEFT JOIN Doctors ON  Zayavki.Doctor = Doctors.EmailD
                WHERE Zayavki.EmailZ = '" + User.Identity.GetUserName() + "' or Doctors.EmailD= '"+ User.Identity.GetUserName() + "'";
                var result = context.Database.SqlQuery<ZayavkiModels>(sql).ToList();
                return View(result);
            }

        }

        public ActionResult Edit(string Id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "")] ZayavkiModels ZayavkiModel)
        {
            try
            {
                if (Zayavki.Edit(ZayavkiModel) )
                    return RedirectToAction("Index");
                else
                    return View("Edit");
            }
            catch
            {
                return View("Edit");
            }
        }

        public ActionResult CreateDoctors(string Id)
        {
            string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-WebApplication1-20201104082923.mdf;Initial Catalog=aspnet-WebApplication1-20201104082923;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT Doctors.Qualification, Doctors.EmailD FROM dbo.Doctors", conn);
                conn.Open();
                SqlDataReader myreader = cmd.ExecuteReader();
                List<SelectListItem> list = new List<SelectListItem>();
                while (myreader.Read())
                {
                    {
                        list.Add(new SelectListItem() { Text = myreader["Qualification"].ToString(), Value = myreader["EmailD"].ToString() });
                    };

                }
                ViewBag.Listtest = list;
                //conn.Close();
            }
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult CreateDoctors([Bind(Exclude = "")]ZayavkiModels ZayavkiModel)
        {
            try
            {
                if (Zayavki.CreateDoctors(ZayavkiModel))
                    return RedirectToAction("Index");
                else
                    return View("CreateDoctors");
            }
            catch
            {
                return View("CreateDoctors");
            }
        }

        public ActionResult Delete(string Id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(ZayavkiModels ZayavkiModel)
        {
            using (var context = new ApplicationDbContext())
            {
                var copy = @"INSERT Disease ([Date], [Doctor], [Recept], [FIOp], [EmailZ],[EmailQ], [Disease]) SELECT [Date], [Doctor], [Recept], [FIOp], [EmailZ],[EmailQ], [Disease] FROM Zayavki where Zayavki.Date IN(SELECT TOP (1) Date FROM Zayavki ORDER BY Date ASC)"; /*WHERE Zayavki.EmailZ='" + User.Identity.Name + "'"*/
                var resultcopy = context.Database.SqlQuery<ZayavkiModels>(copy).ToList();
                var sqldelete = @"Delete from Zayavki where Zayavki.Date IN(SELECT TOP (1) Date FROM Zayavki ORDER BY Date ASC)";
                var result = context.Database.SqlQuery<ZayavkiModels>(sqldelete).ToList();
            }
            return Redirect("/Zayavki/Index");
        }
    }
}