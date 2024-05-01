﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CastafraySoundCatalog.Models
{
    public class ImageModel
    {
        public int ImageId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Nullable<int> FileSize { get; set; }
        public string FilePath { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public string FileExt { get; set; }
        public DateTime DateAdded { get; set; }
    }
}