using System.Web;
using System.Web.SessionState;
using ThreeDPrintingProjects.Services.Project.Builder;

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
                return (IProjectBuilder)Session[ProjectBuilderKey];
            }
            set
            {
                Session[ProjectBuilderKey] = value;
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