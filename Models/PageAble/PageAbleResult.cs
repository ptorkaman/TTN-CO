using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Models.PageAble
{
    public class PageAbleResult
    {
        [FromQuery(Name = "page"), Required]
        public int Page { get; set; }
        [FromQuery]
        public int PageSize { get; set; } = 20;
        [FromQuery]

        public string OrderBy { get; set; }
    }
}
