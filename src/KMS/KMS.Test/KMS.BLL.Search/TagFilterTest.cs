﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Castle.Windsor;
using KMS.Model;
using KMS.BLL.Search.Knowledge;
using KMS.DAL;

namespace KMS.Test
{
    [TestFixture]
    public class TagFilterTest
    {
        [SetUp]
        public void Init()
        {
            IWindsorContainer container = ContainerBuilder.Build();
            knowledgeRepository = container.Resolve<IRepository<KnowledgeInfo>>();
            tagRepository = container.Resolve<IRepository<TagInfo>>();
            knowledgeTagAssociationRepository = container.Resolve<IRepository<KnowledgeTagAssociationInfo>>();
            tagFilter = container.Resolve<TagFilter>();
        }

        [Test]
        public void FilterTest1()
        {
            var result = knowledgeRepository.GetAll();
            var result2 = tagFilter.OnFilter(result, "tags:a b c");
            foreach(var p in result2)
            {
                Console.WriteLine(p.KnowledgeId);
            }
        }
        private IRepository<KnowledgeInfo> knowledgeRepository;
        private IRepository<TagInfo> tagRepository;
        private IRepository<KnowledgeTagAssociationInfo> knowledgeTagAssociationRepository;
        private TagFilter tagFilter;
    }
}

