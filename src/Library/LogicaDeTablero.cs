using System;
namespace ClassLibrary
{
/// <summary>
///  Clase encargada de manejar la logica pura del juego
/// </summary>
  public static class LogicaDeTablero
  {
  /// <summary>
  /// Metodo encargado de añadir un barco a un tablero, se le asignan el inicio y el final,
  /// luego se asignan las variables en caso de que se cumple la condicion de que se posicionen 
  /// horizontal o verticalmente y que las casillas marcadas esten en la matriz.
  /// </summary>
  /// <param name="tablero"></param>
  /// <param name="filainicio"></param>
  /// <param name="columnainicio"></param>
  /// <param name="filafinal"></param>
  /// <param name="columnafinal"></param>
  
  public static void Añadirbarco(Tablero tablero, int filainicio, int columnainicio,  int filafinal, int columnafinal)
  {
    if (filainicio == filafinal)
    {
      for (int i = columnainicio; i <= columnafinal; i++)
      {
        tablero.ActualizarTablero(filafinal, i, 'B');
      }
    }

    else if (columnainicio == columnafinal)
    {
      for (int i = filainicio; i <= filafinal; i++)
      {          
        tablero.ActualizarTablero(i, columnainicio, 'B');
            
      }
    }

    }
    /// <summary>
    /// Encargado de realizar un ataque y devolver el resultado del ataque.
    /// </summary>
    /// <param name="tablero"></param>
    /// <param name="columna"></param>
    /// <param name="fila"></param>
    /// <returns></returns>
    public static void Atacar( Tablero tablero,  int fila, int columna)
    {
      tablero.ActualizarTablero(fila, columna, 'A');
    }
    public static bool Finalizar(Tablero tablero)
    { 
      return tablero.terminado;
    }
  }
}