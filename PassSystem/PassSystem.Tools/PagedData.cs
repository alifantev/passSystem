using System.Collections.Generic;

namespace PassSystem.Tools
{
    public class PagedData<T> where T: class
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalRows { get; set; }
    }
}