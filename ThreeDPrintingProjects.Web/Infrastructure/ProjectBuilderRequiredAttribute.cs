using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ThreeDPrintingProjects.Web.Infrastructure
{
    public class ProjectBuilderRequiredAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (SessionStateSink.ProjectBuilder == null)
            {
                filterContext.Result = new RedirectResult("/project/create");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}