using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using ThreeDPrintingProjects.Services.Project.Model;
using ThreeDPrintingProjects.Services.Project.Service;
using ThreeDPrintingProjects.Web.Models;

namespace ThreeDPrintingProjects.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Create", "Project");
            }

            var model = new HomeModel
            {
                ClientId = ConfigurationManager.AppSettings["Thingiverse:client_id"],
                PartialView = "_IsNotAuthenticated"
            };
            return View(model);
        }
    }
}