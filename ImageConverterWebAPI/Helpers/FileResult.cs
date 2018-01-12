using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ImageConverterWebAPI.Helpers
{
    public class FileResult : IHttpActionResult
    {
        private readonly string filePath;
        public FileResult(string filePath)
        {
            this.filePath = filePath;
        }

        private HttpResponseMessage FileResponseMessage()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(File.OpenRead(this.filePath));
            string contentType = MimeMapping.GetMimeMapping(Path.GetExtension(this.filePath));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
            return response;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                return FileResponseMessage();
            }, cancellationToken);
        }
    }
}