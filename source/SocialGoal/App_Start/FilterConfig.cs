using SocialGoal.Web.Core.Filters;
using System.Web;
using System.Web.Mvc;

namespace SocialGoal
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ErrorPageAttribute());
        }
    }
}