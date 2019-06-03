namespace Sitecore.Feature.RssLoader.Controllers
{
    using System.Web.Mvc;
    using Sitecore.Feature.RssLoader.Repositories;
    using Sitecore.Foundation.SitecoreExtensions.Extensions;
    using Sitecore.Mvc.Presentation;

    public class RssLoaderController : Controller
    {
        public RssLoaderController(IRssLoaderRepository newsRepository)
        {
            this.Repository = newsRepository;
        }

        private IRssLoaderRepository Repository { get; }

        public ActionResult NewsList()
        {
            var items = this.Repository.Get(RenderingContext.Current.Rendering.Item);
            return this.View("NewsList", items);
        }

        public ActionResult LatestNews()
        {
            //TODO: change to parameter template
            var count = RenderingContext.Current.Rendering.GetIntegerParameter("count", 5);
            var items = this.Repository.GetLatest(RenderingContext.Current.Rendering.Item, count);
            return this.View("LatestNews", items);
        }
    }
}