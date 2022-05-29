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
        protected int tamaño;
        /// <summary>
        /// Este ArrayList de char es donde esta contenido una gran parte de los datos del juego.
        /// </summary>
        protected char[,] matriz;
        /// <summary>
        /// Este atributo contiene el numero de ataques efectuados hacia el tablero.
        /// </summary>
        public int tiradas = 0;
        /// <summary>
        /// Este atributo se encarga de mostrar el estado terminado de la partida, normalmente esta en false.
        /// </summary>
        public bool terminado = false;
        /// <summary>
        /// En este atributo se ve el numero de jugador de quien es el dueño del tablero, osea el que puede ver la informacion de los barcos intactos principalmente.
        /// </summary>
        public int DueñodelTablero;
        /// <summary>
        /// Variable que facilita saber quien es el ganador de la partida cuando se almacena.
        /// </summary>
        public bool Ganador = false;
        /// <summary>
        /// Constructor de tableros, crea una matriz en base al tamaño que le diga quien llame al metodo
        /// </summary>
        /// <param name="Tamaño"></param>
        /// <param name="dueño"></param>
        public Tablero(int Tamaño, int dueño)
        {
            this.tamaño = Tamaño;
            this.matriz = new char[tamaño, tamaño];
            this.DueñodelTablero = dueño;
        }
        /// <summary>
        /// Metodo el cual se ejecuta para cambiar un punto de la matriz.
        /// </summary>
        /// <param name="filas"></param>
        /// <param name="columnas"></param>
        /// <param name="nuevovalor"></param>
        public void ActualizarTablero(int filas, int columnas, char nuevovalor)
        {
            if (filas <= this.tamaño && columnas <= this.tamaño)
            {
                if (nuevovalor == 'B')
                {
                    matriz[filas, columnas] = nuevovalor;
                }
                else if (nuevovalor == 'A')
                {
                    if (matriz[filas, columnas] == 'B' || matriz[filas, columnas] == 'T')
                    {
                        matriz[filas, columnas] = 'T';
                    }
                    else
                    {
                        matriz[filas, columnas] = 'W';
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
        public string VerCasilla(int columna, int fila)
        {
            switch (matriz[columna, fila])
            {
                case 'W':
                    return "La casilla ya habia sido atacada y contiene Agua";
                case 'T':
                    return "La casilla ya habia sido atacada y hay una parte de barco dañada";
                case 'B':
                    return "Buen tiro, has atacado a un barco";
            }
            return "Que lastima!! has disparado al agua";
        }
        /// <summary>
        /// Metodo encargado de retornar una copia de la matriz para luego ser impresa.
        /// </summary>
        /// <param name="usuarioqueconsulta"></param>
        /// <returns></returns>
        public char[,] VerTablero(int usuarioqueconsulta)
        {
            // polimorfismo
            return matriz;
        }
        /// <summary>
        /// Metodo llamado para Finalizar
        /// </summary>
        public void Finalizar()
        {
            DatosdePartida partida = new DatosdePartida();
            partida.Almacenar(this);
        }
    }
}