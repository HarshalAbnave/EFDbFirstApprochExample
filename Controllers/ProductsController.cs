using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDbFirstApprochExample.Models;
using EFDbFirstApprochExample.Filters;

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