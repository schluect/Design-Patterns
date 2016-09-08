using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeDPrintingProjects.Services.Statistics.Models;

namespace ThreeDPrintingProjects.Services.Statistics
{
    public interface IStatsService
    {
        void TrackProjectSummaryCreation(ProjectSummaryCreation projectCreation);
        void TrackAddDesign(AddDesign addDesign);
    }
}
