using HuynhThiY.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace HuynhThiY.Areas.Admin.Controllers
{
    public class CategorysController : Controller
    {
        webBanhangEntities objwebBanhangEntities = new webBanhangEntities();
        // GET: Admin/Category
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var lstCategory = new List<Category>();
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
                lstCategory = objwebBanhangEntities.Categories.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            {
                lstCategory = objwebBanhangEntities.Categories.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            lstCategory = lstCategory.OrderByDescending(n => n.Id).ToList();
            return View(lstCategory.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Details(int Id)
        {
            var objCategory = objwebBanhangEntities.Categories.Where(n => n.Id == Id).FirstOrDefault();
            return View(objCategory);
        }
        public ActionResult Delete(int Id)
        {
            var objCategory = objwebBanhangEntities.Categories.Where(n => n.Id == Id).FirstOrDefault();
            return View(objCategory);
        }
        [HttpPost]
        public ActionResult Delete(Category objca)
        {
            var objCategory = objwebBanhangEntities.Categories.Where(n => n.Id == objca.Id).FirstOrDefault();
            objwebBanhangEntities.Categories.Remove(objCategory);
            objwebBanhangEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int Id)
        {
            var objCategory = objwebBanhangEntities.Categories.Where(n => n.Id == Id).FirstOrDefault();
            return View(objCategory);
        }
        [HttpPost]
        public ActionResult Edit(int Id, Category objCategory)
        {
            if (ModelState.IsValid)
            {
                if (objCategory.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objCategory.ImageUpload.FileName);
                    string extension = Path.GetExtension(objCategory.ImageUpload.FileName);
                    fileName = fileName + extension;
                    objCategory.Avatar = fileName;
                    objCategory.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items"), fileName));
                }
                objCategory.UpdatedOnUct = DateTime.UtcNow;
                objwebBanhangEntities.Entry(objCategory).State = EntityState.Modified;
                objwebBanhangEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objCategory);
        }

        [HttpGet]
        public ActionResult Create()
        {


            return View();


        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Category objCategory)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    if (objCategory.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objCategory.ImageUpload.FileName);
                        string extension = Path.GetExtension(objCategory.ImageUpload.FileName);
                        fileName = fileName + extension;
                        objCategory.Avatar = fileName;
                        objCategory.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items/"), fileName));
                    }
                    objCategory.CreatedOnUct = DateTime.Now;
                    objwebBanhangEntities.Categories.Add(objCategory);
                    objwebBanhangEntities.SaveChanges();
                    return RedirectToAction("Index");
                }

                catch (Exception)

                {
                    return RedirectToAction("Index");
                }
            }

            return View(objCategory);
        }

    }
}