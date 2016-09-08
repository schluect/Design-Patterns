using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThreeDPrintingProjects.Services.DesignRepo;
using ThreeDPrintingProjects.Services.DesignRepo.Model;
using ThreeDPrintingProjects.Services.Project.Model;
using ThreeDPrintingProjects.Web.Infrastructure;
using ThreeDPrintingProjects.Web.Models.Designs;

namespace ThreeDPrintingProjects.Web.Controllers
{
    [ProjectBuilderRequired]
    public class DesignsController : Controller
    {
        private IDesignRepoService _designRepoService;

        public DesignsController(IDesignRepoService designRepoService)
        {
           _designRepoService = designRepoService;
        }

        // GET: Designs
        public ActionResult Index(string keyword)
        {
            List<Design> designs = _designRepoService.SearchForDesigns(keyword);
            var designSearchModel = new DesignSearchModel
            {
                Designs = designs!=null?designs.Select(x=> new DesignModel(x) { HasBeenAdded = SessionStateSink.ProjectBuilder.ContainsDesign(x.Id) }).ToList():new List<DesignModel>(),
                Keyword = keyword
            };
            return View(designSearchModel);
        }

        public ActionResult Add(int id)
        {
            return Json(SessionStateSink.ProjectBuilder.BuildDesign(id));
        }

        public ActionResult Remove(int id)
        {
            return Json(SessionStateSink.ProjectBuilder.RemoveDesign(id));
        }
    }
}