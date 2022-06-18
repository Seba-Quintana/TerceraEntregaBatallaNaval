using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase almacena el perfil de un usuario.
    /// Implementa la interfaz ICloneable para poder crear una copia superficial de un perfil. 
    /// </summary>
    public class PerfilUsuario:ICloneable
    {
        /// <summary>
        /// Nombre del jugador
        /// </summary>
        public string Nombre;

        /// <summary>
        /// Identificación del jugador otorgada por el bot
        /// </summary>
        private int ID;

        /// <summary>
        /// Contraseña del usuario
        /// </summary>
        public string Contraseña;

        /// <summary>
        /// Identificación númerica del jugador
        /// </summary>
        public int NumeroDeJugador;

        /// <summary>
        /// Cantidad de partidas ganadas
        /// </summary>
        public int Ganadas = 0;

        /// <summary>
        /// Cantidad de partidas perdidas
        /// </summary>
        public int Perdidas = 0;
      
        /// <summary>
        /// historial del usuario en concreto
        /// </summary>
        public List<DatosdePartida> HistorialPersonal;

        /// <summary>
        /// Metodo de la interfaz ICloneable para crear un clon
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// Constructor del perfil de usuario.
        /// </summary>
        /// <param name="Nombre"></param>
        /// <param name="ID"></param>
        /// <param name="Contraseña"></param>
        /// <param name="NumeroDeJugador"></param>
        public PerfilUsuario (string Nombre, int ID, string Contraseña, int NumeroDeJugador)
        {
            this.Nombre = Nombre;
            this.ID = ID;
            this.Contraseña = Contraseña;
            this.NumeroDeJugador = NumeroDeJugador;
        }

        /// <summary>
        /// Añade partidas al historial personal del usuario
        /// </summary>
        /// <param name="partida"> Partida a añadir </param>
        public void AñadiralHistorial(DatosdePartida partida)
        {
            this.HistorialPersonal.Add(partida);
        }

        /// <summary>
        /// Devuelve el perfil para imprimir
        /// </summary>
        /// <returns> Devuelve el Perfil del usuario </returns>
        public PerfilUsuario VerPerfil()
        {
            return this;
        }

        /// <summary>
        /// Devuelve el historial personal para imprimir
        /// </summary>
        /// <returns> Devuelve una lista con todos los datos de partida del perfil</returns>
        public List<DatosdePartida> VerHistorialPersonal()
        {
            return this.HistorialPersonal;
        }
    }
}
