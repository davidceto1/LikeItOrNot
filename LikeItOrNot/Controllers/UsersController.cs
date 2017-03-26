using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LikeItOrNot.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace LikeItOrNot.Controllers
{
    public class UsersController : Controller
    {
        private DBContext db = new DBContext();

        public RoleManager<IdentityRole> RoleManager { get; private set; }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        [HttpPost]
        public ActionResult LikeImage([Bind(Include = "Id,Number")] ImageModel imageModel)
        {
            if (ModelState.IsValid)
            {
                string userId = Request.GetOwinContext().Authentication.User.Identity.GetUserId();
                User user = db.Users.Find(userId);
                user.LikedImages.Add(imageModel);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            //return View( Json(db.ImageModels.ToList(), JsonRequestBehavior.AllowGet));
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public ActionResult DislikeImage([Bind(Include = "Id,Number")] ImageModel imageModel)
        {
            if (ModelState.IsValid)
            {
                string userId = Request.GetOwinContext().Authentication.User.Identity.GetUserId();
                User user = db.Users.Find(userId);
                user.DislikedImages.Add(imageModel);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            //return View( Json(db.ImageModels.ToList(), JsonRequestBehavior.AllowGet));
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // GET: ImageModels/ListLikedImages
        public ActionResult ListLikedImages()
        {

            string userId = Request.GetOwinContext().Authentication.User.Identity.GetUserId();
            User user = db.Users.Find(userId);
            return Json(user.LikedImages, JsonRequestBehavior.AllowGet);
        }

        // GET: ImageModels/LisDislikedImages
        public ActionResult ListDislikedImages()
        {

            string userId = Request.GetOwinContext().Authentication.User.Identity.GetUserId();
            User user = db.Users.Find(userId);
            return Json(user.DislikedImages, JsonRequestBehavior.AllowGet);
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
