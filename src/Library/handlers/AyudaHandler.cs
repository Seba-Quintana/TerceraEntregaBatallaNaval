using Telegram.Bot.Types;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "Ayuda".
    /// </summary>
    public class AyudaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BaseHandler"/>. Esta clase procesa el mensaje "Ayuda".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public AyudaHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/Ayuda"};
        }

        /// <summary>
        /// Procesa el mensaje "Ayuda" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="mensaje">El mensaje a procesar.</param>
        /// <param name="respuesta">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message mensaje, out string respuesta)
        {
            if (this.CanHandle(mensaje))
            {
                respuesta = "Aqui va explicacion de comandos";
                return true;
            }

            respuesta = string.Empty;
            return false;
        }
    }
}
