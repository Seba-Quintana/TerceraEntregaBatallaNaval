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
        /// <summary>
        /// Agrega una LogicadePartida a la lista.
        /// </summary>
        /// <param name="partida"></param>
        public static void AlmacenarLogicadePartida(LogicaDePartida partida)
        {
        partidas.Add(partida);
        }
        /// <summary>
        /// Elimina una LogicadePartida de la lista si ya ha terminado.
        /// </summary>
        /// <param name="partida"></param>
        public static void RemoverLogicadePartida(LogicaDePartida partida)
        {
            //if()
        }
    }
}