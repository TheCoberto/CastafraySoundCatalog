using CastafraySoundCatalog.Models;
using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static CastafraySoundCatalog.Globals;
using static CastafraySoundCatalog.Helpers;

namespace CastafraySoundCatalog.Controllers
{
    public class ImagesController : Controller
    {
        public ActionResult ImageViewAll()
        {
            return View(DapperORM.ReturnList<ImageModel>("ImageSelectAll"));
        }

        public ActionResult ImageManager()
        {
            return View(DapperORM.ReturnList<ImageModel>("ImageSelectAll"));
        }

        [HttpGet]
        public ActionResult ImageViewById(int id = 0)
        {
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@ImageId", id);
                return View(DapperORM.ReturnList<ImageModel>("ImageSelectById", param).FirstOrDefault<ImageModel>());
            }
        }

        public ActionResult ImageDelete(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ImageId", id);
            DapperORM.ExecuteWithoutReturn("ImageDeleteById", param);
            return RedirectToAction("ImageManager");
        }

        [HttpPost]
        public ActionResult ImageAdd(HttpPostedFileBase file, string description)
        {
            if (file == null || file.FileName.Length >= 75 || file.FileName.Contains("#") || file.ContentLength <= 0)
            {
                return RedirectToAction("UploadFailed");
            }
            else
            {
                string fileName = Path.GetFileName(file.FileName);
                string fileExt = Path.GetExtension(fileName).ToLower();

                if (IsImage(fileExt))
                {
                    int fileSize = file.ContentLength;
                    DateTime dateAdded = DateTime.Now;
                    string filePath = Path.Combine(Server.MapPath("~/image"), fileName);
                    SqlConnection sqlconn = new SqlConnection(ConnectionString);
                    SqlCommand sqlcomm = new SqlCommand("ImageInsert", sqlconn);
                    sqlcomm.CommandType = CommandType.StoredProcedure;
                    sqlconn.Open();
                    sqlcomm.Parameters.AddWithValue("@Title", fileName);
                    sqlcomm.Parameters.AddWithValue("@Description", description);
                    sqlcomm.Parameters.AddWithValue("@FileExt", fileExt);
                    sqlcomm.Parameters.AddWithValue("@FilePath", filePath);
                    sqlcomm.Parameters.AddWithValue("@FileSize", fileSize);
                    sqlcomm.Parameters.AddWithValue("@DateAdded", dateAdded);
                    sqlcomm.ExecuteNonQuery();
                    file.SaveAs(filePath);
                    sqlconn.Close();
                }

                return RedirectToAction("ImageManager");
            }
        }

        public ActionResult ImageAdd()
        {
            return View();
        }

        public ActionResult ImageViewAllShuffled()
        {
            return View(DapperORM.ReturnList<ImageModel>("ImageSelectAll"));
        }
        public ActionResult UploadFailed()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ImageEdit(int id = 0)
        {
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@ImageId", id);
                return View(DapperORM.ReturnList<ImageModel>("ImageSelectById", param).FirstOrDefault<ImageModel>());
            }
        }

        [HttpPost]
        public ActionResult ImageEdit(ImageModel imageModel)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ImageId", imageModel.ImageId);
            param.Add("@Description", imageModel.Description);
            DapperORM.ExecuteWithoutReturn("ImageUpdate", param);

            return RedirectToAction("ImageManager");
        }   
    }
}