using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Envia a los handlers a modo de string todo lo que desee imprimir.
    /// </summary>
    public class Mensajes
    {
        /// <summary>
        /// Este metodo forma un string con los datos publicos de los usuarios, 
        /// los cuales son: Nombre, Número de Jugador y las cantidades de 
        /// partidas ganadas y partidas perdidas que el usuario tenga.
        /// </summary>
        /// <param name="perfil"></param>
        public string ImprimirPerfilUsuario(PerfilUsuario perfil)
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
        public string ImprimirHistorial(List<DatosdePartida> partidas)
        {
            string respuesta = string.Empty;
            AlmacenamientoUsuario buscador = AlmacenamientoUsuario.Instance();
            IImprimirTablero imprimir = new ImprimirTableroPropio();

            if (partidas.Count > 0)
            {
                int contador = 1;
                respuesta = "Este es el Historial.\n";
                foreach (DatosdePartida partida in partidas)
                {
                    respuesta += ($"Parida numero {contador}\n");

                    if (partida.Tableros == null)
                    {
                        respuesta += ($"Tamaño del tablero: {partida.Tamano}\n");
                        respuesta += ($"Turnos: {partida.Tiradas[0]}\n");
                    }
                    else
                    {
                        foreach (Tablero tablero in partida.Tableros)
                        {
                            respuesta += buscador.ObtenerPerfil(tablero.DuenodelTablero).Nombre;
                            respuesta += ($"\n{imprimir.ImprimirTablero(tablero)}\n");
                            respuesta += ($"Turnos: {partida.Tiradas[0]}\n");
                        }
                    }
                    respuesta += ($"Ganador: {buscador.ObtenerPerfil(partida.Ganador).Nombre}\n");
                    respuesta += ($"Perdedor: {buscador.ObtenerPerfil(partida.Perdedor).Nombre}\n");
                    respuesta += ($"Cantidad de tiradas al agua: {partida.AtaquesAlAgua}");
                    respuesta += ($"Cantidad de tiradas a barcos: {partida.AtaquesABarco}");
                    respuesta += ($"\n\n");
                    contador += 1;
                }
            }
            else 
            {
                respuesta = "Aun no hay partidas en el historial.\n";
            }
            return respuesta;
        }
        
        /// <summary>
        /// Con esto método se crea un string que contiene el ranking, en el que los perfiles tienen posiciones dentro de este, los perfiles
        /// son ordenados según las batallas ganadas que los usuarios tengan.
        /// </summary>
        public string ImprimirRanking(List<PerfilUsuario> perfiles)
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
    }
}
