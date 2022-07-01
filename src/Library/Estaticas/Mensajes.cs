using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Envia a los handlers a modo de string todo lo que desee imprimir implementando la interfaz Iimpresora con una operación polimórfica.
    /// </summary>
    public static class Mensajes
    {
        /// <summary>
        /// Con este método se forma un string con todo lo que deseo mostrar del tablero ingresado como parametro agregándole índices de coordenadas.
        /// Como parametro tambien tiene un bool que identifica si es el tableto del jugador o no para señalizarlo correctamente.
        /// </summary>
        /// <param name="tablero"></param>
        /// <param name="jugador"></param>
        
        public static string ImprimirTablero(char[,] tablero, bool jugador)
        {
            string respuesta = "";
            if (jugador)
            {
                respuesta += ("TABLERO PROPIO\n");
            }
            else
            {
                respuesta += ("TABLERO OPONENTE\n");
            }
            string filaImprimir = "   ";
            List<string> letras = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", " I", "J", "K", "L", "M", "N", "O" };
            respuesta += "\n";
            for (int i = 0; i < tablero.GetLength(1); i++)
            {
                if (i < 5)
                {
                    filaImprimir = filaImprimir + $"  {i + 1}";
                }
                else if (i == 5)
                {
                    filaImprimir = filaImprimir + $"   {i + 1}";
                }
                else if (i < 10)
                {
                    filaImprimir = filaImprimir + $"  {i + 1}";
                }
                else
                {
                    filaImprimir = filaImprimir + $" {i + 1} ";
                }
            }
            respuesta += ($" {filaImprimir}\n");
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
                respuesta += ($"{filaImprimir}\n");
            }
            respuesta += ("\n");
            return respuesta;
        }
        
        /// <summary>
        /// Este metodo forma un string con los datos publicos de los usuarios, 
        /// los cuales son: Nombre, Número de Jugador y las cantidades de 
        /// partidas ganadas y partidas perdidas que el usuario tenga.
        /// </summary>
        /// <param name="perfil"></param>
        public static string ImprimirPerfilUsuario(PerfilUsuario perfil)
        {
            string respuesta = "";
            respuesta += ($"Nombre: {perfil.Nombre}\n");
            respuesta += ($"Numero de jugador: {perfil.NumeroDeJugador}\n");
            respuesta += ($"Ganadas: {perfil.Ganadas}\n");
            respuesta += ($"Perdidas: {perfil.Perdidas}\n");
            return respuesta;
        }
        
        /// <summary>
        /// Este método se encarga de crear un string que contenga el historial de todas las partidas en la lista de partidas ingresada como parametro.
        /// </summary>
        /// <param name="partidas"></param>
        public static string ImprimirHistorial(List<DatosdePartida> partidas)
        {
            string respuesta = "";
            AlmacenamientoUsuario buscador = AlmacenamientoUsuario.Instance();
            foreach (DatosdePartida partida in partidas)
            {
                bool impresion = true;
                foreach (Tablero tablero in partida.Tableros)
                {
                    char[,] tableroAImprimir = tablero.VerTablero();
                    respuesta += ($"{ImprimirTablero(tableroAImprimir, impresion)}\n");
                    impresion = false;
                }
                respuesta += ($"Ganador: {buscador.ObtenerPerfil(partida.Ganador).Nombre}\n");
                respuesta += ($"Perdedor: {buscador.ObtenerPerfil(partida.Perdedor).Nombre}\n");
            }
            return respuesta;
        }
        
        /// <summary>
        /// Con esto método se crea un string que contiene el ranking, en el que los perfiles tienen posiciones dentro de este, los perfiles
        /// son ordenados según las batallas ganadas que los usuarios tengan.
        /// </summary>
        public static string ImprimirRanking(List<PerfilUsuario> perfiles)
        {
            string respuesta = "";
            int puesto = 1;
            foreach (PerfilUsuario perfil in perfiles)
            {
                respuesta += ($"N° {puesto}: {perfil.Nombre} con {perfil.Ganadas} batallas ganadas\n");
                puesto = puesto + 1;
            }
            return respuesta;
        }

        /// <summary>
        /// Devuelve el mensaje recibido.
        /// </summary>
        /// <param name="mensaje"> Mensaje a imprimir </param>
        public static string RecibirMensajes (string mensaje)
        {
            return mensaje;
        }
    }
}
