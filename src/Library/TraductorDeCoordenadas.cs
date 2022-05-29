using System;

namespace ClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class TraductorDeCoordenadas
    {
        /// <summary>
        /// Transforma las coordenadas introducidas por el usuario en en un int[,]
        /// </summary>
        /// <param name="coordenada"></param>
        /// <returns></returns>
        public int[] Traducir(string coordenada)
        {
            int[] traducido = new int[1];
            string[] letras = ["A","B","C","D","E","F","G","H","I","J","K","L","M","N","O"];
            int i = 0;
            while (coordenada.Substring(0).ToUpper() != letras[i])
            {
                i = i + 1;
            }
            traducido[0] = i+1;
            i = 1;
            while (coordenada[1] != i)
            {
                i = i + 1;
            }
            traducido[1] = i;
            return traducido;
        }
    }
}