using System;
namespace ClassLibrary
{
/// <summary>
///  Clase encargada de manejar los tableros directamente
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
  
  public static bool Añadirbarco(Tablero tablero, int filainicio, int columnainicio,  int filafinal, int columnafinal)
  {
    bool SeAñadioElBarco;
    if (filainicio == filafinal)
    {
      SeAñadioElBarco = tablero.AñadirBarco(filainicio, columnainicio, filafinal, columnafinal);
    }

    else
    {       
      SeAñadioElBarco = tablero.AñadirBarco(filainicio, columnainicio, filafinal, columnafinal);
    }
    return SeAñadioElBarco;

    }
    /// <summary>
    /// Metodo encargado de realizar un ataque y devolver el resultado del ataque.
    /// </summary>
    /// <param name="tablero"></param>
    /// <param name="columna"></param>
    /// <param name="fila"></param>
    /// <returns></returns>
    public static char Atacar( Tablero tablero,  int fila, int columna)
    {
      return tablero.Atacar(fila,columna);
    }
    /// <summary>
    /// Metodo utilizado por la clase LogicaDePartida para ver si se ha quedado sin barcos el tablero despues de un ataque
    /// </summary>
    /// <param name="tablero"></param>
    /// <returns></returns>
    public static bool Finalizar(Tablero tablero)
    { 
      return tablero.terminado;
    }
    /// <summary>
    /// Metodo encargado de asignar a un tablero 
    /// su ganador en caso de que sea el dueño.
    /// </summary>
    /// <param name="TableroGanador"></param>
    public static void PartidaFinalizada(Tablero TableroGanador)
    {
      TableroGanador.Victoria();
    }
  }
}
