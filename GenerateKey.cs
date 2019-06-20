using System;
using System.Diagnostics.CodeAnalysis;
using Sitecore;
using Sitecore.Mvc.Extensions;
using Sitecore.Mvc.Pipelines.Response.RenderRendering;
using Sitecore.Mvc.Presentation;

namespace Sitecore.Foundation.Caching.Pipelines
{
    public class GenerateKey : Sitecore.Mvc.Pipelines.Response.RenderRendering.GenerateCacheKey
    {
        protected override string GenerateKey(Rendering rendering, RenderRenderingArgs args)
        {
            var key = base.GenerateKey(rendering, args);

            if (string.IsNullOrWhiteSpace(key)) return null;

            try
            {
                if (rendering.RenderingItem.InnerItem["VaryByWebsite"].ToBool())
                    key += GetUrlExtend();
            }
            catch (Exception)
            {
                return key;
            }

            return key;
        }

        private static string GetUrlExtend()
        {
            var site = Context.Site;

            return "_#url:" + site.Name;
        }
    }
}