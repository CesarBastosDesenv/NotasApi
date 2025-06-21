using System;
using System.Text.Json;
using Nota.Api.Models;


namespace Nota.Api.Extensions;

public static class HttpExtensions
{
public static void AddPaginationHeader(this HttpResponse response, PaginationHeader header)
    {
        var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
        response.Headers.Add("Pagination", JsonSerializer.Serialize(header, jsonOptions));
        response.Headers.Add("Acces-Control-Expose-Headers", "Pagination");
    }
}
