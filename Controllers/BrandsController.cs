using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDbFirstApprochExample.Models;

namespace EFDbFirstApprochExample.Controllers
{
    public class BrandsController : Controller
    {
        // GET: Brands
        public ActionResult Index()
        {
            CompanyDbContext db = new CompanyDbContext();

            List<Brand> brands = db.Brands.ToList();

            return View(brands);
        }
    }
}