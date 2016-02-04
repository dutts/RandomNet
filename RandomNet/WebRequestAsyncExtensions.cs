using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace RandomNet
{
    public static class WebRequestAsyncExtensions
    {
        public static Task<WebResponse> GetReponseAsync(this System.Net.WebRequest request)
        {
            return Task.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, null);
        }

        public static Task<Stream> GetRequestStreamAsync(this System.Net.WebRequest request)
        {
            return Task.Factory.FromAsync(request.BeginGetRequestStream, request.EndGetRequestStream, null);
        }
    }
}
