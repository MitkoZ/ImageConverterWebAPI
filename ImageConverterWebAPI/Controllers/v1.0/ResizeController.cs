using ImageConverterWebAPI.BindModels;
using ImageConverterWebAPI.Helpers;
using PrimeHolding.ImageConverter;
using PrimeHolding.ImageConverter.Exceptions;
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
    [RoutePrefix("api/v1.0/Resize")]
    public class ResizeController : BaseController
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
            destinationPath = Path.Combine(directoryInfo.FullName, @"Database\ConvertedPictures", guidAndExtension);
        }

        [Route("Crop")]
        [HttpPost]
        public IHttpActionResult Crop([FromUri]CropBindModel cropBindModel)
        {
            if (!HasSubmittedFile())
            {
                return BadRequest("Image not uploaded!");
            }
            string sourcePath, destinationPath;
            HttpPostedFile httpPostedFile;
            SetSourceAndDestionationPath(out sourcePath, out destinationPath, out httpPostedFile);
            SaveImageFromInput(sourcePath, ref httpPostedFile);
            try
            {
                ImageContext imageContext = new ImageContext(sourcePath, destinationPath, "Crop", cropBindModel.X, cropBindModel.Y, cropBindModel.Width, cropBindModel.Height);
                imageContext.ExecuteStrategy();
                return new FileResult(destinationPath);
            }
            catch (InvalidImageFormatException invalidImageFormatException)
            {
                return new CustomHttpActionResult(Request, HttpStatusCode.BadRequest, invalidImageFormatException.Message);
            }
            catch (InvalidPixelFormatException invalidPixelFormatException)
            {
                return new CustomHttpActionResult(Request, HttpStatusCode.BadRequest, invalidPixelFormatException.Message);
            }
            catch (InvalidCropDimensionsException invalidCropDimensionsException)
            {
                return new CustomHttpActionResult(Request, HttpStatusCode.BadRequest, invalidCropDimensionsException.Message);
            }
            catch (InvalidPathException invalidPathException)
            {
                return new CustomHttpActionResult(Request, HttpStatusCode.BadRequest, invalidPathException.Message);
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
            catch (OutOfMemoryException outOfMemoryException)
            {
                return new CustomHttpActionResult(Request, HttpStatusCode.InternalServerError, outOfMemoryException.Message);
            }
        }

        [Route("KeepAspect")]
        [HttpPost]
        public IHttpActionResult KeepAspect([FromUri]KeepAspectBindModel keepAspectBindModel)
        {
            if (!HasSubmittedFile())
            {
                return BadRequest("Image not uploaded!");
            }
            string sourcePath, destinationPath;
            HttpPostedFile httpPostedFile;
            SetSourceAndDestionationPath(out sourcePath, out destinationPath, out httpPostedFile);
            SaveImageFromInput(sourcePath, ref httpPostedFile);
            try
            {
                ImageContext imageContext = new ImageContext(sourcePath, destinationPath, "KeepAspect", keepAspectBindModel.Width, keepAspectBindModel.Height);
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
            catch (GenericException genericException)
            {
                return new CustomHttpActionResult(Request, HttpStatusCode.InternalServerError, genericException.Message);
            }
            catch (InvalidResizeSizeException invalidResizeSizeException)
            {
                return new CustomHttpActionResult(Request, HttpStatusCode.BadRequest, invalidResizeSizeException.Message);
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

        [Route("Skew")]
        [HttpPost]
        public IHttpActionResult Skew([FromUri]SkewBindModel skewBindModel)
        {
            if (!HasSubmittedFile())
            {
                return BadRequest("Image not uploaded!");
            }
            string sourcePath, destinationPath;
            HttpPostedFile httpPostedFile;
            SetSourceAndDestionationPath(out sourcePath, out destinationPath, out httpPostedFile);
            SaveImageFromInput(sourcePath, ref httpPostedFile);
            try
            {
                ImageContext imageContext = new ImageContext(sourcePath, destinationPath, "Skew", skewBindModel.Width, skewBindModel.Height);
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
            catch (GenericException genericException)
            {
                return new CustomHttpActionResult(Request, HttpStatusCode.InternalServerError, genericException.Message);
            }
            catch (InvalidResizeSizeException invalidResizeSizeException)
            {
                return new CustomHttpActionResult(Request, HttpStatusCode.BadRequest, invalidResizeSizeException.Message);
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
