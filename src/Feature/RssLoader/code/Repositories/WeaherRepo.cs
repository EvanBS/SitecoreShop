namespace Sitecore.Feature.RssLoader.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Script.Serialization;
    using Sitecore.Data.Items;
    using Sitecore.Feature.RssLoader.DTO;
    using Sitecore.Foundation.DependencyInjection;
    using Sitecore.Foundation.Indexing.Models;
    using Sitecore.Foundation.Indexing.Repositories;
    using Sitecore.Foundation.SitecoreExtensions.Extensions;

    [Service(typeof(IWeatherRepo))]
    public class WeaherRepo : IWeatherRepo
    {
        
        public float GetWeather()
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q=Kyiv&appid=19a005c212fb37a0afcc54d06133e6ee";

            var json = new WebClient().DownloadString(url);

            JavaScriptSerializer js = new JavaScriptSerializer();
            var productList = js.Deserialize<Weather>(json);

            var currentDegrees = float.Parse(productList.main.temp.Replace(".", ","));

            currentDegrees -= 273;

            return currentDegrees;
        }
    }
}