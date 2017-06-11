using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnRaoVat.Areas.Admin.Controllers
{
    public class CityController : BaseController
    {
        // GET: Admin/City
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new CityDao();
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
        public ActionResult Create(City city )
        {
            if(ModelState.IsValid)
            {
                var dao = new CityDao();
                city.CreatedDate = DateTime.Now;
                long id = dao.Insert(city);
                if(id > 0)
                {
                    return RedirectToAction("Index", "City");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm khu vực không thành công");
                }
            }
            return View("Index");
        }

        public ActionResult Edit(int id)
        {
            var city = new CityDao().ViewDetail(id);
            return View(city);
        }

        [HttpPost]
        public ActionResult Edit(City city)
        {
            if(ModelState.IsValid)
            {
                var dao = new CityDao();
                var result = dao.Update(city);
                if(result)
                {
                    return RedirectToAction("Index", "City");
                }
                else
                {
                    ModelState.AddModelError("","Cập nhật khu vực không thành công");
                }
            }
            return View("Index");
        }

        public ActionResult Delete(int id)
        {
            var dao = new CityDao();
            dao.Delete(id);
            return RedirectToAction("Index");
        }

        DoAnASPDBContext db = new DoAnASPDBContext();

    }
}