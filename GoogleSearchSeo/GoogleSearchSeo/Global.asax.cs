using Castle.Windsor;
using Castle.Windsor.Installer;
using GoogleSearchSeo.Core.Logic.Conctract;
using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GoogleSearchSeo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer _container;

        public MvcApplication()
        {
            _container = new WindsorContainer().Install(FromAssembly.This());
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Setup Castle Windsor to resolve controller dependencies
            // Source: https://gist.github.com/martinnormark/3128275 
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(_container.Kernel));
        }
        
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex != null)
            {
                ILogger logger = _container.Resolve<ILogger>();
                logger.Error(ex);
            }
        }
    }
}
