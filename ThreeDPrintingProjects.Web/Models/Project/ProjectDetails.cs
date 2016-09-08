using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ThreeDPrintingProjects.Web.Models.Project
{
    public class ProjectDetails
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(2000)]
        public string Description { get; set; }
    }
}