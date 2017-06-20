﻿using DoAnRaoVat.Models;
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
    public class NewsController : BaseController
    {
        // GET: News
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
        public ActionResult Create(News news, HttpPostedFileBase[] files)
        {
            if (ModelState.IsValid)
            {

                string imageUrl = "";
                string image = "";
                foreach (HttpPostedFileBase file in files)
                {

                    if (file != null)
                    {
                        try
                        {
                            image += imageUrl + ";";
                            imageUrl = Path.GetFileName(file.FileName);
                            string path = Path.Combine(Server.MapPath("~/App_Data/Uploads"), imageUrl);
                            file.SaveAs(path);
                            ViewBag.Message = files.Count().ToString() + " Tệp tải thành công!!";
                        }
                        catch (Exception ex)
                        {
                            ViewBag.Message = "ERROR:" + ex.Message.ToString();
                        }
                    }
                        
                    else
                    {
                        ViewBag.Message = "Bạn chưa chỉ định tệp.";
                    }
                }


                var dao = new NewsDao();
                news.CreatedDate = DateTime.Now;
                news.Status = true;
                news.Image = image;
                long id = dao.Insert(news);
                if (id > 0)
                {
                    ViewBag.Success = "Đăng bài thành công.";
                    ModelState.Clear();
                }
                else
                {
                    ModelState.AddModelError("", "Đăng bài không thành công!!");
                }

            }
            SetViewBagProduct();
            SetViewBagCity();
            return View("Create");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var news = new NewsDao().ViewDetail(id);
            SetViewBagProduct(news.ProductID);
            SetViewBagCity(news.CityID);
            return View();
        }

        [HttpPost]
        public ActionResult Edit(News news)
        {
            if (ModelState.IsValid)
            {

                var dao = new NewsDao();
                news.ModifiedDate = DateTime.Now;
                var result = dao.Update(news);
                if (result)
                {
                    return RedirectToAction("Index", "News");
                }
                else
                {
                    ModelState.AddModelError("", "Chỉnh sửa bài đăng không thành công");
                }
            }
            SetViewBagProduct(news.ProductID);
            SetViewBagCity(news.CityID);
            return View("Edit");
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