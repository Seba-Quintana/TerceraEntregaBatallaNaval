using System;
using System.Collections.Generic;

namespace unicornio
{
    /// <summary>
    /// Esta clase empareja a dos jugadores en una lista.
    /// Hay dos colas existentes, una para el modo normal y otra para el modo rapido
    /// </summary>
    public class PerfilUsuario
    {
        public string Nombre;
        private int ID;
        public string Contraseña;
        public int NumeroDeJugador;
        public int OponenteEnPartida;
        public int Ganadas;
        public int Perdidas;
        public List<DatosdePartidas> HistorialPersonal;

        public PerfilUsuario (string Nombre, int ID, string Contraseña, int NumeroDeJugador, 
                            int OponenteEnPartida, int Ganadas,
                            int Perdidas)//, List<DatosdePartidas> HistorialPersonal)
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
        public void AñadiralHistorial(DatosdePartidas partida)
        {
            this.HistorialPersonal = partida;
        }
        public PerfilUsuario VerPerfil()
        {
            return this;
        }
        
        /// <summary>
        /// Devuelve el historial personal para imprimir
        /// </summary>
        /// <returns></returns>
        public List<DatosdePartidas> VerHistorialPersonal()
        {
            return this.HistorialPersonal;
        }
    }
}