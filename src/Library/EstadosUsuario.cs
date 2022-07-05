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
        public static EstadosUsuarios Instance()
        {
            if (instance == null)
            {
                instance = new EstadosUsuarios();
            }
            return instance;
        }
        private Dictionary<long, int> EstadosDeJugadores = new Dictionary<long, int>();
        
        
        public bool ContieneId(long ID)
        {
            return this.EstadosDeJugadores.ContainsKey(ID);
        }


        public int VerEstado(long ID)
        {
            return this.EstadosDeJugadores[ID];
        }
        

        public void ReiniciarEstados(long ID)
        {
            this.EstadosDeJugadores[ID]=1;
        }


        public void AvanzarEstados(long ID, int estadosAAvanzar)
        {
            this.EstadosDeJugadores[ID]+=estadosAAvanzar;
        }


        public void RetrocederEstados(long ID, int estadosARetroceder)
        {
            this.EstadosDeJugadores[ID]-=estadosARetroceder;
        }

        
        public void NuevoJugador(long ID)
        {
            EstadosDeJugadores.Add(ID,0);
        }
    }
}
