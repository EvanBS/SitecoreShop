namespace Sitecore.Feature.RssLoader.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Net;
    using System.Text.RegularExpressions;
    using System.Web.Mvc;
    using System.Web.Script.Serialization;
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using Sitecore.Feature.RssLoader.DTO;
    using Sitecore.Feature.RssLoader.Repositories;
    using Sitecore.Foundation.SitecoreExtensions.Extensions;
    using Sitecore.Mvc.Presentation;
    using Sitecore.SecurityModel;
    using Sitecore.Analytics.Tracking;
    using Sitecore.Analytics;
    using System.Web.Http;

    public class RssLoaderController : Controller
    {
        public RssLoaderController(IRssLoaderRepository newsRepository, IWeatherRepo weatherRepo)
        {
            this.Repository = newsRepository;
            this.weatherRepo = weatherRepo;
        }

        private IRssLoaderRepository Repository { get; }
        private IWeatherRepo weatherRepo { get; }

        public ActionResult ByDataCustom()
        {
            return View("ByDataCustom", weatherRepo);
        }


        public string MyTest()
        {
            var dataSourceId = RenderingContext.CurrentOrNull.Rendering.DataSource;
            var dataSource = Sitecore.Context.Database.GetItem(dataSourceId);

            var n = dataSource.Fields["input"].Value;

            long nthPrime = FindPrimeNumber(Convert.ToInt32(n));


            return "calculated ^ " + nthPrime;
        }

        [System.Web.Mvc.HttpPost]
        public string HardAlg([FromBody] string inp)
        {
            long nthPrime = FindPrimeNumber(Convert.ToInt32(inp));

            return "zdarova : " + nthPrime.ToString();

            //nthPrime = 322;
            return nthPrime.ToString();
        }


        public ActionResult Cacheable()
        {
            return View("~/Views/CacheRenderings/Cacheable.cshtml");
        }

        public long FindPrimeNumber(int n)
        {
            int count = 0;
            long a = 2;
            while (count < n)
            {
                long b = 2;
                int prime = 1;// to check if found a prime
                while (b * b <= a)
                {
                    if (a % b == 0)
                    {
                        prime = 0;
                        break;
                    }
                    b++;
                }
                if (prime > 0)
                {
                    count++;
                }
                a++;
            }
            return (--a);
        }

        public ActionResult NewsList()
        {

            string profileName = "Articles";

            Profile profile;
            if (Tracker.Current.Interaction.Profiles.ContainsProfile(profileName))
            {
                profile = Tracker.Current.Interaction.Profiles[profileName];
            }
            else
            {
                var profiles = new List<Sitecore.Analytics.Model.ProfileData>
                {
                    new Sitecore.Analytics.Model.ProfileData(profileName )
                };

                Tracker.Current.Interaction.Profiles.Initialize(profiles);
                profile = Tracker.Current.Interaction.Profiles[profileName];
            }

            string result = profile.ToString();


            return View("NewsList", (object)result);

            return Content(profile.ToString());


            var url = "https://newsapi.org/v2/everything?q=apple&from=2019-06-03&to=2019-06-03&sortBy=popularity&apiKey=150b111921fa4576b423a65f126bc7b7";

            var json = new WebClient().DownloadString(url);

            JavaScriptSerializer js = new JavaScriptSerializer();
            var productList = js.Deserialize<Article>(json);

            Item listRootItem = Sitecore.Context.Database.GetItem(Templates.RssLoader.NewsListRootID);

            var newArticles = productList.articles
                .Where(p => !listRootItem.Children.Any(p2 => p2.Fields["Author"].Value.Replace(" ", String.Empty) == p.author.Replace(" ", String.Empty)));

            foreach (var article in newArticles.Take(5))
            {
                using (new SecurityDisabler())
                {
                    Database master = Sitecore.Configuration.Factory.GetDatabase("master");
                    if (master != null)
                    {
                        TemplateItem template = master.GetTemplate(new ID("{A0D05971-89EC-4DC2-ACFF-BA0AA3465C84}"));
                        if (template != null)
                        {

                            string itemname = article.author.Replace(" ", String.Empty);

                            Item newItem = listRootItem?.Add(itemname, template);

                            newItem.Editing.BeginEdit();
                            newItem.Fields["NewsSummary"].Value = article.title;
                            newItem.Fields["Author"].Value = itemname;
                            newItem.Fields["urlToImage"].Value = article.urlToImage;
                            newItem.Fields["description"].Value = article.description;

                            


                            try
                            {
                                newItem.Fields["NewsDate"].Value = article.publishedAt.Replace(":", String.Empty).Replace("-", String.Empty);

                            }
                            catch (Exception)
                            {

                            }

                            newItem.Editing.EndEdit();
                            newItem.Editing.AcceptChanges();
                        }
                    }
                }
            }


            var items = this.Repository.Get(RenderingContext.Current.Rendering.Item);
            

            return View("NewsList", items);
        }

        public ActionResult LatestNews()
        {
            return Content("sfdr");
            string profileName = "Articles";

            Profile profile;
            if (Tracker.Current.Interaction.Profiles.ContainsProfile(profileName))
            {
                profile = Tracker.Current.Interaction.Profiles[profileName];
            }
            else
            {
                var profiles = new List<Sitecore.Analytics.Model.ProfileData>
                {
                    new Sitecore.Analytics.Model.ProfileData(profileName )
                };

                Tracker.Current.Interaction.Profiles.Initialize(profiles);
                profile = Tracker.Current.Interaction.Profiles[profileName];
            }



            return Content(profile.ToString());
        }
    }
}