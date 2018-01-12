using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ImageConverterWebAPI.Controllers.v1._0
{
    public class BaseController : ApiController
    {
        [NonAction]
        protected bool HasSubmittedFile()
        {
            return HttpContext.Current.Request.Files.Count != 0;
        }

        [NonAction]
        protected void SaveImageFromInput(string sourcePath, ref HttpPostedFile httpPostedFile)
        {
            using (FileStream outputFileStream = new FileStream(sourcePath, FileMode.Create))
            {
                httpPostedFile.InputStream.CopyTo(outputFileStream);
            }
        }

    }
}
