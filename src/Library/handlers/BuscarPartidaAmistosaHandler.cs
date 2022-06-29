using Telegram.Bot.Types;
using System.Text;
using System.Collections.Generic;
using System;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "ConfirmarBusqueda".
    /// </summary>
    public class ConfirmarBusquedaHandler : BaseHandler
    {
		public Dictionary<long, string[]> HistoriaLocal = new Dictionary<long, string[]>();

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BaseHandler"/>. Esta clase procesa el mensaje "ConfirmarBusqueda".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public ConfirmarBusquedaHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/BuscarPartidaAmistosa"};
        }

		protected override bool CanHandle(Message message)
        {
            if (!HistoriaLocal.ContainsKey(message.Chat.Id))
            {
                return base.CanHandle(message);
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Procesa el mensaje "ConfirmarBusqueda" y retorna true; retorna false en caso contrario.
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
                UsersHistory historia = UsersHistory.Instance();
                if (!HistoriaLocal.ContainsKey(IDdeljugador))
                {
                    HistoriaLocal.Add(IDdeljugador, new string[2]);
                    respuesta = "Indique el numero de jugador de su amigo: \n";
                    return true;
                }
				else if (HistoriaLocal[IDdeljugador][0] == null)
				{
					HistoriaLocal[IDdeljugador][0] = mensaje.Text;
					AlmacenamientoUsuario conversor = AlmacenamientoUsuario.Instance();
					long idInvitado = conversor.ConversorNumaID(Int32.Parse(mensaje.Text));
					Planificador.anadirListaEsperaAmigos(IDdeljugador, idInvitado);
					respuesta = "Espere la confirmacion de su amigo...";
					return true;
				}
            }
            return false;
        }
    }
}
