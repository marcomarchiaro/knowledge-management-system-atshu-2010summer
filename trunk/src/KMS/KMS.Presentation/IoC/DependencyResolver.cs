using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcContrib.Interfaces;
using Castle.Windsor;

namespace KMS.Presentation
{
    public class DependencyResolver : IDependencyResolver
    {
        public DependencyResolver(IWindsorContainer container)
        {
            this.container = container;
        }

        #region IDependencyResolver 成员

        public void DisposeImplementation(object instance)
        {
            container.Release(instance);
        }

        public object GetImplementationOf(Type type)
        {
            if (this.container.Kernel.HasComponent(type))
            {
                return this.container.Resolve(type);
            }
            return null;
        }

        public Interface GetImplementationOf<Interface>(Type type)
        {
            return (Interface)this.GetImplementationOf(type);
        }

        public Interface GetImplementationOf<Interface>()
        {
            return (Interface)this.GetImplementationOf(typeof(Interface));
        }

        #endregion

        private IWindsorContainer container;
    }
}
