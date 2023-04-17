using HuynhThiY.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace HuynhThiY.Controllers
{
    public class CategoryController : Controller
    {
        webBanhangEntities objwebBanhangEntities = new webBanhangEntities();
        // GET: Category
        public ActionResult Index()
        {
            var lstCategory = objwebBanhangEntities.Categories.ToList();
            return View(lstCategory);
        }

        public ActionResult ProductCategory(int Id)
        {
            var listProduct = objwebBanhangEntities.Products.Where(n=>n.CategoryId==Id).ToList();
            return View(listProduct);
        }
    }

    
}