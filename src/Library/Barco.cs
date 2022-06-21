using System.Collections.Generic;
using System;
namespace ClassLibrary
{
    /// <summary>
    /// Clase encargada de guardar las caracteristicas 
    /// basicas de un barco y administrarlos.
    /// </summary>
    public class Barco
    {
        /// <summary>
        /// Atributo para ver las partes del barco que estan enteras.
        /// </summary>
        private char[] partes;
        /// <summary>
        /// Atributo para poder ver las coordenadas ocupadas por el barco.
        /// </summary>
        private List<int[]> casillasSinHundir;
        /// <summary>
        /// Atributo para poder ver las coordenadas ocupadas por el barco.
        /// </summary>
        private List<int[]> casillasOcupadas;
        /// <summary>
        /// Atributo Encargado de guardar la cantidad de casillas que ocupa el largo.
        /// </summary>
        private int largo;
        /// <summary>
        /// Atributo Encargado de guardar la orientacion del barco para utilizarlo en los diferentes metodos.
        /// </summary>
        private string orientacion;
        /// <summary>
        /// Constructor de la clase barco.
        /// </summary>
        /// <param name="filaInicio"></param>
        /// <param name="columnaInicio"></param>
        /// <param name="filaFinal"></param>
        /// <param name="columnaFinal"></param>
        /// <param name="coordenadasAUtilizar"></param>
        public Barco(int filaInicio, int columnaInicio, int filaFinal, int columnaFinal, List<int[]> coordenadasAUtilizar)
        {
            this.largo = Calcularlargo(filaInicio, columnaInicio, filaFinal, columnaFinal);

            this.partes = new char[this.largo+1];

            for (int i=0; i <= this.largo ; i++)
            {
                this.partes[i] = 'B';
            }
            this.casillasSinHundir = coordenadasAUtilizar;
            this.casillasOcupadas = coordenadasAUtilizar;           
        }
        /// <summary>
        /// Metodo Utilizado por el tablero para Dañar a un barco.
        /// </summary>
        /// <param name="filaAtaque"></param>
        /// <param name="columnaAtaque"></param>
        /// <returns></returns>
        public char Dañar(int filaAtaque, int columnaAtaque)
        {
            if (this.orientacion == "Horizontal")
            {
                if (this.partes[columnaAtaque] == 'B')
                {
                    this.partes[columnaAtaque] = 'X';
                    int[] casillaAEliminar = new int [2] {filaAtaque, columnaAtaque };

                    if (this.hundido())
                    {
                        return 'H';
                    }
                    return 'D';
                }
                else
                {
                    return 'T';
                }
                
            }
            else
            {
                if (this.partes[filaAtaque] == 'B')
                {
                    this.partes[filaAtaque] = 'X';

                    int[] casillaAEliminar = new int [2] {filaAtaque, columnaAtaque };
                    
                    if (this.hundido())
                    {
                        return 'H';
                    }
                    return 'D';
                }
                else
                {
                    return 'T';
                }
                
            }
            
                
        }
        /// <summary>
        /// Metodo utilizado por tablero para obtener los lugares ocupados por el barco.
        /// </summary>
        /// <returns></returns>
        public List<int[]> ObtenerPartesDeBarcoHundido()
        {
            return this.casillasOcupadas;
        }
        /// <summary>
        ///  Metodo con la responsabilidad de calcular el largo del barco.
        /// </summary>
        /// <param name="filaInicio"></param>
        /// <param name="columnaInicio"></param>
        /// <param name="filaFinal"></param>
        /// <param name="columnaFinal"></param>
        /// <returns></returns>
        private int Calcularlargo(int filaInicio, int columnaInicio, int filaFinal, int columnaFinal)
        {
            if(filaInicio == filaFinal)
            {
                this.orientacion = "Horizontal";
                return columnaFinal -  columnaInicio;
            }
            else
            {
                this.orientacion = "Vertical";
                return filaFinal - filaInicio;
            }
        }
        /// <summary>
        /// Metodo encargado de verificar si a un barco 
        /// no le quedan partes sin dañar.
        /// </summary>
        /// <returns></returns>
        private bool hundido()
        {
            foreach (char parte in this.partes)
            {
                if (parte == 'B')
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Metodo responsable de ver si una casilla es parte del barco.
        /// </summary>
        /// <param name="filaAtaque"></param>
        /// <param name="columnaAtaque"></param>
        /// <returns></returns>

        public bool VerSiCasillaFormaParte(int filaAtaque, int columnaAtaque)
        {
            int[] posibleParteDeBarco = new int[2];
            posibleParteDeBarco[0] = filaAtaque;
            posibleParteDeBarco[1] = columnaAtaque;

            foreach (int[] parteDeBarco in casillasSinHundir)
            {
                if (parteDeBarco[0] == posibleParteDeBarco[0] && parteDeBarco[1] == posibleParteDeBarco[1])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
