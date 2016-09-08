using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using ThreeDPrintingProjects.Services.DesignRepo;
using ThreeDPrintingProjects.Services.Project.Builder;
using ThreeDPrintingProjects.Services.Project.Service;

namespace ThreeDPrintingProjects.NinjectModules
{
    public class ServiceModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IProjectService>().To<ProjectService>();
            Bind<IProjectBuilder>().To<ProjectBuilder>().InTransientScope();
            Bind<IDesignRepoService>().To<DesignRepoService>();
        }
    }
}
