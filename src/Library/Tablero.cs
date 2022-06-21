using System;
using System.Linq;
using System.Collections.Generic;

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
        /// Lista encargada de guardar los barcos enteros que existen en el tablero.
        /// </summary>
        /// <returns></returns>
        public List<Barco> barcos = new List<Barco>();
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
        public bool AñadirBarco(int filaInicio, int columnaInicio, int filaFinal, int columnaFinal)
        {
            List<int[]> CoordenadasQueSeQuierenUtilizar = this.EspaciosAUtilizar(filaInicio, columnaInicio, filaFinal, columnaFinal);
            if (this.noHayColisiónDeBarcos(filaInicio, columnaInicio, filaFinal, columnaFinal, CoordenadasQueSeQuierenUtilizar))
            {
                Barco nuevoBarco = new Barco(filaInicio, columnaInicio, filaFinal, columnaFinal, CoordenadasQueSeQuierenUtilizar);
                this.barcos.Add(nuevoBarco);
                return true;
            }
            return false;
        }
       
        /// <summary>
        /// Metodo el cual se ejecuta para cambiar un punto de la matriz.
        /// </summary>
        /// <param name="fila"></param>
        /// <param name="columna"></param>
        /// <param name="nuevovalor"></param>
        /*public void ActualizarTablero(int fila, int columna, char nuevovalor)
        {
            if ()
            {
                if (nuevovalor == 'B')
                {
                    
                }
                else if (nuevovalor == 'A')
                {
                    if (matriz[fila, columna] == 'B')
                    {
                        this.matriz[fila, columna] = 'T';
                        //this.CantidadDeBarcosEnteros -= 1;
                        if (barcos.Count==0){terminado=true;}

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
        }*/
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
            char[ , ] MatrizConBarcos = matriz.Clone() as char[ , ];
            foreach (int[] coordenadas in this.EspaciosUtilizados())
            {
                int i = coordenadas[0];
                int j = coordenadas[1];
                MatrizConBarcos[i,j] = 'B';
            }

            return MatrizConBarcos;
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
        private List<int[]> EspaciosAUtilizar(int filaInicio, int columnaInicio, int filaFinal, int columnaFinal)
        {
            List<int[]> CoordenadasDelBarco = new List<int[]>();
            if (filaInicio == filaFinal)
            {
                for (int i = columnaInicio; i <= columnaFinal; i++)
                {
                    int[] nuevaCoordenada = new int[2];
                    nuevaCoordenada[0] = filaInicio;
                    nuevaCoordenada[1] = i;
                    CoordenadasDelBarco.Add(nuevaCoordenada);
                }
            }
            else
            {
                for (int i = filaInicio; i <= filaFinal; i++)
                {
                    int[] nuevaCoordenada = new int[2];
                    nuevaCoordenada[0] = i;
                    nuevaCoordenada[1] = columnaInicio;
                    CoordenadasDelBarco.Add(nuevaCoordenada);
                }
            }
            return CoordenadasDelBarco;
        }
        private List<int[]> EspaciosUtilizados()
        {
            List<int[]> EspaciosUtilizadosAnteriormente = new List<int[]>();

            foreach(Barco barco in barcos)
            {
                List<int[]>PartesdeunBarco = barco.ObtenerPartesDeBarco();
                
                foreach (int[] coordenadaDeParteDeBarco in PartesdeunBarco)
                {
                    EspaciosUtilizadosAnteriormente.Add(coordenadaDeParteDeBarco);
                }
            }
            return EspaciosUtilizadosAnteriormente;
        }
        private bool noHayColisiónDeBarcos(int filaInicio, int columnaInicio, int filaFinal, int columnaFinal, List<int[]> CoordenadasQueSeQuierenUtilizar)
        {
            List<int[]> CoordenadasUtilizadosAnteriormente = this.EspaciosUtilizados();

            foreach (int[] CoordenadasQueQuieroUsar in CoordenadasQueSeQuierenUtilizar)
            {
                foreach(int[] CoordenadasAnteriores in CoordenadasUtilizadosAnteriormente)
                {
                    if (CoordenadasQueQuieroUsar[0] == CoordenadasAnteriores[0] && CoordenadasQueQuieroUsar[1] == CoordenadasAnteriores[1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        
    }
}
