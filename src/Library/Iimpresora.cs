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
        /// Esta operación se encarga de Imprimir el tablero del juego, teniendo como parametros a 
        /// una matriz de caracteres de tablero y una valor booleano de jugador.
        /// </summary>
        /// <param name="tablero"></param>
        public void ImprimirTablero(char[,] tablero, bool jugador);
        /// <summary>
        /// Esta operación se encarga de imprimir el perfil del usuario, teniendo como parámetro 
        /// a un perfil de tipo PerfilUsuario. Esto nos servirá para ver los tableros al disputarse las partidas.
        /// </summary>
        /// <param name="perfil"></param>
        public void ImprimirPerfilUsuario(PerfilUsuario perfil);
        /// <summary>
         /// Esta operción se encarga de imprimir al historial, que recibe como 
        /// parámetro una lista llamada partidas tipo <DatosdePartida>, nos mostrará el perfil que quiéramos ver, si es 
        /// que existe este. 
        /// <param name="partidas"></param>
        public void ImprimirHistorial(List<DatosdePartida> partidas);
        /// <summary>
        /// Esta operción se encarga de imprimir el ranking de jugadores, 
        /// recibiendo como parametro una lista llamada perfiles tipo <PerfilUsuario>, 
        /// dentro de esa lista se ordenará los usuarios con sus respectivas victorias, derrotas y 
        /// partidas jugadas tomando estas para que cada usuario sea capáz de obtener un puesto dentro del Ranking  
        /// </summary>
        /// <param name="perfiles"></param>
        public void ImprimirRanking(List<PerfilUsuario> perfiles);
    }
}