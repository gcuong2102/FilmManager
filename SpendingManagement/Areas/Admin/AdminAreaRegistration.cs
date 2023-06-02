using System.Web.Mvc;

namespace SpendingManagement.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                   "Manage_Hastags",
                   "quan-li-hastag",
                   new { controller = "FilmManager", AreaName = "admin", action = "Hastag", id = UrlParameter.Optional },
                   new[] { "SpendingManagement.Areas.Admin.Controllers" }
               );
            context.MapRoute(
                "Manage_Languages",
                "quan-li-ngon-ngu",
                new { controller = "FilmManager", AreaName = "admin", action = "Language", id = UrlParameter.Optional },
                new[] { "SpendingManagement.Areas.Admin.Controllers" }
            );
            context.MapRoute(
                "Manage_Qualities",
                "quan-li-chat-luong",
                new { controller = "FilmManager", AreaName = "admin", action = "Quality", id = UrlParameter.Optional },
                new[] { "SpendingManagement.Areas.Admin.Controllers" }
            );
            context.MapRoute(
                "Manage_Categories",
                "quan-li-the-loai",
                new { controller = "FilmManager", AreaName = "admin", action = "Category", id = UrlParameter.Optional },
                new[] { "SpendingManagement.Areas.Admin.Controllers" }
            );
            context.MapRoute(
                "Manage_Images",
                "quan-li-hinh-anh",
                new { controller = "FilmManager", AreaName = "admin", action = "Image", id = UrlParameter.Optional },
                new[] { "SpendingManagement.Areas.Admin.Controllers" }
            );
            context.MapRoute(
                "Manage_Film",
                "quan-li-phim",
                new { controller = "FilmManager", AreaName = "admin", action = "Film", id = UrlParameter.Optional },
                new[] { "SpendingManagement.Areas.Admin.Controllers" }
            );
            context.MapRoute(
                "Manage_AddFilm",
                "quan-li-film/them-moi",
                new { controller = "FilmManager", AreaName = "admin", action = "AddFilm", id = UrlParameter.Optional },
                new[] { "SpendingManagement.Areas.Admin.Controllers" }
            );
            context.MapRoute(
                "Manage_Status",
                "quan-li-trang-thai",
                new { controller = "FilmManager", AreaName = "admin", action = "Status", id = UrlParameter.Optional },
                new[] { "SpendingManagement.Areas.Admin.Controllers" }
            );
            context.MapRoute(
                "Default_Admin",
                "Admin",
                new { controller = "Home", AreaName = "admin", action = "Index", id = UrlParameter.Optional },
                new[] { "SpendingManagement.Areas.Admin.Controllers" }
            );
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "SpendingManagement.Areas.Admin.Controllers" }
            );
        }
    }
}