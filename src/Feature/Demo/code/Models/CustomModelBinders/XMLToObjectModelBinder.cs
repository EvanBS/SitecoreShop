using Sitecore.Analytics;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace Sitecore.Feature.Demo.Models.CustomModelBinders
{
    public class XMLToObjectModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            TestInfo testInfo = new TestInfo();
            testInfo.fuck = "Fuk";
            return testInfo;

        }
    }


    public class XMLToObjectModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(Type modelType)
        {
            //5.
            var receivedContentType = HttpContext.Current.Request.ContentType.ToLower();
            if (receivedContentType != "text/xml")
            {
                return null;
            }

            return new XMLToObjectModelBinder();
        }
    }


}