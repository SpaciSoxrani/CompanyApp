using Microsoft.AspNetCore.Http;

namespace MusicApp.Extensions;

public static class ResponseExtensions
{
    public static void AddApplicationError(this HttpResponse response, string message)
    {
        response.Headers.Add("Music-App-Error", message);
    }
}