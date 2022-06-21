namespace ClassLibrary
{
    /// <summary>
    /// Clase encargada de guardar las caracteristicas 
    /// basicas de un barco y administrarlos.
    /// </summary>
    public class Barco
    {
        /// <summary>
        /// Atributo para guardar el lugar de inicio del barco.
        /// </summary>
        private int[] inicio;
        /// <summary>
        /// Atributo para guardar el lugar del final del barco.
        /// </summary>
        private int[] final;
        /// <summary>
        /// Atributo para ver las partes del barco que estan enteras.
        /// </summary>
        private char[] partes;
        /// <summary>
        /// Atributo para poder ver las coordenadas ocupadas por el barco.
        /// </summary>
        private int[][] casillasOcupadas;
        /// <summary>
        /// Atributo Encargado de guardar la cantidad de casillas que ocupa el largo.
        /// </summary>
        private int largo;
        /// <summary>
        /// Atributo Encargado de guardar la orientacion del barco para utilizarlo en los diferentes metodos.
        /// </summary>
        private string orientacion;
        private Barco( int[] inicioDeBarco , int[] finalDeBarco)
        {
            this.inicio = inicioDeBarco;
            this.final = finalDeBarco;
            this.largo = Calcularlargo(inicio, final);
            this.partes = new char[ this.largo ];
            for (int i=0; i< this.largo ; i++)
            {
                this.partes[i] = 'B';
            }
            this.casillasOcupadas = new int[this.largo][];
            this.anotarLugarDeBarco();
            
        }
        /// <summary>
        /// Metodo Utilizado por el tablero para Dañar a un barco
        /// </summary>
        /// <param name="ataque"></param>
        /// <returns></returns>
        public char Dañar(int [] ataque)
        {
            if (this.verSiCasillaFormaParte(ataque))
            {
                if (this.orientacion == "Horizontal")
                {
                    if (this.partes[ataque[1]] == 'B')
                    {
                        this.partes[ataque[1]] = 'X';
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
                    if (this.partes[ataque[0]] == 'B')
                    {
                        this.partes[ataque[0]] = 'X';
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
            return '\u0000';            
                
        }
        /// <summary>
        /// Metodo utilizado por tablero para obtener los lugares ocupados por el barco.
        /// </summary>
        /// <returns></returns>
        public int[][] ObtenerPartesDeBarco()
        {
            return this.casillasOcupadas;
        }
        /// <summary>
        /// Metodo con la responsabilidad de calcular el largo del barco.
        /// </summary>
        /// <param name="inicioDeBarco"></param>
        /// <param name="finalDeBarco"></param>
        /// <returns></returns>
        private int Calcularlargo(int[] inicioDeBarco , int[] finalDeBarco)
        {
            if(inicio[0] == final[0])
            {
                this.orientacion = "Horizontal";
                return inicio[1] -  final[1];
            }
            else
            {
                this.orientacion = "Vertical";
                return inicio[0] - final[0];
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
        /// Metodo encargado de completar el Array casillasOcupadas con
        /// las coordendas que ocupa el barco en el tablero.
        /// </summary>
        private void anotarLugarDeBarco()
        {
            int espacioDeCoordenada = 0;
            if (this.orientacion == "Horizontal")
            {
                for (int i = this.inicio[0]; i < this.final[0]; i++)
                {
                    int[] NuevaCoordenada = new int [2];
                    NuevaCoordenada[0] = i;
                    NuevaCoordenada[1] = inicio[1];
                    this.casillasOcupadas[espacioDeCoordenada] = NuevaCoordenada;
                    espacioDeCoordenada++;
                }
            }
            else if (this.orientacion == "Vertical")
            {
                for(int j = this.inicio[1]; j < this.final[1]; j++)
                {
                    int[] NuevaCoordenada = new int [2];
                    NuevaCoordenada[0] = inicio[0];
                    NuevaCoordenada[1] = j;
                    this.casillasOcupadas[espacioDeCoordenada] = NuevaCoordenada;
                    espacioDeCoordenada++;
                }
            }
        }
        /// <summary>
        /// Metodo responsable de ver si una casilla es parte del barco.
        /// </summary>
        /// <param name="posibleParteDeBarco"></param>
        /// <returns></returns>

        private bool verSiCasillaFormaParte(int[] posibleParteDeBarco)
        {
            foreach (int[] parteDeBarco in casillasOcupadas)
            {
                if (parteDeBarco == posibleParteDeBarco)
                {
                    return true;
                }
            }
            return false;
        }
    }
}