using System.Collections.Generic;
using System.Text.Json;
using MediatR;
using SS.Template.Application.Infrastructure;

namespace SS.Template.Application.Queries
{
    public class ListQuery
    {
       
        public string OrderBy { get; set; }

        public string Term { get; set; }
        public string Filter { get; set; }

        public virtual List<FilterQuery> FilterQuery
        {
            get
            {
                if (!string.IsNullOrEmpty(Filter))
                {
                    return JsonSerializer.Deserialize<List<FilterQuery>>(Filter);

                }
                return new List<FilterQuery>();
            }
        }


    }
    public class FilterQuery
{
    public string Key { get; set; }
    public List<object> Value { get; set; }
}

    public class ListQuery<T> : ListQuery, IRequest<ListResult<T>>
    {
    }

    public static class ListQueryExtensions
    {
        public static ICollection<SortCriterion> GetSortCriteria(this ListQuery query)
        {
            return SortCriteriaHelper.GetSortCriteria(query?.OrderBy);
        }
    }
}
