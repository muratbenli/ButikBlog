using ButikBlog.Attributes;
using ButikBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ButikBlog.Areas.Admin.Controllers
{
    [Breadcrumb("Kategoriler")]
    public class CategoriesController : AdminBaseController
    {

        [Breadcrumb("İndeks")]
        // GET: Admin/Categories
        public ActionResult Index()
        {
            return View(db.Categories.OrderByDescending(x => x.CategoryName).ToList());
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var category = db.Categories.Find(id);

            if (category == null)
            {
                return HttpNotFound();
            }
            if (category.Posts.Count > 0)
            {
                return Json(new { success = false, error = "Silmek istediğiniz kategoride yazılar bulunduğundan silinememektedir." });

            }

            db.Categories.Remove(category);
            db.SaveChanges();
           
            return Json(new { success = true });
        }

        [Breadcrumb("Yeni")]
        public ActionResult New()
        {
            return View("Edit", new Category());
        }

        [Breadcrumb("Yeni")]
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult New(Category model)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(model);
                db.SaveChanges();
                TempData["successMessage"] = "Yeni kategori başarı ile oluşturuldu.";
                return RedirectToAction("Index");
            }

            return View("Edit", model);
        }

        [Breadcrumb("Düzenle")]
        public ActionResult Edit(int id)
        {
            return View("Edit", db.Categories.Find(id));
        }

        [Breadcrumb("Düzenle")]
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                TempData["successMessage"] = "Kategori ismi başarı ile değiştirildi.";
                return RedirectToAction("Index");
            }

            return View("Edit", model);
        }

    }
}