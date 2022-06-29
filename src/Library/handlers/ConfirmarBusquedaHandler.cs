using Telegram.Bot.Types;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "ConfirmarBusqueda".
    /// </summary>
    public class ConfirmarBusquedaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BaseHandler"/>. Esta clase procesa el mensaje "ConfirmarBusqueda".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public ConfirmarBusquedaHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/Aceptar"};
        }

        /// <summary>
        /// Procesa el mensaje "ConfirmarBusqueda" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="mensaje">El mensaje a procesar.</param>
        /// <param name="respuesta">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message mensaje, out string respuesta)
        {
            if (this.CanHandle(mensaje))
            {
				long? invitado = Planificador.VerListaEsperaAmigos(mensaje.Chat.Id);
				if (invitado != null)
				{
					respuesta = "";
				}
                respuesta = "";
                return true;
            }

            respuesta = string.Empty;
            return false;
        }
    }
}
