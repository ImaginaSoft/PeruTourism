﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PeruTourism.Models.Pasajero;
using PeruTourism.Repository.PeruTourism;
using PeruTourism.Models.Visa;
using PeruTourism.Utility;
using PeruTourism.Models.PeruTourism;

namespace PeruTourism.Controllers
{
	public class PasajeroController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}


		public ActionResult Pasajero(string Parametro1)
		{

			return View("Pasajero");

		}


		//[HttpPost]
		//public JsonResult RegistrarPasajero(string NombrePasajero)
		//{

		//	PasajeroAccess objPasajero = new PasajeroAccess();

		//	string gg = objPasajero.InsertarHistorialCliente(pDesLog, pCodCliente, pNroPedido, pNroPropuesta, pNroVersion);

		//	return Json(gg, JsonRequestBehavior.AllowGet);
		//}




	}
}
