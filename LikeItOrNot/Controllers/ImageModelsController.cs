using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LikeItOrNot.Models;

namespace LikeItOrNot.Controllers
{
    public class ImageModelsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: ImageModels
        public ActionResult Index()
        {
            return Json(db.ImageModels.ToList(),JsonRequestBehavior.AllowGet);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
