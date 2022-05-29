using System;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase se encarga de añadir las partidas que se jugaron a la lista que se define posteriormente.
    /// </summary>
    public class Historial
    {
      public static List<DatosdePartidas> partidas;
    
      public void AlmacenarPartida(DatosdePartidas partida)
      {
        partidas.add(partida);

      }
    }
}