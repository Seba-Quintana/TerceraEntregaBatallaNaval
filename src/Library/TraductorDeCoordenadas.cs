using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class TraductorDeCoordenadas
    {
        /// <summary>
        /// Transforma las coordenadas introducidas por el usuario en en un int[,]
        /// </summary>
        /// <param name="coordenada"></param>
        /// <returns></returns>
        public static int[] Traducir(string coordenada)
        {
            try
            {
                if ((coordenada.Length != 2) && (coordenada.Length != 3))
                   throw new ArgumentOutOfRangeException(coordenada);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw ex;
            }
            int[] traducido = new int[2];
            List<string> letras = new List<string> () {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O"};
            int i = 0;
            while ((i < letras.Count) && (coordenada.Substring(0,1).ToUpper() != letras[i]))
            {
                i = i + 1;
            }
            if (coordenada.Length == 2)
            {
                traducido[0] = i;
                traducido[1] = (int)Char.GetNumericValue(coordenada[1]) - 1;
            }
            else
            {
                traducido[0] = i;
                traducido[1] = (int)Char.GetNumericValue(coordenada[1])*10 + (int)Char.GetNumericValue(coordenada[2]) - 1;
            }
            return traducido;
        }
    }
}