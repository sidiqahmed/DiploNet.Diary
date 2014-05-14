using System.Web;
using System.Web.Mvc;

namespace DiploNet.Diary.Web.MVCSite
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}