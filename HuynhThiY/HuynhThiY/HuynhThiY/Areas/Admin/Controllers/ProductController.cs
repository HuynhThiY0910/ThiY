using HuynhThiY.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;
using static HuynhThiY.Common;

namespace HuynhThiY.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        webBanhangEntities objwebBanhangEntities = new webBanhangEntities();
        // GET: Admin/Product
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {

            var lstProduct = new List<Product>();
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentFilter;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                lstProduct = objwebBanhangEntities.Products.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            {
                lstProduct = objwebBanhangEntities.Products.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            lstProduct = lstProduct.OrderByDescending(n => n.Id).ToList();
            return View(lstProduct.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            this.LoadData();
            return View();

        }

        [HttpPost]
        public ActionResult Create(Product objProduct)
        {
            this.LoadData();
            if (ModelState.IsValid)
            {
                try
                {
                    if (objProduct.ImageUpload != null)
                    {
                        //iphone.jpg
                        string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                        string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                        //jpg
                        fileName = fileName + extension;
                        objProduct.Avatar = fileName;
                        //luu file hinh
                        objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items"), fileName));
                    }
                    objProduct.CreatedOnUct = DateTime.UtcNow;
                    objwebBanhangEntities.Products.Add(objProduct);
                    objwebBanhangEntities.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(objProduct);
        }

        void LoadData()
        {
            Common objCommon = new Common();
            //lay du lieu db
            var LstCat = objwebBanhangEntities.Categories.ToList();
            //conver sang select
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dtCategory = converter.ToDataTable(LstCat);

            ViewBag.ListCategory = objCommon.ToSelectList(dtCategory, "id", "Name");
            //lay du lieu thuong hieu

            var lstBrand = objwebBanhangEntities.Brands.ToList();
            DataTable dtBrand = converter.ToDataTable(lstBrand);
            //convest sang select

            ViewBag.ListBrand = objCommon.ToSelectList(dtBrand, "id", "Name");

            List<ProductTypeId> lstProductType = new List<ProductTypeId>();
            ProductTypeId objProductType = new ProductTypeId();
            objProductType.Id = 1;
            objProductType.Name = "giảm giá sốc";

            lstProductType.Add(objProductType);

            objProductType = new ProductTypeId();
            objProductType.Id = 2;
            objProductType.Name = "Đề xuất";

            lstProductType.Add(objProductType);
            DataTable dtProductType = converter.ToDataTable(lstProductType);
            ViewBag.Producttype = objCommon.ToSelectList(dtProductType, "id", "Name");
        }


        [HttpGet]
        public ActionResult Details(int Id)
        {
            var objProduct = objwebBanhangEntities.Products.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var objProduct = objwebBanhangEntities.Products.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Delete(Product objPro)
        {
            var objProduct = objwebBanhangEntities.Products.Where(n => n.Id == objPro.Id).FirstOrDefault();
            objwebBanhangEntities.Products.Remove(objProduct);
            objwebBanhangEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var objProduct = objwebBanhangEntities.Products.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Edit(int Id, Product objProduct)
        {
            if(ModelState.IsValid)
            {
                if (objProduct.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                    string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                    fileName = fileName + extension;
                    objProduct.Avatar = fileName;
                    objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items"), fileName));
                }
                objProduct.UpdatedOnUct = DateTime.UtcNow;
                objwebBanhangEntities.Products.Add(objProduct);
                objwebBanhangEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objProduct);
        }

        }
    }


 

