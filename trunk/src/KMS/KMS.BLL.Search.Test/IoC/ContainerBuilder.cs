using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using KMS.BLL;
using KMS.BLL.Search.Knowledge;

namespace KMS.BLL.Search.Test
{
    public static class ContainerBuilder
    {
        public static IWindsorContainer Build()
        {
            var container = new WindsorContainer("Windsor.config");

            // add facilities
            //container.AddFacility("AutoTx", new TransactionFacility());
            //container.AddFacility("Logger", new LoggingFacility(LoggerImplementation.Log4net, "log4net.config"));
            // register handler selectors

            // automatically register controllers
            //container.Register(AllTypes
            //                       .Of<Controller>()
            //                       .FromAssembly(Assembly.GetExecutingAssembly())
            //                       .Configure(c => c.LifeStyle.Transient));

//            register services
            container.Register(
                Component.For<DateRangeFilter>().LifeStyle.Transient,
                Component.For<TagFilter>().LifeStyle.Transient,
                Component.For(typeof(IRepository<>)).ImplementedBy(typeof(Repository<>)).LifeStyle.Transient
                );

//             container.Register(
//                 Component.For(typeof(IRepository<>)).ImplementedBy(typeof(Repository<>)).LifeStyle.Transient
//                 Component.For<IRepository>().ImplementedBy<Repository>().LifeStyle.Transient,
//                 Component.For<IUserService>().ImplementedBy<UserService>().LifeStyle.Transient,
//                 Component.For<IAuthorizationFilter>().ImplementedBy<AuthorizationAttribute>().LifeStyle.Transient,
//                 Component.For<MarkSetupService>().LifeStyle.Transient,
//                 Component.For<ExamService>().LifeStyle.Transient,
//                 Component.For<PaperService>().LifeStyle.Transient,
//                 Component.For<MarkTeacherService>().LifeStyle.Transient,
//                 Component.For<CheckTeacherService>().LifeStyle.Transient,
//                 Component.For<MarkService>().LifeStyle.Transient,
//                 Component.For<CheckService>().LifeStyle.Transient,
// 
//                 Component.For<IServiceLocator>().Instance(new WindsorServiceLocator(container)).LifeStyle.Singleton,
//                 Component.For<IItemWrapperService>().ImplementedBy<ItemWrapperService>().LifeStyle.Singleton,
//                 Component.For<IItemAccess>().ImplementedBy<ItemAccess>().LifeStyle.Singleton,
//                 Component.For<ItemTypeTable>().LifeStyle.Singleton,
//                 Component.For<StudentAnswerParser>().LifeStyle.Singleton,
//                 Component.For<ItemContentService>().LifeStyle.Singleton
//                 );

            return container;
        }
    }
}
