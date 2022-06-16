[System.Serializable]
public class JugadorNoEncontradoException : System.Exception
{
    public int NumeroDeJugador;
    public JugadorNoEncontradoException() { }
    public JugadorNoEncontradoException(string message) : base(message) { }
    public JugadorNoEncontradoException(string message, System.Exception inner) : base(message, inner) { }
    public JugadorNoEncontradoException(string message, int numerodejugador) : this(message)
    {
        NumeroDeJugador = numerodejugador;
    }
}