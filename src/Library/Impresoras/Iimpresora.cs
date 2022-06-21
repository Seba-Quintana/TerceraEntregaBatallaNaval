//--------------------------------------------------------------------------------
// <copyright file="Train.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Para evitar tener que preguntar por el destino de la impresión en Program.cs el código que varía según el destino se encuentra en diferentes clases que implementan esta interfaz.
    /// </summary>
    public interface Iimpresora
    {
        /// <summary>
        /// Esta operación se encarga de Imprimir el tablero del juego, teniendo como parametros
        /// una matriz de caracteres de tablero y una valor booleano de jugador.
        /// </summary>
        /// <param name="tablero"></param>
        /// <param name="jugador"></param>
        void ImprimirTablero(char[,] tablero, bool jugador);
        
        /// <summary>
        /// Esta operación se encarga de imprimir el perfil del usuario, teniendo como parámetro
        /// un perfil de usuario.
        /// </summary>
        /// <param name="perfil"></param>
        void ImprimirPerfilUsuario(PerfilUsuario perfil);
        
        /// <summary>
        /// Esta operción se encarga de imprimir el historial, recibe como 
        /// parámetro una lista de partidas
        /// </summary>
        /// <param name="partidas"></param>
        void ImprimirHistorial(List<DatosdePartida> partidas);

        /// <summary>
        /// Esta operción se encarga de imprimir el ranking de jugadores.
        /// Recibe como parametro la lista de los perfiles ordenada en base a la cantidad de victorias de cada jugador.
        /// </summary>
        /// <param name="perfiles"></param>
        void ImprimirRanking(List<PerfilUsuario> perfiles);
    }
}
