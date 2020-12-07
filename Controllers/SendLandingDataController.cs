using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaSigma.Controllers
{
    public class SendLandingDataController : Controller
    {
        
        [HttpPost]
        public ActionResult Index(FormCollection data)
        {
            var state = data["stateField"];
            var city = data["cityField"];
            var name = data["nameField"];
            var email = data["emailField"];
            PruebaSigmaBaseDatos db = new PruebaSigmaBaseDatos();
            var landingDataEntity = db.landing_data;
            landing_data ld = new landing_data();
            ld.Nombre = name;
            ld.Departamento = state;
            ld.Ciudad = city;
            ld.Correo = email;
            landingDataEntity.Add(ld);
            db.SaveChanges();
            
            return View();
        }
    }
}