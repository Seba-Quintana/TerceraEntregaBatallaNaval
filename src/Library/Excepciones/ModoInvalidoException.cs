
/// <summary>
/// Excepcion por si un modo ingresado es invalido
/// </summary>
[System.Serializable]
public class ModoInvalidoException : System.Exception
{
    /// <summary>
    /// modo invalido
    /// </summary>
    public int Modo { get; }

    /// <summary>
    /// Constructor default
    /// </summary>
    public ModoInvalidoException() { }

    /// <summary>
    /// Constructor default
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public ModoInvalidoException(string message) : base(message) { }

    /// <summary>
    /// Constructor default
    /// </summary>
    /// <param name="message"></param>
    /// <param name="inner"></param>
    /// <returns></returns>
    public ModoInvalidoException(string message, System.Exception inner) : base(message, inner) { }

    /// <summary>
    /// Constructor adicional para asignar el modo invalido al atributo
    /// y para conseguir el mensaje a mostrar de ser necesario.
    /// </summary>
    /// <param name="message"> mensaje a mostrar </param>
    /// <param name="modo"> numero del jugador no encontrado </param>
    /// <returns></returns>
    public ModoInvalidoException(string message, int modo) : this(message)
    {
        Modo = modo;
    }
}