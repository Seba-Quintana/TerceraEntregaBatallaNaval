using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase se encarga de añadir las partidas que se jugaron a la lista que se define posteriormente.
    /// </summary>
    public static class Historial
    {
      private static List<DatosdePartida> partidas;

      public static List<DatosdePartida> Partidas
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
      public static void AlmacenarPartida(DatosdePartida partida)
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