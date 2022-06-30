using Telegram.Bot.Types;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "VerHistorial".
    /// </summary>
    public class VerHistorialHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BaseHandler"/>. Esta clase procesa el mensaje "VerHistorial".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public VerHistorialHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/VerHistorial"};
        }

        /// <summary>
        /// Procesa el mensaje "VerHistorial" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="mensaje">El mensaje a procesar.</param>
        /// <param name="respuesta">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message mensaje, out string respuesta)
        {
             respuesta = string.Empty;
            if (this.CanHandle(mensaje))
            {
                long IDdeljugador = mensaje.Chat.Id;
                AlmacenamientoUsuario almacenamiento = AlmacenamientoUsuario.Instance();
                Historial historial = Historial.Instance();
                Planificador.VerHistorial();
                respuesta = "Este es el historial.";
                return true;
            }

            respuesta = string.Empty;
            return false;
        }
    }
}
