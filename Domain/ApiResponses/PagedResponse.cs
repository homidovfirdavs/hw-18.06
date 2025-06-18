using System.Net;

namespace Domain.ApiResponses;

public class PagedResponse<T> : Responce<T>

{
    public int TotalRecords { get; set; }
    public int TotalPages { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    
    public PagedResponse(T? data, int totalRecords, int pageNumber, int pageSize) : base(data, null)
    {
        TotalRecords = totalRecords;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling((float)totalRecords / PageSize);
    }

    public PagedResponse(string message, HttpStatusCode statusCode) : base(message, statusCode)
    {
        
    }

    
}