using EFDbFirstApprochExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFDbFirstApprochExample.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult Index(string search = "",string SortColumn = "ProductName",string IconClass = "fa-sort-asc", int PageNo = 1)
        {
            CompanyDbContext db = new CompanyDbContext();

            List<Product> products = db.Products.Where(x => x.ProductName.Contains(search)).ToList();
            
            #region Sorting

            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;
            if(ViewBag.SortColumn == "ProductID")
            {
                if(ViewBag.IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(x => x.ProductID).ToList();
                }
                else
                {
                    products = products.OrderByDescending(x => x.ProductID).ToList();
                }
            }

            if (ViewBag.SortColumn == "ProductName")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(x => x.ProductName).ToList();
                }
                else
                {
                    products = products.OrderByDescending(x => x.ProductName).ToList();
                }
            }

            if (ViewBag.SortColumn == "DateOfPurchase")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(x => x.DateOfPurchase).ToList();
                }
                else
                {
                    products = products.OrderByDescending(x => x.DateOfPurchase).ToList();
                }
            }

            if (ViewBag.SortColumn == "Price")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(x => x.Price).ToList();
                }
                else
                {
                    products = products.OrderByDescending(x => x.Price).ToList();
                }
            }

            if (ViewBag.SortColumn == "AvailabilityStatus")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(x => x.AvailabilityStatus).ToList();
                }
                else
                {
                    products = products.OrderByDescending(x => x.AvailabilityStatus).ToList();
                }
            }

            if (ViewBag.SortColumn == "BrandID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(x => x.BrandID).ToList();
                }
                else
                {
                    products = products.OrderByDescending(x => x.BrandID).ToList();
                }
            }

            if (ViewBag.SortColumn == "CategoryID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(x => x.CategoryID).ToList();
                }
                else
                {
                    products = products.OrderByDescending(x => x.CategoryID).ToList();
                }
            }
            #endregion

            #region Paging
            int NoOfRecordPerPage = 5;
            int NoOfPages = (Int32)Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordPerPage));
            int NoOfRecordToSkip = (PageNo - 1) * NoOfRecordPerPage;
            ViewBag.PageNo = PageNo;
            ViewBag.NoOfPages = NoOfPages;
            products = products.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            #endregion

            return View(products);
        }

        public ActionResult Details(long id)
        {
            CompanyDbContext db = new CompanyDbContext();

            Product product = db.Products.Where(x => x.ProductID == id).FirstOrDefault();

            return View(product);
        }

        public ActionResult Create()
        {
            CompanyDbContext db = new CompanyDbContext();

            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "ProductID, ProductName, Price, DateOfPurchase, AvailabilityStatus, CategoryID, BrandID, Active")]Product product)
        {
            if(ModelState.IsValid)
            {
                CompanyDbContext db = new CompanyDbContext();

                db.Products.Add(product);

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                CompanyDbContext db = new CompanyDbContext();

                ViewBag.Categories = db.Categories.ToList();
                ViewBag.Brands = db.Brands.ToList();
                return View();
            }  
        }

        public ActionResult Edit(long id)
        {
            CompanyDbContext db = new CompanyDbContext();

            Product product = db.Products.Where(x => x.ProductID == id).FirstOrDefault();
            
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            CompanyDbContext db = new CompanyDbContext();

            Product product1 = db.Products.Where(x => x.ProductID == product.ProductID).FirstOrDefault();
            product1.ProductName = product.ProductName;
            product1.Price = product.Price;
            product1.DateOfPurchase = product.DateOfPurchase;
            product1.CategoryID = product.CategoryID;
            product1.BrandID = product.BrandID;
            product1.AvailabilityStatus = product.AvailabilityStatus;
            product1.Active = product.Active;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(long id)
        {
            CompanyDbContext db = new CompanyDbContext();

            Product product = db.Products.Where(x => x.ProductID == id).FirstOrDefault();

            return View(product);
        }

        [HttpPost]
        public ActionResult Delete(long id,Product product)
        {
            CompanyDbContext db = new CompanyDbContext();

            Product product1 = db.Products.Where(x => x.ProductID == id).FirstOrDefault();
            db.Products.Remove(product1);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}