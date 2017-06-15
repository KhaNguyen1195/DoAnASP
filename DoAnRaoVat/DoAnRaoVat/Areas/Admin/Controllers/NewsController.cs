using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnRaoVat.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        // GET: Admin/News
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new NewsDao();
            var model = dao.LissAllPaging(searchString, page, pageSize);
            ViewBag.searchString = searchString;
            return View(model);
        }

        public void SetViewBagProduct(long? selectedId = null)
        {
            var dao = new ProductDao();
            ViewBag.ProductID = new SelectList(dao.LissAllProduct(), "ID", "Name", selectedId);
        }

        public void SetViewBagCity(long? selectedId = null)
        {
            var dao = new CityDao();
            ViewBag.CityID = new SelectList(dao.LissAllCity(), "ID", "Name", selectedId);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBagProduct();
            SetViewBagCity();
            return View();

        }

        [HttpPost]
        public ActionResult Create(News news)
        {
            if (ModelState.IsValid)
            {
                var dao = new NewsDao();
                news.CreatedDate = DateTime.Now;
                long id = dao.Insert(news);
                if (id > 0)
                {
                    return RedirectToAction("Index", "News");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng tin không thành công");
                }
            }
            SetViewBagProduct();
            SetViewBagCity();
            return View("Create");
        }

        public ActionResult Edit(int id)
        {
            var news = new NewsDao().ViewDetail(id);
            SetViewBagProduct(news.ProductID);
            SetViewBagCity(news.CityID);
            return View(news);
        }


        [HttpPost]
        public ActionResult Edit(News news)
        {
            if (ModelState.IsValid)
            {
                var dao = new NewsDao();
                var result = dao.Update(news);
                if (result)
                {
                    return RedirectToAction("Index", "News");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật tin không thành công");
                }
            }
            SetViewBagProduct(news.ProductID);
            SetViewBagCity(news.CityID);
            return View("Edit");
        }

        public ActionResult Delete(int id)
        {
            var dao = new NewsDao();
            dao.Delete(id);
            return RedirectToAction("Index");
        }

        DoAnASPDBContext db = new DoAnASPDBContext();
    }
}