using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Almacena la LogicaDePartida mientras esta en curso
    /// </summary>
    public static class PartidaEnJuego
    {
        /// <summary>
        /// 
        /// </summary>
        public static List<LogicaDePartida> partidas;
        /// <summary>f
        /// Agrega una LogicadePartida a la lista.
        /// </summary>
        /// <param name="partida"></param>
        public static void AlmacenarLogicadePartida(LogicaDePartida partida)
        {
            partidas.Add(partida);
        }
        /// <summary>
        /// Elimina una LogicadePartida de la lista.
        /// </summary>
        /// <param name="partida"></param>
        public static void RemoverLogicadePartida(LogicaDePartida partida)
        {
            if (partidas.Contains(partida))
            {
                partidas.Remove(partida);
            }
        }
        public static LogicaDePartida ObtenerLogicadePartida(int numeroDeJugador)
        {
            foreach (LogicaDePartida partida in partidas)
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