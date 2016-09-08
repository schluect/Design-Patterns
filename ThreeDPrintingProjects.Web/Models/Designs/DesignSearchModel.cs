using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThreeDPrintingProjects.Services.DesignRepo.Model;

namespace ThreeDPrintingProjects.Web.Models.Designs
{
    public class DesignSearchModel
    {
        public List<DesignModel> Designs { get; set; }
        public string Keyword { get; set; }
    }
}