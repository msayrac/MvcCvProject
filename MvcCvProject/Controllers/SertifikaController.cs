using MvcCvProject.Models.Entity;
using MvcCvProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCvProject.Controllers
{
	public class SertifikaController : Controller
	{
		// GET: Sertifika

		SertifikaRepository repo = new SertifikaRepository();
		public ActionResult Index()
		{
			var sertifikalar = repo.List();

			return View(sertifikalar);
		}

		[HttpGet]
		public ActionResult SertifikaEkle()
		{

			return View();
		}

		[HttpPost]
		public ActionResult SertifikaEkle(Sertifikalarim s)
		{
			repo.TAdd(s);

			return RedirectToAction("Index");
		}

		public ActionResult SertifikaSil(int id)
		{
			Sertifikalarim s = repo.Find(x => x.ID == id);
			repo.TDelete(s);
			return RedirectToAction("Index");
		}


		[HttpGet]
		public ActionResult SertifikaDuzenle(int id)
		{
			
			Sertifikalarim s = repo.Find(x => x.ID == id);
			return View(s);
		}

		[HttpPost]
		public ActionResult SertifikaDuzenle(Sertifikalarim sertifika)
		{
			Sertifikalarim s = repo.Find(x => x.ID == sertifika.ID);
			s.Tarih = sertifika.Tarih;
			s.Aciklama = sertifika.Aciklama;

			repo.TUpdate(s);

			return RedirectToAction("Index");
		}

	}
}