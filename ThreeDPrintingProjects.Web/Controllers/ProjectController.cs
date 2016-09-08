using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThreeDPrintingProjects.Services.Project.Builder;
using ThreeDPrintingProjects.Services.Project.Model;
using ThreeDPrintingProjects.Services.Project.Service;
using ThreeDPrintingProjects.Web.Infrastructure;
using ThreeDPrintingProjects.Web.Models.Project;

namespace ThreeDPrintingProjects.Web.Controllers
{
    public class ProjectController : Controller
    {
        private IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // GET: Project
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(string id)
        {
            return View();
        }

        [Route(Name="ProjectCreate")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProjectDetails projectDetails)
        {
            if (ModelState.IsValid)
            {
                IProjectBuilder projectBuilder = _projectService.StartProject();
                projectBuilder.BuildProjectDetails(new ProjectDetailModel
                {
                    Description = projectDetails.Description,
                    Name = projectDetails.Name
                });

                SessionStateSink.ProjectBuilder = projectBuilder;
                return RedirectToAction("Index", "Designs");
            }

            return View(projectDetails);
        }

        [ProjectBuilderRequired]
        public ActionResult Summary()
        {
            SummaryModel model = SessionStateSink.ProjectBuilder.GetSummary();

            return View(model);
        }
    }
}