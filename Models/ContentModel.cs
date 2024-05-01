using System.Web;

namespace CastafraySoundCatalog.Models
{
    public class ContentModel
    {
        public int ContentId { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public string FileExtension { get; set; }
        public string BlobUrl { get; set; }
    }
}