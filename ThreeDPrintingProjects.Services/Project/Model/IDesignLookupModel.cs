using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeDPrintingProjects.Services.DesignRepo;

namespace ThreeDPrintingProjects.Services.Project.Model
{
    public interface IDesignLookupModel
    {
        DesignRepoSource DesignRepoSource { get; set; }
    }
}
