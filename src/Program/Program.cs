//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;
using ClassLibrary;

namespace ConsoleApplication
{
    /// <summary>
    /// Programa de consola de demostración.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Punto de entrada al programa principal.
        /// </summary>
        public static void Main()
        {
            Tablero tab = new Tablero(8,1);
            /*int[] amanda = new int [2];
            amanda[0] = 3;
            amanda[1] = 4;
            int[] franco = new int [2];
            franco[0] = 8;
            franco[1] = 4;*/
            int[] amanda = TraductorDeCoordenadas.Traducir("E3");
            int[] franco =TraductorDeCoordenadas.Traducir("E8");

            int[] seba = TraductorDeCoordenadas.Traducir("A1");
            int[] Santi =TraductorDeCoordenadas.Traducir("A5");

            Console.WriteLine(Logica.AtacarCasilla(tab,seba[0],seba[1]));
            Logica.Añadirbarco(tab,amanda,franco);
            Console.WriteLine(Logica.AtacarCasilla(tab,Santi[0],Santi[1]));
            ImpresoraConsola.ImprimirTablero(tab.VerTablero(1));
        }
    }
}