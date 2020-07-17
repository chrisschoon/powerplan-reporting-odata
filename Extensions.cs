using Microsoft.AspNet.OData.Query;
using System.Linq;

namespace PowerPlan.OData
{
    public static class Extensions
    {
        /// <summary>
        /// Apply $orderby if specified
        /// </summary>
        public static IQueryable<T> ApplyOrderBy<T>(this IQueryable<T> rawQuery, ODataQueryOptions<T> odata)
        {
            IQueryable<T> returnQuery = rawQuery;

            if (odata.OrderBy != null)
            {
                returnQuery = odata.OrderBy.ApplyTo(rawQuery);
            }

            return returnQuery;
        }

        /// <summary>
        /// Take only the necessary records as specified by $skip and $top, if specified
        /// </summary>
        public static IQueryable<T> ApplyTop<T>(this IQueryable<T> rawQuery, ODataQueryOptions<T> odata)
        {
            IQueryable<T> returnQuery = rawQuery;

            if (odata.Top != null)
            {
                returnQuery = rawQuery.Take((odata.Skip?.Value ?? 0) + odata.Top.Value);
            }

            return returnQuery;
        }
    }
}
