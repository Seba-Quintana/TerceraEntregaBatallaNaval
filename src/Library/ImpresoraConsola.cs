using System;

namespace ClassLibrary
{
    /// <summary>
    /// Muestra por consola todo lo que desee imprimir implementando la interfaz Iimpresora con una operación polimórfica.
    /// </summary>
    public static class ImpresoraConsola
    {
        /// <summary>
        /// Imprime el tablero en consola agregandole indices de coordenadas
        /// </summary>
        /// <param name="tablero"></param>
        public static void ImprimirTablero(char[,] tablero)
        {
            string filaImprimir = "  ";
            string letras = "ABCDEFGHIJKLMNO";
            string[] numeros = new string[15];
            for (int j = 0 ; j<9 ; j++)
            {
                numeros[j] = $" {j + 1}";
            }
            for (int j = 9 ; j<numeros.Length ; j++)
            {
                numeros[j] = $"{j + 1}";
            }
            for (int i = 0; i<tablero.GetLength(1); i++)
            {
                filaImprimir = filaImprimir + " " + letras[i];
            }
            Console.WriteLine(filaImprimir);
            for (int fila = 0; fila<tablero.GetLength(0); fila++)
            {
                filaImprimir = numeros[fila];
                for (int columna = 0; columna<tablero.GetLength(1); columna++)
                {
                    switch (tablero[fila, columna])
                    {
                        case 'W' :
                            filaImprimir = filaImprimir + " " + "W";
                            break;
                        case 'T':
                            filaImprimir = filaImprimir + " " + "T";
                            break;
                        case 'B':
                            filaImprimir = filaImprimir + " " + "B";
                            break;
                        default:
                            filaImprimir = filaImprimir + " " + "X";
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
        public static void ImprimirPerfilUsuario(PerfilUsuario perfil)
        {
            Console.WriteLine($"Nombre: {perfil.Nombre}");
            Console.WriteLine($"Ganadas: {perfil.Ganadas}");
            Console.WriteLine($"Nombre: {perfil.Perdidas}");
        }
        /// <summary>
        /// Imprime el historial de todas las partidas jugadas en consola
        /// </summary>
        public static void ImprimirHistorial()
        {
           /* foreach (DatosdePartida partida in Admin.ObtenerHistorial())
            {
                foreach (Tablero tablero in partida)
                {
                    ImprimirTablero(tablero);
                }
                Console.WriteLine($"Ganador: {Admin.ObtenerPerfil(partida.Ganador).Nombre}");
                Console.WriteLine($"Ganador: {Admin.ObtenerPerfil(partida.Perdedor).Nombre}");
            }*/
        }
        /// <summary>
        /// Imprime en consola un rancking, en el que los perfiles tienen posiciones ordenados segun batallas ganadas
        /// </summary>
        public static void ImprimirRanking()
        {
            /*int puesto = 1;
            foreach (PerfilUsuario perfil in Admin.ObtenerRanking())
            {
                Console.WriteLine($"N° {puesto}: {perfil.Nombre} con {perfil.Ganadas} batallas ganadas");
                puesto = puesto + 1;
            }*/
        }
    }
}