using System;

namespace ClassLibrary
{
    /// <summary>
    /// Clase encargada de almacenar los datos referentes al acabar una partida
    /// </summary>
    public class DatosdePartida
    {
        /// <summary>
        /// Lugar donde se almacenan los tableros.
        /// </summary>
        public Tablero[] Tableros;
        /// <summary>
        /// Lugar donde se almacenan los jugadores.
        /// </summary>
        public int[] Jugadores;
        /// <summary>
        /// El int es el número de jugador del perfil de usuario perteneciente al ganador.
        /// </summary>
        public int Ganador=0;
        /// <summary>
        /// El int es el número de jugador del perfil de usuario perteneciente al perdedor.
        /// </summary>
        public int Perdedor=0;
        /// <summary>
        /// Metodo encargado de almacenar los datos.
        /// </summary>
        /// <param name="tableroParaAgregar"></param>
        public void Almacenar(Tablero tableroParaAgregar)
        {
            almacenarTableros(tableroParaAgregar);
            almacenarJugador(tableroParaAgregar.DueñodelTablero);
            if (tableroParaAgregar.Ganador)
            {
                Ganador = tableroParaAgregar.DueñodelTablero;
            }
            else if (!tableroParaAgregar.Ganador)
            {
                Perdedor = tableroParaAgregar.DueñodelTablero;
            }
            if (Ganador!=0 && Perdedor!=0)
            {
                //Historial.AlmacenarPartida(this);
            }
        }
        /// <summary>
        /// Metodo encargado de almacenar un tablero
        /// </summary>
        /// <param name="tableroParaAgregar"></param>
        private void almacenarTableros(Tablero tableroParaAgregar)
        {
            if (Tableros == null)
            {
                Tableros = new Tablero[2];
                Tableros[0] = tableroParaAgregar;
            }
            else
            {
                Tableros[1] = tableroParaAgregar;
            }
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
