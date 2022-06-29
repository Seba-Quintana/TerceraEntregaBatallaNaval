using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Muestra por consola todo lo que desee imprimir implementando la interfaz Iimpresora con una operación polimórfica.
    /// </summary>
    public class ImpresoraConsola : IImpresora
    {
        /// <summary>
        /// Parte de singleton. Atributo donde se guarda la instancia de la impresora (o null si no fue creada).
        /// </summary>
        private static ImpresoraConsola instance = null; 
 
        /// <summary>
        /// Parte de singleton. Constructor llamado por el metodo Instance en caso de crearse una impresora.
        /// </summary>
        private ImpresoraConsola()
        {
        }
        
        /// <summary>
        /// Se crea una instancia de la clase ImpresoraConsola con el patron de diseño Singleton, 
        /// en caso de que no exista, se crea una Impresora.
        /// </summary>
        /// <returns> instancia de impresora </returns>
        public static ImpresoraConsola Instance()
        {
            if (instance == null)
                instance = new ImpresoraConsola();
      
            return instance;
        }
        /// <summary>
        /// Con este método se imprime el tablero ingresado como parametro en la consola agregándole índices de coordenadas.
        /// Como parametro tambien tiene un bool que identifica si es el tableto del jugador o no para señalizarlo correctamente.
        /// </summary>
        /// <param name="tablero"></param>
        /// <param name="jugador"></param>
        
        public void ImprimirTablero(char[,] tablero, bool jugador)
        {
            if (jugador)
            {
                Console.WriteLine("TABLERO PROPIO\n");
            }
            else
            {
                Console.WriteLine("TABLERO OPONENTE\n");
            }
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
                            filaImprimir = filaImprimir + " " + "O ";
                            break;
                        case 'T':
                            filaImprimir = filaImprimir + " " + "X ";
                            break;
                        case 'B':
                            filaImprimir = filaImprimir + " " + "B ";
                            break;
                        case '-':
                            filaImprimir = filaImprimir + " " + "- ";
                            break;
                        case 'H':
                            filaImprimir = filaImprimir + " " + "H ";
                            break;
                        default:
                            filaImprimir = filaImprimir + " " + "~ ";
                            break;
                    }
                }
                Console.WriteLine(filaImprimir);
            }
            Console.WriteLine("\n");
        }
        
        /// <summary>
        /// Este metodo imprime los datos publicos de los usuarios en consola, 
        /// los cuales son: Nombre, Número de Jugador y las cantidades de 
        /// partidas ganadas y partidas perdidas que el usuario tenga.
        /// </summary>
        /// <param name="perfil"></param>
        public void ImprimirPerfilUsuario(PerfilUsuario perfil)
        {
            Console.WriteLine($"Nombre: {perfil.Nombre}");
            Console.WriteLine($"Numero de jugador: {perfil.NumeroDeJugador}");
            Console.WriteLine($"Ganadas: {perfil.Ganadas}");
            Console.WriteLine($"Perdidas: {perfil.Perdidas}");
        }
        
        /// <summary>
        /// Este método se encarga de imprimir el historial de todas las partidas en la lista de partidas ingresada como parametro en la consola.
        /// </summary>
        /// <param name="partidas"></param>
        public void ImprimirHistorial(List<DatosdePartida> partidas)
        {
            AlmacenamientoUsuario buscador = AlmacenamientoUsuario.Instance();
            foreach (DatosdePartida partida in partidas)
            {
                bool impresion = true;
                foreach (Tablero tablero in partida.Tableros)
                {
                    char[,] tableroAImprimir = tablero.VerTablero();
                    this.ImprimirTablero(tableroAImprimir, impresion);
                    impresion = false;
                }
                Console.WriteLine($"Ganador: {buscador.ObtenerPerfil(partida.Ganador).Nombre}");
                Console.WriteLine($"Perdedor: {buscador.ObtenerPerfil(partida.Perdedor).Nombre}");
            }
        }
        
        /// <summary>
        /// Con esto método se imprime en consola un ranking, en el que los perfiles tienen posiciones dentro de este, los perfiles
        /// son ordenados según las batallas ganadas que los usuarios tengan.
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

        /// <summary>
        /// Imprime mensajes.
        /// </summary>
        /// <param name="mensaje"> Mensaje a imprimir </param>
        public void RecibirMensajes (string mensaje)
        {
            Console.WriteLine(mensaje);
        }
    }
}
