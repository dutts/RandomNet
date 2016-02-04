using System.Net;

namespace RandomNet
{
    internal static class Request
    {
        public static WebRequest Create(string uri)
        {
            var request = WebRequest.Create(uri);
            request.Proxy = null;
            request.Credentials = CredentialCache.DefaultCredentials;
            return request;
        }
    }
}
