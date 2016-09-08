using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using MongoDB.Bson;
using MongoDB.Driver;
using Ninject;
using ThreeDPrintingProjects.Services.Project.Builder;
using ThreeDPrintingProjects.Services.Project.Model;
using ThreeDPrintingProjects.Services.Statistics;

namespace ThreeDPrintingProjects.Services.Project.Service
{
    public class ProjectService: IProjectService
    {
        private MongoClient CreateMongoClient()
        {
            string user = ConfigurationManager.AppSettings["db:user"];
            string pass = ConfigurationManager.AppSettings["db:pass"];
            string url = ConfigurationManager.AppSettings["db:url"];
            return new MongoClient(string.Format("mongodb://{0}:{1}@{2}", user, pass, url));
        }

        private IMongoDatabase _database;
        private IMongoDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    _database = CreateMongoClient().GetDatabase("threed_projects");
                }
                return _database;
            }
        }

        public bool CreateProject(ProjectModel project)
        {
            var projectCollection = Database.GetCollection<ProjectModel>("projects");
            projectCollection.InsertOne(project);
            return true;
        }

        public bool UpdateProject(ProjectModel project)
        {
            var projectCollection = Database.GetCollection<ProjectModel>("projects");
            projectCollection.FindOneAndReplace(x => x.Id.Equals(project.Id), project);
            return true;
        }

        public ProjectModel GetProject(ObjectId id)
        {
            var projectCollection = Database.GetCollection<ProjectModel>("projects");
            return projectCollection.Find(x => x.Id.Equals(id)).First();
        }

        public List<ProjectModel> GetProjectsForUser(string userId)
        {
            var projectCollection = Database.GetCollection<ProjectModel>("projects");
            return projectCollection.Find(x => x.UserId.Equals(userId)).ToList();
        }

        public IProjectBuilder StartProject()
        {
            IProjectBuilder projectBuilder = ServiceLocator.Current.GetInstance<IProjectBuilder>();
            IStatTrackDecotrator statDecoratorProjectBuilder = ServiceLocator.Current.GetInstance<IStatTrackDecotrator>();

            statDecoratorProjectBuilder.SetProjectBuilder(projectBuilder);

            return statDecoratorProjectBuilder;
        }
    }
}
