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
        private string nombre;

        public string Nombre
        {
            get
            {
                return nombre;
            }
        }

        /// <summary>
        /// Identificación del jugador otorgada por el bot
        /// </summary>
        private int ID;

        /// <summary>
        /// Contraseña del usuario
        /// </summary>
        private string contraseña;

        /// <summary>
        /// Identificación númerica del jugador
        /// </summary>
        public int NumeroDeJugador;

        /// <summary>
        /// Cantidad de partidas ganadas
        /// </summary>
        private int ganadas = 0;

        public int Ganadas
        {
            get
            {
                return ganadas;
            }
        }

        /// <summary>
        /// Cantidad de partidas perdidas
        /// </summary>
        private int perdidas = 0;

        public int Perdidas
        {
            get
            {
                return perdidas;
            }
        }
      
        /// <summary>
        /// historial del usuario en concreto
        /// </summary>
        private List<DatosdePartida> HistorialPersonal;

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
            this.nombre = Nombre;
            this.ID = ID;
            this.contraseña = Contraseña;
            this.NumeroDeJugador = NumeroDeJugador;
        }

        /// <summary>
        /// Añade partidas al historial personal del usuario
        /// </summary>
        /// <param name="partida"> Partida a añadir </param>
        public void AñadiralHistorial(DatosdePartida partida)
        {
            if (partida.Ganador == NumeroDeJugador)
            {
                ganadas++;
            }
            else
            {
                perdidas++;
            }
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
        /// Devuelve una copia del historial personal para imprimir
        /// </summary>
        /// <returns> Devuelve una lista con todos los datos de partida del perfil</returns>
        public List<DatosdePartida> ObtenerHistorialPersonal()
        {
            List<DatosdePartida> historial = new List<DatosdePartida>();
            int i = 0;
            while (i < this.HistorialPersonal.Count)
            {
                historial.Add(this.HistorialPersonal[i]);
                i++;
            }
            return historial;
        }
    }
}
