using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeDPrintingProjects.Services.Project.Builder;

namespace ThreeDPrintingProjects.Services.Statistics
{
    public interface IStatTrackDecorator : IProjectBuilder
    {
        void SetProjectBuilder(IProjectBuilder projectBuilder);
    }
}
