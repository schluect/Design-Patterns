using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeDPrintingProjects.Services.Project.Builder;
using ThreeDPrintingProjects.Services.Statistics.Models;

namespace ThreeDPrintingProjects.Services.Statistics
{
    public class StatTrackerProjectBuilder: IStatTrackDecorator
    {
        private IProjectBuilder _projectBuilder;
        private IStatsService _statsService;
        public StatTrackerProjectBuilder(IStatsService statsService)
        {
            _statsService = statsService;
        }

        public void SetProjectBuilder(IProjectBuilder projectBuilder)
        {
            _projectBuilder = projectBuilder;
        }

        public Project.Model.AddDesignResult BuildDesign(int id)
        {
            _statsService.TrackAddDesign(new AddDesign(){ DesignId = id, DateCreated = DateTimeOffset.UtcNow });
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
            _statsService.TrackProjectSummaryCreation(new ProjectSummaryCreation(){ DesignIds = _projectBuilder.GetDesignIds(), DateCreated = DateTimeOffset.UtcNow });
            return _projectBuilder.GetSummary();
        }

        public ICollection<int> GetDesignIds()
        {
            return _projectBuilder.GetDesignIds();
        }
    }
}
