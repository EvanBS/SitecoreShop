namespace Sitecore.Feature.Career.Indexing
{
    using System;
    using System.Collections.Generic;
    using System.Configuration.Provider;
    using System.Linq.Expressions;
    using Sitecore.ContentSearch.SearchTypes;
    using Sitecore.Data;
    using Sitecore.Data.Fields;
    using Sitecore.Foundation.Dictionary.Repositories;
    using Sitecore.Foundation.Indexing.Infrastructure;
    using Sitecore.Foundation.Indexing.Models;
    using Sitecore.Web.UI.WebControls;

    public class CareerIndexingProvider : ProviderBase, ISearchResultFormatter, IQueryPredicateProvider
    {
        public Expression<Func<SearchResultItem, bool>> GetQueryPredicate(IQuery query)
        {
            var fieldNames = new[] {Templates.Career.Fields.Title_FieldName, Templates.Career.Fields.Summary_FieldName, Templates.Career.Fields.Body_FieldName};
            return GetFreeTextPredicateService.GetFreeTextPredicate(fieldNames, query);
        }

        public string ContentType => DictionaryPhraseRepository.Current.Get("/Career/Search/Content Type", "Career");

        public IEnumerable<ID> SupportedTemplates => new[] {Templates.Career.ID};

        public void FormatResult(SearchResultItem item, ISearchResult formattedResult)
        {
            var contentItem = item.GetItem();
            if (contentItem == null)
            {
                return;
            }

            formattedResult.Title = FieldRenderer.Render(contentItem, Templates.Career.Fields.JobTitle.ToString());
            formattedResult.Description = FieldRenderer.Render(contentItem, Templates.Career.Fields.Summary.ToString());
            formattedResult.Media = ((ImageField)contentItem.Fields[Templates.Career.Fields.Image])?.MediaItem;
            formattedResult.ViewName = "~/Views/Career/CareerSearchResult.cshtml";
        }
    }
}