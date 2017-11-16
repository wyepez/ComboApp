using System;
using System.Collections.Generic;

namespace ComboApp.Models
{
    public class PageResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public Uri NextPageLink { get; set; }
        public long? Count { get; set; }
    }
}
