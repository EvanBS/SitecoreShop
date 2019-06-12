using Sitecore.Analytics;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Feature.Demo.Models
{
    public class StatisticInfoModel : RenderingModel
    {
        public override void Initialize(Rendering rendering)
        {
            string profileName = "Articles";

            if (Tracker.Current.Interaction.Profiles.ContainsProfile(profileName))
            {
                MyProf = Tracker.Current.Interaction.Profiles[profileName];
            }
            else
            {
                var profiles = new List<Sitecore.Analytics.Model.ProfileData>
                {
                    new Sitecore.Analytics.Model.ProfileData(profileName )
                };

                Tracker.Current.Interaction.Profiles.Initialize(profiles);
                MyProf = Tracker.Current.Interaction.Profiles[profileName];
            }

            PatternCardName = MyProf.PatternLabel;

            base.Initialize(rendering);
        }

        public IDictionary<string, double> Dict { get; set; }

        public Sitecore.Analytics.Tracking.Profile MyProf { get; set; }

        public string PatternCardName { get; set; }
    }
}