
/// <summary>
/// Excepcion por si un jugador no se encuentra.
/// </summary>
[System.Serializable]
public class JugadorNoEncontradoException : System.Exception
{
    /// <summary>
    /// numero del jugador no encontrado
    /// </summary>
    public int NumeroDeJugador { get; }

    /// <summary>
    /// Constructor default
    /// </summary>
    public JugadorNoEncontradoException() { }

    /// <summary>
    /// Constructor default
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public JugadorNoEncontradoException(string message) : base(message) { }

    /// <summary>
    /// Constructor default
    /// </summary>
    /// <param name="message"></param>
    /// <param name="inner"></param>
    /// <returns></returns>
    public JugadorNoEncontradoException(string message, System.Exception inner) : base(message, inner) { }

    /// <summary>
    /// Constructor adicional para asignar numero de jugador no encontrado al atributo
    /// y para conseguir el mensaje a mostrar de ser necesario.
    /// </summary>
    /// <param name="message"> mensaje a mostrar </param>
    /// <param name="numerodejugador"> numero del jugador no encontrado </param>
    /// <returns></returns>
    public JugadorNoEncontradoException(string message, int numerodejugador) : this(message)
    {
        NumeroDeJugador = numerodejugador;
    }
}