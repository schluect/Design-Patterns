using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThreeDPrintingProjects.Services.DesignRepo.Model;

namespace ThreeDPrintingProjects.Web.Models.Designs
{
    public class DesignModel: Design
    {
        public DesignModel(Design design)
        {
            Id = design.Id;
            Name = design.Name;
            Url = design.Url;
            Public_Url = design.Public_Url;
            Thumbnail = design.Thumbnail;
        }

        public bool HasBeenAdded { get; set; }
    }
}