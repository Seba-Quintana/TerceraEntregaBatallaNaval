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
  /// luego se asignan las variables si se cumple la condicion de que se posicionen horizontal o verticalmente
  /// y que las casillas marcadas esten en la matriz.
  /// </summary>
  /// <param name="tablero"></param>
  /// <param name="inicioDeBarco"></param>
  /// <param name="finalDeBarco"></param>
  
  public static void Añadirbarco(Tablero tablero, int[] inicioDeBarco, int[] finalDeBarco)
  {
    if (inicioDeBarco[0] == finalDeBarco[0])
    {
      for (int i = inicioDeBarco[1]; i <= finalDeBarco[1]; i++)
      {
        tablero.ActualizarTablero(inicioDeBarco[0], i, 'B');
      }
    }

    else if (inicioDeBarco[1] == finalDeBarco[1])
      {
        for (int i = inicioDeBarco[0]; i <= finalDeBarco[0]; i++)
        {
          //Controlador por si el jugador envia una coordenada invalida como por ej A0
          
          tablero.ActualizarTablero(i, inicioDeBarco[1], 'B');
            
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
    public static string AtacarCasilla( Tablero tablero, int[] LugarDeAtaque)
    {
      int columna = LugarDeAtaque[0];
      int fila = LugarDeAtaque[1];
      string LugarAtaque = tablero.VerCasilla(columna, fila);
      tablero.ActualizarTablero(columna, fila, 'A');
      return LugarAtaque;
    }
  }
}