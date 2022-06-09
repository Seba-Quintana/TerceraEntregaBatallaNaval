using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase se encarga de añadir las partidas que se jugaron a la lista que se define posteriormente.
    /// </summary>
    public static class Historial
    {
      public static List<DatosdePartida> partidas;
    
      public static void AlmacenarPartida(DatosdePartida partida)
      {
        partidas.Add(partida);
      }
    }
}