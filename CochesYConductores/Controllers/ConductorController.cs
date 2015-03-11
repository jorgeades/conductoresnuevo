using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CochesYConductores.Models;

namespace CochesYConductores.Controllers
{
    public class ConductorController : Controller
    {

        public VehiculosEntities1 db = new VehiculosEntities1();
        
        
        // GET: Conductor
        public ActionResult ConductoresIndex()
        {
            return View(db.Conductor.ToList());
        }
    }
}