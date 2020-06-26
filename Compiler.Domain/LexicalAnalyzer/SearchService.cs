using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.Compiler.Domain.Tables.LexicalAnalyzer
{
    /// <summary>
    /// need add comparable
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SearchService<T>
        where T : IComparable<T>
    {
        private static readonly Lazy<SearchService<T>> _lazy =
            new Lazy<SearchService<T>>(() => new SearchService<T>());

        public static SearchService<T> Instance => _lazy.Value;
        
        private SearchService()
        {

        }

        public T BinarySearch(T value, int left, int right, List<T> collection)
        {

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (collection[mid].CompareTo(value) == 0)
                    return collection[mid];

                if(value.CompareTo(collection[mid]) == -1)
                    return BinarySearch(value, left, mid, collection);

                return BinarySearch(value, mid, right, collection);
            }

            throw new KeyNotFoundException("Not recognized state in States");
        }
    }
}
