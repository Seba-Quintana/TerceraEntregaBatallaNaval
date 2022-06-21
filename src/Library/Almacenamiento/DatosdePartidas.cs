using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Clase encargada de almacenar los datos referentes al acabar una partida.
    /// </summary>
    public class DatosdePartida
    {
        /// <summary>
        /// Lugar donde se almacenan los tableros.
        /// </summary>
        public Tablero[] Tableros = new Tablero[2];
        /// <summary>
        /// Lugar donde se almacenan los jugadores.
        /// </summary>
        public int[] Jugadores;
        /// <summary>
        /// Representa el numero de Tiradas que hubo en la partida.
        /// </summary>
        public int[] Tiradas;
        /// <summary>
        /// El int es el número de jugador del perfil de usuario perteneciente al ganador.
        /// </summary>
        public int Ganador;
        /// <summary>
        /// El int es el número de jugador del perfil de usuario perteneciente al perdedor.
        /// </summary>
        public int Perdedor;
        /// <summary>
        /// Metodo encargado de almacenar los datos.
        /// </summary>
        /// <param name="tablerosParaAgregar"></param>
        /// <param name="jugadas"></param>
        public void Almacenar(Tablero[] tablerosParaAgregar, int[] jugadas)
        {
            almacenarTableros(tablerosParaAgregar);
            almacenarJugador(tablerosParaAgregar[0].DueñodelTablero);
            almacenarJugador(tablerosParaAgregar[1].DueñodelTablero);
            Jugadores[0] = tablerosParaAgregar[0].DueñodelTablero;
            Jugadores[1] = tablerosParaAgregar[1].DueñodelTablero;
            Tiradas = jugadas;

            if (tablerosParaAgregar[0].Ganada)
            {
                Ganador = Jugadores[0];
                Perdedor = Jugadores[1];
            }
            else
            {
                Ganador = Jugadores[1];
                Perdedor = Jugadores[0];
            }
            Historial historial = Historial.Instance();
            historial.AlmacenarPartida(this);
        }
        /// <summary>
        /// Metodo encargado de almacenar un tablero
        /// </summary>
        /// <param name="tablerosParaAgregar"></param>
        private void almacenarTableros(Tablero[] tablerosParaAgregar)
        {
            Tableros = tablerosParaAgregar;

        }
        /// <summary>
        /// Metodo encargado de almacenar un jugador
        /// </summary>
        /// <param name="jugador"></param>
        private void almacenarJugador(int jugador)
        {
            if (Jugadores == null)
            {
                Jugadores = new int[2];
                Jugadores[0] = jugador;
            }
            else
            {
                Jugadores[1] = jugador;
            }
        }
    }
}
