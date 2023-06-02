using Microsoft.AspNet.Identity;
using SpendingManagement.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpendingManagement.Areas.Admin.Controllers
{
    public class UpdateDataController : AdminController
    {
        public JsonResult UpdateCategory(category category)
        {
            category.meta = CreateMeta(category.name);
            category.link = "/" + CreateMeta(category.name);
            category.userupdatedid = User.Identity.GetUserId().ToString();
            var result = new DataAccess().UpdateCategory(category);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateHashtag(hashtag hashtag)
        {
            hashtag.meta = CreateMeta(hashtag.name);
            var result = new DataAccess().UpdateHashtag(hashtag);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}