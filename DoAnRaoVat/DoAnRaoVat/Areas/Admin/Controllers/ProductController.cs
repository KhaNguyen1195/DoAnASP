using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnRaoVat.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new ProductDao();
            var model = dao.LissAllPaging(searchString, page, pageSize);
            ViewBag.searchString = searchString;
            return View(model);
        }

        public void SetViewBag(long? selectedId = null)
        {
            var dao = new CategoryDao();
            ViewBag.Category_ID = new SelectList(dao.LissAll(), "ID", "Name", selectedId);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();

        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                product.CreatedDate = DateTime.Now;
                long id = dao.Insert(product);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm danh mục không thành công");
                }
            }
            SetViewBag();
            return View("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = new ProductDao().ViewDetail(id);
            SetViewBag(product.Category_ID);
            return View(product);
        }


        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                var result = dao.Update(product);
                if (result)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật danh mục không thành công");
                }
            }
            SetViewBag(product.Category_ID);
            return View("Index");
        }

        public ActionResult Delete(int id)
        {
            var dao = new ProductDao();
            dao.Delete(id);
            return RedirectToAction("Index");
        }

        DoAnASPDBContext db = new DoAnASPDBContext();
    }
}