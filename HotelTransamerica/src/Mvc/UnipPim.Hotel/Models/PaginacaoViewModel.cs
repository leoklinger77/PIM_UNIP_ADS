using System;
using System.Collections.Generic;

namespace UnipPim.Hotel.Models
{
    public class PaginacaoViewModel<T> : IPagedViewModel where T : class
    {
        public IEnumerable<T> List { get; set; }
        public int TotalResult { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Query { get; set; }
        public string ReferenceAction { get; set; }
        public double TotalPages => Math.Ceiling((double)TotalResult / PageSize);
    }

    public interface IPagedViewModel
    {
        public string ReferenceAction { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Query { get; set; }
        public int TotalResult { get; set; }
        public double TotalPages { get; }
    }
}
