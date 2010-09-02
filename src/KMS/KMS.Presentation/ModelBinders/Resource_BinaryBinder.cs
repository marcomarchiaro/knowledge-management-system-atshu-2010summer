using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KMS.Model;

namespace KMS.Presentation
{
    public class Resource_BinaryModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Resource_BinaryInfo model = new Resource_BinaryInfo();
            var form = controllerContext.HttpContext.Request.Form;
	        var files = controllerContext.HttpContext.Request.Files;

            if (files.Count != 1) 
                return null;
            if (files[0].ContentLength == 0) 
                return null;

            foreach (var property in model.GetType().GetProperties())
            {
                if (property.PropertyType!=typeof(string))
                    continue;
                foreach(string key in form.Keys)
                {
                    if(key ==property.Name)
                    {
                        property.SetValue(property, form[key], null);
                    }
                }
 
            }

            Stream stream = files[0].InputStream;
            stream.Read(model.Binary, 0, files[0].ContentLength);
            model.MIME = files[0].ContentType;

	        return model;
        }
    }
}
