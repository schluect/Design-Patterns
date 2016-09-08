using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ThreeDPrintingProjects.Services.DesignRepo.Model
{
    public class Design
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Public_Url { get; set; }
        public string Thumbnail { get; set; }
    }
}
