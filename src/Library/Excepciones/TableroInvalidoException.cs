
/// <summary>
/// Excepcion por si un tablero es invalido
/// </summary>
[System.Serializable]
public class TableroInvalidoException : System.Exception
{
    /// <summary>
    /// Tablero invalido
    /// </summary>
    public int Tamaño { get; }

    /// <summary>
    /// Constructor default
    /// </summary>
    public TableroInvalidoException() { }

    /// <summary>
    /// Constructor default
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public TableroInvalidoException(string message) : base(message) { }

    /// <summary>
    /// Constructor default
    /// </summary>
    /// <param name="message"></param>
    /// <param name="inner"></param>
    /// <returns></returns>
    public TableroInvalidoException(string message, System.Exception inner) : base(message, inner) { }

    /// <summary>
    /// Constructor adicional para asignar el tablero invalido al atributo
    /// y para conseguir el mensaje a mostrar de ser necesario.
    /// </summary>
    /// <param name="message"> mensaje a mostrar </param>
    /// <param name="tamaño"> numero del jugador no encontrado </param>
    /// <returns></returns>
    public TableroInvalidoException(string message, int tamaño) : this(message)
    {
        Tamaño = tamaño;
    }
}
