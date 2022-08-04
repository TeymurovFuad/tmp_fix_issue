using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.RefitConfig
{
    [DebuggerStepThrough]
    public class HttpClientDiagnosticsHandler : DelegatingHandler
    {
        public HttpClientDiagnosticsHandler(HttpMessageHandler innerHandler) : base(innerHandler)
        {
        }

        public HttpClientDiagnosticsHandler()
        {


        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            Log.Debug(string.Format("Request: {0}", request));
            if (request.Content != null)
            {
                var content = await request.Content.ReadAsStringAsync().ConfigureAwait(false);
                Log.Debug(string.Format("Request Content: {0}", content));
            }

            var response = await base.SendAsync(request, cancellationToken);
            Log.Debug(string.Format("Response: {0}", response));
            response.EnsureSuccessStatusCode();

            if (response.Content != null)
            {
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                Log.Debug(string.Format("Response Content: {0}", content));
            }

            return response;
        }
    }
}
