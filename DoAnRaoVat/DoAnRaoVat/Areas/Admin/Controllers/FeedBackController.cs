using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnRaoVat.Areas.Admin.Controllers
{
    public class FeedBackController : BaseController
    {
        // GET: Admin/FeedBack
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new FeedBackDao();
            var model = dao.LissAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FeedBack feedback)
        {
            if (ModelState.IsValid)
            {
                var dao = new FeedBackDao();
                feedback.CreatedDate = DateTime.Now;
                long id = dao.Insert(feedback);
                if (id > 0)
                {
                    return RedirectToAction("Index", "FeedBack");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm khu vực không thành công");
                }
            }
            return View("Create");
        }

        public ActionResult Edit(int id)
        {
            var feedback = new FeedBackDao().ViewDetail(id);
            return View(feedback);
        }

        [HttpPost]
        public ActionResult Edit(FeedBack feedback)
        {
            if (ModelState.IsValid)
            {
                var dao = new FeedBackDao();
                var result = dao.Update(feedback);
                if (result)
                {
                    return RedirectToAction("Index", "FeedBack");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật khu vực không thành công");
                }
            }
            return View("Edit");
        }

        public ActionResult Delete(int id)
        {
            var dao = new FeedBackDao();
            dao.Delete(id);
            return RedirectToAction("Index");
        }

        DoAnASPDBContext db = new DoAnASPDBContext();
    }
}