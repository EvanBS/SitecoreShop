using System;

namespace Sitecore.Feature.RssLoader.DTO
{
    public class Articles
    {
        public string title { get; set; }

        public string author { get; set; }

        public string description { get; set; }

        public string urlToImage { get; set; }

        public string publishedAt { get; set; }
    }
}