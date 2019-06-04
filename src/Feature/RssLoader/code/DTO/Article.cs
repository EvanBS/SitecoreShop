using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Feature.RssLoader.DTO
{
    public class Article
    {
        public int totalResults { get; set; }

        public List<Articles> articles { get; set; }
    }
}