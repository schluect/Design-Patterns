using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using ThreeDPrintingProjects.Services.Project.Builder;
using ThreeDPrintingProjects.Services.Project.Model;

namespace ThreeDPrintingProjects.Services.Project.Service
{
    public interface IProjectService
    {
        bool CreateProject(ProjectModel project);
        bool UpdateProject(ProjectModel project);
        ProjectModel GetProject(ObjectId id);
        List<ProjectModel> GetProjectsForUser(string userId);
        IProjectBuilder StartProject();
    }
}
