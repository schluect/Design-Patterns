using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeDPrintingProjects.Services.DesignRepo.Model;

namespace ThreeDPrintingProjects.Services.DesignRepo
{
    public interface IDesignRepoService
    {
        List<Design> SearchForDesigns(string keyword);
        string Authenticate(string code);
        Design GetById(int id);
    }
}
