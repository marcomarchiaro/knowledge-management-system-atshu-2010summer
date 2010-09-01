using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Mvc.Resources;
using System.Globalization;
using System.Reflection;
using Castle.Windsor;

namespace KMS.Presentation
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        // The constructor:
        // 1. Sets up a new IoC container
        // 2. Registers all components specified in web.config
        // 3. Registers all controller types as components
        public WindsorControllerFactory(IWindsorContainer container)
        {
            this.container = container;
        }

        // Constructs the controller instance needed to service each request this part is Updated to be compatible with MVC 2
        protected override IController
            GetControllerInstance
            (RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
                throw new HttpException(0x194, "NoControllerFound");
            if(!container.Kernel.HasComponent(controllerType))
                throw new InvalidOperationException();
            return container.Resolve(controllerType) as IController;
        }
        /*
         * For MVC 1 use this
        protected override IController GetControllerInstance(Type controllerType)
        {
            return (IController)container.Resolve(controllerType);
        }*/

        private IWindsorContainer container;
    }
}
