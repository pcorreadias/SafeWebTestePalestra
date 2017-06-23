using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PalestrasSafeWeb.Models;
namespace PalestrasSafeWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ListaPalestras()
        {
            List<Palestras> listaPalestras;
            using (var db = new DatabaseEntities())
            {
                listaPalestras = db.Palestras.ToList();
            }

            return View(listaPalestras);
        }

        public ActionResult CriaPalestra()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitPalestra(Palestras palestra)
        {
            if(ModelState.IsValid)
            {
                using (var db = new DatabaseEntities())
                {
                    db.Palestras.Add(palestra);
                    db.SaveChanges();
                }

                return RedirectToAction("ListaPalestras");
            }
            else
                return View();
        }

        public ActionResult Agenda()
        {
            return View();
        }

        public ActionResult ListaAgenda()
        {
            List<Palestras> listaPalestras;
            using (var db = new DatabaseEntities())
            {
                listaPalestras = db.Palestras.ToList();
            }

            return PartialView("~/Views/Home/_ListaAgenda.cshtml", listaPalestras);
        }

        public ActionResult MontaAgenda()
        {
            MontarAgendaPalestras();
            return View("Agenda");
        }

        private void MontarAgendaPalestras()
        {
            List<Palestras> listaPalestras;
            List<Palestras> listaPalestras60 = new List<Palestras>();
            List<Palestras> listaPalestras45 = new List<Palestras>();
            List<Palestras> listaPalestras30 = new List<Palestras>();
            List<Palestras> listaPalestras5 = new List<Palestras>();
            int totalMinutosManha = 180;
            int totalMinutosTarde = 180;

            //using (var db = new DatabaseEntities())
            //{
            //    listaPalestras = db.Palestras.ToList();

            //    foreach(Palestras palestra in listaPalestras)
            //    {
            //        if (palestra.Duracao == 60)
            //            listaPalestras60.Add(palestra);
            //        else if (palestra.Duracao == 45)
            //            listaPalestras45.Add(palestra);
            //        else if (palestra.Duracao == 30)
            //            listaPalestras30.Add(palestra);
            //        else if (palestra.Duracao == 5)
            //            listaPalestras30.Add(palestra);
            //    }

            //    foreach(Palestras palestra60 in listaPalestras60)
            //    {
            //        if(totalMinutosManha > palestra60.Duracao)

            //    }

            //}
        }
    }
}