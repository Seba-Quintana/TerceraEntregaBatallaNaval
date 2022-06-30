using Telegram.Bot.Types;
using System.Collections.Generic;
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
            respuesta = string.Empty;
            if (this.CanHandle(mensaje))
            {
                long IDdeljugador = mensaje.Chat.Id;
                AlmacenamientoUsuario almacenamiento = AlmacenamientoUsuario.Instance();
                List <PerfilUsuario> ranking = almacenamiento.ObtenerRanking();
                Planificador.VerRanking();
                respuesta = "Este es el ranking donde están los jugadores con sus posiciones, dependiendo de sus partidas ganadas y perdidas. ";
                return true;
            }

            respuesta = "No hay jugadores en el Ranking";
            return false;
        }
    }
}
