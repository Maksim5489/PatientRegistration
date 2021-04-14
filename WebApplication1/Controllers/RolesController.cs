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

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin, Doctor")]
    public class RolesController : Controller
    {
        readonly Base bases = new Base();
        // GET: Roles
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                var sql = @"SELECT AspNetUsers.Id , AspNetUsers.PhoneNumber , AspNetUsers.UserName, AspNetRoles.Name As Role
                FROM AspNetUsers 
                LEFT JOIN AspNetUserRoles ON  AspNetUserRoles.UserId = AspNetUsers.Id 
                LEFT JOIN AspNetRoles ON AspNetRoles.Id = AspNetUserRoles.RoleId";
                var result = context.Database.SqlQuery<UsersWithRoles>(sql).ToList();
                return View(result);
            }

        }

        public ActionResult Edit(string Id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "")] UsersWithRoles UsersWithRole)
        {
            try
            {
                if (bases.Edited(UsersWithRole))
                    return RedirectToAction("Index");
                else
                    return View("Edit");
            }
            catch
            {
                return View("Edit");
            }
        }


        public ActionResult AddRole(string Id, string UserId)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult AddRole([Bind(Exclude = "")] UsersWithRoles UsersWithRole)
        {
            try
            {
                if (bases.AddRole(UsersWithRole))
                    return RedirectToAction("Index");
                else
                    return View("AddRole");
            }
            catch
            {
                return View("AddRole");
            }
        }
    }
}