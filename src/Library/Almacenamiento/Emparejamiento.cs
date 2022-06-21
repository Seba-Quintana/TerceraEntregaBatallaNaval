using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase empareja a dos jugadores en una cola.
    /// Hay dos colas existentes, una para el modo normal y otra para el modo rapido.
    /// </summary>
    public class Emparejamiento
    {
        /// <summary>
        /// Cola de emparejamiento (modo normal)
        /// </summary>
        public Queue<int> ColaEmparejamientosN = new Queue<int>();

        /// <summary>
        /// Cola de emparejamiento (modo rapido)
        /// </summary>
        public Queue<int> ColaEmparejamientosR = new Queue<int>();
        
        /// <summary>
        /// Parte de singleton. Atributo donde se guarda la instancia del
        /// Emparejamiento (o null si no fue creada).
        /// </summary>
        private static Emparejamiento instance = null;

        /// <summary>
        /// Parte de singleton. Constructor llamado por el metodo Instance de crearse un Emparejamiento.
        /// </summary>
        private Emparejamiento()
        {
        }

        /// <summary>
        /// Singleton de Emparejamiento. Si no existe una instancia
        /// de Emparejamiento, crea una. Si ya existe la devuelve
        /// </summary>
        /// <returns> Instancia nueva de Emparejamiento,
        /// o de darse el caso, una previamente creada </returns>
        public static Emparejamiento Instance()
        {
            if (instance == null)
            {
                instance = new Emparejamiento();
            }
            return instance;
        }

        /// <summary>
        /// Remueve usuario de cola de emparejamiento
        /// </summary>
        /// <param name="usuario"> usuario a remover </param>
        public void RemoverListaEspera(int usuario)
        {
            if (ColaEmparejamientosN.Contains(usuario))
            {
                int largoCola = ColaEmparejamientosN.Count;
                int i = 0;
                while (i <= largoCola - 1)
                {
                    if (ColaEmparejamientosN.Peek() == usuario)
                        ColaEmparejamientosN.Dequeue();
                    else
                    {
                        ColaEmparejamientosN.Enqueue(ColaEmparejamientosN.Peek());
                        ColaEmparejamientosN.Dequeue();
                    }
                    i++;
                }
            }
            else if (ColaEmparejamientosR.Contains(usuario))
            {
                int largoCola = ColaEmparejamientosR.Count;
                int i = 0;
                while (i <= largoCola - 1)
                {
                    if (ColaEmparejamientosR.Peek() == usuario)
                        ColaEmparejamientosR.Dequeue();
                    else
                    {
                        ColaEmparejamientosR.Enqueue(ColaEmparejamientosR.Peek());
                        ColaEmparejamientosR.Dequeue();
                    }
                    i++;
                }
            }
        }

        /// <summary>
        /// Empareja a dos jugadores, el jugador que busca partida y uno aleatorio (determinado por la cola)
        /// </summary>
        /// <param name="modo"> modo de juego elegido </param>
        /// <param name="jugador"> jugador que busca emparejamiento </param>
        public int[] EmparejarAleatorio(int modo, int jugador)
        {
            try
            {
                if ((modo != 0) && (modo != 1))
                    throw new ModoInvalidoException();
            }
            catch (ModoInvalidoException)
            {
                throw new ModoInvalidoException("Modo invalido", modo);
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
        /// <param name="modo"> modo de juego elegido </param>
        /// <param name="jugador1"> jugador 1 </param>
        /// <param name="jugador2"> jugador 2 </param>
        /// <returns></returns>
        public int[] EmparejarAmigos(int modo, int jugador1, int jugador2)
        {
            try
            {
                if ((modo != 0) && (modo != 1))
                    throw new ModoInvalidoException();
            }
            catch (ModoInvalidoException)
            {
                throw new ModoInvalidoException("Modo invalido", modo);
            }

            int[] Amigos = new int[4];
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
