using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TMDBApp.Extensions
{
    public static class AddRangeExtension
    {
        public static void AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> list)
        {
            foreach (var item in list)
                collection.Add(item);
        }
    }
}

