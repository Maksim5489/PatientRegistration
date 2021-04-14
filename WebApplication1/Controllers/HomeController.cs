using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAO;
using WebApplication1.Models;
using System.Data.SqlClient;

namespace WebApplication1.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
