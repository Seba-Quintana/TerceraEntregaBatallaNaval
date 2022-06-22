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
            this.asignadorDeOrientacion(filaInicio, filaFinal);

            this.asignadorDePartes(filaInicio, columnaInicio, filaFinal, columnaFinal);

            this.casillasSinHundir = coordenadasAUtilizar;

            this.casillasOcupadas = coordenadasAUtilizar;           
        }
        private void asignadorDePartes(int filaInicio, int columnaInicio, int filaFinal, int columnaFinal)
        {
            if (this.orientacion == "Horizontal")
            {
                this.partes = new char[columnaFinal + 1];

                for (int i=columnaInicio; i <= columnaFinal; i++)
                {
                    this.partes[i] = 'B';
                }
            }
            else
            {
                this.partes = new char[filaFinal + 1];

                for (int i=filaInicio; i <= filaFinal; i++)
                {
                    this.partes[i] = 'B';
                }
            }
        }
        private void asignadorDeOrientacion(int filaInicio, int filaFinal)
        {
            if (filaInicio==filaFinal)
            {
                this.orientacion = "Horizontal";
            }
            else
            {
                this.orientacion = "Vertical";
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

        public bool ParteDelBarco(int filaAtaque, int columnaAtaque)
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
    }
}
