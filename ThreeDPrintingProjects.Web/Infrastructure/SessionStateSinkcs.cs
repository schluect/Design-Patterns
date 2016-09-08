using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;
using ThreeDPrintingProjects.Services.DesignRepo.Model;
using ThreeDPrintingProjects.Services.Project.Builder;
using ThreeDPrintingProjects.Services.Project.Model;
using ThreeDPrintingProjects.Web.Models.Project;

namespace ThreeDPrintingProjects.Web.Infrastructure
{
    public class SessionStateSink
    {
        private static HttpSessionState Session
        {
            get { return HttpContext.Current.Session; }
        }

        private const string ProjectBuilderKey = "CurrentProjectBuilder";

        public static IProjectBuilder ProjectBuilder
        {
            get
            {
                return new ProjectBuilder(null);
                return (IProjectBuilder)Session[ProjectBuilderKey];
            }
            set
            {
                Session[ProjectBuilderKey] = value;
            }
        }

        private const string DesignsAddedKey = "DesignsAdded";
        public static IDictionary<int, Design> DesignsAdded
        {
            get
            {
                if (Session[DesignsAddedKey] == null)
                {
                    Session[DesignsAddedKey] = new Dictionary<int, Design>();
                }

                return (IDictionary<int, Design>)Session[DesignsAddedKey];
            }
            set
            {
                if (Session[DesignsAddedKey] == null)
                {
                    Session[DesignsAddedKey] = new Dictionary<int, Design>();
                }

                Session[DesignsAddedKey] = value;
            }
        }

        private const string ProjectDetailKey = "ProjectDetail";
        public static ProjectDetails ProjectDetail
        {
            get
            {
                return (ProjectDetails)Session[ProjectDetailKey];
            }
            set
            {
                Session[ProjectDetailKey] = value;
            }
        }

        private const string ThingiverseCodeKey = "ThingiverseCode";
        public static string ThingiverseCode
        {
            get
            {
                return (string)Session[ThingiverseCodeKey];
            }
            set
            {
                Session[ThingiverseCodeKey] = value;
            }
        }
    }
}