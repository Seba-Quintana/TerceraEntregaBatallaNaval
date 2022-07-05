using Telegram.Bot.Types;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "Comenzar".
    /// </summary>
    public class ComenzarHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BaseHandler"/>. Esta clase procesa el mensaje "Comenzar".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public ComenzarHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/Start"};
        }

        /// <summary>
        /// Procesa el mensaje "Comenzar" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="mensaje">El mensaje a procesar.</param>
        /// <param name="respuesta">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message mensaje, out string respuesta)
        {
            if (this.CanHandle(mensaje))
            {
                respuesta = "Bienvenido al bot del equipo 9. Esperamos que lo disfrute";
                respuesta += $"\nEscribe '/Registrar' para registrarte, o '/InicioSesion' para iniciar sesion";
                EstadosUsuarios.Instance().NuevoJugador(mensaje.Chat.Id);
                return true;
            }
            respuesta = string.Empty;
            return false;
        }
    }
}
