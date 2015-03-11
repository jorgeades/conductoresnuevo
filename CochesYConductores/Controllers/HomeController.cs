using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CochesYConductores.Models;

namespace CochesYConductores.Controllers
{
    public class HomeController : Controller
    {

        public VehiculosEntities1 db = new VehiculosEntities1();


        // GET: Home
        public ActionResult Index()
        {
            return View(db.Vehiculo.ToList());


        }

        public ActionResult Alta()
        {
            ViewBag.idConductores = new MultiSelectList(db.Conductor, "idConductor", "nombre");
            return View(new Vehiculo());
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Alta(Vehiculo model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new VehiculosEntities1())
                {
                    db.Vehiculo.Add(model);

                    foreach (var idC in model.idConductores)
                    {
                        var c = db.Conductor.Find(idC);
                        model.Conductor.Add(c);

                    }

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(model);

        }

        public ActionResult DetallesConductor(int id)
        {
            var c = db.Conductor.Find(id);
            return View(c);

        }


        public ActionResult Modificar(int id)
        {
            var veh = db.Vehiculo.Find(id);
            ViewBag.idConductores = new MultiSelectList(db.Conductor, "idConductor", "nombre");

            return View(veh);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Modificar(Vehiculo model)
        {
            if (ModelState.IsValid)
            {

                var m = db.Vehiculo.Find(model.id);
                m.marca = model.marca;
                m.modelo = model.modelo;
                foreach (var idC in model.idConductores)
                {
                    var c = db.Conductor.Find(idC);
                    model.Conductor.Add(c);

                }

                db.SaveChanges();

                return RedirectToAction("Index");

               

            }
          

            return View(model);

        }



    }
}