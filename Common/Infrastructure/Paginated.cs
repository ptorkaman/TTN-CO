using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace TTN
{
   
    public class Paginated<T> : IPaginated<T>
    {
        public Paginated(IPagedList<T> pagedList)
        {
            this.Data = pagedList;
            this.TotalCount = pagedList.TotalCount;
        }
        
        public IEnumerable<T> Data { get; set; }

       
        /// <summary>
        /// Gets the total number of data.
        /// </summary>
        public int TotalCount { get; set; }
    }
}
