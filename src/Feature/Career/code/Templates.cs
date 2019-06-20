namespace Sitecore.Feature.Career
{
  using Sitecore.Data;

  public struct Templates
  {
    public struct Career
    {

      public static readonly ID ID = new ID("{E88EE415-932B-41B1-8B60-99712182A6C1}");

      public static readonly ID CareerRootID = new ID("{E827D97D-380D-4EAE-BD52-2721F364D774}");

      public struct Fields
      {
        public static readonly ID JobTitle = new ID("{BAFA2ADA-3C72-4E47-AC5E-2A43E9EFC124}");
        public const string Title_FieldName = "JobTitle";

        public static readonly ID Summary = new ID("{23CD0A54-D2FE-4549-9BF1-856D44E517D0}");
        public const string Summary_FieldName = "JobSummary";

        public static readonly ID Body = new ID("{DC9C59EF-C817-4548-8425-1361343F22A2}");
        public const string Body_FieldName = "jobBody";

        public static readonly ID Image = new ID("{4DF98EAB-79E3-42A4-BF2D-18E95D2A4240}");

        public static readonly ID Date = new ID("{05E68658-19E4-43B3-93CC-67FD152CE040}");

      }
    }

    public struct CareerFolder
    {
      public static readonly ID ID = new ID("{73CA66C3-745A-4498-BD97-6E14983DDBD6}");
    }
  }
}