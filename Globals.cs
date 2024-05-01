﻿using System.Configuration;

namespace CastafraySoundCatalog
{
    public static class Globals
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public static string[] SupportedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".mp4", ".mov", ".avi", ".webm", ".heic", ".jfif" };
        public static string[] SoundFileExtensions = { ".wav", ".mp3", ".ogg" };
        public static string[] ImageFileExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".jfif" };
        public static string[] VideoFileExtensions = { ".mp4", ".mov", ".webm", ".avi", ".heic"};
    }
}