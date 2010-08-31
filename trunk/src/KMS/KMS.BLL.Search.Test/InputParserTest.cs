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
        public void Test2()
        {
            string text = "tags:a b c";
            string content = InputParser.ParseContent(text, "tags");
            Console.WriteLine(content);
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
        [Test]
        public void LongText()
        {
            string text = " tags: x1, x2, x3 tag:123 31,4 dateRange: 2007-1-1~ 2010-2 date: 2009-1-1";
            string content1 = InputParser.ParseContent(text, "tags");
            string content2 = InputParser.ParseContent(text, "tag");
            string content3 = InputParser.ParseContent(text, "dateRange");
            string content4 = InputParser.ParseContent(text, "date");

            Assert.AreEqual("x1, x2, x3", content1);
            Assert.AreEqual("123 31,4", content2);
            Assert.AreEqual("2007-1-1~ 2010-2", content3);
            Assert.AreEqual("2009-1-1", content4);

        }
    }
}
