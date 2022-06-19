using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Almacena la Partida mientras esta en curso
    /// </summary>
    public static class PartidasEnJuego
    {
        /// <summary>
        /// 
        /// </summary>
        public static List<Partida> partidas = new List<Partida>();
        /// <summary>f
        /// Agrega una Partida a la lista.
        /// </summary>
        /// <param name="partida"></param>
        public static void AlmacenarPartida(Partida partida)
        {
            partidas.Add(partida);
        }
        /// <summary>
        /// Elimina una Partida de la lista.
        /// </summary>
        /// <param name="partida"></param>
        public static void RemoverPartida(Partida partida)
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
        public static Partida ObtenerPartida(int numeroDeJugador)
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
    }
}