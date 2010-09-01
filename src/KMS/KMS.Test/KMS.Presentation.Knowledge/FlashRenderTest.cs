using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using KMS.BLL.Search;
using KMS.Presentation.Knowledge;
using KMS.BLL;
using KMS.Model;
using NUnit.Framework;
using KMS.Common;

namespace KMS.Test.KMS.Presentation.Knowledge
{
    [TestFixture]
    public class FlashRenderTest
    {
        [Test]
        public void RenderTest()
        {
            string expected = "<embed src=\'http://player.youku.com/player.php/sid/XMjAzMDQ2NjQ0/v.swf\' quality=\'high\' width=\'480\' height=\'400\' type=\'application/x-shockwave-flash\' />";
            string URL ="http://player.youku.com/player.php/sid/XMjAzMDQ2NjQ0/v.swf";
            string MIME1 = "image/gif";
            string MIME2 = "flv-application/octet-stream";
            FlashRender render = new FlashRender();
            NameValueCollection attr = new NameValueCollection();
            attr.Add("quality", "high");
            attr.Add("width", "480");
            attr.Add("height", "400");
            attr.Add("type", "application/x-shockwave-flash");


            bool mimeFail = render.IsSupported(MIME1);
            string content2 = render.Render(URL, MIME2, attr);
            Assert.IsFalse(mimeFail);
            Assert.AreEqual(expected, content2);
            
        }

    }
}
