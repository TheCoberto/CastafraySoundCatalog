using CastafraySoundCatalog.Models;
using Dapper;
using System;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static CastafraySoundCatalog.Globals;
using static CastafraySoundCatalog.Helpers;
using CastafraySoundCatalog.Services;

namespace CastafraySoundCatalog.Controllers
{
    public class ContentController : Controller
    {
        Random rng = new Random();

        public ActionResult ContentViewAll()
        {
            return View(DapperORM.ReturnList<ContentModel>("ContentSelectAll"));
        }

        public ActionResult ContentManager()
        {
            return View(DapperORM.ReturnList<ContentModel>("ContentSelectAll"));
        }

        public ActionResult ImageManager()
        {
            var allFiles = DapperORM.ReturnList<ContentModel>("ContentSelectAll");
            var images = allFiles.Where(x => ImageFileExtensions.Any(ext => ext == x.FileExtension));

            return View(images);
        }
        public ActionResult VideoManager()
        {
            var allFiles = DapperORM.ReturnList<ContentModel>("ContentSelectAll");
            var videos = allFiles.Where(x => VideoFileExtensions.Any(ext => ext == x.FileExtension));

            return View(videos);
        }
        public ActionResult SoundManager()
        {
            var allFiles = DapperORM.ReturnList<ContentModel>("ContentSelectAll");
            var sounds = allFiles.Where(x => SoundFileExtensions.Any(ext => ext == x.FileExtension));

            return View(sounds);
        }

        public ActionResult ContentViewAllShuffled()
        {
            return View(DapperORM.ReturnList<ContentModel>("ContentSelectAll"));
        }

        public ActionResult Storage()
        {
            return View();
        }

        public ActionResult ContentViewById(int id = 0)
        {
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@ContentId", id);
                return View(DapperORM.ReturnList<ContentModel>("ContentSelectById", param).FirstOrDefault());
            }
        }

        public ActionResult ContentDelete(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ContentId", id);
            DapperORM.ExecuteWithoutReturn("ContentDeleteById", param);
            return RedirectToAction("ContentManager");
        }

        [HttpPost]
        public ActionResult ContentAdd(HttpPostedFileBase file, string description, string title, string artist)
        {
            if (file == null || file.FileName.Length >= 75 || file.FileName.Contains("#") || file.ContentLength <= 0)
            {
                return RedirectToAction("UploadFailed");
            }
            else
            {
                string fileName = Path.GetFileName(file.FileName);
                string fileExt = Path.GetExtension(fileName).ToLower();

                if (IsValidFileType(fileExt))
                {
                    var blobService = new AzureBlobService();
                    var blobUrl = blobService.UploadFile(file);
                    int fileSize = file.ContentLength;
                    DateTime currentDateTime = DateTime.Now;
                    SqlConnection sqlconn = new SqlConnection(ConnectionString);
                    SqlCommand sqlcomm = new SqlCommand("ContentInsert", sqlconn);
                    sqlcomm.CommandType = CommandType.StoredProcedure;
                    sqlconn.Open();
                    sqlcomm.Parameters.AddWithValue("@FileName", fileName);
                    sqlcomm.Parameters.AddWithValue("@Title", title);
                    sqlcomm.Parameters.AddWithValue("@Artist", artist);
                    sqlcomm.Parameters.AddWithValue("@Description", description);
                    sqlcomm.Parameters.AddWithValue("@FileExtension", fileExt);
                    sqlcomm.Parameters.AddWithValue("@FileSize", fileSize);
                    sqlcomm.Parameters.AddWithValue("@DateAdded", currentDateTime);
                    sqlcomm.Parameters.AddWithValue("@DateMod", currentDateTime);
                    sqlcomm.Parameters.AddWithValue("@BlobUrl", blobUrl);
                    sqlcomm.ExecuteNonQuery();
                    sqlconn.Close();
                }
                else
                {
                    return RedirectToAction("UploadFailed");
                }

                return RedirectToAction("ContentManager");
            }
        }

        public ActionResult ContentAdd()
        {
            return View();
        }

        public ActionResult UploadFailed()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ContentEdit(int id = 0)
        {
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@ContentId", id);
                return View(DapperORM.ReturnList<ContentModel>("ContentSelectById", param).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult ContentEdit(ContentModel contentModel)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ContentId", contentModel.ContentId);
            param.Add("@Title", contentModel.Title);
            param.Add("@Artist", contentModel.Artist);
            param.Add("@Description", contentModel.Description);
            DapperORM.ExecuteWithoutReturn("ContentUpdate", param);

            return RedirectToAction("ContentManager");
        }
    }
}