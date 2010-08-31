using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using KMS.BLL.Search.Knowledge;

namespace KMS.BLL.Search.Test
{
    [TestFixture]
    public class InputParserTest
    {
        [Test]
        public void DateRangeTag()
        {
            string str = InputParser.ParseContent("dateRange:2010-8-8~2010-8-12", "dateRange");
            Assert.AreEqual("2010-8-8~2010-8-12", str);
        }

        [Test]
        public void ComplicatedText()
        {
            string text = "  dateRange:123~1345 tags:a b c ";
            string content1 = InputParser.ParseContent(text, "dateRange");
            string content2 = InputParser.ParseContent(text, "tags");
            Assert.AreEqual("123~1345", content1);
            Assert.AreEqual("a b c", content2);
        }
    }
}
