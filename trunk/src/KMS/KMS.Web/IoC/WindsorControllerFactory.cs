using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.Windsor;

namespace KMS.Web
{
    [Obsolete]
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        public WindsorControllerFactory(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }

        protected override IController GetControllerInstance(Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(0x194, string.Format("The controller for path '{0}' could not be found or it does not implement IController.", base.RequestContext.HttpContext.Request.Path));
            }
            return (IController)this.container.Resolve(controllerType);
        }

        public override void ReleaseController(IController controller)
        {
            this.container.Release(controller);
        }

        private IWindsorContainer container;
    }
}
