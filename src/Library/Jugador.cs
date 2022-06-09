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
    
      public void PartidaAmistosa(int jugador1, int jugador2)
      {
        //Admin.EmparejarAmigos(jugador1, jugador2);
      }
    
      public void BuscarPartida(int partida)
      {
        //Admin.BuscarPartida(partida);
      }
      /// <summary>
      /// 
      /// </summary>
      public void VisualizarTablero()
      {
        //Admin.ObtenerTableroOponente();
        //Admin.ObtenerTablero();
      }
      /// <summary>
      /// 
      /// </summary>
      /// <param name="inicio"></param>
      /// <param name="final"></param>
      public void PosicionarBarcos(string inicio, string final)
      {
        //LogicaDePartida.añadirBarco(TraductorDeCoordenadas.Traducir(inicio),TraductorDeCoordenadas.Traducir(final));
      }
      /// <summary>
      /// 
      /// </summary>
      /// <param name="coordenada"></param>
      public void Atacar(string coordenada)
      {
        //LogicaDePartida.Atacar(TraductorDeCoordenadas.Traducir(coordenada));
      }
    }
    

}