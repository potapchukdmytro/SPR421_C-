using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_Linq
{
    public static class CollectionsExtension
    {
        public static IEnumerable<T> Pagination<T>(this IEnumerable<T> collection, int page, int pageSize)
        {
            double pages = Math.Ceiling((double)collection.Count() / pageSize);

            if (page <= 0 || page > pages)
            {
                return new List<T>();
            }

            return collection.Skip(pageSize * (page - 1)).Take(pageSize);
        }
    }
}
