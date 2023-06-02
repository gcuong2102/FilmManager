using Microsoft.AspNet.Identity;
using SpendingManagement.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpendingManagement.Areas.Admin.Controllers
{
    public class GetDataController : Controller
    {
        FilmDbContext db = new FilmDbContext();
        [HttpGet]
        public JsonResult GetCategory(string strId)
        {
            var category = new DataAccess().GetCategory(strId);
            return Json(category, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetHashTag(string strId)
        {
            var hashtag = new DataAccess().GetHashTag(strId);
            return Json(hashtag, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetListCategory(string searchString,int page,int pageSize)
        {
            int totalRecord = 0;
            string userId = User.Identity.GetUserId().ToString();
            pageSize = db.Settingadmins.Where(x => x.userid == userId).FirstOrDefault().defaultPage;
            IEnumerable<category> model = new DataAccess().GetCategoryListToPagedList(searchString, ref totalRecord, page, pageSize);
            foreach(var item in model)
            {
                item.link = item.last_update.ToString("dd/MM/yyyy");
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetListHashTag(string searchString, int page, int pageSize)
        {
            int totalRecord = 0;
            string userId = User.Identity.GetUserId().ToString();
            pageSize = db.Settingadmins.Where(x => x.userid == userId).FirstOrDefault().defaultPage;
            var model = new DataAccess().GetHastagListToPagedList(searchString, ref totalRecord, page, pageSize);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}