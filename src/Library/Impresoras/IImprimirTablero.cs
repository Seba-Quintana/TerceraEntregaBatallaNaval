using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Para evitar tener que preguntar si mostrar el tablero como el propio o el del oponente
    /// el código que varía según el destino se encuentra en diferentes clases que implementan esta interfaz.
    /// Implementando polimorfismo
    /// </summary>
    public interface IImprimirTablero
    {
        /// <summary>
        /// Esta operación se encarga de crear un string que contiene el tablero listo para mostrarse.
        /// </summary>
        /// <param name="tablero"> El tablero que deseo se vuelva una string </param>
        string ImprimirTablero(Tablero tablero);
    }
}