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
                if(partida.jugadores[0] == numeroDeJugador)
                {
                    return partida;
                    
                }
                else if (partida.jugadores[1] == numeroDeJugador)
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
                if(partida.jugadores[0] == numeroDeJugador)
                {
                    return true;
                    
                }
                else if (partida.jugadores[1] == numeroDeJugador)
                {
                    return true;
                }
            }
            return false;
        }
    }
}