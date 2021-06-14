using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFDbFirstApprochExample.Filters
{
    public class MyActionFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.NoOfVisitorsOfTheDay = 60;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
           
            filterContext.Controller.ViewBag.NoOfVisitorsOfTheDay = 50;
        }
    }
}