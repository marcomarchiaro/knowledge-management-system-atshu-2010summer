using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KMS.Model;

namespace KMS.Presentation
{
    public class KnowledgeClassBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            KnowledgeClassInfo knowledgeClass = (KnowledgeClassInfo)base.BindModel(controllerContext, bindingContext);
            if (knowledgeClass.FatherKnowledgeClassInfo == null)
            {
                knowledgeClass.FatherKnowledgeClassInfo = new KnowledgeClassInfo();
                knowledgeClass.FatherKnowledgeClassInfo.KnowledgeClassId = (Int32)bindingContext.ValueProvider.GetValue("fatherId").ConvertTo(typeof(Int32));
            }
            return knowledgeClass;
        }
    }
}