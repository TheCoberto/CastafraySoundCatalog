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
    public class SoundsController : Controller
    {
        public ActionResult SoundManager()
        {
            return View(DapperORM.ReturnList<SoundModel>("SoundSelectAll"));
        }

        public ActionResult MyMusic()
        {
            return View(DapperORM.ReturnList<SoundModel>("SoundSelectAll"));
        }

        [HttpGet]
        public ActionResult SoundEdit(int id = 0)
        {
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@SoundId", id);
                return View(DapperORM.ReturnList<SoundModel>("SoundSelectById", param).FirstOrDefault<SoundModel>());
            }
        }

        [HttpPost]
        public ActionResult SoundEdit(SoundModel soundModel)
        {

            DynamicParameters param = new DynamicParameters();
            param.Add("@SoundId", soundModel.SoundId);
            param.Add("@Title", soundModel.Title);
            param.Add("@Artist", soundModel.Artist);
            DapperORM.ExecuteWithoutReturn("SoundUpdate", param);

            return RedirectToAction("SoundManager");
        }

        public ActionResult Delete(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@SoundId", id);
            DapperORM.ExecuteWithoutReturn("SoundDeleteById", param);
            return RedirectToAction("SoundManager");
        }

        [HttpPost]
        public ActionResult SoundAdd(HttpPostedFileBase file, string title, string artist)
        {
            if (file != null && file.ContentLength > 0)
            {
                string fileName = Path.GetFileName(file.FileName);
                string fileExt = Path.GetExtension(fileName);
                if (IsSound(fileExt))
                {
                    int fileSize = file.ContentLength;
                    DateTime dateAdded = DateTime.Now;
                    string filePath = Path.Combine(Server.MapPath("~/sound"), fileName);
                    SqlConnection sqlconn = new SqlConnection(ConnectionString);
                    SqlCommand sqlcomm = new SqlCommand("SoundInsert", sqlconn);
                    sqlcomm.CommandType = CommandType.StoredProcedure;
                    sqlconn.Open();
                    sqlcomm.Parameters.AddWithValue("@Title", title);
                    sqlcomm.Parameters.AddWithValue("@Artist", artist);
                    sqlcomm.Parameters.AddWithValue("@FileName", fileName);
                    sqlcomm.Parameters.AddWithValue("@FileExtension", fileExt);
                    sqlcomm.Parameters.AddWithValue("@FilePath", filePath);
                    sqlcomm.Parameters.AddWithValue("@FileSize", fileSize);
                    sqlcomm.Parameters.AddWithValue("@DateAdded", dateAdded);
                    sqlcomm.ExecuteNonQuery();
                    sqlconn.Close();
                }
            }
            return RedirectToAction("SoundManager");
        }

        public ActionResult SoundAdd()
        {
            return View();
        }
    }
}