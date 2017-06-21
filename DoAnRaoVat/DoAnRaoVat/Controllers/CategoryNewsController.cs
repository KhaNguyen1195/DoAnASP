using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnRaoVat.Controllers
{
    public class CategoryNewsController : Controller
    {
        // GET: CategoryNews
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

       

        [ChildActionOnly]
        public PartialViewResult Category()
        {
            var model = new CategoryDao().LissAll();
            return PartialView(model);
        }

        [ChildActionOnly]
        public PartialViewResult CategoryMenu()
        {
            var model = new CategoryDao().LissAll();
            return PartialView(model);
        }

        public ActionResult Detail(long id)
        {
            var news = new NewsDao().ViewDetail(id);
            ViewBag.Product = new CategoryDao().ViewDetail(news.ProductID.Value);
            return View();
        }
    }
}