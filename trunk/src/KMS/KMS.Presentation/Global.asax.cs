using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using MvcContrib.ControllerFactories;
using MvcContrib.Interfaces;
using Castle.Windsor;
using Microsoft.Practices.ServiceLocation;

namespace KMS.Presentation
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication, IContainerAccessor
    {
        protected void Application_Start()
        {
            RouteTable.Routes.MapRoute(
                "Resource",
                "Resource/{id}",
                new { controller = "Resource", action = "GetResourceHTML" }
                );

            RouteTable.Routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );

            InitializeWindsor();
        }

        protected void Application_End()
        {
            container.Dispose();
        }

        protected virtual void InitializeWindsor()
        {
            if (container != null)
                return;
            container = ContainerBuilder.Build();
            //IDependencyResolver resolver = new DependencyResolver(container);
            //IoCControllerFactory controllerFactory = new IoCControllerFactory(resolver);
            // set the controller factory to the Windsor controller factory (in MVC Contrib)
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container));
            ServiceLocator.SetLocatorProvider(() => container.Resolve<IServiceLocator>());
        }

        #region IContainerAccessor 成员

        public IWindsorContainer Container
        {
            get { return container; }
        }

        private static IWindsorContainer container;

        #endregion
    }
}