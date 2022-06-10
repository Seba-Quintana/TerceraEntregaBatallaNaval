using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Muestra por consola todo lo que desee imprimir implementando la interfaz Iimpresora con una operación polimórfica.
    /// </summary>
    public class ImpresoraConsola : Iimpresora
    {
        private static ImpresoraConsola impresoraConsola  = null; 
 
        private ImpresoraConsola()
        {
        }

        public static ImpresoraConsola Instance()
        {
            if (impresoraConsola == null)
                impresoraConsola = new ImpresoraConsola();
      
            return impresoraConsola;
        }
        /// <summary>
        /// Imprime el tablero en consola agregandole indices de coordenadas
        /// </summary>
        /// <param name="tablero"></param>
        public void ImprimirTablero(char[,] tablero)
        {
            string filaImprimir = "  ";
            List<string> letras = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O" };
            Console.WriteLine(filaImprimir);
            for (int i = 0; i < tablero.GetLength(1); i++)
            {
                if (i < 10)
                {
                    filaImprimir = filaImprimir + $" {i + 1} ";
                }
                else
                {
                    filaImprimir = filaImprimir + $"{i + 1} ";
                }
            }
            Console.WriteLine(filaImprimir);
            for (int fila = 0; fila < tablero.GetLength(0); fila++)
            {
                filaImprimir = letras[fila] + " ";
                for (int columna = 0; columna < tablero.GetLength(1); columna++)
                {
                    switch (tablero[fila, columna])
                    {
                        case 'W':
                            filaImprimir = filaImprimir + " " + "W ";
                            break;
                        case 'T':
                            filaImprimir = filaImprimir + " " + "T ";
                            break;
                        case 'B':
                            filaImprimir = filaImprimir + " " + "B ";
                            break;
                        default:
                            filaImprimir = filaImprimir + " " + "X ";
                            break;
                    }
                }
                Console.WriteLine(filaImprimir);
            }
        }
        /// <summary>
        /// Imprime los datos publicos de los usuarios en consola
        /// </summary>
        /// <param name="perfil"></param>
        public void ImprimirPerfilUsuario(PerfilUsuario perfil)
        {
            Console.WriteLine($"Nombre: {perfil.Nombre}");
            Console.WriteLine($"Ganadas: {perfil.Ganadas}");
            Console.WriteLine($"Nombre: {perfil.Perdidas}");
        }
        /// <summary>
        /// Imprime el historial de todas las partidas jugadas en consola
        /// </summary>
        /// <param name="partidas"></param>
        public void ImprimirHistorial(List<DatosdePartida> partidas)
        {
            Admin ad = Admin.Instance();
            foreach (DatosdePartida partida in partidas)
            {
                foreach (Tablero tablero in partida.Tableros)
                {
                    ad.ObtenerTablero(tablero.DueñodelTablero);
                }
                Console.WriteLine($"Ganador: {ad.ObtenerPerfil(partida.Ganador).Nombre}");
                Console.WriteLine($"Perdedor: {ad.ObtenerPerfil(partida.Perdedor).Nombre}");
            }
        }
        /// <summary>
        /// Imprime en consola un ranking, en el que los perfiles tienen posiciones ordenados segun batallas ganadas
        /// </summary>
        public void ImprimirRanking(List<PerfilUsuario> perfiles)
        {
            int puesto = 1;
            foreach (PerfilUsuario perfil in perfiles)
            {
                Console.WriteLine($"N° {puesto}: {perfil.Nombre} con {perfil.Ganadas} batallas ganadas");
                puesto = puesto + 1;
            }
        }
    }
}