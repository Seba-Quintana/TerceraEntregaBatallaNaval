using System;

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
          //PerfilUsuario a = Admin.ObtenerPerfil(perfil);
      }  
    
      public void VerRanking()
      {
          //Admin.ObtenerRanking();
      }
    
      public void VerHistorial(int historial)
      {
          //Admin.ObtenerHistorial(historial);
      }
    
      public void PartidaAmistosa(int modo, int jugador1, int jugador2)
      {
        Admin ad = new Admin();
        ad.EmparejarAmigos(modo, jugador1, jugador2);
      }
    
      public void BuscarPartida(int modo, int jugador1)
      {
        Admin ad = new Admin();
        ad.Emparejar(modo, jugador1);
      }
    
      public void VisualizarTablero()
      {
        //Admin.ObtenerTableroAtaque();
        //Admin.ObtenerTableroDefensa();
      }
      public void Atacar(string coordenada)
      {
        int[] nuevaCoordenada = TraductorDeCoordenadas.Traducir(coordenada);
        //Logica.IndicarCasilla(nuevaCoordenada);
      }
    }
    

}