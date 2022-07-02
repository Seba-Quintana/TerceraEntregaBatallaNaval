using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Envia a los handlers a modo de string el tablero implementando la interfaz IImprimirTablero con una operación polimórfica.
    /// 
    /// </summary>
    public class ImprimirTableroOponente: IImprimirTablero
    {
        /// <summary>
        /// Con este método se forma un string el tablero ingresado como parámetro agregándole índices de coordenadas.
        /// Se muestra el tablero ocultando los barcos aun no tocados por el oponente.
        /// </summary>
        /// <param name="tablero"> el tablero que volver string </param>
        
        public string ImprimirTablero(Tablero tablero)
        {
            char[,] matriz = tablero.VerTablero();

            //QUITO LOS BARCOS DEL CLON OBTENIDO DE LA MATRIZ DEL TABLERO
            char[ , ] matrizSinBarcos = matriz;
            for (int i = 0; i <  matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if (matrizSinBarcos[i,j]== 'B')
                    {
                        matrizSinBarcos[i,j]= '\u0000';
                    }
                }
            }
            //AGREGO EL AYUDANTE DE TIRO
            matrizSinBarcos = ayudanteDeTiro(matrizSinBarcos);
            //CREO EL STRING
            string respuesta = "\nTABLERO OPONENTE\n\n";
            string filaImprimir = "   ";
            List<string> letras = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", " I", "J", "K", "L", "M", "N", "O" };
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
        /// <summary>
        /// Cuando un barco es atacado señaliza donde se pueden encontrar los otros puntos del barco
        /// </summary>
        /// <param name="matriz"> matriz del tablero que quiero señalizar </param>
        public char[ , ] ayudanteDeTiro (char[ , ] matriz)
        {
            int tamanoDeFilas =  matriz.GetLength(0);
            int tamanoDeColumnas = matriz.GetLength(1);

            for (int i = 0; i < tamanoDeFilas; i++)
            {
                for (int j = 0; j < tamanoDeColumnas; j++)
                {
                    if (matriz[i,j] == 'T')
                    {
                        bool casillaIzquierdaDisparada = false;
                        bool casillaDerechaDisparada = false;
                        bool casillaInferiorDisparada = false;
                        bool casillaSuperiorDisparada = false;
                        char casillaVacia = '\u0000';

                        if (i != 0)//n
                        {
                            casillaIzquierdaDisparada = (matriz[i-1,j] == 'T');
                        }
                        if(i != tamanoDeFilas-1)//e
                        {
                            casillaDerechaDisparada = (matriz[i+1,j] == 'T');
                        }
                        if (j != 0)//f
                        {
                            casillaSuperiorDisparada = (matriz[i,j-1] == 'T');
                        }
                        if (j != tamanoDeColumnas-1)//g
                        {
                            casillaInferiorDisparada = (matriz[i,j+1] == 'T');
                        }
                        bool sinAlrededoresDanada = !(casillaIzquierdaDisparada || casillaDerechaDisparada || casillaInferiorDisparada || casillaSuperiorDisparada);
                        bool barcoVertical = (casillaInferiorDisparada ^ casillaSuperiorDisparada);
                        bool barcoHorizontal = (casillaIzquierdaDisparada ^ casillaDerechaDisparada);
                        
                        if (sinAlrededoresDanada)
                        {
                            if (i != 0 )//n
                            {
                                if (matriz[i-1,j] == casillaVacia)
                                {
                                    matriz[i-1,j] = '-';
                                }
                                
                            }
                            if(i != tamanoDeFilas-1 )//e
                            {
                                if (matriz[i+1,j] == casillaVacia)
                                {
                                    matriz[i+1,j] = '-';
                                }
                                
                            }
                            if (j != 0 )//f
                            {
                                if (matriz[i,j-1] == casillaVacia)
                                {
                                    matriz[i,j-1] = '-';
                                }
                            }
                            if (j != tamanoDeColumnas-1 )//g
                            {
                                if (matriz[i,j+1] == casillaVacia)
                                {
                                    matriz[i,j+1] = '-';
                                }
                            }
                        }
                        else 
                        {
                            if (barcoVertical)
                            {
                                if (j != 0 && !casillaSuperiorDisparada )//f
                                {
                                    if (matriz[i,j-1] == casillaVacia)
                                    {
                                        matriz[i,j-1] = '-';
                                    }
                                }
                                if (j != tamanoDeColumnas-1  && !casillaInferiorDisparada )//g
                                {
                                    if (matriz[i,j+1] == casillaVacia)
                                    {
                                        matriz[i,j+1] = '-';
                                    }
                                }
                            }
                            if (barcoHorizontal)
                            {
                                if (i != 0 && !casillaIzquierdaDisparada )//n
                                {
                                    if (matriz[i-1,j] == casillaVacia)
                                    {
                                        matriz[i-1,j] = '-';
                                    }
                                }
                                if(i != tamanoDeFilas-1 && !casillaDerechaDisparada)//e
                                {
                                    if (matriz[i+1,j] == casillaVacia)
                                    {
                                        matriz[i+1,j] = '-';
                                    }
                                }
                            }
                        }
                        
                    }
                }
            }
            return matriz;
        }
    }
}
