using Sitecore.Analytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Feature.Demo.Models
{
    public class ModelBinderSatistic : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            string profileName = "Articles";

            Sitecore.Analytics.Tracking.Profile profile;
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



            StatisticInfo statisticInfo = new StatisticInfo();


            statisticInfo.MyProf = profile;
            statisticInfo.PatternCardName = profile.PatternLabel;


            return statisticInfo;
        }
    }
}