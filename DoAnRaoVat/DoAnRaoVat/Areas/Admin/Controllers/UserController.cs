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
        //[HasCredential(RoleID = "VIEW_USER")]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new UserDao();
            var model = dao.LissAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        //[HasCredential(RoleID = "ADD_USER")]
        public ActionResult Create()
        {
            return View();
        }

        //[HasCredential(RoleID = "EDIT_USER")]
        public ActionResult Edit(int id)
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }

        [HttpPost]
        //[HasCredential(RoleID = "ADD_USER")]
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
            return View("Create");
        }

        [HttpPost]
        //[HasCredential(RoleID = "EDIT_USER")]
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
            return View("Edit");
        }

        //[HasCredential(RoleID = "DELETE_USER")]
        public ActionResult Delete(int id)
        {
            var dao = new UserDao();
            dao.Delete(id);
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public JsonResult ChangeStatus(long id)
        //{
        //    var result = new UserDao().ChangeStatus(id);
        //    return Json(new
        //    {
        //        status = result
        //    });
        //}
    }
}