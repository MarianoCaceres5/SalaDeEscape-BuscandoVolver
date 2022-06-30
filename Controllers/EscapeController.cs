using System.Threading;
using System.Transactions;
using System.IO;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Data.SqlTypes;
using System.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalaEscape.Models;
using System.Timers;

namespace SalaEscape.Controllers
{
    public class EscapeController : Controller
    {
        public IActionResult Index()
        {            
            Escape.ReiniciarParametros();
            return View();            
        }

        public IActionResult Comenzar(string nombre)
        {            
            Escape.ReiniciarParametros();        
            Escape.ComenzarTimer();                        
            Escape.NombreJugador = nombre;            
            Escape.IniciarDeNuevo();
            ViewBag.Sala = 1;            
            return View("Habitacion1");
        }

        [HttpPost] public IActionResult Habitacion(int sala, string clave){

            if(Escape.Segundos >= 3600){
                Escape.IniciarDeNuevo(); 
                return View("Derrota"); 
            }
                                     
            if(Escape.ResolverSala(sala, clave.ToLower())){
                if(sala == 4){    
                    ViewBag.Segundos = Escape.Segundos;    
                    Escape.FinalizarTimer();                           
                    Escape.IniciarDeNuevo();         
                    ViewBag.IntentosExtra = Escape.IntentosExtra;
                    ViewBag.PistasExtra = Escape.PistasExtra;                         
                    return View("Victoria");
                }else{       
                    ViewBag.Sala = Escape.EstadoJuego;                    
                    return View($"Habitacion{Escape.EstadoJuego}"); 
                }
            }else{                 
                ViewBag.Sala = Escape.EstadoJuego;
                bool error = true;
                ViewBag.Error = error;                            
                return View($"Habitacion{Escape.EstadoJuego}"); 
            }                          
        }
    }
}