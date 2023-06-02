using SpendingManagement.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpendingManagement.Areas.Admin.Controllers
{
    public class DeleteController : AdminController
    {
        [HttpPost]
        public JsonResult DeleteCategory(string categoryId)
        {
            var result = new DataAccess().DeleteCategory(categoryId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DeleteHashTag(string hashtagId)
        {
            var result = new DataAccess().DeleteHashTag(hashtagId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}