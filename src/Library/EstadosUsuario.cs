using System;
using System.Linq;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Clase encargada de manejar los estados de los diferentes usuarios
    /// </summary>
    public class EstadosUsuarios
    {
        static EstadosUsuarios instance;
        private EstadosUsuarios()
        {
        }

        /// <summary>
        /// Metodo para aplicar singleton
        /// </summary>
        /// <returns> crea una instancia en caso de no existir una,
        /// de lo contrario devuelve la instancia ya creada </returns>
        public static EstadosUsuarios Instance()
        {
            if (instance == null)
            {
                instance = new EstadosUsuarios();
            }
            return instance;
        }
        private Dictionary<long, int> estadosDeJugadores = new Dictionary<long, int>();
        
        /// <summary>
        /// Verifica si el jugador ya tiene estado
        /// </summary>
        /// <param name="ID"> id del jugador </param>
        /// <returns> true si se encuentra, false de lo contrario </returns>
        public bool ContieneId(long ID)
        {
            return this.estadosDeJugadores.ContainsKey(ID);
        }

        /// <summary>
        /// Devuelve el estado del jugador
        /// </summary>
        /// <param name="ID"> id del jugador </param>
        /// <returns> Devuelve el estado del jugador </returns>
        public int VerEstado(long ID)
        {
            return this.estadosDeJugadores[ID];
        }
        
        /// <summary>
        /// Metodo que reinicia el estado del jugador (lo envia al menu)
        /// </summary>
        /// <param name="ID"> id del jugador </param>
        public void ReiniciarEstados(long ID)
        {
            this.estadosDeJugadores[ID]=1;
        }

        /// <summary>
        /// Metodo para avanzar el estado de un jugador
        /// </summary>
        /// <param name="ID"> id del jugador </param>
        /// <param name="estadosAAvanzar"> cantidad de estados a avanzar </param>
        public void AvanzarEstados(long ID, int estadosAAvanzar)
        {
            this.estadosDeJugadores[ID]+=estadosAAvanzar;
        }

        /// <summary>
        /// Metodo para retroceder el estado de un jugador
        /// </summary>
        /// <param name="ID"> id del jugador </param>
        /// <param name="estadosARetroceder"> cantidad de estados a retroceder </param>
        public void RetrocederEstados(long ID, int estadosARetroceder)
        {
            if (this.estadosDeJugadores[ID] - estadosARetroceder >= 0)
                this.estadosDeJugadores[ID]-=estadosARetroceder;
        }

        /// <summary>
        /// Añadir jugador a la lista de estados
        /// </summary>
        /// <param name="ID"> id del jugador </param>
        public void NuevoJugador(long ID)
        {
            estadosDeJugadores.Add(ID,0);
        }
    }
}
