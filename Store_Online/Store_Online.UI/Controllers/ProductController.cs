using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store_Online.Core.Models;
using Store_Online.DataAccess.Inmemory;

namespace Store_Online.UI.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository context;
        public ProductController()
        {
            context = new ProductRepository();
        }
        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }
        public ActionResult Create(Product product)
        {
            if(ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                context.Insert(product);
                context.Commit();
                return RedirectToAction("index");
            }
        }
        public ActionResult Edit(string ID)
        {
            Product product = context.Find(ID);
            if(product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
        }
        [HttpPost]
        public ActionResult Edit(Product product, string ID)
        {
            Product prod = context.Find(ID);
            if (prod == null)
            {
                return HttpNotFound();
            }
            else
            {
                if(!ModelState.IsValid)
                {
                    return View(product);
                }

            }
        }
    }
}