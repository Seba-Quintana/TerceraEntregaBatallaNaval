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
        public static Queue<int> ColaEmparejamientosN;

        /// <summary>
        /// Lista de emparejamiento (modo rapido)
        /// </summary>
        public static Queue<int> ColaEmparejamientosR;
        
        /// <summary>
        /// Remueve usuario de lista de emparejamiento
        /// </summary>
        /// <param name="usuario"></param>
        public static void RemoverListaEspera(int usuario)
        {/*
            PerfilUsuario jugador = Admin.ObtenerPerfil(usuario);
            PerfilUsuario jugador = Admin.ObtenerPerfil(usuario);
            List<PerfilUsuario> colaCopia = new List<PerfilUsuario>();
            if (ColaEmparejamientosN.Contains(jugador))
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
            }
            else if (ColaEmparejamientosR.Contains(jugador))
            {
                int largoCola = ColaEmparejamientosR.Count;
                int i = 0;
                while (i != largoCola)
                {
                    colaCopia.Add(ColaEmparejamientosR.Peek());
                    if (ColaEmparejamientosR.Peek() == jugador)
                        colaCopia.Remove(jugador);
                    ColaEmparejamientosR.Dequeue();
                    i++;
                }
                i = 0;
                while (i != largoCola - 1)
                {
                    ColaEmparejamientosR.Enqueue(colaCopia[i]);
                    i++;
                }
            }
        */
            try
            {
                if (!ColaEmparejamientosN.Contains(usuario))
                    if (!ColaEmparejamientosR.Contains(usuario))
                        throw new ArgumentOutOfRangeException();
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new JugadorNoEncontradoException
                ("El jugador no se encuentra esperando partida", usuario);
            }
            try
            {    
                if (ColaEmparejamientosN.Contains(usuario))
                {
                    int largoCola = ColaEmparejamientosN.Count;
                    int i = 0;
                    while (i < largoCola - 1)
                    {
                        if (ColaEmparejamientosN.Peek() == usuario)
                            ColaEmparejamientosN.Dequeue();
                        else
                        {
                            ColaEmparejamientosN.Enqueue(ColaEmparejamientosN.Peek());
                            ColaEmparejamientosN.Dequeue();
                            i++;
                        }
                    }
                }
                else if (ColaEmparejamientosR.Contains(usuario))
                {
                    int largoCola = ColaEmparejamientosR.Count;
                    int i = 0;
                    while (i < largoCola - 1)
                    {
                        if (ColaEmparejamientosR.Peek() == usuario)
                            ColaEmparejamientosR.Dequeue();
                        else
                        {
                            ColaEmparejamientosR.Enqueue(ColaEmparejamientosR.Peek());
                            ColaEmparejamientosR.Dequeue();
                            i++;
                        }
                    }
                }
            }
            catch(ArgumentException ExCola)
            {
                throw new ArgumentException("Excepcion por argumento (cola)", ExCola);
            }
        }

        /// <summary>
        /// Empareja a dos jugadores, el que busca partida y uno aleatorio (determinado por la cola)
        /// </summary>
        /// <param name="modo"> modo de juego elegido </param>
        /// <param name="jugador"> jugador a emparejar </param>
        public static int[] EmparejarAleatorio(int modo, int jugador)
        {
            try
            {
                if (modo != 0)
                    if (modo != 1)
                        throw new ArgumentException();
            }
            catch (ArgumentException ExModo)
            {
                throw new ArgumentException("Excepcion por argumento (modo)", ExModo);
            }
            if (modo == 0) // modo normal
            {
                ColaEmparejamientosN.Enqueue(jugador);
                if (ColaEmparejamientosN.Count >= 2)
                {
                    int[] jugadores = new int[2];
                    int uno = ColaEmparejamientosN.Peek();
                    ColaEmparejamientosN.Dequeue();
                    jugadores[0] = uno;
                    jugadores[1] = ColaEmparejamientosN.Peek();
                    ColaEmparejamientosN.Dequeue();
                    return jugadores;
                }
            }
            else if (modo == 1) // modo rapido
            {
                ColaEmparejamientosR.Enqueue(jugador);
                if (ColaEmparejamientosR.Count >= 2)
                {
                    int[] jugadores = new int[2];
                    int uno = ColaEmparejamientosR.Peek();
                    ColaEmparejamientosR.Dequeue();
                    jugadores[0] = uno;
                    jugadores[1] = ColaEmparejamientosR.Peek();
                    ColaEmparejamientosR.Dequeue();
                    return jugadores;
                }
            }
            return null;
        }

        /// <summary>
        /// Empareja a dos usuarios especificos
        /// </summary>
        /// <param name="modo"></param>
        /// <param name="jugador1"></param>
        /// <param name="jugador2"></param>
        /// <returns></returns>
        public static int[] EmparejarAmigos(int modo, int jugador1, int jugador2)
        {
            int[] Amigos = new int[2];
            // Como se diferencian los modos?
            if (modo == 0) // modo normal
            {
                Amigos[0] = jugador1;
                Amigos[1] = jugador2;
            }
            else if (modo == 1) // modo rapido
            {
                Amigos[0] = jugador1;
                Amigos[1] = jugador2;
            }
            return Amigos;
        }
    }
}
