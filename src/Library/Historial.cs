using System;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase se encarga de añadir las partidas que se jugaron a la lista que se define posteriormente.
    /// </summary>
    public class Historial
    {
      public static List<ListadePartidas> partidas;
    
      public void AñadirPartida(partida)
      {
        partidas.add(partida);

      }
      public void Ganar()
      {

        Ganadas+=1;
      }
    
      public void Perder()
      {
        Perdidas+=1;
      }
    }
}