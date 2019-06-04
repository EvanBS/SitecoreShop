namespace Sitecore.Feature.RssLoader
{
  using Sitecore.Data;

  public struct Templates
  {
    public struct RssLoader
    {

      public static readonly ID ID = new ID("{C31ED8DE-49BC-4E1B-BF43-9A5087174E32}");

      public static readonly ID NewsListRootID = new ID("{E715382A-E49C-4CFA-AA02-67DEA757513F}");

      public struct Fields
      {
        public static readonly ID Title = new ID("{E9E60CAB-F6DB-441B-99CE-4D85FC1411A3}");
        public const string Title_FieldName = "NewsTitle";

        public static readonly ID Image = new ID("{D8B9AC15-1BBE-4BBB-99BC-D8E903EC37D4}");

        public static readonly ID Date = new ID("{AD95B4F3-3CA1-4654-AB25-D7652DD66F85}");

        public static readonly ID Summary = new ID("{DE547539-EA91-43E3-A592-72459CA1CC1B}");
        public const string Summary_FieldName = "NewsSummary";

        public static readonly ID Body = new ID("{181E9767-F9BE-4B11-98BF-A2541C1BAAC5}");
        public const string Body_FieldName = "NewsBody";
      }
    }

    public struct RssLoaderFolder
    {
      public static readonly ID ID = new ID("{A876E0FC-20AA-4A2F-B10F-1E6ED6E847CC}");
    }
  }
}