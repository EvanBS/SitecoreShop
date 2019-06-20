namespace Sitecore.Feature.Career.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text.RegularExpressions;
    using System.Web.Mvc;
    using System.Web.Script.Serialization;
    using Sitecore.Analytics;
    using Sitecore.Analytics.Core;
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using Sitecore.Feature.Career.Repositories;
    using Sitecore.Foundation.SitecoreExtensions.Extensions;
    using Sitecore.Mvc.Presentation;
    using Sitecore.SecurityModel;
    

    public class CareerController : Controller
    {
        public CareerController(ICareerRepository newsRepository)
        {
            this.Repository = newsRepository;
        }

        private ICareerRepository Repository { get; }

        public ActionResult JobList()
        {
            var items = this.Repository.Get(RenderingContext.Current.Rendering.Item);
            /*
            var jobSearchGoal = Tracker.Current.Session.Interaction.Pages.SelectMany(x => x.PageEvents)
            .OrderByDescending(x => x.Timestamp).Where(g => g.Name == "User Searches Job").FirstOrDefault();
            */

            return View("JobList", items);
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