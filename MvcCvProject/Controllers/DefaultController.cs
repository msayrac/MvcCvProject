using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvProject.Models.Entity;

namespace MvcCvProject.Controllers
{
	[AllowAnonymous]
	public class DefaultController : Controller
	{
		// GET: Default

		DbCvEntities db = new DbCvEntities();
		public ActionResult Index()
		{

			var degerler = db.TblHakkimda.ToList();

			return View(degerler);
		}


		public PartialViewResult SosyalMedya()
		{

			var sosyalMedya = db.TblSosyalMedya.Where(x => x.Durum == true).ToList();

			return PartialView(sosyalMedya);
		}


		public PartialViewResult Deneyim()
		{

			var deneyimler = db.TblDeneyimlerim.ToList();

			return PartialView(deneyimler);
		}

		public PartialViewResult Egitimler()
		{
			var egitimler = db.TblEgitimlerim.ToList();
			return PartialView(egitimler);
		}

		public PartialViewResult Yeteneklerim()
		{
			var yetenekler = db.TblYeteneklerim.ToList();

			return PartialView(yetenekler);
		}

		public PartialViewResult Hobilerim()
		{
			var hobilerim = db.TblHobilerim.ToList();

			return PartialView(hobilerim);
		}

		public PartialViewResult Sertifikalarim()
		{
			var sertifika = db.Sertifikalarim.ToList();

			return PartialView(sertifika);
		}

		[HttpGet]
		public PartialViewResult Iletisim()
		{
			var iletisim = db.TblIletisim.ToList();

			return PartialView(iletisim);
		}

		[HttpPost]
		public PartialViewResult Iletisim(TblIletisim t)
		{

			t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());

			db.TblIletisim.Add(t);

			db.SaveChanges();

			return PartialView();
		}






	}
}