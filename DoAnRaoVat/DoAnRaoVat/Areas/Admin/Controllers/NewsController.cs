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


        public ActionResult Detail(long id)
        {
            var news = new NewsDao().ViewDetail(id);
            ViewBag.Product = new CategoryDao().ViewDetail(news.ProductID.Value);
            return View(news);
        }


    }
}