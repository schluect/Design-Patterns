using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using ThreeDPrintingProjects.Services.Statistics.Models;

namespace ThreeDPrintingProjects.Services.Statistics
{
    public class StatsService: IStatsService
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

        public void TrackProjectSummaryCreation(ProjectSummaryCreation projectCreation)
        {
            var metric = new Metric<ProjectSummaryCreation>()
            {
                StatType = MetricType.CreateProjectSummary,
                Data = projectCreation
            };

            var projectCollection = Database.GetCollection<Metric<ProjectSummaryCreation>>("stats");
            projectCollection.InsertOne(metric);
        }

        public void TrackAddDesign(AddDesign addDesign)
        {
            var metric = new Metric<AddDesign>()
            {
                StatType = MetricType.AddDesign,
                Data = addDesign
            };

            var projectCollection = Database.GetCollection<Metric<AddDesign>>("stats");
            projectCollection.InsertOne(metric);
        }
    }
}
