using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase se encarga de añadir las partidas que se jugaron a la lista que se define posteriormente.
    /// </summary>
    public static class Historial
    {
      /// <summary>
      /// Creamos una lista llamada partidas, cuyo tipo es <DatosdePartida> que es donde se almacenará las partidas que
      /// hemos jugado independientemente en cuanto a si hemos ganado o perdido.
      /// </summary>
      public static List<DatosdePartida> partidas;
      /// <summary>
      /// Este método básicamente se encarga de almacenar la partida en la lista que hemos creado anteriormente,
      /// luego de finalizar la partida, guardándose en el historial de nuestro usuario
      /// </summary>
      /// <param name="partida"></param>
      public static void AlmacenarPartida(DatosdePartida partida)
      {
        partidas.Add(partida);
      }
    }
}