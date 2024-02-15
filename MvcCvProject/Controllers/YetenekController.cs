using MvcCvProject.Models.Entity;
using MvcCvProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCvProject.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
        YetenekRepository repo = new YetenekRepository();

        public ActionResult Index()
        {
            var yetenekler = repo.List();

            return View(yetenekler);
        }

        public ActionResult YetenekSil(int id)
        {
            TblYeteneklerim t =repo.Find(x=>x.ID == id);
            
            repo.TDelete(t);

            return RedirectToAction("Index");

        }
    }
}