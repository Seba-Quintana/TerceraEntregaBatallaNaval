using Telegram.Bot.Types;
using System.Text;
using System.Collections.Generic;
using System;
using Telegram.Bot;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "BuscarPartidaAmistosa".
    /// </summary>
    public class BuscarPartidaAmistosaHandler : BaseHandler
    {
        /// <summary>
        /// Diccionario que almacena los mensajes ingresados por cada uno
        /// de los jugadores que se encuentran en esta etapa.
        /// </summary>
        /// <returns></returns>
		public Dictionary<long, string[]> HistoriaLocal = new Dictionary<long, string[]>();

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BaseHandler"/>. Esta clase procesa el mensaje "BuscarPartidaAmistosa".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public BuscarPartidaAmistosaHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/BuscarPartidaAmistosa"};
        }

        /// <summary>
        /// Determina si este "handler" puede procesar el mensaje.
        /// </summary>
        /// <param name="message"> mensaje a procesar </param>
        /// <returns> Devuelve base.CanHandler si el usuario tiene estado,
        /// de lo contrario devuelve false </returns>
		protected override bool CanHandle(Message message)
        {
            if (!HistoriaLocal.ContainsKey(message.Chat.Id) || (message.Text).StartsWith("/"))
            {
                return base.CanHandle(message);
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Procesa el mensaje "BuscarPartidaAmistosa" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="mensaje">El mensaje a procesar.</param>
        /// <param name="respuesta">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message mensaje, out string respuesta)
        {
            try
            {
                long IDDelJugador = mensaje.Chat.Id;
                respuesta = string.Empty;
                if (this.CanHandle(mensaje))
                {
                    EstadosUsuarios historia = EstadosUsuarios.Instance();
                    TelegramBotClient bot = SingletonBot.Instance();
                    if (!HistoriaLocal.ContainsKey(IDDelJugador))
                    {
                        HistoriaLocal.Add(IDDelJugador, new string[2]);
                        respuesta = "Indique el numero de jugador de su amigo: \n";
                        return true;
                    }
                    else if (HistoriaLocal[IDDelJugador][0] == null)
                    {
                        HistoriaLocal[IDDelJugador][0] = mensaje.Text;
                        long idInvitado = Planificador.ConversorNumaID(Int32.Parse(mensaje.Text));
                        Planificador.anadirListaEsperaAmigos(IDDelJugador, idInvitado);
                        respuesta = "Espere la confirmacion de su amigo...\nPresione /SalirEmparejamiento para cancelar la solicitud";
                        bot.SendTextMessageAsync(idInvitado,"Usted a sido invitado a una partida,\npresione /Aceptar para entrar en partida");
                        return true;
                    }
                }
                if (HistoriaLocal.ContainsKey(IDDelJugador))
                {
                    HistoriaLocal.Remove(IDDelJugador);
                }
                return false;
            }
            catch (Exception)
            {
                long IDdeljugador = mensaje.Chat.Id;
                EstadosUsuarios estados = EstadosUsuarios.Instance();
                respuesta = "Ha ocurrido un error. Intente de nuevo \n";
                estados.ReiniciarEstados(IDdeljugador);
                return true;
            }
        }
    }
}
