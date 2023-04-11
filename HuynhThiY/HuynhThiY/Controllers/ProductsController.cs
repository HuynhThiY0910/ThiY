using HuynhThiY.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HuynhThiY.Controllers
{
    public class ProductsController : Controller
    {
        webBanhangEntities objwebBanhangEntities = new webBanhangEntities();
        // GET: Products
        public ActionResult Index(int Id)
        {
            var objProduct = objwebBanhangEntities.Products.Where(n=>n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
    }
}