using SocialGoal.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SocialGoal.Web.Core.Filters
{
    public class ErrorPageAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            filterContext.Result = new RedirectResult("/Error/ErrorPage");
            LogHelper.WriteLog("ErrorLog", filterContext.Exception.ToString());
        }
    }
}