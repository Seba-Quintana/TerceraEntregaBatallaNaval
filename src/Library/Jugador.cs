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
      /// <summary>
      /// Numero del jugador. Sirve como identificación.
      /// </summary>
      public int NumeroDeJugador;

      /// <summary>
      /// Constructor del jugador.
      /// </summary>
      /// <param name="nombre"> nombre del jugador </param>
      /// <param name="id"> La id es para simular la id caracteristica del usuario,
      /// la cual es proporcionada por el bot </param>
      /// <param name="contraseña"> contraseña del jugador </param>
      public Jugador(string nombre, int id, string contraseña)
      {
        Admin ad = Admin.Instance();
        this.NumeroDeJugador = ad.Registrar(nombre, id, contraseña);
      }

      /// <summary>
      /// Remueve el jugador de la lista de usuarios
      /// </summary>
      public void Remover()
      {
        Admin ad = Admin.Instance();
        ad.Remover(this.NumeroDeJugador);
      }
      
      /// <summary>
      /// Permite al jugador visualizar su perfil
      /// </summary>
      /// <param name="perfil"></param>
      public void VerPerfil(int perfil)
      {
        Admin ad = Admin.Instance();
        ad.VerPerfil(perfil);
      }
    
      /// <summary>
      /// Permite al jugador visualizar el ranking
      /// </summary>
      public void VerRanking()
      {
        Admin ad = Admin.Instance();
        ad.ObtenerRanking();
      }
    
      /// <summary>
      /// Permite al jugador ver el historial
      /// </summary>
      /// <param name="historial"></param>
      public void VerHistorial(int historial)
      {
        Admin ad = Admin.Instance();
        ad.ObtenerHistorial(historial);
      }
    
      /// <summary>
      /// Busqueda de partida amistosa (jugar partida con un amigo)
      /// </summary>
      /// <param name="modo"> modo de juego elegido </param>
      /// <param name="jugador2"> jugador con el que se quiere emparejar </param>
      /// <param name="tamano"> tamaño del tablero </param>
      public void PartidaAmistosa(int modo, int jugador2, int tamano)
      {
        Admin ad = Admin.Instance();
        ad.EmparejarAmigos(modo, this.NumeroDeJugador, jugador2, tamano);
      }
    
      /// <summary>
      /// Busqueda de partida (partida con oponente aleatorio)
      /// </summary>
      /// <param name="modo"> modo de juego elegido </param>
      /// <param name="tamano"></param>
      public void BuscarPartida(int modo, int tamano)
      {
        Admin ad = Admin.Instance();
        ad.Emparejar(modo, this.NumeroDeJugador, tamano);
      }
      /// <summary>
      /// Permite al jugador visualizar el tablero actual
      /// </summary>
      public void VisualizarTablero()
      {
        Admin ad = Admin.Instance();
        ad.ObtenerTableroOponente(this.NumeroDeJugador);
        ad.ObtenerTablero(this.NumeroDeJugador);
      }
      /// <summary>
      /// Permite al jugador posicionar barcos
      /// </summary>
      /// <param name="inicio"> coordenada que indica la primera casilla del barco </param>
      /// <param name="final"> coordenada que indica la ultima casilla del barco </param>
      public string PosicionarBarcos(string inicio, string final)
      {
        LogicaDePartida partida = PartidasEnJuego.ObtenerLogicadePartida(this.NumeroDeJugador);
        string mensajeBarco = partida.AñadirBarco(inicio, final, this.NumeroDeJugador);
        return mensajeBarco;
      }

      /// <summary>
      /// Permite al jugador atacar
      /// </summary>
      /// <param name="coordenada"> coordenada de ataque </param>
      public string Atacar(string coordenada)
      {
        LogicaDePartida partida = PartidasEnJuego.ObtenerLogicadePartida(this.NumeroDeJugador);
        string mensajeAtaque = partida.Atacar(coordenada, this.NumeroDeJugador);
        return mensajeAtaque;
      }
    }
}
