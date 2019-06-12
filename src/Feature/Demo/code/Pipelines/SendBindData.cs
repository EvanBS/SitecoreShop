namespace Sitecore.Feature.Demo.Pipelines
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using Sitecore.Diagnostics;
    using Sitecore.Feature.Demo.Models.CustomModelBinders;
    using Sitecore.Pipelines;

    public class SendBindData
    {
        public void Process(PipelineArgs args)
        {
            ModelBinderProviders.BinderProviders.Insert(0, new XMLToObjectModelBinderProvider());
            Log.Info("SendBindDataPip", this);
        }
    }
}