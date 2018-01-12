using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageConverterWebAPI.BindModels
{
    public class CropBindModel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}