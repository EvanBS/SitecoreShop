using Sitecore.Workflows.Simple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;

namespace Sitecore.Feature.RssLoader.CalculateCount
{
    public class CalculateTotalPrice
    {
        public void Process(WorkflowPipelineArgs args)
        {
            Item dataItem = args.DataItem;
            using (new Sitecore.SecurityModel.SecurityDisabler())
            {
                try
                {
                    if (dataItem != null)
                    {
                        dataItem.Editing.BeginEdit();
                        dataItem.Fields["AllPrice"].Value = (int.Parse(dataItem.Fields["SinglePrice"].Value) * int.Parse(dataItem.Fields["Counts"].Value)).ToString();
                        dataItem.Editing.EndEdit();
                    }
                }
                catch
                {
                    dataItem.Editing.CancelEdit();
                }
            }
        }
    }
}