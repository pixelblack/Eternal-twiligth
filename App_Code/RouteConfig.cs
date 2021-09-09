using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;
/// <summary>
/// Esta clase se encarga de cortar la extencion de las urls
/// </summary>
public static class RouteConfig
{
    public static void RegisterRoutes(RouteCollection routes)
    {
        FriendlyUrlSettings settings = new FriendlyUrlSettings();
        settings.AutoRedirectMode = RedirectMode.Permanent;
        routes.EnableFriendlyUrls(settings);
    }

}