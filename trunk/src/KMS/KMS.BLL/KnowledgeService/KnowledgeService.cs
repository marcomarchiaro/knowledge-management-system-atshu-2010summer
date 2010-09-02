using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Model;
using KMS.DAL;
using KMS.BLL.Search;
using Castle.Services.Transaction;

namespace KMS.BLL
{
    public class KnowledgeService : IKnowledgeService
    {
        public KnowledgeService(
            IRepository<KnowledgeInfo> knowledgeRepo,
            IRepository<KnowledgeTagAssociationInfo> knowTagAssRepo,
            IRepository<KnowledgeClassInfo> knowledgeClassRepo,
            IRepository<KnowledgeKnowledgeClassAssociationInfo> knowKnowClsAssRepo,
            IRepository<TagInfo> tagRepo,
            IKeyWordAnalyzer keyWordAnalyzer)
        {
            this.tagRepo = tagRepo;
            this.knowKnowClsAssRepo = knowKnowClsAssRepo;
            this.knowledgeClassRepo = knowledgeClassRepo;
            this.knowledgeRepo = knowledgeRepo;
            this.knowTagAssRepo = knowTagAssRepo;
            this.keyWordAnalyzer = keyWordAnalyzer;
        }

        public void CreateKnowledge(KnowledgeInfo knowledge,int knowledgeClassId, IEnumerable<string> tags)
        {
            KnowledgeClassInfo knowClass = knowledgeClassRepo.GetById(knowledgeClassId);
            if (knowClass == null)
                throw new Exception("指定的知识分类不存在");

            knowledgeRepo.SaveOnSubmit(knowledge);

            KnowledgeKnowledgeClassAssociationInfo kkc = new KnowledgeKnowledgeClassAssociationInfo();
            kkc.KnowledgeInfo = knowledge;
            kkc.KnowledgeClassInfo = knowClass;
            knowKnowClsAssRepo.SaveOnSubmit(kkc);

            //IEnumerable<string> tags2 = tags; //keyWordAnalyzer.DoAnalyze(tags);
            IEnumerable<string> tags2 = keyWordAnalyzer.DoAnalyze(tags);
            foreach (var t in tags2)
            {
                var result = from tt in tagRepo.GetAll()
                             where tt.Name == t
                             select tt;
                if (result.Count() == 0)
                {
                    TagInfo tag = new TagInfo();
                    tag.Name = t;
                    tagRepo.SaveOnSubmit(tag);
                    KnowledgeTagAssociationInfo kta = new KnowledgeTagAssociationInfo();
                    kta.KnowledgeInfo = knowledge;
                    kta.TagInfo = tag;
                    knowTagAssRepo.SaveOnSubmit(kta);
                }
                else
                {
                    foreach (var r in result)
                    {
                        KnowledgeTagAssociationInfo kta = new KnowledgeTagAssociationInfo();
                        kta.KnowledgeInfo = knowledge;
                        kta.TagInfo = r;
                        knowTagAssRepo.SaveOnSubmit(kta);
                    }
                }
            }
        }

        private IRepository<KnowledgeInfo> knowledgeRepo;
        private IRepository<KnowledgeClassInfo> knowledgeClassRepo;
        private IRepository<TagInfo> tagRepo;
        private IRepository<KnowledgeTagAssociationInfo> knowTagAssRepo;
        private IRepository<KnowledgeKnowledgeClassAssociationInfo> knowKnowClsAssRepo;
        private IKeyWordAnalyzer keyWordAnalyzer;
    }
}
