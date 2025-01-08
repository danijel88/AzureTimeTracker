namespace AzureTimeTracker.Utils;

public static class HttpClientExtensions
{
    public static async Task<HttpResponseMessage> PatchAsync(this HttpClient client, string requestUri, HttpContent content)
    {
        var request = new HttpRequestMessage(new HttpMethod("PATCH"), requestUri) { Content = content };
        return await client.SendAsync(request);
    }
}