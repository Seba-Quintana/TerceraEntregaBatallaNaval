using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase empareja a dos jugadores en una lista.
    /// Hay dos colas existentes, una para el modo normal y otra para el modo rapido
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
        /// Numero de jugador del oponente actual (0 si no hay oponente)
        /// </summary>
        public int OponenteEnPartida;

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
        public List<DatosdePartida> HistorialPersonal;
        public object Clone()
    {
        return this.MemberwiseClone();
    }
        /// <summary>
        /// constructor del perfil de usuario.
        /// </summary>
        /// <param name="Nombre"></param>
        /// <param name="ID"></param>
        /// <param name="Contraseña"></param>
        /// <param name="NumeroDeJugador"></param>
        /// <param name="OponenteEnPartida"></param>
        /// <param name="Ganadas"></param>
        /// <param name="Perdidas"></param>
        /// <param name="HistorialPersonal"></param>
        public PerfilUsuario (string Nombre, int ID, string Contraseña, int NumeroDeJugador, 
                            int OponenteEnPartida, int Ganadas,
                            int Perdidas, List<DatosdePartida> HistorialPersonal)
        {
            this.Nombre = Nombre;
            this.ID = ID;
            this.Contraseña = Contraseña;
            this.NumeroDeJugador = NumeroDeJugador;
            this.OponenteEnPartida = OponenteEnPartida;
            this.Ganadas = Ganadas;
            this.Perdidas = Perdidas;
            this.HistorialPersonal = HistorialPersonal;
        }

        /// <summary>
        /// Añade partidas al historial personal del usuario
        /// </summary>
        /// <param name="partida"></param>
        public void AñadiralHistorial(DatosdePartida partida)
        {
            this.HistorialPersonal.Add(partida);
        }

        /// Devuelve el perfil para imprimir
        /// </summary>
        /// <returns></returns>
      
        public PerfilUsuario VerPerfil()
        {
            return this;
        }

        
        /// <summary>
        /// Devuelve el historial personal para imprimir
        /// </summary>
        /// <returns></returns>
        public List<DatosdePartida> VerHistorialPersonal()
        {
            return this.HistorialPersonal;
        }
    }
}