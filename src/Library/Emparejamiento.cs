using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase empareja a dos jugadores en una lista.
    /// Hay dos colas existentes, una para el modo normal y otra para el modo rapido
    /// </summary>
    public static class Emparejamiento
    {
        /// <summary>
        /// Lista de emparejamiento (modo normal)
        /// </summary>
        public static List<PerfilUsuario> ListaEmparejamientosN;
        //public static Queue<PerfilUsuario> ColaEmparejamientosN;

        /// <summary>
        /// Lista de emparejamiento (modo rapido)
        /// </summary>
        public static List<PerfilUsuario> ListaEmparejamientosR;
        //public static Queue<PerfilUsuario> ColaEmparejamientosR;
        
        /// <summary>
        /// Remueve usuario de lista de emparejamiento
        /// </summary>
        /// <param name="usuario"></param>
        public static void RemoverListaEspera(int usuario)
        {
            foreach (PerfilUsuario perfilUsuario in ListaEmparejamientosN)
            {
                if (perfilUsuario.NumeroDeJugador == usuario)
                {
                    ListaEmparejamientosN.Remove(perfilUsuario);
                    //ListaEmparejamientosN.Dequeue();
                }
            }
            foreach (PerfilUsuario perfilUsuario in ListaEmparejamientosR)
            {
                if (perfilUsuario.NumeroDeJugador == usuario)
                {
                    ListaEmparejamientosR.Remove(perfilUsuario);
                    //ListaEmparejamientosN.Dequeue();
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
                //ListaEmparejamientosN.Add(perfilJugador);
                //ListaEmparejamientosN.Enqueue(perfilJugador);
            }
            if (modo == 1) // modo rapido
            {
                //PerfilUsuario perfilJugador = Admin.ObtenerPerfil(jugador);
                //ListaEmparejamientosR.Add(perfilJugador);
                //ListaEmparejamientosR.Enqueue(perfilJugador);
            }
        }

        /// <summary>
        /// Empareja a dos usuarios especificos
        /// </summary>
        /// <param name="modo"></param>
        /// <param name="jugador1"></param>
        /// <param name="jugador2"></param>
        /// <returns></returns>
        public static PerfilUsuario[] EmparejarAmigos(int modo, int jugador1, int jugador2)
        {
            //PerfilUsuario perfilJugador1 = Admin.ObtenerPerfil(jugador1);
            //PerfilUsuario perfilJugador2 = Admin.ObtenerPerfil(jugador2);
            PerfilUsuario[] listaAmigos = new PerfilUsuario[2];
            if (modo == 0) // modo normal
            {
                //listaAmigos[0] = listaAmigos[perfilJugador1];
                //listaAmigos[1] = listaAmigos[perfilJugador2];
            }
            if (modo == 1) // modo rapido
            {
                //listaAmigos[0] = listaAmigos[perfilJugador1];
                //listaAmigos[1] = listaAmigos[perfilJugador2];
            }
            return listaAmigos;
        }
    }
}