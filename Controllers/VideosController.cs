using CastafraySoundCatalog.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    public class VideosController : Controller
    {
        public ActionResult VideoViewAll()
        {
            return View(DapperORM.ReturnList<VideoModel>("VideoSelectAll"));
        }

        public ActionResult VideoManager()
        {
            return View(DapperORM.ReturnList<VideoModel>("VideoSelectAll"));
        }

        [HttpGet]
        public ActionResult VideoViewById(int id = 0)
        {
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@VideoId", id);
                return View(DapperORM.ReturnList<VideoModel>("VideoSelectById", param).FirstOrDefault<VideoModel>());
            }
        }

        public ActionResult VideoDelete(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@VideoId", id);
            DapperORM.ExecuteWithoutReturn("VideoDeleteById", param);
            return RedirectToAction("VideoManager");
        }

        [HttpPost]
        public ActionResult VideoAdd(HttpPostedFileBase file, string description)
        {
            if (file == null || file.FileName.Length >= 75 || file.FileName.Contains("#") || file.ContentLength <= 0)
            {
                return RedirectToAction("UploadFailed");
            }
            else
            {
                string fileName = Path.GetFileName(file.FileName);
                string fileExt = Path.GetExtension(fileName).ToLower();
                if (IsVideo(fileExt))
                {
                    int fileSize = file.ContentLength;
                    DateTime dateAdded = DateTime.Now;
                    string filePath = Path.Combine(Server.MapPath("~/video"), fileName);
                    SqlConnection sqlconn = new SqlConnection(ConnectionString);
                    SqlCommand sqlcomm = new SqlCommand("VideoInsert", sqlconn);
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

                return RedirectToAction("VideoManager");
            }
        }

        public ActionResult VideoAdd()
        {
            return View();
        }

        public ActionResult UploadFailed()
        {
            return View();
        }

        [HttpGet]
        public ActionResult VideoEdit(int id = 0)
        {
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@VideoId", id);
                return View(DapperORM.ReturnList<VideoModel>("VideoSelectById", param).FirstOrDefault<VideoModel>());
            }
        }

        [HttpPost]
        public ActionResult VideoEdit(VideoModel videoModel)
        {

            DynamicParameters param = new DynamicParameters();
            param.Add("@VideoId", videoModel.VideoId);
            param.Add("@Description", videoModel.Description);
            DapperORM.ExecuteWithoutReturn("VideoUpdate", param);

            return RedirectToAction("VideoManager");
        }
    }
}