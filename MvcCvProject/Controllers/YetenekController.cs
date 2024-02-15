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

		[HttpGet]
		public ActionResult YeniYetenek()
		{
			return View();
		}

		[HttpPost]
		public ActionResult YeniYetenek(TblYeteneklerim p)
		{
			repo.TAdd(p);
			return RedirectToAction("Index");
		}

		public ActionResult YetenekSil(int id)
		{
			TblYeteneklerim t = repo.Find(x => x.ID == id);

			repo.TDelete(t);

			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult YetenekDuzenle(int id)
		{
			var t = repo.Find(x => x.ID == id);

			return View(t);
		}

		[HttpPost]
		public ActionResult YetenekDuzenle(TblYeteneklerim t)
		{
			var y =repo.Find(x=>x.ID== t.ID);
			y.Yetenek = t.Yetenek;
			y.Oran = t.Oran;

			repo.TUpdate(y);

			
			return RedirectToAction("Index");
		}




	}
}