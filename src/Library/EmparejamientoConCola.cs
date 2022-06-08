using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase empareja a dos jugadores en una lista.
    /// Hay dos colas existentes, una para el modo normal y otra para el modo rapido
    /// </summary>
    public static class EmparejamientoConCola
    {
        /// <summary>
        /// Lista de emparejamiento (modo normal)
        /// </summary>
        public static Queue<PerfilUsuario> ColaEmparejamientosN;

        /// <summary>
        /// Lista de emparejamiento (modo rapido)
        /// </summary>
        public static Queue<PerfilUsuario> ColaEmparejamientosR;
        
        /// <summary>
        /// Remueve usuario de lista de emparejamiento
        /// </summary>
        /// <param name="usuario"></param>
        public static void RemoverListaEspera(int usuario)
        {
            //PerfilUsuario jugador = Admin.ObtenerPerfil(usuario);
            List<PerfilUsuario> colaCopia = new List<PerfilUsuario>();
            /*if (ColaEmparejamientosN.Contains(jugador))
            {
                int largoCola = ColaEmparejamientosN.Count;
                int i = 0;
                while (i != largoCola)
                {
                    colaCopia.Add(ColaEmparejamientosN.Peek());
                    if (ColaEmparejamientosN.Peek() == jugador)
                        colaCopia.Remove(jugador);
                    ColaEmparejamientosN.Dequeue();
                    i++;
                }
                i = 0;
                while (i != largoCola - 1)
                {
                    ColaEmparejamientosN.Enqueue(colaCopia[i]);
                    i++;
                }
            }*/
            //else if (ColaEmparejamientosR.Contains(jugador))
            {
                int largoCola = ColaEmparejamientosR.Count;
                int i = 0;
                while (i != largoCola)
                {
                    /*colaCopia.Add(ColaEmparejamientosR.Peek());
                    if (ColaEmparejamientosR.Peek() == jugador)
                        colaCopia.Remove(jugador);
                    ColaEmparejamientosR.Dequeue();
                    i++;*/
                }
                i = 0;
                while (i != largoCola - 1)
                {
                    ColaEmparejamientosR.Enqueue(colaCopia[i]);
                    i++;
                }
            }






        }

        /// <summary>
        /// Empareja a dos jugadores
        /// </summary>
        /// <param name="modo"></param>
        /// <param name="jugador"></param>
        public static void EmparejarAleatorio(int modo, int jugador)
        {
            if (modo == 0) // modo normal
            {
                //PerfilUsuario perfilJugador = Admin.ObtenerPerfil(jugador);
                //ColaEmparejamientosN.Enqueue(perfilJugador);
            }
            if (modo == 1) // modo rapido
            {
                //PerfilUsuario perfilJugador = Admin.ObtenerPerfil(jugador);
                //ColaEmparejamientosR.Enqueue(perfilJugador);
            }
        }

        /// <summary>
        /// Empareja a dos usuarios especificos
        /// </summary>
        /// <param name="modo"></param>
        /// <param name="jugador1"></param>
        /// <param name="jugador2"></param>
        /// <returns></returns>
        public static Queue<PerfilUsuario> EmparejarAmigos(int modo, int jugador1, int jugador2)
        {
            Queue<PerfilUsuario> colaAmigos = new Queue<PerfilUsuario>();
            //PerfilUsuario perfilJugador1 = Admin.ObtenerPerfil(jugador1);
            //PerfilUsuario perfilJugador2 = Admin.ObtenerPerfil(jugador2);
            // Como se diferencian los modos?
            if (modo == 0) // modo normal
            {
                //colaAmigos.Enqueue(perfilJugador1);
                //colaAmigos.Enqueue(perfilJugador2);
            }
            else if (modo == 1) // modo rapido
            {
                //colaAmigos.Enqueue(perfilJugador1);
                //colaAmigos.Enqueue(perfilJugador2);
            }
            return colaAmigos;
        }
    }
}
