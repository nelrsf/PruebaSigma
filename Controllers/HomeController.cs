using Newtonsoft.Json;
using PruebaSigma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PruebaSigma.Controllers
{
    public class HomeController : Controller
    {
        private string apiUrl = "https://sigma-studios.s3-us-west-2.amazonaws.com/test/colombia.json";
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public async Task<ActionResult> Landing()

        {
            var httpClient = new HttpClient();
            var jsonColombia = await httpClient.GetStringAsync(apiUrl);
            var cities = JsonConvert.DeserializeObject<Root>(jsonColombia);
            Type _departamentos = cities.GetType();
            System.Reflection.PropertyInfo[] departamentos= _departamentos.GetProperties();
            List<string> nomDepartamentos = new List<string>();
            foreach(var dep in departamentos)
            {
                nomDepartamentos.Add(dep.Name);
            }
            Country colombiaModel = new Country("Colombia", cities, nomDepartamentos);
           
            return View(colombiaModel);
        }
    }
}
