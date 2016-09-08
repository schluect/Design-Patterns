using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeDPrintingProjects.Services.Project.Builder;

namespace ThreeDPrintingProjects.Services.Statistics
{
    public class StatTrackerProjectBuilder: IProjectBuilder
    {
        private IProjectBuilder _projectBuilder;
        public void SetProjectBuilder(IProjectBuilder projectBuilder)
        {
            _projectBuilder = projectBuilder;
        }

        public Project.Model.AddDesignResult BuildDesign(int id)
        {
            return _projectBuilder.BuildDesign(id);
        }

        public Project.Model.RemoveDesignResult RemoveDesign(int id)
        {
            return _projectBuilder.RemoveDesign(id);
        }

        public bool BuildProjectDetails(Project.Model.ProjectDetailModel projectDetailModel)
        {
            return _projectBuilder.BuildProjectDetails(projectDetailModel);
        }

        public bool ContainsDesign(int id)
        {
            return _projectBuilder.ContainsDesign(id);
        }

        public Project.Model.SummaryModel GetSummary()
        {
            return _projectBuilder.GetSummary();
        }
    }
}
