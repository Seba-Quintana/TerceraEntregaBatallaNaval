//--------------------------------------------------------------------------------
// <copyright file="Train.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;

namespace ClassLibrary
{
    /// <summary>
    /// Para evitar tener que preguntar por el destino de la impresión en Program.cs el código que varía según el destino se encuentra en diferentes clases que implementan esta interfaz y mantener el LSP.
    /// </summary>
    public interface Iimpresora
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tablero"></param>
        void ImprimirTablero(string[] tablero);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tablero"></param>
        void ImprimirTableroOponente(string[] tablero);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeroDeJugador"></param>
        void ImprimirPerfilUsuario(int numeroDeJugador);
        /// <summary>
        /// 
        /// </summary>
        void ImprimirHistorial();
        /// <summary>
        /// 
        /// </summary>
        void ImprimirRanking();
        /// <summary>
        /// 
        /// </summary>
        void ImprimirModos();
    }
}