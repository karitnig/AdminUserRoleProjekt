using System.Web;
using System.Web.Mvc;

namespace AdminUserRoleProj_TMN
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
