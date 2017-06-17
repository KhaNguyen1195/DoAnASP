using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnRaoVat.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            return View();
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
                news.Status = true;
                long id = dao.Insert(news);
                if (id > 0)
                {
                    ViewBag.Success = "Đăng bài thành công.";
                    ModelState.Clear();
                }
                else
                {
                    ModelState.AddModelError("", "Đăng bài không thành công");
                }
            }
            SetViewBagProduct();
            SetViewBagCity();
            return View("Create");
        }

        
    }
}