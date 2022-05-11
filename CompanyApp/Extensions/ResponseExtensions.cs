using Microsoft.AspNetCore.Http;

namespace CompanyApp.Extensions;

public static class ResponseExtensions
{
    public static void AddApplicationError(this HttpResponse response, string message)
    {
        response.Headers.Add("Company-App-Error", message);
    }
}