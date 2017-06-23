using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnRaoVat.Areas.Admin.Controllers
{
    public class NewsController : BaseController
    {
        // GET: Admin/News
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new NewsDao();
            var model = dao.LissAllPaging(searchString, page, pageSize);
            ViewBag.searchString = searchString;
            return View(model);
        }


        public ActionResult Detail(long id)
        {
            var news = new NewsDao().ViewDetail(id);
            ViewBag.Product = new CategoryDao().ViewDetail(news.ProductID.Value);
            return View(news);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var news = new NewsDao().ViewDetail(id);
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
                    ModelState.AddModelError("", "Cập nhật danh mục không thành công");
                }
            }
            return View("Edit");
        }

        /*-------------- Thay đổi trạng thái--------------------*/
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new NewsDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}