using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Model;
using KMS.BLL;

namespace KMS.Presentation.Knowledge
{
    public class KnowledgeRender : IKnowledgeRender
    {
        public KnowledgeRender(IRepository<ResourceInfo> resourceRepository, IResourceRender resourceRender)
        {
            this.resourceRepository = resourceRepository;
            this.resourceRender = resourceRender;
        }

        /// <summary>
        /// 将KnowdegeInfo里的Content内容呈现到标准HTML。
        /// 如<html>
        ///     <div>你好</div>
        ///     <KMS:Resource id="ad123af-123131-543124-123123" />
        ///     <span>谢谢</span>
        ///   </html>
        /// 把其中<KMS:Resource ... />标记标识的id的ResourceInfo取出来，并用IKnowledgeRender接口里的RenderKnowledge方法替换掉
        /// </summary>
        /// <param name="knowledge"></param>
        /// <returns></returns>
        public string RenderKnowledge(KnowledgeInfo knowledge)
        {
            throw new NotImplementedException();
        }

        private IRepository<ResourceInfo> resourceRepository;
        private IResourceRender resourceRender;
    }
}
