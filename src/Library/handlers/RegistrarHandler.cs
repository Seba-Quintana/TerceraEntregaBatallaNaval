using Telegram.Bot.Types;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "Registrar".
    /// </summary>
    public class RegistrarHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="RegistrarHandler"/>. Esta clase procesa el mensaje "Registrar".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public RegistrarHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"Registrar"};
        }

        /// <summary>
        /// Procesa el mensaje "Registrar" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message message, out string response)
        {
            if (this.CanHandle(message))
            {
                response = "Registrar";
                return true;
            }

            response = string.Empty;
            return false;
        }
    }
}
