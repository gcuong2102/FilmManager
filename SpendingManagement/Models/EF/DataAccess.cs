using SpendingManagement.Common;
using SpendingManagement.Models.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SpendingManagement.Models;

namespace SpendingManagement.Models.EF
{
    public class DataAccess
    {
        //Process Function------------------------------------------------------------------------------------------------------------------------------------------------------
        FilmDbContext dbFilm;
        public DataAccess()
        {
            dbFilm = new FilmDbContext();
        }
        private string ChangeLink(string link)
        {
            return link + "-" + DateTime.Now.Second.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Hour.ToString();
        }
        private long GetIdFromSecurity(string code)
        {
            int startIndex = code.IndexOf('_') + 1;
            long id = (long)Convert.ToDouble(code.Substring(startIndex));
            return id;
        }
        //Get Function------------------------------------------------------------------------------------------------------------------------------------------------------
        public List<FilmViewModels> GetFilmList(List<film> films,int page,int pageSize)
        {
            var list = new List<FilmViewModels>();
            foreach (var film in films)
            {
                //category list
                var listCategory = new List<long>();
                foreach (var category in dbFilm.Category_Films.Where(x => x.filmid == film.id).ToList())
                {
                    listCategory.Add(category.categoryid);
                }
                //image list
                var listImage = new List<long>();
                foreach (var image in dbFilm.Image_Films.Where(x => x.filmid == film.id).ToList())
                {
                    listImage.Add(image.imageid);
                }
                //language list
                var listLanguage = new List<long>();
                foreach (var language in dbFilm.Language_Films.Where(x => x.filmid == film.id).ToList())
                {
                    listLanguage.Add(language.languageid);
                }
                var filmModel = new FilmViewModels()
                {
                    film_id = film.id,
                    filmname = film.filmname,
                    category_id = listCategory,
                    country_id = film.country_id,
                    description = film.description,
                    image_id = listImage,
                    getIds = "123",
                    language_id = listLanguage,
                    orginal_language_id = film.orginal_language_id,
                    quality_id = film.quality_id,
                    release_date = film.release_date,
                    status_id = film.status_id,
                    time = film.time,
                    view = film.view
                };
                list.Add(filmModel);
            }
            return list.OrderByDescending(x => x.film_id).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }      
        public IEnumerable GetLanguageListToViewBag()
        {
            return dbFilm.Languages.OrderBy(x => x.name).ToList();
        }
        public IEnumerable GetStatusListToViewBag()
        {
            return dbFilm.Statuses.OrderBy(x => x.name).ToList();
        }
        public IEnumerable GetCategoryListToViewBag()
        {
            return dbFilm.Categories.OrderBy(x => x.name).ToList();
        }
        public IEnumerable GetCountryListToViewBag()
        {
            return dbFilm.Countries.OrderBy(x => x.name).ToList();
        }
        public IEnumerable GetStatusListToPagedList(string searchString, ref int totalRecord, int pageIndex,int pageSize)
        {
            totalRecord = dbFilm.Statuses.ToList().Count();
            if (string.IsNullOrEmpty(searchString))
            {
                return dbFilm.Statuses.OrderBy(x=>x.id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
            else
            {
                return dbFilm.Statuses.Where(x=>x.name.Contains(searchString)).OrderBy(x => x.id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }

        }
        public IEnumerable GetFilmListToPagedList(string searchString, ref int totalRecord, int page, int pageSize)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                var listfilm = dbFilm.Films.OrderByDescending(x => x.id).ToList();
                totalRecord = listfilm.Count;
                return GetFilmList(listfilm, page, pageSize);
            }
            else
            {
                var listfilm = dbFilm.Films.Where(x => x.filmname.Contains(searchString)).OrderByDescending(x => x.id).ToList();
                totalRecord = listfilm.Count;
                return GetFilmList(listfilm, page, pageSize);
            }
        }
        public IEnumerable<category> GetCategoryListToPagedList(string searchString, ref int totalRecord, int page, int pageSize)
        {
            totalRecord = dbFilm.Categories.ToList().Count();
            if (string.IsNullOrEmpty(searchString))
            {
                return dbFilm.Categories.OrderByDescending(x => x.id).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
            else
            {
                return dbFilm.Categories.Where(x => x.name.Contains(searchString)).OrderByDescending(x => x.id).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }
        public IEnumerable GetQualityListToPagedList(string searchString, ref int totalRecord, int page, int pageSize)
        {
            totalRecord = dbFilm.Quanlities.ToList().Count();
            if (string.IsNullOrEmpty(searchString))
            {
                return dbFilm.Quanlities.OrderBy(x => x.id).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
            else
            {
                return dbFilm.Quanlities.Where(x => x.name.Contains(searchString)).OrderBy(x => x.id).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }
        public IEnumerable GetLanguageListToPagedList(string searchString, ref int totalRecord, int page, int pageSize)
        {
            totalRecord = dbFilm.Languages.ToList().Count();
            if (string.IsNullOrEmpty(searchString))
            {
                return dbFilm.Languages.OrderBy(x => x.id).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
            else
            {
                return dbFilm.Languages.Where(x => x.name.Contains(searchString)).OrderBy(x => x.id).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }
        public IEnumerable GetHastagListToPagedList(string searchString, ref int totalRecord, int page, int pageSize)
        {
            totalRecord = dbFilm.Hashtags.ToList().Count();
            if (string.IsNullOrEmpty(searchString))
            {
                return dbFilm.Hashtags.OrderBy(x => x.id).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
            else
            {
                return dbFilm.Hashtags.Where(x => x.name.Contains(searchString)).OrderBy(x => x.id).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }
        public IEnumerable GetQualityListToViewBag()
        {
            return dbFilm.Quanlities.OrderBy(x => x.name).ToList();
        }
        public status GetStatusFilm(long id)
        {
            return dbFilm.Statuses.Find(id);
        }
        public List<category> GetListCategoryFilm(long id)
        {
            var list = new List<category>();
            foreach (var category in dbFilm.Category_Films.Where(x => x.filmid == id).ToList())
            {
                var obj = dbFilm.Categories.Where(x => x.id == category.categoryid).FirstOrDefault();
                list.Add(obj);
            }
            return list;
        }
        public image GetImageMain(long id)
        {
            var idMainImage = dbFilm.Image_Films.Where(x => x.filmid == id && x.main == true).FirstOrDefault().imageid;
            return dbFilm.Images.Where(x => x.id == idMainImage).FirstOrDefault();
        }
        public category GetCategory(string strId)
        {
            int startIndex = strId.IndexOf('_') + 1;
            long id = (long)Convert.ToDouble(strId.Substring(startIndex));
            return dbFilm.Categories.Where(x => x.id == id).FirstOrDefault();
        }
        public hashtag GetHashTag(string strId)
        {
            long id = GetIdFromSecurity(strId);
            return dbFilm.Hashtags.Find(id);
        }
        //Add Function------------------------------------------------------------------------------------------------------------------------------------------------------
        public bool AddFilm(FilmViewModels model, string userid)
        {
            try
            {
                var newfilm = new film()
                {
                    country_id = model.country_id,
                    category_id = model.category_id.FirstOrDefault(),
                    filmname = model.filmname,
                    description = model.description,
                    orginal_language_id = model.orginal_language_id,
                    last_update = DateTime.Now,
                    time = model.time,
                    title = Functions.CreateMeta(model.filmname),
                    quality_id = model.quality_id,
                    status_id = model.status_id,
                    release_date = model.release_date,
                    user_id = userid,
                    view = 0,

                };
                dbFilm.Films.Add(newfilm);
                dbFilm.SaveChanges();
                //Add category
                foreach (var item in model.category_id)
                {
                    dbFilm.Category_Films.Add(new category_film()
                    {
                        filmid = newfilm.id,
                        categoryid = item,
                    });
                }
                foreach (var item in model.language_id)
                {
                    dbFilm.Language_Films.Add(new language_film()
                    {
                        filmid = newfilm.id,
                        languageid = item,
                    });
                }
                for (int i = 0; i < model.image_id.Count; i++)
                {
                    if (i == 0)
                    {
                        dbFilm.Image_Films.Add(new image_film()
                        {
                            filmid = newfilm.id,
                            main = true,
                            imageid = model.image_id[i],
                            order = i
                        });
                    }
                    else
                    {
                        dbFilm.Image_Films.Add(new image_film()
                        {
                            filmid = newfilm.id,
                            main = false,
                            imageid = model.image_id[i],
                            order = i,
                        });
                    }
                }
                dbFilm.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public ResultModels AddLanguage(language language)
        {
            try
            {
                if (dbFilm.Languages.Where(x => x.name == language.name).Count() == 0)
                {
                    dbFilm.Languages.Add(language);
                    dbFilm.SaveChanges();
                    return new ResultModels() { result = true, text = "Thêm ngôn ngữ thành công", data = language };
                }
                else
                {
                    return new ResultModels() { result = false, text = "Ngôn ngữ này đã có, vui lòng kiểm tra lại" };
                }

            }
            catch (Exception ex)
            {
                return new ResultModels() { result = false, text = "Có lỗi xảy ra, vui lòng thử lại" };
            }
        }
        public ResultModels AddCategory(category category)
        {
            try
            {
                if (dbFilm.Categories.Where(x => x.name == category.name).Count() == 0)
                {
                    if (dbFilm.Categories.Where(x => x.link == category.link).Count() == 0)
                    {
                        category.link = category.link;
                    }
                    else
                    {
                        category.link = ChangeLink(category.link);
                    }
                    dbFilm.Categories.Add(category);
                    dbFilm.SaveChanges();
                    return new ResultModels() { result = true, text = "Thêm thể loại thành công", data = category };
                }
                else
                {
                    return new ResultModels() { result = false, text = "Thể loại này đã có, vui lòng kiểm tra lại" };
                }

            }
            catch (Exception ex)
            {
                return new ResultModels() { result = false, text = "Có lỗi xảy ra, vui lòng thử lại" };
            }
        }
        public ResultModels AddHastag(hashtag hashtag)
        {
            try
            {
                if (dbFilm.Hashtags.Where(x => x.name == hashtag.name).Count() == 0)
                {
                    dbFilm.Hashtags.Add(hashtag);
                    dbFilm.SaveChanges();
                    return new ResultModels() { result = true, text = "Thêm hashtag thành công", data = hashtag };
                }
                else
                {
                    return new ResultModels() { result = false, text = "Hashtag này đã có, vui lòng kiểm tra lại" };
                }

            }
            catch (Exception ex)
            {
                return new ResultModels() { result = false, text = "Có lỗi xảy ra, vui lòng thử lại" };
            }
        }
        public ResultModels AddStatus(status status)
        {
            try
            {
                if (dbFilm.Statuses.Where(x => x.name == status.name).Count() == 0)
                {
                    dbFilm.Statuses.Add(status);
                    dbFilm.SaveChanges();
                    return new ResultModels() { result = true, text = "Thêm trạng thái thành công", data = status };
                }
                else
                {
                    return new ResultModels() { result = false, text = "Trạng thái này đã có, vui lòng kiểm tra lại" };
                }
            }
            catch
            {
                return new ResultModels() { result = false, text = "Có lỗi xảy ra, vui lòng thử lại" };
            }
        }
        public List<image> AddImageReturn(List<image> images)
        {
            var list = new List<image>();
            foreach(var image in images)
            {
                dbFilm.Images.Add(image);
                dbFilm.SaveChanges();
                list.Add(image);
            }
            return list;
        }
        public void AddImage(image image)
        {
            dbFilm.Images.Add(image);
            dbFilm.SaveChanges();
        }
        //Update Function------------------------------------------------------------------------------------------------------------------------------------------------------
        public ResultModels UpdateCategory(category category)
        {
            try
            {
                if (dbFilm.Categories.Where(x => x.name == category.name).Count() == 0)
                {
                    var categoryOld = dbFilm.Categories.Find(category.id);
                    categoryOld.name = category.name;
                    categoryOld.meta = category.meta;
                    if(dbFilm.Categories.Where(x=>x.link == category.link).Count() == 0)
                    {
                        categoryOld.link = category.link;
                    }
                    else
                    {
                        categoryOld.link = ChangeLink(category.link);
                    }
                    categoryOld.last_update = DateTime.Now;
                    categoryOld.userupdatedid = category.userupdatedid;
                    dbFilm.SaveChanges();
                    return new ResultModels() { result = true, text = "Cập nhật thể loại thành công", data = category };
                }
                else
                {
                    return new ResultModels() { result = false, text = "Thể loại này đã có, vui lòng kiểm tra lại" };
                }

            }
            catch (Exception ex)
            {
                return new ResultModels() { result = false, text = "Có lỗi xảy ra, vui lòng thử lại" };
            }
        }
        public ResultModels UpdateHashtag(hashtag hashtag)
        {
            try
            {
                if (dbFilm.Hashtags.Where(x => x.name == hashtag.name).Count() == 0)
                {
                    var hashtagOld = dbFilm.Hashtags.Find(hashtag.id);
                    hashtagOld.name = hashtag.name;
                    hashtagOld.meta = hashtag.meta;
                    dbFilm.SaveChanges();
                    return new ResultModels() { result = true, text = "Cập nhật thể loại thành công", data = hashtag };
                }
                else
                {
                    return new ResultModels() { result = false, text = "Thể loại này đã có, vui lòng kiểm tra lại" };
                }

            }
            catch (Exception ex)
            {
                return new ResultModels() { result = false, text = "Có lỗi xảy ra, vui lòng thử lại" };
            }
        }
        //Delete Function------------------------------------------------------------------------------------------------------------------------------------------------------
        public ResultModels DeleteCategory(string categoryId)
        {
            try
            {
                var category = dbFilm.Categories.Find(GetIdFromSecurity(categoryId));
                dbFilm.Categories.Remove(category);
                dbFilm.SaveChanges();
                return new ResultModels() { result = true, text = "Xóa thành công", data = category };

            }
            catch (Exception ex)
            {
                return new ResultModels() { result = false, text = "Có lỗi xảy ra, vui lòng thử lại" };
            }
        }
        public ResultModels DeleteHashTag(string hashTagID)
        {
            try
            {
                var hashtag = dbFilm.Hashtags.Find(GetIdFromSecurity(hashTagID));
                dbFilm.Hashtags.Remove(hashtag);
                dbFilm.SaveChanges();
                return new ResultModels() { result = true, text = "Xóa thành công", data = hashtag };

            }
            catch (Exception ex)
            {
                return new ResultModels() { result = false, text = "Có lỗi xảy ra, vui lòng thử lại" };
            }
        }
    }
}