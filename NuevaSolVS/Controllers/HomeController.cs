using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NuevaSolVS.Models;

namespace NuevaSolVS.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
        public IActionResult  Tarjeta([FromBody] ModeloTarheta linkCorto)
        {
            string link = linkCorto.LinkCorto;
            var tarjeta = listaTarjetas.FirstOrDefault(t => t.LinkCorto == link);
            return View("Tarjeta", tarjeta);
        }

        [HttpPost]
        public IActionResult GeneracionURL ([FromBody] ModeloTarheta modelo){

            string nombreDe = modelo.De;
    
            var tarjeta = listaTarjetas.FirstOrDefault(t => t.De == nombreDe);
            return new JsonResult(tarjeta.LinkCorto);
            
        }

}
