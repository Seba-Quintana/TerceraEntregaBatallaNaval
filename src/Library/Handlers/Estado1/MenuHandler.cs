using Telegram.Bot.Types;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "Menu".
    /// </summary>
    public class MenuHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BaseHandler"/>. Esta clase procesa el mensaje "Menu".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public MenuHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/Menu"};
        }

        /// <summary>
        /// Procesa el mensaje "Menu" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="mensaje">El mensaje a procesar.</param>
        /// <param name="respuesta">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message mensaje, out string respuesta)
        {
            if (this.CanHandle(mensaje))
            {
                respuesta = "Estas ubicado en el menu principal.";
                respuesta += "Estos son los comandos que podras utilizar: \n /Remover \n /VerPerfil \n /VerRanking \n /VerHistorial \n /VerHistorialPersonal \n /BuscarPartida \n /BuscarPartidaAmistosa \n Para mas informacion, presione: /Ayuda";
                return true;
            }

            respuesta = string.Empty;
            return false;
        }
    }
}
