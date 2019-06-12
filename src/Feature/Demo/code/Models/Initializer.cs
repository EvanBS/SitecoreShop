using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Feature.Demo.Models
{
    public class Initializer
    {
        public static void Initialize()
        {
            ModelBinders.Binders.Add(typeof(ID), new IDBinder());
        }
    }
}