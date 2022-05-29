using System;
namespace ClassLibrary
{
  /// <summary>
  ///  Clase encargada de manejar la logica pura del juego
  /// </summary>
    public static class Logica
    {
        /// <summary>
        /// Metodo encargado de añadir un barco a un tablero, se le asignan el inicio y el final,
        /// luego se asignan las variables si se cumple la condicion de que se posicionen horizontal o verticalmente
        /// y que las casillas marcadas esten en la matriz.
        /// </summary>
        /// <param name="tablero"></param>
        /// <param name="InicioDeBarco"></param>
        /// <param name="FinalDeBarco"></param>
        
        public void Añadirbarco(Tablero tablero, int[] InicioDeBarco, int[] FinalDeBarco)
        {
            if (InicioDeBarco[0] == FinalDeBarco[0])
            {
                for (int i = InicioDeBarco[1] - 1; i < FinalDeBarco[1]; i++)
                {
                    if (i >= 0)
                    {
                        tablero.ActualizarTablero(InicioDeBarco[0], i, 'B');
                    }

                }
            }

            if (InicioDeBarco[1] == FinalDeBarco[1])
            {
                for (int i = InicioDeBarco[1] - 1; i < FinalDeBarco[1]; i++)
                {
                    if (i >= 0)
                    {
                        tablero.ActualizarTablero(i, InicioDeBarco[1], 'B');
                    }
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
      public string AtacarCasilla( Tablero tablero, int columna, int fila)
      {
        string LugardeAtaque = tablero.VerCasilla(columna, fila);
        tablero.ActualizarTablero(columna, fila, 'A');
        return LugardeAtaque;
      }

    }
}