using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ImageConverterWebAPI.Helpers
{
    public class CustomHttpActionResult : IHttpActionResult
    {
        // A helper class that allows you to return a HttpStatusCode and a message (something like Request.CreateResponse(httpCode, message)) but inside a method which return type is IHttpActionResult
        private HttpRequestMessage request;
        private HttpStatusCode statusCode;
        private string message;

        public CustomHttpActionResult(HttpRequestMessage request, HttpStatusCode statusCode, string message)
        {
            this.request = request;
            this.statusCode = statusCode;
            this.message = message;
        } 

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(request.CreateErrorResponse(statusCode, message));
        }
    }
}