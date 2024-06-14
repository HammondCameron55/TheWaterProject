namespace TheWaterProject.Infrastructure
{
    public static class UrlExtensions
    {
        // This method is an extension method that adds a new method to the HttpRequest class.
        public static string PathAndQuery(this HttpRequest request) =>
            request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();
    }
}
