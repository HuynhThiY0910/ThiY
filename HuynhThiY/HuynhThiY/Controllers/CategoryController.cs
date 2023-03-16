using HuynhThiY.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HuynhThiY.Controllers
{
    public class CategoryController : Controller
    {
        WebBanHangEntities1 objWebBanHangEntities1 = new WebBanHangEntities1();
        // GET: Category
        public ActionResult Index()
        {
            var lstCategory = objWebBanHangEntities1.Categories.ToList();
            return View(lstCategory);
        }
        public ActionResult ProductCategory(int Id)
        {
            var ListProduct = objWebBanHangEntities1.products.Where(n => n.CategoryId == Id).ToList();

            return View(ListProduct);
        }
    }
}