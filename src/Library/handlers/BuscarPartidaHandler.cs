using Telegram.Bot.Types;
using System.Collections.Generic;
using System.Text;
using System;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "BuscarPartida".
    /// </summary>
    public class BuscarPartidaHandler : BaseHandler
    {
		/// <summary>
        /// El estado del comando.
        /// </summary>
		public Dictionary<long, string[]> HistoriaLocal = new Dictionary<long, string[]>();

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BaseHandler"/>. Esta clase procesa el mensaje "BuscarPartida".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public BuscarPartidaHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/BuscarPartida"};
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
        /// Procesa el mensaje "BuscarPartida" y retorna true; retorna false en caso contrario.
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
                    respuesta = "Indique el modo de juego: \n";
                    return true;
                }
				else if (HistoriaLocal[IDdeljugador][0] == null)
				{
					HistoriaLocal[IDdeljugador][0] = mensaje.Text;
					respuesta = $"{HistoriaLocal[IDdeljugador][0]} \n" + "Indique el tamaño del tablero: \n";
					return true;
				}
				else if (HistoriaLocal[IDdeljugador][1] == null)
				{
					HistoriaLocal[IDdeljugador][1] = mensaje.Text;
					
					AlmacenamientoUsuario conversor = AlmacenamientoUsuario.Instance();
					bool emparejado = Planificador.Emparejar(Int32.Parse(HistoriaLocal[IDdeljugador][0]), conversor.ConversorIDaNum(IDdeljugador), Int32.Parse(HistoriaLocal[IDdeljugador][1]));
					if (!emparejado)
						respuesta = "Buscando partida... \n";
					else
						respuesta = "Partida encontrada! \n";
					return true;
				}
            }
            return false;
        }
    }
}
