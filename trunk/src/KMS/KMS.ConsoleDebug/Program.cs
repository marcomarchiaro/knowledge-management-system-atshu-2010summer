using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Web;
using KMS.BLL;
using KMS.Model;
using Castle.Windsor;
using NHibernate;

namespace KMS.ConsoleDebug
{
    class Program
    {
        public static IWindsorContainer container;

        static void Main(string[] args)
        {
            container = ContainerBuilder.Build();
            Test1();
        }

        static void Test1()
        {
            Repository<Resource_FlashInfo> re = container.Resolve<Repository<Resource_FlashInfo>>();
            Repository<ResourceInfo> rr = container.Resolve<Repository<ResourceInfo>>();
            Resource_FlashInfo aaa;
            Repository<TagInfo> rt = container.Resolve<Repository<TagInfo>>();
            TagInfo bbb;
            Repository<ResourceTagAssociationInfo> r3 = container.Resolve<Repository<ResourceTagAssociationInfo>>();

            ISession session = re.Session;
            ;
            Console.WriteLine(rr.GetById(new Guid("96533852-291f-4707-8fb2-4dca88551e93")).GetType());
            ResourceTagAssociationInfo ccc = r3.GetById(1);
            //aaa = (Resource_FlashInfo)ccc.ResourceInfo;
            Console.WriteLine(ccc.ResourceInfo.GetType());
            
            Console.ReadLine();
        }
    }
}
