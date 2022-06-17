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
      public int NumeroDeJugador;

      public Jugador(string nombre, int id, string contraseña)
      {
        Admin ad = Admin.Instance();
        this.NumeroDeJugador = ad.Registrar(nombre, id, contraseña);
      }

      public void Remover()
      {
        Admin ad = Admin.Instance();
        ad.Remover(this.NumeroDeJugador);
      }
      
      public void VerPerfil(int perfil)
      {
         Admin ad = Admin.Instance();
         ad.VerPerfil(perfil);
      }  
    
      public void VerRanking()
      {
         Admin ad = Admin.Instance();
         ad.ObtenerRanking();
      }
    
      public void VerHistorial(int historial)
      {
          Admin ad = Admin.Instance();
          ad.ObtenerHistorial(historial);
      }
    
      public void PartidaAmistosa(int modo, int jugador2, int tamano)
      {
        Admin ad = Admin.Instance();
        ad.EmparejarAmigos(modo, this.NumeroDeJugador, jugador2, tamano);

      }
    
      public void BuscarPartida(int modo)
      {

        Admin ad = Admin.Instance();
        ad.Emparejar(modo, this.NumeroDeJugador);
      }
      /// <summary>
      /// 
      /// </summary>
      public void VisualizarTablero()
      {
        Admin ad = Admin.Instance();
        ad.ObtenerTableroOponente(this.NumeroDeJugador);
        ad.ObtenerTablero(this.NumeroDeJugador);
      }
      /// <summary>
      /// 
      /// </summary>
      /// <param name="inicio"></param>
      /// <param name="final"></param>
      public void PosicionarBarcos(string inicio, string final)
      {
        LogicaDePartida partida = PartidasEnJuego.ObtenerLogicadePartida(this.NumeroDeJugador);
        partida.AñadirBarco(inicio, final, this.NumeroDeJugador);
      }
      /// <summary>
      /// 
      /// </summary>
      /// <param name="coordenada"></param>
      public void Atacar(string coordenada)
      {
        LogicaDePartida partida = PartidasEnJuego.ObtenerLogicadePartida(this.NumeroDeJugador);
        partida.Atacar(coordenada, this.NumeroDeJugador);
      }
    }
    

}
