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
        try
        {
          this.NumeroDeJugador = Admin.Registrar(nombre, id, contraseña);
        }
        catch (Exception e)
        {
          throw new Exception("no se pudo crear un jugador", e);
        }
      }

      /// <summary>
      /// Remueve el jugador de la lista de usuarios
      /// </summary>
      public void Remover()
      {
        try
        {
          Admin.Remover(this.NumeroDeJugador);
        }
        catch (Exception e)
        {
          throw new Exception("no se pudo crear un jugador", e);
        }
      }
      
      /// <summary>
      /// Permite al jugador visualizar su perfil
      /// </summary>
      /// <param name="perfil"></param>
      public void VerPerfil(int perfil)
      {
        try
        {
          Admin.VerPerfil(perfil);
        }
        catch (Exception e)
        {
          throw new Exception("No se pudo visualizar el perfil", e);
        }
      }
    
      /// <summary>
      /// Permite al jugador visualizar el ranking
      /// </summary>
      public void VerRanking()
      {
        try
        {
          Admin.VerRanking();
        }
        catch (Exception e)
        {
          throw new Exception("No se pudo ver el ranking", e);
        }
      }
    
      /// <summary>
      /// Permite al jugador ver el historial
      /// </summary>
      public void VerHistorial()
      {
        try
        {
          Admin.VerHistorial();
        }
        catch (Exception e)
        {
          throw new Exception("No se pudo ver el historial", e);
        }
      }
    
      /// <summary>
      /// Permite al jugador ver su historial personal
      /// </summary>
      /// <param name="numerodejugador"> jugador del que se quiere ver el historial </param>
      public void VerHistorialPersonal(int numerodejugador)
      {
        try
        {
          Admin.VerHistorialPersonal(numerodejugador);
        }
        catch (Exception e)
        {
          throw new Exception("No se pudo ver el historial", e);
        }
      }

      /// <summary>
      /// Busqueda de partida amistosa (jugar partida con un amigo)
      /// </summary>
      /// <param name="modo"> modo de juego elegido </param>
      /// <param name="jugador2"> jugador con el que se quiere emparejar </param>
      /// <param name="tamano"> tamaño del tablero </param>
      public void PartidaAmistosa(int modo, int jugador2, int tamano)
      {
        try
        {
          Admin.EmparejarAmigos(modo, this.NumeroDeJugador, jugador2, tamano);
        }
        catch (Exception e)
        {
          throw new Exception("no se pudo emparejar con otro jugador", e);
        }
      }
    
      /// <summary>
      /// Busqueda de partida (partida con oponente aleatorio)
      /// </summary>
      /// <param name="modo"> modo de juego elegido </param>
      /// <param name="tamano"></param>
      public void BuscarPartida(int modo, int tamano)
      {
        try
        {
          Admin.Emparejar(modo, this.NumeroDeJugador, tamano);
        }
        catch (Exception e)
        {
          throw new Exception("no se pudo emparejar con otro jugador", e);
        }
      }
      /// <summary>
      /// Permite al jugador visualizar el tablero actual
      /// </summary>
      public void VisualizarTableros()
      {
        try
        {
          Admin.VerTableroOponente(this.NumeroDeJugador);
          Admin.VerTablero(this.NumeroDeJugador);
        }
        catch (Exception e)
        {
          throw new Exception("No se pudo ver el tablero", e);
        }
      }
      /// <summary>
      /// Permite al jugador posicionar barcos
      /// </summary>
      /// <param name="inicio"> coordenada que indica la primera casilla del barco </param>
      /// <param name="final"> coordenada que indica la ultima casilla del barco </param>
      public string PosicionarBarcos(string inicio, string final)
      {
        return Admin.Posicionar(inicio ,final ,NumeroDeJugador);
      }

      /// <summary>
      /// Permite al jugador atacar
      /// </summary>
      /// <param name="coordenada"> coordenada de ataque </param>
      public string Atacar(string coordenada)
      {
        
        return Admin.Atacar(coordenada, NumeroDeJugador);
      }

      /// <summary>
      /// Permite al jugador rendirse
      /// </summary>
      public void Rendirse()
      {
        Admin.Rendirse(this.NumeroDeJugador);
      }
    }
}
