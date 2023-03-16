using HuynhThiY.Context;
using HuynhThiY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HuynhThiY.Controllers
{
    public class HomeController : Controller
    {

        WebBanHangEntities1 objWebBanHangEntities1 = new WebBanHangEntities1();

        public ActionResult Index()
        {
            HomeModel objHomeModel = new HomeModel();

            objHomeModel.ListCategory = objWebBanHangEntities1.Categories.ToList();
            objHomeModel.ListProduct = objWebBanHangEntities1.products.ToList();
            return View(objHomeModel);
        }
        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpPost]
        public ActionResult Register(int a)
        {
            ViewBag.Message = "Your contact page.";

            return View("Index");
        }
    }
}