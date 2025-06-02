using HttpClient? httpclient = new();
string? http = "http";
string? url = "localhost";
string? port = "5031";

// var path = "normalRequest";
// var path = "nonBlockRequest";
string? path = "blockRequest";

Parallel.For(
    0,
    Int32.MaxValue,
    i =>
    {
        Task<HttpResponseMessage>? response = httpclient.GetAsync($"{http}://{url}:{port}/{path}");
        response.Wait();
        Console.WriteLine(response.Result.StatusCode);
    }
);
