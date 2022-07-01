using Telegram.Bot.Types;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "SalirEmparejamiento".
    /// </summary>
    public class SalirEmparejamientoHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BaseHandler"/>. Esta clase procesa el mensaje "SalirEmparejamiento".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public SalirEmparejamientoHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/SalirEmparejamiento" };
        }

        /// <summary>
        /// Procesa el mensaje "SalirEmparejamiento" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="mensaje">El mensaje a procesar.</param>
        /// <param name="respuesta">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message mensaje, out string respuesta)
        {
            respuesta = string.Empty;
            if (this.CanHandle(mensaje))
            {
				UsersHistory historia = UsersHistory.Instance();
				AlmacenamientoUsuario conversor = AlmacenamientoUsuario.Instance();
                long IDdeljugador = mensaje.Chat.Id;
				int usuario = conversor.ConversorIDaNum(IDdeljugador);
				Planificador.removerListaEspera(usuario);
				respuesta += $"Emparejamiento cancelado \n";
				historia.ReiniciarEstados(IDdeljugador);
				return true;
            }
            return false;
        }
    }
}
