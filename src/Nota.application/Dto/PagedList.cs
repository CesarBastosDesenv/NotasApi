using System;

namespace Nota.application.Dto;

public class PagedList
{
    public int TotalCount { get; set; }
    public int CurrentPage { get; set;}
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public object Data { get; set; }
}
