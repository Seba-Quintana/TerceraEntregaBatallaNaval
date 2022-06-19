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
            List<string> letras = new List<string> () {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O"};
            List<string> numeros = new List<string> () {"1","2","3","4","5","6","7","8","9","10","11","12","13","14","15"};
            try
            {
                if ((coordenada.Length < 2) || (coordenada.Length > 3))
                {
                   int[] a = null;
                   return a;
                }
                if (!(letras.Contains(coordenada.Substring(0,1).ToUpper())))
                {
                   int[] a = null;
                   return a ;
                }
                if (numeros.Contains(coordenada.Substring(1,1).ToUpper()) == false)
                {
                    int[] a = null;
                    return a;
                }
                if ((coordenada.Length == 3) && (numeros.Contains(coordenada.Substring(3,1).ToUpper()) == false))
                {
                    int[] a = null;
                    return a;
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw ex;
            }
            int[] traducido = new int[2];
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