using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Almacena la Partida mientras esta en curso
    /// </summary>
    public class PartidasEnJuego
    {
        /// <summary>
        /// Lista de partidas en juego
        /// </summary>
        public List<Partida> partidas = new List<Partida>();
        /// <summary>
        /// Parte de singleton. Atributo donde se guarda la instancia de PartidasEnJuego (o null si no fue creada).
        /// </summary>
        static PartidasEnJuego instance;

        /// <summary>
        /// Parte de singleton. Constructor llamado por el metodo Instance de crearse
        /// una instancia de PartidasEnJuego.
        /// </summary>
        private PartidasEnJuego()
        {
        }

        /// <summary>
        /// Singleton de PartidasEnJuego.
        /// Si no existe una instancia de PartidasEnJuego, crea una. Si ya existe la devuelve
        /// </summary>
        /// <returns> Instancia nueva de PartidasEnJuego, o de darse el caso, una previamente creada </returns>
        public static PartidasEnJuego Instance()
        {
            if (instance == null)
            {
                instance = new PartidasEnJuego();
            }
            return instance;
        }
        
        /// <summary>
        /// Agrega una Partida a la lista.
        /// </summary>
        /// <param name="partida"></param>
        public void AlmacenarPartida(Partida partida)
        {
            partidas.Add(partida);
        }
        /// <summary>
        /// Elimina una Partida de la lista.
        /// </summary>
        /// <param name="partida"></param>
        public void RemoverPartida(Partida partida)
        {
            if (partidas.Contains(partida))
            {
                partidas.Remove(partida);
            }
        }
        /// <summary>
        /// Metodo utilizado para obtener la logica de partida,
        /// buscandola externamente en esta clase limitandola 
        /// para que no se pueda acceder a ella desde un 
        /// usuario que no este jugando dicha partida.
        /// </summary>
        /// <param name="numeroDeJugador"></param>
        /// <returns></returns>
        public Partida ObtenerPartida(int numeroDeJugador)
        {
            foreach (Partida partida in partidas)
            {
                if(partida.Jugadores[0] == numeroDeJugador)
                {
                    return partida;
                    
                }
                else if (partida.Jugadores[1] == numeroDeJugador)
                {
                    return partida;
                }
            }
            return null;
        }
        /// <summary>
        /// Metodo creado para poder verificicar si 
        /// un jugador esta en alguna partida en curso.
        /// </summary>
        /// <param name="numeroDeJugador"></param>
        /// <returns></returns>
        public bool EstaElJugadorEnPartida(int numeroDeJugador)
        {
            foreach (Partida partida in partidas)
            {
                if(partida.Jugadores[0] == numeroDeJugador)
                {
                    return true;
                    
                }
                else if (partida.Jugadores[1] == numeroDeJugador)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Metodo creado con el objetivo de obtener el NumeroDeJugador del oponente
        /// de un jugador que consulta.
        /// </summary>
        /// <param name="numeroDeJugador"></param>
        /// <returns></returns>
        public int ObtenerNumOponente (int numeroDeJugador)
        {
            foreach (Partida partida in partidas)
            {
                if(partida.Jugadores[0] == numeroDeJugador)
                {
                    return partida.Jugadores[1];
                    
                }
                else if (partida.Jugadores[1] == numeroDeJugador)
                {
                    return partida.Jugadores[0];
                }
            }
            return 0;
        }
        /// <summary>
        /// Verifica si la partida del jugador esta terminada
        /// </summary>
        /// <param name="numeroDeJugador"> Jugador en partida </param>
        /// <returns> true si la partida esta finalizada y false en caso contrario </returns>
        public bool EstaTerminada(int numeroDeJugador)
        {
            foreach (Partida partida in partidas)
            {
                if(partida.Jugadores[0] == numeroDeJugador)
                {
                    return partida.PartidaTerminada();                  
                }
                else if (partida.Jugadores[1] == numeroDeJugador)
                {
                    return partida.PartidaTerminada();
                }
            }
            return false;
        }
    }
}

