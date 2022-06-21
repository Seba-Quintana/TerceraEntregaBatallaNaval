using System;

namespace ClassLibrary
{
    /// <summary>
    /// Clase encargada de manejar el espacio de juego.
    /// </summary>
    public class Tablero
    {
        /// <summary>
        /// Este atributo sirve para saber el tamaño de la matriz sin tener que recurrir a metodos que midan su tamaño
        /// </summary>
        public int Tamaño{get;}
        /// <summary>
        /// Este ArrayList de char es donde esta contenido una gran parte de los datos del juego.
        /// </summary>
        protected char[,] matriz;
        /// <summary>
        /// Este atributo se encarga de mostrar el estado terminado de la partida, normalmente esta en false.
        /// </summary>
        public bool terminado = false;
        /// <summary>
        /// Representa la cantidad de partes de barco sin dañar.
        /// </summary>
        public int CantidadDeBarcosEnteros;
        /// <summary>
        /// En este atributo se ve el numero de jugador de quien es el dueño del tablero, osea el que puede ver la informacion de los barcos intactos principalmente.
        /// </summary>
        public int DueñodelTablero;
        /// <summary>
        /// Variable que facilita saber si el dueño del tablero fue quien gano la partida.
        /// </summary>
        public bool Ganada= false;
        /// <summary>
        /// Constructor de tableros, crea una matriz en base al tamaño que le diga quien llame al metodo
        /// </summary>
        /// <param name="tamaño"></param>
        /// <param name="dueño"></param>
        public Tablero(int tamaño, int dueño)
        {
            this.Tamaño = tamaño;
            this.matriz = new char[tamaño, tamaño];
            this.DueñodelTablero = dueño;
        }
        /// <summary>
        /// Metodo el cual se ejecuta para cambiar un punto de la matriz.
        /// </summary>
        /// <param name="fila"></param>
        /// <param name="columna"></param>
        /// <param name="nuevovalor"></param>
        public void ActualizarTablero(int fila, int columna, char nuevovalor)
        {
            if (fila <= this.Tamaño && columna <= this.Tamaño)
            {
                if (nuevovalor == 'B')
                {
                    if (this.matriz[fila, columna] == '\u0000')//Mira que el espacio asignado este vacio antes de poner un Barco
                    {
                        this.matriz[fila, columna] = 'B';
                        //this.CantidadDeBarcosEnteros+=1;
                    }
                    else if (this.matriz[fila, columna]== 'B')
                    {
                        this.matriz[fila, columna] = 'T';
                        //this.CantidadDeBarcosEnteros-=1;
                    }
                }
                else if (nuevovalor == 'A')
                {
                    if (matriz[fila, columna] == 'B')
                    {
                        this.matriz[fila, columna] = 'T';
                        //this.CantidadDeBarcosEnteros -= 1;
                        if (CantidadDeBarcosEnteros==0){terminado=true;}

                    }
                    else if (matriz[fila, columna] == 'T')
                    {
                        this.matriz[fila, columna] = 'T';
                    }
                    else
                    {
                        matriz[fila, columna] = 'W';
                    }
                }
            }
        }
        /// <summary>
        /// Metodo utilizado por logica para ver la casilla donde se esta atacando
        /// </summary>
        /// <param name="columna"></param>
        /// <param name="fila"></param>
        /// <returns></returns>
        public char VerCasilla(int fila, int columna)
        {
            
            return (matriz[fila, columna]);
        }
        /// <summary>
        /// Metodo encargado de retornar una copia de la matriz para luego ser impresa.
        /// </summary>
        /// <returns></returns>
        public char[,] VerTablero()
        {
            return matriz.Clone() as char[ , ];
        }
        /// <summary>
        /// Metodo utilizado internamente por la clase tablero
        /// para asignar el int del dueño al ganador en caso 
        /// de que este sea el ganador
        /// </summary>
        public void Victoria()
        {
            this.Ganada = true;
        }
        
    }
}
