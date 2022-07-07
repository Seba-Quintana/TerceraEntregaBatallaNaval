﻿using System;
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
        /// Int que representa la cantidad de disparos realizados a lugares donde habian barcos
        /// </summary>
        protected int cantidadDeDisparosAlAgua{get;set;} = 0;
        /// <summary>
        /// Int que representa la cantidad de disparos realizados al agua por ambos jugadores
        /// </summary>
        public int CantidadDeDisparosAlAgua{get{return cantidadDeDisparosAlAgua;}}
        /// <summary>
        /// Int que representa la cantidad de disparos realizados a lugares donde habian barcos
        /// </summary>
        protected int cantidadDeDisparosABarcos{get;set;} = 0;
        /// <summary>
        /// Int que representa la cantidad de disparos realizados a lugares donde habian barcos
        /// </summary>
        public int CantidadDeDisparosABarcos{get{return cantidadDeDisparosABarcos;}}
        /// <summary>
        /// Este atributo sirve para saber el tamaño de la matriz sin tener que recurrir a metodos que midan su tamaño
        /// </summary>
        public int Tamano{get;}
        /// <summary>
        /// Este ArrayList de char es donde esta contenido una gran parte de los datos del juego (contiene el tablero).
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
        public int DuenodelTablero;
        /// <summary>
        /// Variable que facilita saber si el dueño del tablero fue quien gano la partida.
        /// </summary>
        public bool Ganada= false;
        /// <summary>
        /// Todas las coordenadas donde hay barcos
        /// </summary>
        /// <returns></returns>
        public List<int[]> CoordenadasDeBarcosPosicionados = new List<int[]>();
        /// <summary>
        /// Contador de cuantas partes dañadas hay en el tablero.
        /// </summary>
        public int CantidadPartesBarcoDañadas = 0;
        /// <summary>
        /// Constructor de tableros, crea una matriz en base al tamaño que le diga quien llame al metodo
        /// </summary>
        /// <param name="tamano"> tamaño que sera el tablero </param>
        /// <param name="dueno"> dueño del tablero </param>
        public Tablero(int tamano, int dueno)
        {
            this.Tamano = tamano;
            this.matriz = new char[tamano, tamano];
            this.DuenodelTablero = dueno;
        }
        /// <summary>
        /// Metodo Utilizado por el tablero para añadir un barco.
        /// </summary>
        /// <param name="filaInicio"></param>
        /// <param name="columnaInicio"></param>
        /// <param name="filaFinal"></param>
        /// <param name="columnaFinal"></param>
        /// <returns></returns>
        public bool AgregarBarco(int filaInicio, int columnaInicio, int filaFinal, int columnaFinal)
        {
            List<int[]> CoordenadasQueSeQuierenUtilizar = this.EspaciosAUtilizar(filaInicio, columnaInicio, filaFinal, columnaFinal);

            if (this.noHayColisiónDeBarcos(CoordenadasQueSeQuierenUtilizar))
            {
                Barco nuevoBarco = new Barco(filaInicio, columnaInicio, filaFinal, columnaFinal, CoordenadasQueSeQuierenUtilizar);
                this.barcos.Add(nuevoBarco);
                actualizarCoordenadasDeBarcosPosicionados(CoordenadasQueSeQuierenUtilizar);
                return true;
            }
            return false;
        }
       
        /// <summary>
        /// Metodo el cual se ejecuta para cambiar un punto de la matriz.
        /// </summary>
        /// <param name="fila"></param>
        /// <param name="columna"></param>
        public char Atacar(int fila, int columna)
        {
            bool objetivoCasillaVacia = casillaVacia(fila,columna);

            if (ExisteBarcoEnEsaPosicion(fila, columna))
            {
                int[] coordenadaARemover = new int[2];
    
                Barco barcoHundido= null;
                foreach (Barco posibleObjetivo in barcos)
                {
                    if (posibleObjetivo.ParteDelBarco(fila, columna))
                    {   
                        char respuestaDeBarco = posibleObjetivo.Danar(fila, columna);
                        switch(respuestaDeBarco)
                        {
                            case 'D':
                                coordenadaARemover[0] = fila;
                                coordenadaARemover[1] = columna;
                                this.matriz[fila, columna] = 'T';
                                CantidadPartesBarcoDañadas += 1;
                                break;
                            case 'T':
                                //Dejo el caso por si mas adelante queremos que haga algo cuando se ataca una coordenada dañada
                                break;
                            case 'H':
                                coordenadaARemover[0] = fila;
                                coordenadaARemover[1] = columna;
                                this.matriz[fila, columna] = 'T';
                                CantidadPartesBarcoDañadas += 1;
                                barcoHundido =posibleObjetivo;
                                break;
                        }
                    }
                }
                if (barcoHundido !=null)
                {
                    this.barcoHundido(barcoHundido.ObtenerPartesDeBarcoHundido(), barcoHundido);
                }
            }
            else
            {
                this.cantidadDeDisparosAlAgua+=1;
                matriz[fila,columna] = 'W';
            }
            if (matriz[fila,columna] == 'H' || matriz[fila,columna] == 'T')
                this.cantidadDeDisparosABarcos+=1;
            if (objetivoCasillaVacia)
            {
                
                return matriz[fila,columna];
            }
            else
            {
                char coordenadaChar = matriz[fila,columna];
                string coordenadaStr = (coordenadaChar.ToString()).ToLower();
                char coordenadaFinal = Convert.ToChar(coordenadaStr);
                return coordenadaFinal;
            }
        }
        private bool casillaVacia(int fila, int columna)
        {
            return matriz[fila,columna] == '\u0000';
        }
        /// <summary>
        /// Metodo encargado de hacer lo necesario cuando un barco es hundido
        /// </summary>
        /// <param name="partesDeBarcoACambiar"></param>
        /// <param name="barcoEliminado"></param>
        public void barcoHundido(List<int[]> partesDeBarcoACambiar, Barco barcoEliminado)
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
        /// <summary>
        /// Metodo encargado de ver si la partida a terminado y cambiar el atributo de terminado a true.
        /// </summary>
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
            foreach (int[] coordenadas in this.CoordenadasDeBarcosPosicionados)
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
            foreach(int[] CoordenadasAnteriores in this.CoordenadasDeBarcosPosicionados)
            {
                if(posibleBarco[0] == CoordenadasAnteriores[0] && posibleBarco[1] == CoordenadasAnteriores[1])
                {
                    return true;
                }
            }
            return false;
        }
        private void actualizarCoordenadasDeBarcosPosicionados(List<int[]> CoordenadasDeNuevoBarco)
        {
            foreach (int[] coordenadaDeParteDeBarco in CoordenadasDeNuevoBarco)
            {
                    this.CoordenadasDeBarcosPosicionados.Add(coordenadaDeParteDeBarco);
            }
        }
        private bool noHayColisiónDeBarcos(List<int[]> CoordenadasQueSeQuierenUtilizar)
        {

            foreach (int[] CoordenadasQueQuieroUsar in CoordenadasQueSeQuierenUtilizar)
            {
                if (ExisteBarcoEnEsaPosicion(CoordenadasQueQuieroUsar[0],CoordenadasQueQuieroUsar[1]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
