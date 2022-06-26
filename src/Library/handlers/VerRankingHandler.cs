using Telegram.Bot.Types;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "VisualizarRanking".
    /// </summary>
    public class VisualizarRankingHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BaseHandler"/>. Esta clase procesa el mensaje "VisualizarRanking".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public VisualizarRankingHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/VisualizarRanking"};
        }

        /// <summary>
        /// Procesa el mensaje "VisualizarRanking" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="mensaje">El mensaje a procesar.</param>
        /// <param name="respuesta">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message mensaje, out string respuesta)
        {
            if (this.CanHandle(mensaje))
            {
                respuesta = "";
                return true;
            }

            respuesta = string.Empty;
            return false;
        }
    }
}
