using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tarjeta.Models;

namespace Tarjeta.Controllers
{
    public class TarjetaController : Controller
    {
        // GET: Tarjeta
        public ActionResult Index()
        {
            return View();
        }

        //Listado de Tarjeta 
        private static List<ModeloTarheta> listaTarjetas = new List<ModeloTarheta>
            {
                new ModeloTarheta { De = "Juan", Para = "María", Monto = 50, Mensaje = "¡Feliz cumpleaños!", LinkLargo = "https://www.ejemplo.com/largo", LinkCorto = "https://www.ejemplo.com/corto" },
                new ModeloTarheta { De = "María", Para = "Pedro", Monto = 100, Mensaje = "¡Feliz Navidad!", LinkLargo = "https://www.ejemplo.com/navidad", LinkCorto = "https://www.ejemplo.com/nav" },
                new ModeloTarheta { De = "Pedro", Para = "Laura", Monto = 25, Mensaje = "¡Felicidades por tu graduación!", LinkLargo = "https://www.ejemplo.com/graduacion", LinkCorto = "https://www.ejemplo.com/grad" },
                new ModeloTarheta { De = "Laura", Para = "Carlos", Monto = 75, Mensaje = "¡Feliz aniversario!", LinkLargo = "https://www.ejemplo.com/aniversario", LinkCorto = "https://www.ejemplo.com/ani" },
                new ModeloTarheta { De = "Carlos", Para = "Ana", Monto = 200, Mensaje = "¡Feliz cumpleaños!", LinkLargo = "https://www.ejemplo.com/cumpleanos", LinkCorto = "https://www.ejemplo.com/cum" }
            };


        [HttpPost]
        public ActionResult Tarjeta(string linkCorto)
        {


            var tarjeta = listaTarjetas.FirstOrDefault(t => t.LinkCorto == linkCorto);
            string url_Corto = linkCorto;



            if (tarjeta != null)
            {
                return View("Tarjeta",tarjeta);
            }
            else
            {
                // Si no se encuentra la tarjeta, retornar una vista de error o redireccionar a otra página
                return View("Error");
            }

        }


    }
}