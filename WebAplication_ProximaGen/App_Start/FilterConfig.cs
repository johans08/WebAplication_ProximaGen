using System.Web;
using System.Web.Mvc;

namespace WebAplication_ProximaGen
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
