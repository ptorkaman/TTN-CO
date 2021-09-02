using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Albim.Controllers
{
    //public class PaginationReqParams
    //{
    //    public PaginationReqParams()
    //    {
    //        this.Filters = new List<string>();
    //    }

    //    [FromQuery] public List<string> Filters { get; set; }
    //    //public Int32 Page { get; set; }
    //    //public Int32 PageSize { get; set; }
    //}
    //public class FiltersReq
    //{
    //    [FromQuery] public String Field { get; set; }
    //    [FromQuery] public String Value { get; set; }
    //    [FromQuery] public String ComparisonOperator { get; set; }
    //}
    //public class SpecificationOfDataList<T> where T : class
    //{
    //    public int PageIndex { get; set; }
    //    public int PageSize { get; set; }
    //    public List<FilterSpecification<T>> FilterSpecifications { get; set; }
    //    public string SortSpecification { get; set; }
    //    public bool AscendingSortDirection { get; set; }
    //    public Criteria GetCriteria();
    //    public List<SortItem> GetSortItem();
    //}
    //public class FilterSpecification<T>
    //{
    //    public string PropertyName { get; set; }
    //    public object FilterValue { get; set; }
    //    public FilterOperations FilterOperation { get; set; }
    //}
    //public abstract class Criteria
    //{
    //    public virtual object FirstOprand { get; set; }
    //    public virtual object SecondOperand { get; set; }
    //    public Type ObjectType { get; set; }
    //    public abstract Expression GetExpression(ParameterExpression parameter);
    //    public static Type[] GetKnownType();
    //}
    //public class SortItem
    //{
    //    public SortDirection Direction { get; set; }
    //    public string SortFiledsSelector { get; set; }
    //}
    //public enum FilterOperations
    //{
    //    Equal = 1,
    //    Like = 2,
    //    NotEqual = 3,
    //    GreaterThan = 4,
    //    GreaterThanOrEqual = 5,
    //    LessThan = 6,
    //    LessThanOrEqual = 7,
    //    Between = 8,
    //    Contains = 9,
    //}
    //public enum SortDirection
    //{
    //    Ascending,
    //    Descending,
    //}
}
