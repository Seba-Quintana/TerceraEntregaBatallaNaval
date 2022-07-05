using Telegram.Bot.Types;
using System.Collections.Generic;
using System.Text;
using System;
using Telegram.Bot;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "ConfirmarPartida".
    /// </summary>
    public class ConfirmarPartidaHandler : BaseHandler
    {
		/// <summary>
        /// Diccionario que almacena los mensajes ingresados por cada uno
        /// de los jugadores que se encuentran en esta etapa.
        /// </summary>
        /// <returns></returns>
		public Dictionary<long, string[]> HistoriaLocal = new Dictionary<long, string[]>();

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BaseHandler"/>. Esta clase procesa el mensaje "ConfirmarPartida".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public ConfirmarPartidaHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/Aceptar"};
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
        /// Procesa el mensaje "ConfirmarPartida" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="mensaje">El mensaje a procesar.</param>
        /// <param name="respuesta">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message mensaje, out string respuesta)
        {
            try
            {
                respuesta = string.Empty;
                long IDDelJugador = mensaje.Chat.Id;

                if (this.CanHandle(mensaje))
                {
                    long IDinvitado = Planificador.VerListaEsperaAmigos(IDDelJugador);
                    if (!HistoriaLocal.ContainsKey(IDDelJugador))
                    {
                        HistoriaLocal.Add(IDDelJugador, new string[3]);
                    }
                    if (HistoriaLocal[IDDelJugador][0] == null)
                    {
                        HistoriaLocal[IDDelJugador][0] = mensaje.Text;
                        respuesta = $"{HistoriaLocal[IDDelJugador][0]} \n" + "Indique el modo de juego: \n";
                        return true;
                    }
                    else if (HistoriaLocal[IDDelJugador][1] == null)
                    {
                        HistoriaLocal[IDDelJugador][1] = mensaje.Text;
                        respuesta = $"{HistoriaLocal[IDDelJugador][1]} \n" + "Indique el tamaño del tablero: \n";
                        return true;
                    }
                    
                    else if (HistoriaLocal[IDDelJugador][2] == null)
                    {
                        HistoriaLocal[IDDelJugador][2] = mensaje.Text;
                        

                        bool emparejado = Planificador.EmparejarAmigos(
                        Int32.Parse(HistoriaLocal[IDDelJugador][1]),
                        Planificador.ConversorIDaNum(IDDelJugador),
                        Planificador.ConversorIDaNum(IDinvitado),
                        Int32.Parse(HistoriaLocal[IDDelJugador][2]));
                        if (emparejado)
                        {
                            EstadosUsuarios estadosgenerales = EstadosUsuarios.Instance();
                            TelegramBotClient bot = SingletonBot.Instance();
                            estadosgenerales.AvanzarEstados(IDDelJugador,1);
                            estadosgenerales.AvanzarEstados(IDinvitado,1);
                            bot.SendTextMessageAsync(IDinvitado, $"Emparejamiento completado. \nUtilize /Posicionar para empezar a posicionar sus barcos");
                            respuesta += $"Emparejamiento completado. \nUtilize /Posicionar para empezar a posicionar sus barcos";
                        }
                        HistoriaLocal.Remove(IDDelJugador);
                        HistoriaLocal.Remove(IDinvitado);
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
                long IDDelJugador = mensaje.Chat.Id;
                EstadosUsuarios estados = EstadosUsuarios.Instance();
                respuesta = "Ha habido un error. Intente de nuevo \n";
                estados.ReiniciarEstados(IDDelJugador);
                return true;
            }
        }
    }
}
