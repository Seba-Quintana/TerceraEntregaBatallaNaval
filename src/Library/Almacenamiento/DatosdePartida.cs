using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Clase encargada de almacenar los datos referentes al acabar una partida.
    /// </summary>
    public class DatosdePartida
    {
        /// <summary>
        /// Constructor
        /// </summary>
        [JsonConstructor]
        public DatosdePartida(){}

        /// <summary>
        /// Lugar donde se almacenan los tableros.
        /// </summary>
        public Tablero[] Tableros;

        /// <summary>
        /// Tamaño de las matrices de la partida
        /// </summary>
        [JsonInclude]
        public int Tamano;

        /// <summary>
        /// Lugar donde se almacenan los jugadores.
        /// </summary>
        [JsonInclude]
        public int[] Jugadores;
        
        /// <summary>
        /// Representa el numero de Tiradas que hubo en la partida.
        /// </summary>
        [JsonInclude]
        public int[] Tiradas;
        /// <summary>
        /// Cantidad de tiradas al agua.
        /// </summary>
        public int AtaquesAlAgua;
        /// <summary>
        /// Cantidad de tiradas a barco.
        /// </summary>
        public int AtaquesABarco;

        /// <summary>
        /// El int es el número de jugador del perfil de usuario perteneciente al ganador.
        /// </summary>
        [JsonInclude]
        public int Ganador;

        /// <summary>
        /// El int es el número de jugador del perfil de usuario perteneciente al perdedor.
        /// </summary>
        [JsonInclude]
        public int Perdedor;
        
        /// <summary>
        /// Metodo encargado de almacenar los datos.
        /// </summary>
        /// <param name="tablerosParaAgregar"></param>
        /// <param name="jugadas"> la cantidad de tiradas que cada jugador hizo </param>
        /// <param name="TiradasABarco"> la cantidad de ataques a barcos durante el juego </param>
        /// <param name="TiradasAlAgua"> la cantidad de ataques al agua durante el juego </param>
        public DatosdePartida(Tablero[] tablerosParaAgregar, int[] jugadas, int TiradasABarco, int TiradasAlAgua)
        {
            almacenarTableros(tablerosParaAgregar);
            almacenarJugador(tablerosParaAgregar[0].DuenodelTablero);
            almacenarJugador(tablerosParaAgregar[1].DuenodelTablero);
            Jugadores = new int[2];     
            Jugadores[0] = tablerosParaAgregar[0].DuenodelTablero;
            Jugadores[1] = tablerosParaAgregar[1].DuenodelTablero;
            Tiradas = jugadas;
            AtaquesABarco = TiradasABarco;
            AtaquesAlAgua = TiradasAlAgua;
            Tamano = tablerosParaAgregar[0].Tamano;

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
            if (Tableros == null)
            {
                Tableros = new Tablero[2];   
            }
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
