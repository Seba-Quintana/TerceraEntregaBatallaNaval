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
            int[] traducido = new int[2];
            List<string> letras = new List<string> () {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O"};
            int i = 0;
            while ((i < letras.Count) && (coordenada.Substring(0,1).ToUpper() != letras[i]))
            {
                i = i + 1;
            }
            traducido[0] = i;
            traducido[1] = (int)Char.GetNumericValue(coordenada[1]) - 1;
            Console.WriteLine($"{coordenada[1]} y {traducido[1]}");
            return traducido;
        }
    }
}