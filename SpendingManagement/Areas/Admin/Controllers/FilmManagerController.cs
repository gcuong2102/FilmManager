using SpendingManagement.Models.EF;
using SpendingManagement.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.IO;

namespace SpendingManagement.Areas.Admin.Controllers
{
    public class FilmManagerController : AdminController
    {
        // GET: Admin/FilmManager
        public FilmDbContext db = new FilmDbContext();
        public ActionResult Film(string searchString,int page = 1, int pageSize = 10)
        {
            int totalRecord = 0;
            string userId = User.Identity.GetUserId().ToString();
            pageSize = db.Settingadmins.Where(x => x.userid == userId).FirstOrDefault().defaultPage;
            var model = new DataAccess().GetFilmListToPagedList(searchString,ref totalRecord,page,pageSize);
            SetViewBagForPagedList(totalRecord,page,pageSize,5);
            return View(model);
        }
        [HttpGet]
        public ActionResult AddFilm()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult AddFilm(FilmViewModels model)
        {
            SetViewBag();
            if (ModelState.IsValid)
            {
                var userid = User.Identity.GetUserId();
                var listImages = new List<long>();
                foreach (var item in model.getIds.Split(',').ToList())
                {
                    long id = (long)Convert.ToDouble(item);
                    listImages.Add(id);
                }
                model.image_id = listImages;
                var result = new DataAccess().AddFilm(model, userid);
                if (result)
                {
                    ModelState.AddModelError("", "Thêm thành công");
                    ModelState.Clear();
                }
                else                 
                {
                    ModelState.AddModelError("", "Vui lòng kiểm tra lại thông tin đã nhập");
                }
            }
            return View();
        }
        [HttpPost]
        public JsonResult AddLanguage(string languageName)
        {
            var language = new language();
            language.name = languageName;
            var result = new DataAccess().AddLanguage(language);
            SetViewBag();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddCategory(string categoryName)
        {
            var category = new category()
            {
                name = categoryName,
                last_update = DateTime.Now,
                meta = CreateMeta(categoryName),
                usercreatedid = System.Web.HttpContext.Current.User.Identity.GetUserId(),
                userupdatedid = System.Web.HttpContext.Current.User.Identity.GetUserId(),
                link = "/"+CreateMeta(categoryName)
            };
            var result = new DataAccess().AddCategory(category);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddHashtag(string hastagName)
        {
            var hashtag = new hashtag()
            {
                meta = CreateMeta(hastagName),
                name = hastagName,
            };
            var result = new DataAccess().AddHastag(hashtag);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Status(string searchString, int page = 1, int pageSize = 10)
        {
            int totalRecord = 0;
            string userId = User.Identity.GetUserId().ToString();
            pageSize = db.Settingadmins.Where(x => x.userid == userId).FirstOrDefault().defaultPage;
            var model = new DataAccess().GetStatusListToPagedList(searchString,ref totalRecord, page,pageSize);
            SetViewBagForPagedList(totalRecord, page, pageSize, 5);
            return View(model);
        }
        [HttpPost]
        public JsonResult Status(status status)
        {
            var result = new DataAccess().AddStatus(status);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public void SetViewBag()
        {
            ViewBag.LanguageList = new SelectList(new DataAccess().GetLanguageListToViewBag(), "id", "name");
            ViewBag.StatusList = new SelectList(new DataAccess().GetStatusListToViewBag(), "id", "name");
            ViewBag.CategoryList = new SelectList(new DataAccess().GetCategoryListToViewBag(), "id", "name");
            ViewBag.CountryList = new SelectList(new DataAccess().GetCountryListToViewBag(), "id", "name");
            ViewBag.QualityList = new SelectList(new DataAccess().GetQualityListToViewBag(), "id", "name");
            ViewBag.ImageList = db.Images.OrderByDescending(x => x.id).ToList();
        }
        [HttpGet]
        public JsonResult GetImages()
        {
            return Json(db.Images.ToList(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddImage(HttpPostedFileBase[] files)
        {
            var list = new List<image>();
            var result = new List<image>();
            if (files != null)
            {
                foreach (var file in files)
                {
                    if (file != null || file.ContentLength > 0)
                    {
                        var InputFileName = Path.GetFileName(file.FileName);
                        var ExtensionName = Path.GetExtension(file.FileName);
                        var JustName = Path.GetFileNameWithoutExtension(file.FileName);
                        var server = Path.Combine(Server.MapPath("~/images/") + InputFileName);

                        if (System.IO.File.Exists(server))
                        {
                            var ServerSavePath = Path.Combine(Server.MapPath("~/images/") + JustName + Common.Functions.CreateRandomCode("copy") + ExtensionName);
                            file.SaveAs(ServerSavePath);
                            image image = new image()
                            {
                                last_update = DateTime.Now,
                                name = InputFileName,
                                url = ServerSavePath,
                            };
                            list.Add(image);
                        }
                        else
                        {
                            var ServerSavePath = Path.Combine(Server.MapPath("~/images/") + InputFileName);
                            file.SaveAs(ServerSavePath);
                            image image = new image()
                            {
                                last_update = DateTime.Now,
                                name = InputFileName,
                                url = ServerSavePath,
                            };
                            list.Add(image);
                        }
                    }
                }
                result = new DataAccess().AddImageReturn(list);
                return Json(result,JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult Image()
        {
            ViewBag.ImageList = db.Images.OrderByDescending(x=>x.id).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Image(HttpPostedFileBase[] files)
        {
            if (ModelState.IsValid)
            {   //iterating through multiple file collection   
                foreach (HttpPostedFileBase file in files)
                {
                    //Checking file is available to save.  
                    if (file != null || file.ContentLength > 0)
                    {
                        var InputFileName = Path.GetFileName(file.FileName);
                        var ServerSavePath = Path.Combine(Server.MapPath("~/images/") + InputFileName);

                        if (System.IO.File.Exists(ServerSavePath))
                        {
                            System.IO.File.Delete(ServerSavePath);
                            file.SaveAs(ServerSavePath);
                        }
                        else
                        {
                            image image = new image()
                            {
                                last_update = DateTime.Now,
                                name = InputFileName,
                                url = ServerSavePath,
                            };
                            new DataAccess().AddImage(image);
                            file.SaveAs(ServerSavePath);
                        }
                    }
                }
            }
            ViewBag.ImageList = db.Images.OrderByDescending(x => x.id).ToList();
            return View();
        }
        [HttpGet]
        public ActionResult Test()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Test(List<long> test)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Category(string searchString,int page = 1, int pageSize = 10)
        {
            int totalRecord = 0;
            string userId = User.Identity.GetUserId().ToString();
            pageSize = db.Settingadmins.Where(x => x.userid == userId).FirstOrDefault().defaultPage;
            var model = new DataAccess().GetCategoryListToPagedList(searchString, ref totalRecord, page, pageSize);
            SetViewBagForPagedList(totalRecord, page, pageSize, 5);
            return View(model);
        }
        [HttpGet]
        public ActionResult Quality(string searchString, int page = 1,int pageSize = 10)
        {
            int totalRecord = 0;
            string userId = User.Identity.GetUserId().ToString();
            pageSize = db.Settingadmins.Where(x => x.userid == userId).FirstOrDefault().defaultPage;
            var model = new DataAccess().GetQualityListToPagedList(searchString, ref totalRecord, page, pageSize);
            SetViewBagForPagedList(totalRecord, page, pageSize, 5);
            return View(model);
        }
        [HttpGet]
        public ActionResult Language(string searchString, int page = 1, int pageSize = 10)
        {
            int totalRecord = 0;
            string userId = User.Identity.GetUserId().ToString();
            pageSize = db.Settingadmins.Where(x => x.userid == userId).FirstOrDefault().defaultPage;
            var model = new DataAccess().GetLanguageListToPagedList(searchString, ref totalRecord, page, pageSize);
            SetViewBagForPagedList(totalRecord, page, pageSize, 5);
            return View(model);
        }
        [HttpGet]
        public ActionResult Hastag(string searchString, int page = 1, int pageSize = 10)
        {
            int totalRecord = 0;
            string userId = User.Identity.GetUserId().ToString();
            pageSize = db.Settingadmins.Where(x => x.userid == userId).FirstOrDefault().defaultPage;
            var model = new DataAccess().GetHastagListToPagedList(searchString, ref totalRecord, page, pageSize);
            SetViewBagForPagedList(totalRecord, page, pageSize, 5);
            return View(model);
        }
    }
}