using System.Linq;

namespace CastafraySoundCatalog
{
    public static class Helpers
    {
        public static bool IsValidFileType(string fileExtension)
        {
            if (Globals.SupportedExtensions.Contains(fileExtension))
                return true;
            else
                return false;
        }
        public static bool IsImage(string fileExtension)
        {
            if (Globals.ImageFileExtensions.Contains(fileExtension))
                return true;
            else
                return false;
        }
        public static bool IsVideo(string fileExtension)
        {
            if (Globals.VideoFileExtensions.Contains(fileExtension))
                return true;
            else
                return false;
        }
        public static bool IsSound(string fileExtension)
        {
            if (Globals.SoundFileExtensions.Contains(fileExtension))
                return true;
            else
                return false;
        }
    }
}