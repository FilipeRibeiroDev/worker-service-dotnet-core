using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WorkerService.Application.Interfaces;

namespace WorkerService.Application.Services
{
    public class HttpService : IHttpService
    {
        public async Task<HttpStatusCode> ChecksStatusSite(string url)
        {
            var client = new HttpClient();
            try
            {
                var response = await client.GetAsync(url);
                return response.StatusCode;
            }
            catch (HttpRequestException)
            {
                return HttpStatusCode.NotFound;
            }
            finally
            {
                client.Dispose();
            }
        }
    }
}
