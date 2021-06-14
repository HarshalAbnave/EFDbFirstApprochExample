using System.Collections.Generic;
using Company.DomainModels;
using System.Linq;
using System.Web.Mvc;
using Company.DataLayer;

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