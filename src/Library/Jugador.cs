using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase se encarga de ver cosas como el Perfil, el Ranking y el Historial.
    /// Se encarga de crear Partidas Amistosas y tambien de buscar Partidas
    /// Visualiza al tablero.
    /// </summary>
    public class Jugador
    {
      
      public void VerPerfil(int perfil)
      {
         Admin ad = new Admin();
         ad.ObtenerPerfil(perfil);
      }  
    
      public void VerRanking()
      {
         Admin ad = new Admin();
         ad.ObtenerRanking();
      }
    
      public void VerHistorial(int historial)
      {
          Admin ad = new Admin();
          //ad.ObtenerHistorial(historial);
      }
    
      public void PartidaAmistosa(int jugador1, int jugador2)
      {
        
      }
    
      public void BuscarPartida(int partida)
      {
        
      }
    
      public void VisualizarTablero()
      {
       
      }
      public void Atacar(string coordenada)
      {
  
      }
    }
    

}