using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ThreeDPrintingProjects.Services.DesignRepo.Model;
using ThreeDPrintingProjects.Services.Project.Model;

namespace ThreeDPrintingProjects.Services.Project.Builder
{
    public interface IProjectBuilder
    {
        AddDesignResult BuildDesign(int id);
        RemoveDesignResult RemoveDesign(int id);
        bool BuildProjectDetails(ProjectDetailModel projectDetailModel);
        bool ContainsDesign(int id);
        SummaryModel GetSummary();
    }
}
