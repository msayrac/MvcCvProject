using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using MvcCvProject.Models.Entity;
using MvcCvProject.Repositories;

namespace MvcCvProject.Controllers
{
	public class SosyalMedyaController : Controller
	{
		// GET: SosyalMedya
		GenericRepository<TblSosyalMedya> repo = new GenericRepository<TblSosyalMedya>();

		public ActionResult Index()
		{
			var veriler = repo.List();
			return View(veriler);
		}


		[HttpGet]
		public ActionResult Ekle()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Ekle(TblSosyalMedya p)
		{
			repo.TAdd(p);
			return RedirectToAction("Index");
		}


		[HttpGet]
		public ActionResult SosyalMedyaDuzenle(int id)
		{
			TblSosyalMedya t = repo.Find(x => x.ID == id);
			return View(t);
		}

		[HttpPost]
		public ActionResult SosyalMedyaDuzenle(TblSosyalMedya p)
		{
			TblSosyalMedya t = repo.Find(x => x.ID == p.ID);

			t.Ad = p.Ad;
			t.Link = p.Link;
			t.ikon = p.ikon;
			
			repo.TUpdate(t);

			return RedirectToAction("Index");
		}

		public ActionResult AktifPasifYap(int id)
		{

			var hesap = repo.Find(x=>x.ID == id);

			if(hesap.Durum==true)
			{
				hesap.Durum = false;
			}
			else
			{
				hesap.Durum = true;
			}
			
			repo.TUpdate(hesap);

			return RedirectToAction("Index");

		}







	}
}