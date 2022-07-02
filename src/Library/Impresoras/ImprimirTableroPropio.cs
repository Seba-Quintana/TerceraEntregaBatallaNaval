using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Envia a los handlers a modo de string el tablero implementando la interfaz IImprimirTablero con una operación polimórfica.
    /// </summary>
    public class ImprimirTableroPropio: IImprimirTablero
    {
        /// <summary>
        /// Con este método se forma un string el tablero ingresado como parámetro agregándole índices de coordenadas.
        /// Se muestra el tablero sin ocultar nada de su contenido
        /// </summary>
        /// <param name="tablero"> el tablero que volver string </param>
        
        public string ImprimirTablero(Tablero tablero)
        {
            string respuesta = "TABLERO PROPIO\n\n";
            string filaImprimir = "   ";
            List<string> letras = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", " I", "J", "K", "L", "M", "N", "O" };
            respuesta += "\n";
            char[,] matriz = tablero.VerTablero();
            for (int i = 0; i < matriz.GetLength(1); i++)
            {
                if (i < 5)
                {
                    filaImprimir = filaImprimir + $"  {i + 1}";
                }
                else if (i == 5)
                {
                    filaImprimir = filaImprimir + $"   {i + 1}";
                }
                else if (i < 10)
                {
                    filaImprimir = filaImprimir + $"  {i + 1}";
                }
                else
                {
                    filaImprimir = filaImprimir + $" {i + 1} ";
                }
            }
            respuesta += ($"{filaImprimir}\n");
            for (int fila = 0; fila < matriz.GetLength(0); fila++)
            {
                filaImprimir = letras[fila] + " ";
                for (int columna = 0; columna < matriz.GetLength(1); columna++)
                {
                    switch (matriz[fila, columna])
                    {
                        case 'W':
                            filaImprimir = filaImprimir + " " + "O ";
                            break;
                        case 'T':
                            filaImprimir = filaImprimir + " " + "X ";
                            break;
                        case 'B':
                            filaImprimir = filaImprimir + " " + "B ";
                            break;
                        case '-':
                            filaImprimir = filaImprimir + " " + "- ";
                            break;
                        case 'H':
                            filaImprimir = filaImprimir + " " + "H ";
                            break;
                        default:
                            filaImprimir = filaImprimir + " " + "~ ";
                            break;
                    }
                }
                respuesta += ($"{filaImprimir}\n");
            }
            respuesta += ("\n");
            return respuesta;
        }
    }
}
