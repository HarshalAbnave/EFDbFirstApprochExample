using Company.DataLayer;
using Company.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFDbFirstApprochExample.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Admin/Categories
        public ActionResult Index()
        {
            CompanyDbContext db = new CompanyDbContext();

            List<Category> categories = db.Categories.ToList();

            return View(categories);
        }
    }
}