using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;
using DoAnRaoVat.Common;

namespace DoAnRaoVat.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new UserDao();
            var model = dao.LissAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        public void SetViewBag(string selectedId = null)
        {
            var dao = new UserGroupDao();
            ViewBag.UserGroupID = new SelectList(dao.ListAll(), "ID", "Name", selectedId);
        }

        [HttpGet]
        public ActionResult Create()
        {
            //SetViewBag();
            return View();
        }
        

        [HttpPost]
        public ActionResult Create(User user)
        {
            if(ModelState.IsValid)
            {
                var dao = new UserDao();
                user.CreatedDate = DateTime.Now;
                var encrytedMd5Pas = Encryptor.MD5Hash(user.Password);
                user.Password = encrytedMd5Pas;

                long id = dao.Insert(user);
                if (id > 0)
                {
                    //SetAlert("");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("","Thêm người dùng không thành công");
                }
            }
            //SetViewBag();
            return View("Create");
        }
        public ActionResult Edit(int id)
        {
            var user = new UserDao().ViewDetail(id);
            SetViewBag(user.UserGroupID);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (!string.IsNullOrEmpty(user.Password))
                {
                    var encrytedMd5Pas = Encryptor.MD5Hash(user.Password);
                    user.Password = encrytedMd5Pas;
                }
                var result = dao.Update(user);
                if (result)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật người dùng không thành công");
                }
            }
            SetViewBag(user.UserGroupID);
            return View("Edit");
        }
        
        public ActionResult Delete(int id)
        {
            var dao = new UserDao();
            dao.Delete(id);
            return RedirectToAction("Index");
        }


        /*-------------- Thay đổi trạng thái--------------------*/
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new UserDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}