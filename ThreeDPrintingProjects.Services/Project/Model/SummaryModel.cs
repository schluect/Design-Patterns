using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeDPrintingProjects.Services.Project.Model
{
    public class SummaryModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SummaryDesignModel> SummaryDesignModels { get; set; } 
    }
}
