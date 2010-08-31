using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Reflection;
using Castle.Windsor;

namespace KMS.Presentation
{
    public class MyControllerFactory : IControllerFactory
    {
        public MyControllerFactory(IWindsorContainer container)
        {
            this.container = container;
        }

        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            Assembly ass = Assembly.GetAssembly(typeof(MyControllerFactory));
            Type type = ass.GetType(controllerName + "Controller");
            if (type == null)
                return null;
            if (container.Kernel.HasComponent(type))
                return (IController)container.Resolve(type);
            return null;
        }

        public void ReleaseController(IController controller)
        {
            container.Release(controller);
        }

        private IWindsorContainer container;
    }
}