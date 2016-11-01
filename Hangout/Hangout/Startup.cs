using System.Web.Mvc;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HangOut.Startup))]
namespace HangOut
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
    public static class MyClass
    {
        public static bool DoesViewExist(this HtmlHelper html, string name)
        {
            var controllerContext = html.ViewContext.Controller.ControllerContext;
            var result = ViewEngines.Engines.FindView(controllerContext, name, null);
            return result.View != null;
        }
    }
}
