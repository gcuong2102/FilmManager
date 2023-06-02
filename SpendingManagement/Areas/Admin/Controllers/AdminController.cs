using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SpendingManagement.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(User.Identity.GetUserName() == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "Login" }));
            }
            base.OnActionExecuting(filterContext);
        }
        public void SetViewBagForPagedList(int totalRecord, int page, int pageSize, int maxPage)
        {
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            var totalPage = (decimal)totalRecord / pageSize;
            totalPage = (int)Math.Ceiling(totalPage);
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
        }
        private string ConvertToUnSign3(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        public string CreateMeta(string name)
        {
            return ConvertToUnSign3(name).Replace(' ', '-');
        }
    }
}