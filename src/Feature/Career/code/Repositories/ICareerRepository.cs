namespace Sitecore.Feature.Career.Repositories
{
  using System.Collections.Generic;
  using Sitecore.Data.Items;

  public interface ICareerRepository
    {
    IEnumerable<Item> Get(Item contextItem);
    IEnumerable<Item> GetLatest(Item contextItem, int count);
  }
}