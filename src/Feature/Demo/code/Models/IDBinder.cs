using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sitecore.Feature.Demo.Models
{
    public class IDBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ID id = ID.Null;

            string key = bindingContext.ModelName;
            ValueProviderResult val = bindingContext.ValueProvider.GetValue(key);

            if (val != null)
            {
                var s = val.AttemptedValue;
                if (!string.IsNullOrEmpty(s))
                {
                    ID.TryParse(s, out id);
                }
            }

            return id;
        }
    }
}
