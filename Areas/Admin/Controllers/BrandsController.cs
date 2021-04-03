using EFDbFirstApprochExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFDbFirstApprochExample.Areas.Admin.Controllers
{
    public class BrandsController : Controller
    {
        // GET: Admin/Brands
        public ActionResult Index()
        {
            CompanyDbContext db = new CompanyDbContext();

            List<Brand> brands = db.Brands.ToList();

            return View(brands);
        }
    }
}