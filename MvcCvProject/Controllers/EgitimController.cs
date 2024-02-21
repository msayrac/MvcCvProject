﻿using MvcCvProject.Models.Entity;
using MvcCvProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCvProject.Controllers
{
	public class EgitimController : Controller
	{
		// GET: Egitim

		EgitimRepository repo = new EgitimRepository();

		public ActionResult Index()
		{

			var egitimler = repo.List();
			return View(egitimler);
		}

		[HttpGet]
		public ActionResult EgitimEkle()
		{
			return View();
		}

		[HttpPost]
		public ActionResult EgitimEkle(TblEgitimlerim p)
		{
			if (!ModelState.IsValid)
			{
				return View("EgitimEkle");
			}
			repo.TAdd(p);
			return RedirectToAction("Index");
		}

		public ActionResult EgitimSil(int id)
		{
			TblEgitimlerim t = repo.Find(x => x.Id == id);
			repo.TDelete(t);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult EgitimGetir(int id)
		{
			TblEgitimlerim t = repo.Find(x=>x.Id== id);

			return View(t);
		}

		[HttpPost]
		public ActionResult EgitimGetir(TblEgitimlerim p)
		{
			TblEgitimlerim t =repo.Find(x=>x.Id == p.Id);

			t.Baslik = p.Baslik;
			t.AltBaslik1 = p.AltBaslik1;
			t.AltBaslik2 = p.AltBaslik2;
			t.GNO = p.GNO;
			t.Tarih = p.Tarih;

			repo.TUpdate(t);

			return RedirectToAction("Index");
		}















	}
}