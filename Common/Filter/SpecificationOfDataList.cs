using TTN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TTN
{
    public class SpecificationOfDataList<T>
        where T : class
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public List<FilterSpecification<T>> FilterSpecifications { get; set; }
        public string SortSpecification { get; set; }
        public bool AscendingSortDirection { get; set; }

        public Criteria GetCriteria()
        {
            Criteria criteria = null;
            if (FilterSpecifications != null)
            {
                foreach (var item in FilterSpecifications)
                {
                    if (criteria != null)
                        criteria = criteria.And(CriteriaBuilder.CreateFromilterOperation<T>(item.FilterOperation, item.PropertyName, item.FilterValue));
                    else
                        criteria = CriteriaBuilder.CreateFromilterOperation<T>(item.FilterOperation, item.PropertyName, item.FilterValue);
                }
            }
            return criteria;
        }

        public List<SortItem> GetSortItem()
        {
            List<SortItem> sortItems = new List<SortItem>();
            sortItems.Add(new SortItem() { SortFiledsSelector = (this.SortSpecification != null && this.SortSpecification != "") ? this.SortSpecification : "Id", Direction = this.AscendingSortDirection ? SortDirection.Ascending : SortDirection.Descending });
            return sortItems;
        }
    }
}
