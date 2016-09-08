using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThreeDPrintingProjects.Web.Infrastructure;

namespace ThreeDPrintingProjects.Web.Controllers
{
    public class ThingiverseController : Controller
    {
        // GET: Thingiverse
        public ActionResult Callback(string code)
        {
            SessionStateSink.ThingiverseCode = code;
            return RedirectToAction("Index", "Designs");
        }

        // GET: Thingiverse
        public ActionResult Connect()
        {
            return Redirect("http://www.thingiverse.com/login/oauth/authorize?client_id=f05b688862d157a7a915");
        }
    }
}