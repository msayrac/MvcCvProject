using Microsoft.Ajax.Utilities;
using MvcCvProject.Models.Entity;
using MvcCvProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCvProject.Controllers
{
	[Authorize]

	public class iletisimController : Controller
	{
		// GET: iletisim

		GenericRepository<TblIletisim> iletisimRepo = new GenericRepository<TblIletisim>();

		public ActionResult Index()
		{
			var iletisim = iletisimRepo.List();
			return View(iletisim);
		}



	}
}