namespace HttpRequests.Internal;

internal class MessageHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken
    )
    {
        HttpResponseMessage? response = await base.SendAsync(request, cancellationToken);

        if (response.IsSuccessStatusCode)
        {
            string? content = await response.Content.ReadAsStringAsync();

            Console.WriteLine(content);
        }

        return response;
    }
}
