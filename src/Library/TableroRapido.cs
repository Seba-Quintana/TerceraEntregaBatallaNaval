using System;

namespace ClassLibrary
{
    /// <summary>
    /// Tablero de modo rapido creado en caso de diseñar dicho modo.
    /// </summary>
    public class TableroRapido : Tablero
    {
        /// <summary>
        /// En este contructor se asigna el tamaño de la matriz, se crea la misma y se asigna el dueño del Tablero.
        /// </summary>
        /// <param name="Tamaño"></param>
        /// <param name="dueño"></param>
        /// <returns></returns>
        public TableroRapido(int Tamaño, int dueño) : base(Tamaño,dueño)
        {
            this.tamaño = Tamaño;
            this.matriz = new char [tamaño,tamaño];
            this.DueñodelTablero = dueño;
        }
        /// <summary>
        /// Atributo con el contador del segundo ataque de cada personaje.
        /// </summary>
        public int segundatirada = 0;
        
    }
}