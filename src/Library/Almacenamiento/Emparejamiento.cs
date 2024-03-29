using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase empareja a dos jugadores en un int[,] para poder crear una partida.
    /// Hay dos colas de espera existentes existentes en la espera de partida aleatoria, una para el modo normal y otra para el modo rapido.
    /// </summary>
    public class Emparejamiento
    {

        private List<Tuple<long, long>> listaEsperaAmigos = new List<Tuple<long,long>>();

        /// <summary>
        /// Cola de emparejamiento (modo normal)
        /// </summary>
        private Queue<int> ColaEmparejamientosN = new Queue<int>();

        /// <summary>
        /// Cola de emparejamiento (modo rapido)
        /// </summary>
        private Queue<int> ColaEmparejamientosR = new Queue<int>();
        
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
        public string RemoverListaEspera(int usuario)
        {
            string respuesta = "El numero de usuario ingresado no se encuentra esperando una partida";
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
                respuesta = "Removido correctamente";
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
                respuesta = "Removido correctamente";
            }
            return respuesta;
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

        /// <summary>
        /// Añade a los jugadores como tupla a una
        /// lista de espera de confirmacion para partidas amistosas
        /// </summary>
        /// <param name="anfitrion"> jugador que invita </param>
        /// <param name="invitado"> jugador invitado </param>
        public void AnadirAmigosAEspera(long anfitrion, long invitado)
        {
            Tuple<long, long> jugadores = new Tuple<long, long>(anfitrion, invitado);
            this.listaEsperaAmigos.Add(jugadores);
        }

        /// <summary>
        /// Remueve a los jugadores de la
        /// lista de espera de confirmacion para partidas amistosas
        /// </summary>
        /// <param name="anfitrion"> jugador que invita </param>
        /// <param name="invitado"> jugador invitado </param>
        public void RemoverAmigosDeEspera(long anfitrion, long invitado)
        {
            Tuple<long, long> jugadores = new Tuple<long, long>(anfitrion, invitado);
            if (listaEsperaAmigos.Contains(jugadores))
            {
                listaEsperaAmigos.Remove(jugadores);
            }
        }

        /// <summary>
        /// Se fija quien es el rival de un usuario en el contexto de una partida amistosa
        /// </summary>
        /// <param name="invitado"> jugador invitado </param>
        /// <returns> pareja de jugadores (tupla) </returns>
        public Tuple<long, long> VerListaEsperaAmigos(long invitado)
        {
            Tuple<long, long> parejaRetornar = null;
            foreach (Tuple<long, long> pareja in listaEsperaAmigos)
            {
                if (pareja.Item2 == invitado)
                {
                    parejaRetornar = pareja;
                }
            }
            return parejaRetornar;
        }
    }
}
