using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using ThreeDPrintingProjects.Services.DesignRepo;
using ThreeDPrintingProjects.Services.DesignRepo.Model;
using ThreeDPrintingProjects.Services.Project.Model;

namespace ThreeDPrintingProjects.Services.Project.Builder
{
    public class ProjectBuilder: IProjectBuilder
    {
        private readonly IDictionary<int, Design> _designs;
        private ProjectDetailModel _projectDetailModel;
        private readonly IDesignRepoService _designRepoService;
        public ProjectBuilder(IDesignRepoService designRepoService)
        {
            _designRepoService = designRepoService;
            _designs = new Dictionary<int, Design>();
            _projectDetailModel = new ProjectDetailModel();
        }

        public bool ContainsDesign(int id)
        {
            return _designs.ContainsKey(id);
        }

        public AddDesignResult BuildDesign(int id)
        {
            Design design = GetDesign(id);
            if (design == null)
            {
                return new AddDesignResult { Success = false };
            }

            _designs.Add(id, design);
            return new AddDesignResult {Success = true};
        }

        public RemoveDesignResult RemoveDesign(int id)
        {
            return new RemoveDesignResult
            {
                Success = _designs.Remove(id)
            };
        }

        private Design GetDesign(int id)
        {
            if (!ContainsDesign(id))
            {
                return _designRepoService.GetById(id);
            }

            return  null;
        }

        public bool BuildProjectDetails(ProjectDetailModel projectDetailModel)
        {
            if (projectDetailModel == null)
            {
                return false;
            }

            _projectDetailModel = projectDetailModel;
            return true;
        }

        public SummaryModel GetSummary()
        {
            return new SummaryModel
            {
                Description = _projectDetailModel.Description,
                Name = _projectDetailModel.Name,
                SummaryDesignModels = _designs.Values.Select(x=>new SummaryDesignModel{ Name = x.Name, ImageUrl = x.Thumbnail, DetailUrl = x.Public_Url }).ToList()
            };
        }
    }
}
