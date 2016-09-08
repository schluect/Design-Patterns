using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace ThreeDPrintingProjects.Services.Project.Model
{
    public class ProjectModel
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
    }
}
