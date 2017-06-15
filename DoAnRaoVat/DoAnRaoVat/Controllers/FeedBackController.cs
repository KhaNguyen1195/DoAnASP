using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnRaoVat.Controllers
{
    public class FeedBackController : Controller
    {
        // GET: FeedBack
        public ActionResult Index()
        {
            return View();
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
                feedback.Status = true;
                long id = dao.Insert(feedback);
                if (id > 0)
                {
                    ViewBag.Success = "Phản hồi thành công. Cám ơn bạn đã đóng góp ý kiến.";
                    ModelState.Clear();
                }
                else
                {
                    ModelState.AddModelError("", "Phản hồi không thành công");
                }
            }
            return View("Create");
        }
    }
}