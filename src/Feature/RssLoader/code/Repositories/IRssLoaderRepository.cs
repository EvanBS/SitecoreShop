namespace Sitecore.Feature.RssLoader.Repositories
{
  using System.Collections.Generic;
  using Sitecore.Data.Items;

  public interface IRssLoaderRepository
  {
    IEnumerable<Item> Get(Item contextItem);
    IEnumerable<Item> GetLatest(Item contextItem, int count);
  }
}