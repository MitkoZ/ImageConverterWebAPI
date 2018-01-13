using ImageConverterWebAPI.Helpers;
using PrimeHolding.ImageConverter;
using PrimeHolding.ImageConverter.Exceptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace ImageConverterWebAPI.Controllers.v1._0
{
    [RoutePrefix("api/v1.0/Convert")]
    public class ConvertController : BaseController
    {
        [NonAction]
        private void SetSourceAndDestionationPath(out string sourcePath, out string destinationPath, out HttpPostedFile httpPostedFile)
        {
            DirectoryInfo directoryInfo = Directory.GetParent(Directory.GetParent(HttpContext.Current.Server.MapPath("~")).ToString());
            httpPostedFile = HttpContext.Current.Request.Files[0];
            string extension = Path.GetExtension(httpPostedFile.FileName);
            string guid = Guid.NewGuid().ToString();
            string guidAndExtension = guid + extension;
            sourcePath = Path.Combine(directoryInfo.FullName, @"Database\UploadedPictures", guidAndExtension);
            destinationPath = Path.Combine(directoryInfo.FullName, @"Database\ConvertedPictures", guid);
        }

        /// <summary>
        /// Converts an image to JPG format
        /// </summary>
        /// <returns>A file</returns>
        /// <response code="400">The request from the client could not be understood due to missing parameters/bad syntax</response>
        /// <response code="500">An internal server error occured</response>
        /// <response code="200">The image was successfully converted to JPG format</response>
        /// <remarks>You should include the image that you want to convert to JPG</remarks>

        [Route("ToJPG")]
        [HttpPost]
        public IHttpActionResult ToJPG()
        {
            if (!HasSubmittedFile())
            {
                return BadRequest("Image not uploaded!");
            }
            string sourcePath, destinationPath;
            HttpPostedFile httpPostedFile;
            SetSourceAndDestionationPath(out sourcePath, out destinationPath, out httpPostedFile);
            SaveImageFromInput(sourcePath, ref httpPostedFile);
            destinationPath += ".jpg";
            try
            {
                ImageContext imageContext = new ImageContext(sourcePath, destinationPath, "ConvertToJPG");
                imageContext.ExecuteStrategy();
                return new FileResult(destinationPath);
            }
            catch (InvalidPathException invalidPathException)
            {
                return new CustomHttpActionResult(Request, HttpStatusCode.BadRequest, invalidPathException.Message);
            }
            catch (InvalidImageFormatException invalidImageFormatException)
            {
                return new CustomHttpActionResult(Request, HttpStatusCode.BadRequest, invalidImageFormatException.Message);
            }
            catch (UnathorizedAccessException unauthorizedAccessException)
            {
                return new CustomHttpActionResult(Request, HttpStatusCode.InternalServerError, unauthorizedAccessException.Message);
            }
            catch (WrongSaveImageFormatException wrongSaveImageFormatException)
            {
                return new CustomHttpActionResult(Request, HttpStatusCode.InternalServerError, wrongSaveImageFormatException.Message);
            }
            catch (FileNotFoundException fileNotFoundException)
            {
                return new CustomHttpActionResult(Request, HttpStatusCode.BadRequest, fileNotFoundException.Message);
            }
            catch (DirectoryNotFoundException directoryNotFoundException)
            {
                return new CustomHttpActionResult(Request, HttpStatusCode.BadRequest, directoryNotFoundException.Message);
            }
            catch (PathTooLongException pathTooLongException)
            {
                return new CustomHttpActionResult(Request, HttpStatusCode.BadRequest, pathTooLongException.Message);
            }
        }

        /// <summary>
        /// Converts an image to PNG format
        /// </summary>
        /// <returns>A file</returns>
        /// <response code="400">The request from the client could not be understood due to missing parameters/bad syntax</response>
        /// <response code="500">An internal server error occured</response>
        /// <response code="200">The image was successfully converted to PNG format</response>
        /// <remarks>You should include the image that you want to convert to PNG</remarks>

        [Route("ToPNG")]
        [HttpPost]
        public IHttpActionResult ToPNG()
        {
            if (!HasSubmittedFile())
            {
                return BadRequest("Image not uploaded!");
            }
            string sourcePath, destinationPath;
            HttpPostedFile httpPostedFile;
            SetSourceAndDestionationPath(out sourcePath, out destinationPath, out httpPostedFile);
            SaveImageFromInput(sourcePath, ref httpPostedFile);
            destinationPath += ".png";

            try
            {
                ImageContext imageContext = new ImageContext(sourcePath, destinationPath, "ConvertToPNG");
                imageContext.ExecuteStrategy();
                return new FileResult(destinationPath);
            }
            catch (InvalidPathException invalidPathException)
            {
                return new CustomHttpActionResult(Request, HttpStatusCode.BadRequest, invalidPathException.Message);
            }
            catch (InvalidImageFormatException invalidImageFormatException)
            {
                return new CustomHttpActionResult(Request, HttpStatusCode.BadRequest, invalidImageFormatException.Message);
            }
            catch (UnathorizedAccessException unauthorizedAccessException)
            {
                return new CustomHttpActionResult(Request, HttpStatusCode.InternalServerError, unauthorizedAccessException.Message);
            }
            catch (WrongSaveImageFormatException wrongSaveImageFormatException)
            {
                return new CustomHttpActionResult(Request, HttpStatusCode.InternalServerError, wrongSaveImageFormatException.Message);
            }
            catch (FileNotFoundException fileNotFoundException)
            {
                return new CustomHttpActionResult(Request, HttpStatusCode.BadRequest, fileNotFoundException.Message);
            }
            catch (DirectoryNotFoundException directoryNotFoundException)
            {
                return new CustomHttpActionResult(Request, HttpStatusCode.BadRequest, directoryNotFoundException.Message);
            }
            catch (PathTooLongException pathTooLongException)
            {
                return new CustomHttpActionResult(Request, HttpStatusCode.BadRequest, pathTooLongException.Message);
            }
        }

        /// <summary>
        /// Converts an image to GIF format
        /// </summary>
        /// <returns>A file</returns>
        /// <response code="400">The request from the client could not be understood due to missing parameters/bad syntax</response>
        /// <response code="500">An internal server error occured</response>
        /// <response code="200">The image was successfully converted to GIF format</response>
        /// <remarks>You should include the image that you want to convert to GIF</remarks>
        [Route("ToGIF")]
        [HttpPost]
        public IHttpActionResult ToGIF()
        {
            if (!HasSubmittedFile())
            {
                return BadRequest("Image not uploaded!");
            }
            string sourcePath, destinationPath;
            HttpPostedFile httpPostedFile;
            SetSourceAndDestionationPath(out sourcePath, out destinationPath, out httpPostedFile);
            SaveImageFromInput(sourcePath, ref httpPostedFile);
            destinationPath += ".gif";

            try
            {
                ImageContext imageContext = new ImageContext(sourcePath, destinationPath, "ConvertToGIF");
                imageContext.ExecuteStrategy();
                return new FileResult(destinationPath);
            }
            catch (InvalidPathException invalidPathException)
            {
                return new CustomHttpActionResult(Request, HttpStatusCode.BadRequest, invalidPathException.Message);
            }
            catch (InvalidImageFormatException invalidImageFormatException)
            {
                return new CustomHttpActionResult(Request, HttpStatusCode.BadRequest, invalidImageFormatException.Message);
            }
            catch (UnathorizedAccessException unauthorizedAccessException)
            {
                return new CustomHttpActionResult(Request, HttpStatusCode.InternalServerError, unauthorizedAccessException.Message);
            }
            catch (WrongSaveImageFormatException wrongSaveImageFormatException)
            {
                return new CustomHttpActionResult(Request, HttpStatusCode.InternalServerError, wrongSaveImageFormatException.Message);
            }
            catch (FileNotFoundException fileNotFoundException)
            {
                return new CustomHttpActionResult(Request, HttpStatusCode.BadRequest, fileNotFoundException.Message);
            }
            catch (DirectoryNotFoundException directoryNotFoundException)
            {
                return new CustomHttpActionResult(Request, HttpStatusCode.BadRequest, directoryNotFoundException.Message);
            }
            catch (PathTooLongException pathTooLongException)
            {
                return new CustomHttpActionResult(Request, HttpStatusCode.BadRequest, pathTooLongException.Message);
            }
        }

    }
}
