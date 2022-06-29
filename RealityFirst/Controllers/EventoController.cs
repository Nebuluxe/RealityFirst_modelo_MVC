using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using RealityFirst.Models;
using RealityFirst.Servicio;
using Microsoft.Extensions.Configuration;
 
namespace RealityFirst.Controllers
{
    public class EventoController : Controller
    {
        IConfiguration config;
        EventoServicio evento;
        EntradaServicio entrada;

        public EventoController(IConfiguration config)
        {
            this.config = config;
            string ConnectionString = config.GetConnectionString("DBRealityFirst");
            evento = new EventoServicio(ConnectionString);
            entrada = new EntradaServicio(ConnectionString);

        }

        public IActionResult Eventos(int id)
        {
            IList<EventoModel> lista = evento.DireccionarEventoArtista(id);
            return View("Eventos", lista);
        }

        public IActionResult CompraEntrada(int id)
        {
            EventoModel obj = evento.Get(id);
            return View("CompraEntrada",obj);
        }

        public IActionResult PagoTarjeta(int id)
        {
            EventoModel obj = evento.Get(id);
            return View("PagoTarjeta", obj);
        }

        public IActionResult Ticket(int id)
        {
            EventoModel obj = evento.Get(id);
            return View("Ticket", obj);
        }

        public IActionResult busquedaeventos()
        {
            IList<EventoModel> lista = evento.GetAll();
            return View("busquedaeventos", lista);
        }
    }
}
