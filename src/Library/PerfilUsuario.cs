using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase almacena el perfil de un usuario.
    /// Implementa la interfaz ICloneable para poder crear una copia superficial de un perfil. 
    /// Metodos publicos para poder serializar
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
        public long ID;
        /// <summary>
        /// Contraseña del usuario
        /// </summary>
        public string Contrasena;
        /// <summary>
        /// Identificación numerica del jugador
        /// </summary>
        public int NumeroDeJugador;
        /// <summary>
        /// Cantidad de partidas ganadas
        /// </summary>
        public int Ganadas;

        /// <summary>
        /// Cantidad de partidas perdidas
        /// </summary>
        public int Perdidas;

        /// <summary>
        /// historial del usuario en concreto
        /// </summary>
        public List<DatosdePartida> HistorialPersonal = new List<DatosdePartida>();
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
        /// <param name="contrasena"></param>
        /// <param name="NumeroDeJugador"></param>
        public PerfilUsuario (string Nombre, long ID, string contrasena, int NumeroDeJugador)
        {
            this.Nombre = Nombre;
            this.ID = ID;
            this.Contrasena = contrasena;
            this.NumeroDeJugador = NumeroDeJugador;
            this.Ganadas = 0;
            this.Perdidas = 0;
        }
        /// <summary>
        /// Añade partidas al historial personal del usuario
        /// </summary>
        /// <param name="partida"> Partida a añadir </param>
        public void AgregarAlHistorial(DatosdePartida partida)
        {
            if (partida.Ganador == NumeroDeJugador)
            {
                Ganadas++;
            }
            else
            {
                Perdidas++;
            }
            this.HistorialPersonal.Add(partida);
        }
        /// <summary>
        /// Devuelve el perfil
        /// </summary>
        /// <returns> Devuelve el Perfil del usuario </returns>
        public PerfilUsuario VerPerfil()
        {
            return this;
        }
        /// <summary>
        /// Devuelve una copia del historial personal
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
