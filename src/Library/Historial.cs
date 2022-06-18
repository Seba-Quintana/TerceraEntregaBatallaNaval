using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase se encarga de añadir las partidas que se jugaron a una lista,
    /// con el objetivo de mantener un registro de las partidas jugadas.
    /// </summary>
    public static class Historial
    {
      /// <summary>
      /// Creamos una lista llamada partidas, la cual contiene elementos del tipo DatosdePartida, que es donde se almacenan las partidas que
      /// se han jugado.
      /// </summary>
      public static List<DatosdePartida> partidas;
        
      /// <summary>
      /// Este método se encarga de almacenar las partidas jugadas en la lista de partidas
      /// luego de finalizadas.
      /// </summary>
      /// <param name="partida"> Partida a almacenar </param>
      public static void AlmacenarPartida(DatosdePartida partida)
      {
        partidas.Add(partida);
      }
    }
}
