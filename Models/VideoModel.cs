using System;
using System.Web;

namespace CastafraySoundCatalog.Models
{
    public class VideoModel
    {
        public int VideoId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Description { get; set; }
        public Nullable<int> FileSize { get; set; }
        public string FilePath { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public string VideoPath { get; set; }
        public string FileExt { get; set; }
        public string VideoName { get; set; }
        public int VideoPlayCount { get; set; }
    }
}