using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CastafraySoundCatalog.Models
{
    public class SoundModel
    {
        public int SoundId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string FileExtension { get; set; }
        public string Description { get; set; }
        public Nullable<int> FileSize { get; set; }
        public string FilePath { get; set; }
        public HttpPostedFileBase Sound { get; set; }

        public string SoundPath { get; set; }
        public string SoundExt { get; set; }
        public string FileName { get; set; }
    }
}