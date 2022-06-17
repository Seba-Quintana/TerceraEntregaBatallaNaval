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
        /// 
        /// </summary>
        /// <param name="tablero"></param>
        public void ImprimirTablero(char[,] tablero, bool jugador);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="perfil"></param>
        public void ImprimirPerfilUsuario(PerfilUsuario perfil);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="partidas"></param>
        public void ImprimirHistorial(List<DatosdePartida> partidas);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="perfiles"></param>
        public void ImprimirRanking(List<PerfilUsuario> perfiles);
    }
}