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
        public List<int[]> CantidadDeBarcosPosicionados = new List<int[]>();
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
                actualizarCantidadDeBarcosPosicionados(CoordenadasQueSeQuierenUtilizar);
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
        public void Atacar(int fila, int columna)
        {
            if (ExisteBarcoEnEsaPosicion(fila, columna))
            {
                int[] coordenadaARemover = new int[2];
    
                Barco BarcoHundido= null;
                foreach (Barco posibleObjetivo in barcos)
                {
                    if (posibleObjetivo.VerSiCasillaFormaParte(fila, columna))
                    {   
                        char respuestaDeBarco = posibleObjetivo.Dañar(fila, columna);
                        switch(respuestaDeBarco)
                        {
                            case 'D':
                                coordenadaARemover[0] = fila;
                                coordenadaARemover[1] = columna;
                                this.matriz[fila, columna] = 'T';
                                
                                
                                break;
                            case 'T':
                                //Dejo el caso por si mas adelante queremos que haga algo cuando se ataca una coordenada dañada
                                break;
                            case 'H':
                                coordenadaARemover[0] = fila;
                                coordenadaARemover[1] = columna;
                                this.matriz[fila, columna] = 'T';
                                BarcoHundido =posibleObjetivo;
                                break;
                        }
                    }
                }
                if (BarcoHundido !=null)
                {
                    this.BarcoHundido(BarcoHundido.ObtenerPartesDeBarcoHundido(), BarcoHundido, coordenadaARemover);
                }
            }
            else
            {
            matriz[fila,columna] = 'W';
            }
        }
        public void BarcoHundido(List<int[]> partesDeBarcoACambiar, Barco barcoEliminado, int[] coordenadaARemover)
        {
            foreach (int[] coordenada in partesDeBarcoACambiar)
            {
                int CoordenadaFila = coordenada[0];
                int Coordenadacolumna = coordenada[1];
                matriz[CoordenadaFila ,Coordenadacolumna] = 'H';
            }
            barcos.Remove(barcoEliminado);
            this.TerminoTablero();
        }
        public void TerminoTablero()
        {
            if (this.barcos.Count==0)
            {
                this.terminado = true;
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
            char[ , ] MatrizConBarcos = matriz.Clone() as char[ , ];
            foreach (int[] coordenadas in this.CantidadDeBarcosPosicionados)
            {
                int i = coordenadas[0];
                int j = coordenadas[1];
                if( MatrizConBarcos[i,j] == '\u0000' )
                {
                    MatrizConBarcos[i,j] = 'B';
                }
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
                    int [] nuevaCoordenada = new int[]{filaInicio,i};
                    CoordenadasDelBarco.Add(nuevaCoordenada);
                }
            }
            else
            {
                for (int i = filaInicio; i <= filaFinal; i++)
                {
                    int [] nuevaCoordenada = new int[]{i,columnaInicio};
                    CoordenadasDelBarco.Add(nuevaCoordenada);
                }
            }
            return CoordenadasDelBarco;
        }
        private bool ExisteBarcoEnEsaPosicion(int fila, int columna)
        {
            int [] posibleBarco = new int[]{fila,columna};
            foreach(int[] CoordenadasAnteriores in this.CantidadDeBarcosPosicionados)
            {
                if(posibleBarco[0] == CoordenadasAnteriores[0] && posibleBarco[1] == CoordenadasAnteriores[1])
                {
                    return true;
                }
            }
            return false;
        }
        private void actualizarCantidadDeBarcosPosicionados(List<int[]> CoordenadasDeNuevoBarco)
        {
            foreach (int[] coordenadaDeParteDeBarco in CoordenadasDeNuevoBarco)
            {
                    this.CantidadDeBarcosPosicionados.Add(coordenadaDeParteDeBarco);
            }
        }
        private bool noHayColisiónDeBarcos(int filaInicio, int columnaInicio, int filaFinal, int columnaFinal, List<int[]> CoordenadasQueSeQuierenUtilizar)
        {

            foreach (int[] CoordenadasQueQuieroUsar in CoordenadasQueSeQuierenUtilizar)
            {
                foreach(int[] CoordenadasAnteriores in this.CantidadDeBarcosPosicionados)
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
