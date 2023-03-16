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
        WebBanHangEntities1 objWebBanHangEntities1 = new WebBanHangEntities1();
        // GET: Products
        public ActionResult Index(int Id)
        {
            var lstProduct = objWebBanHangEntities1.products.Where(n => n.id == Id).FirstOrDefault();
            return View(lstProduct);
        }
    }
}