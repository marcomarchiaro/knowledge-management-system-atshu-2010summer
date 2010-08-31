using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Castle.Windsor;
using KMS.Model;
using KMS.BLL.Search.Knowledge;

namespace KMS.BLL.Search.Test
{
    [TestFixture]
    public class DateRangeFilterTest
    {
        [SetUp]
        public void Init()
        {
            IWindsorContainer container = ContainerBuilder.Build();
            knowledgeRepository = container.Resolve<IRepository<KnowledgeInfo>>();
            dateRangeFilter = container.Resolve<DateRangeFilter>();
        }

        [Test]
        public void InitData()
        {
            KnowledgeInfo k1 = new KnowledgeInfo();
            k1.Name = "k1";
            k1.Content = "k1";
            knowledgeRepository.SaveOnSubmit(k1);

            KnowledgeInfo k2 = new KnowledgeInfo();
            k2.Name = "k2";
            k2.Content = "k2";
            knowledgeRepository.SaveOnSubmit(k2);

            KnowledgeInfo k3 = new KnowledgeInfo();
            k3.Name = "k3";
            k3.Content = "k3";
            knowledgeRepository.SaveOnSubmit(k3);

            KnowledgeInfo k4 = new KnowledgeInfo();
            k4.Name = "k4";
            k4.Content = "k4";
            knowledgeRepository.SaveOnSubmit(k4);

            KnowledgeInfo k5 = new KnowledgeInfo();
            k5.Name = "k5";
            k5.Content = "k5";
            knowledgeRepository.SaveOnSubmit(k5);

            knowledgeRepository.SubmitChanges();
        }

        [Test]
        public void FilterTest()
        {
            var result = knowledgeRepository.GetAll();
            var result2 = dateRangeFilter.OnFilter(result, "dateRange:2010-7-25~2010-8-5");
            foreach (var p in result2.ToList())
            {
                Console.WriteLine(p.Name + "  " + p.TimeStamp);
            }
        }

        private IRepository<KnowledgeInfo> knowledgeRepository;
        private DateRangeFilter dateRangeFilter;
    }
}
