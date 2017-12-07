using System.Collections.Generic;

namespace RJF.MobileApp.ViewModel
{
    public class CollectionResult<T> where T : class
    {
        public IEnumerable<T> Collection { get; set; }
        public int TotalCount { get; set; }
    }
}
