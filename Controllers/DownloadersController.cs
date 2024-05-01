using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using System.Diagnostics;

namespace CastafraySoundCatalog.Controllers
{
    public class DownloadersController : Controller
    {
        public ActionResult AudioDownloader()
        {
            return View();
        }
        public ActionResult VideoDownloader()
        {
            return View();
        }
        public ActionResult DownloadAudio(string name, string url)
        {
            var fileName = $"{name}.mp3";
            var outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Downloads", fileName);

            var processStartInfo = new ProcessStartInfo
            {
                FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "yt-dlp.exe"),
                Arguments = $"-x --audio-format mp3 -o \"{outputPath}\" {url}",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = new Process())
            {
                process.StartInfo = processStartInfo;
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                if (process.ExitCode == 0 && System.IO.File.Exists(outputPath))
                {
                    return File(outputPath, "audio/mpeg", fileName);
                }
            }

            return Content("Failed to download audio.");
        }

        public ActionResult DownloadVideo(string name, string url)
        {
            var fileName = $"{name}.mp4";
            var outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Downloads", fileName);

            var processStartInfo = new ProcessStartInfo
            {
                FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "yt-dlp.exe"),
                Arguments = $"-f bestvideo[ext=mp4]+bestaudio[ext=m4a]/mp4 -o \"{outputPath}\" {url}",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = new Process())
            {
                process.StartInfo = processStartInfo;
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                if (process.ExitCode == 0 && System.IO.File.Exists(outputPath))
                {
                    return File(outputPath, "video/mp4", fileName);
                }
            }

            return Content("Failed to download video.");
        }
    }
}