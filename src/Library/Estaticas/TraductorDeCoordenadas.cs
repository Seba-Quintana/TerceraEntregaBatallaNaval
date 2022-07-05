using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase se encarga de traducir las coordenadas ingresadas por el usuario a una forma en que el programa lo entienda
    /// </summary>
    public static class TraductorDeCoordenadas
    {
        /// <summary>
        /// Transforma las coordenadas introducidas por el usuario en un int[,]
        /// </summary>
        /// <param name="coordenada"></param>
        /// <returns> Devuelve la coordenada en un arreglo de int. De ser invalida, devuelve null </returns>
        public static int[] Traducir(string coordenada)
        {
            List<string> letras = new List<string> () {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O"};
            List<string> numeros = new List<string> () {"0","1","2","3","4","5","6","7","8","9"};
            if ((coordenada.Length < 2) || (coordenada.Length > 3))
            {
                return null;
            }
            if (!(letras.Contains(coordenada.Substring(0,1).ToUpper())))
            {
                return null ;
            }
            if (numeros.Contains(coordenada.Substring(1,1)) == false)
            {
                return null;
            }
            if ((coordenada.Length == 2) && coordenada[1] == '0' )
            {
                return null;
            }
            if ((coordenada.Length == 3) && (numeros.Contains(coordenada.Substring(2,1)) == false))
            {
                return null;
            }
            int[] traducido = new int[2];
            int i = 0;
            while ((i < letras.Count) && (coordenada.Substring(0,1).ToUpper() != letras[i]))
            {
                i = i + 1;
            }
            traducido[0] = i;
            if (coordenada.Length == 2)
            {
                traducido[1] = (int)Char.GetNumericValue(coordenada[1]) - 1;
            }
            else
            {
                if (coordenada[2] != 0)
                {
                    traducido[1] = (int)Char.GetNumericValue(coordenada[1])*10 + (int)Char.GetNumericValue(coordenada[2]) - 1;
                }
                else
                {
                    traducido[1] = ((int)Char.GetNumericValue(coordenada[1])-1)*10 + 9;
                }
            }
            return traducido;
        }
    }
}
