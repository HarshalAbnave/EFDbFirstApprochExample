using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDbFirstApprochExample.Filters;
using Company.DataLayer;
using Company.DomainModels;

namespace EFDbFirstApprochExample.Controllers
{
    
    public class ProductsController : Controller
    {
        // GET: Products
        [AuthenticationFilter]
        public ActionResult Index()
        {
            CompanyDbContext companyDb = new CompanyDbContext();
            List<Product> products = companyDb.Products.ToList();
            return View(products);
        }
    }
}