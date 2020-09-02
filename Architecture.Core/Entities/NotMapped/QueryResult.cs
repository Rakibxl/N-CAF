using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Architecture.Core.Entities.NotMapped
{
    public class QueryResult<T>
    {
        public int Total { get; set; }
        public int TotalFilter { get; set; }
        public IList<T> Items { get; set; }
    }
}