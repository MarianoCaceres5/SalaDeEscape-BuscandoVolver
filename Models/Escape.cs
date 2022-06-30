using System.Dynamic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;

namespace SalaEscape.Models{

    public static class Escape{

        private static List <string> IncognitasSalas = new List<string>();        
        private static int _estadoJuego = 0;        
        private static int _intentosExtra = 0;
        private static int _errores = 0;
        private static int _pistasExtra = 0;
        private static string _nombreJugador = "";
        private static Timer _reloj;        
        private static int _segundos = 0;    
                 

        private static void InicializarLista(){

            IncognitasSalas.Add("");
            string incognita1 = "dios";
            IncognitasSalas.Add(incognita1);
            string incognita2 = "2001-09-11";
            IncognitasSalas.Add(incognita2);       
            string incognita3 = "azul"; 
            IncognitasSalas.Add(incognita3);
            string incognita4 = "1867"; 
            IncognitasSalas.Add(incognita4);        
        }

        public static int EstadoJuego{
            get{return _estadoJuego;}           
        }

        public static int IntentosExtra{
            get{return _intentosExtra;}
        }

        public static int PistasExtra{
            get{return _pistasExtra;}
        }

        public static string NombreJugador {
            get{return _nombreJugador;}
            set{_nombreJugador = value;}
        }

        public static int Errores{
            get{return _errores;}
        }

        public static Timer Reloj{
            get{return _reloj;}            
        }

        public static int Segundos{
            get{
                return _segundos;
            }
        }

        public static bool ResolverSala(int sala, string incognita){

            if (IncognitasSalas.Count != 5){
                InicializarLista();                
            }

            if(IncognitasSalas[sala]==incognita) {
                _estadoJuego = sala + 1;
                _errores = 0;                
                return true;                    
            }else{

                _intentosExtra = _intentosExtra+1;
                _errores = _errores+1;
                
                if(_errores == 3 || _errores == 4){
                    _pistasExtra++;
                } 

                if(_errores == 5){
                    _segundos += 60*5;
                }

                return false;
            }                                           

        }      

        public static void IniciarDeNuevo(){
            _estadoJuego=1;
        }  

        public static void ReiniciarParametros(){
            _segundos = 0;
            _intentosExtra = 0;
            _errores = 0;
            _pistasExtra = 0;
            _estadoJuego = 0;
        }       

        public static void FinalizarTimer(){
            _reloj.Stop();
            _reloj.Dispose();
            _segundos=3601;
        }

        public static void ComenzarTimer()
        {                   
            _reloj = new Timer(1000);
            // Definimos el evento que se dispara al finalizar cada intervalo de tiempo 
            _reloj.Elapsed += Tick;
            _reloj.AutoReset = true;
            _reloj.Enabled = true;
        }        

        public static void Tick(Object source, ElapsedEventArgs e)
        {
            _segundos++;            
        }   
        


    }
}