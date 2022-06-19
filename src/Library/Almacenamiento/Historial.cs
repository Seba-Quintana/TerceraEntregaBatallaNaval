using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase se encarga de añadir las partidas que se jugaron a una lista,
    /// con el objetivo de mantener un registro de las partidas jugadas.
    /// </summary>
    public class Historial
    {
      private List<DatosdePartida> partidas = new List<DatosdePartida>();

        static Historial instance;

        /// <summary>
        /// Parte de singleton. Constructor llamado por el metodo Instance de crearse un Historial.
        /// </summary>
        private Historial()
        {
        }

        /// <summary>
        /// Singleton de Historial. Si no existe una instancia de Historial, crea una. Si ya existe la devuelve
        /// </summary>
        /// <returns> Instancia nueva de Historial, o de darse el caso, una previamente creada </returns>
        public static Historial Instance()
        {
            if (instance == null)
            {
                instance = new Historial();
            }
            return instance;
        }
      /// <summary>
      /// Atributo que funciona para poder ver la lista de partidas desde otras clases, pero no modificarla.
      /// </summary>
      /// <value></value>
      public List<DatosdePartida> Partidas
      {
        get
        {
          return partidas;
        }
      }

      /// <summary>
      /// Almacena la partida en el historial general y los historiales personales de los jugadores.
      /// </summary>
      /// <param name="partida"> partida a almacenar </param>
      public void AlmacenarPartida(DatosdePartida partida)
      {
        AlmacenamientoUsuario buscador = AlmacenamientoUsuario.Instance();
        PerfilUsuario jugador1 = buscador.ObtenerPerfil(partida.Jugadores[0]);
        PerfilUsuario jugador2 = buscador.ObtenerPerfil(partida.Jugadores[1]);
        jugador1.AñadiralHistorial(partida);
        jugador2.AñadiralHistorial(partida);
        partidas.Add(partida);
      }
    }
}
