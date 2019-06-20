using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Web.Script.Serialization;
using Sitecore;
using Sitecore.Feature.RssLoader.DTO;
using Sitecore.Mvc.Extensions;
using Sitecore.Mvc.Pipelines.Response.RenderRendering;
using Sitecore.Mvc.Presentation;

namespace Sitecore.Feature.Demo.Pipelines
{
    public class GenerateKeys : Sitecore.Mvc.Pipelines.Response.RenderRendering.GenerateCacheKey
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
            string url = "http://api.openweathermap.org/data/2.5/weather?q=Kyiv&appid=19a005c212fb37a0afcc54d06133e6ee";

            var json = new WebClient().DownloadString(url);

            JavaScriptSerializer js = new JavaScriptSerializer();
            var productList = js.Deserialize<Weather>(json);

            var currentDegrees = float.Parse(productList.main.temp.Replace(".", ","));

            currentDegrees -= 273;


            return "_#weather:" + currentDegrees;
        }
    }
}