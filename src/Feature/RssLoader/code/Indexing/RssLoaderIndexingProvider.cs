namespace Sitecore.Feature.RssLoader.Indexing
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

    public class RssLoaderIndexingProvider : ProviderBase, ISearchResultFormatter, IQueryPredicateProvider
    {
        public Expression<Func<SearchResultItem, bool>> GetQueryPredicate(IQuery query)
        {
            var fieldNames = new[] {Templates.RssLoader.Fields.Title_FieldName, Templates.RssLoader.Fields.Summary_FieldName, Templates.RssLoader.Fields.Body_FieldName};
            return GetFreeTextPredicateService.GetFreeTextPredicate(fieldNames, query);
        }

        public string ContentType => DictionaryPhraseRepository.Current.Get("/RssLoader/Search/Content Type", "RssLoader");

        public IEnumerable<ID> SupportedTemplates => new[] {Templates.RssLoader.ID};

        public void FormatResult(SearchResultItem item, ISearchResult formattedResult)
        {
            var contentItem = item.GetItem();
            if (contentItem == null)
            {
                return;
            }

            formattedResult.Title = FieldRenderer.Render(contentItem, Templates.RssLoader.Fields.Title.ToString());
            formattedResult.Description = FieldRenderer.Render(contentItem, Templates.RssLoader.Fields.Summary.ToString());
            formattedResult.Media = ((ImageField)contentItem.Fields[Templates.RssLoader.Fields.Image])?.MediaItem;
            formattedResult.ViewName = "~/Views/RssLoader/RssLoaderSearchResult.cshtml";
        }
    }
}