﻿using System.Web.Mvc;

namespace DBTek.BugGuardian.MVC.Filters
{
    public class BugGuardianBugHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {            
            base.OnException(filterContext);
            
            using (var creator = new Creator())
            {
                //Implemented as synchronous because Asp.net doesn't support async filters
                creator.AddBug(filterContext.Exception);
            }
        }
    }
}