using Sitecore.Feature.RssLoader.DTO;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;
using System.Net;
using System.Web.Script.Serialization;

namespace Sitecore.Feature.RssLoader
{
    public class WeatherCheckCampaign<T> : OperatorCondition<T> where T : RuleContext
    {

        public float CurrentDegrees { get; set; } = 20;

        ///<summary>

        /// Gets or sets the campaign.

        ///</summary>

        ///<value>The campaign.</value>

        public float degree

        {

            get;

            set;

        }

        ///<summary>

        /// Executes the specified rule context.

        ///</summary>

        ///<param name="ruleContext">The rule context.</param>

        ///<returns>

        ///''' <c>True</c>, if the condition succeeds, otherwise <c>false</c>.

        ///</returns>

        protected override bool Execute(T ruleContext)
        {

            string url = "http://api.openweathermap.org/data/2.5/weather?q=Kyiv&appid=19a005c212fb37a0afcc54d06133e6ee";

            var json = new WebClient().DownloadString(url);

            JavaScriptSerializer js = new JavaScriptSerializer();
            var productList = js.Deserialize<Weather>(json);

            CurrentDegrees = float.Parse(productList.main.temp.Replace(".", ","));

            CurrentDegrees -= 273;

            ConditionOperator conditionOperator = this.GetOperator();


            switch (conditionOperator)
            {
                case ConditionOperator.Unknown:
                    return false;

                case ConditionOperator.Equal:
                    return CurrentDegrees == degree;

                case ConditionOperator.GreaterThanOrEqual:
                    return CurrentDegrees >= degree;

                case ConditionOperator.GreaterThan:
                    return CurrentDegrees > degree;

                case ConditionOperator.LessThanOrEqual:
                    return CurrentDegrees <= degree;

                case ConditionOperator.LessThan:
                    return CurrentDegrees < degree;

                case ConditionOperator.NotEqual:
                    return CurrentDegrees != degree;

            }

            return false;
        }

    }
}