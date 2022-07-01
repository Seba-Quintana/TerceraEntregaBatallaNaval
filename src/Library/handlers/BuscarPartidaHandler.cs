using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Types;


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

		/// <summary>
		/// Determina si este "handler" puede procesar el mensaje.
		/// </summary>
		/// <param name="message"> mensaje a procesar </param>
		/// <returns> Devuelve base.CanHandler si el usuario tiene estado,
        /// de lo contrario devuelve false </returns>
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
                    HistoriaLocal.Add(IDdeljugador, new string[3]);
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
                    UsersHistory Estados = UsersHistory.Instance();
                    int[] emparejado; 
                    emparejado = Planificador.Emparejar(Int32.Parse(HistoriaLocal[IDdeljugador][0]), conversor.ConversorIDaNum(IDdeljugador), Int32.Parse(HistoriaLocal[IDdeljugador][1]));
                    if (emparejado==null)
                    {
						respuesta = "Buscando partida... \n";
                    }
					else
                    {
                		respuesta = "Partida encontrada! \n";
                        TelegramBotClient bot = SingletonBot.Instance();
                        AlmacenamientoUsuario almacenamientodeUsuarios = AlmacenamientoUsuario.Instance();
                        int IntJugadorEnemigo = emparejado[0];
                        long IDJugadorEnemigo = almacenamientodeUsuarios.ConversorNumaID(IntJugadorEnemigo);
                        bot.SendTextMessageAsync(IDJugadorEnemigo,"Partida encontrada! \n Presione /Posicionar para posicionar un barco");
                        HistoriaLocal.Remove(IDdeljugador);
                        Estados.AvanzarEstados(IDdeljugador,1);
                        Estados.AvanzarEstados(IDJugadorEnemigo,1);
                    }
					return true;
				}
				else if (HistoriaLocal[IDdeljugador][2] == null)
				{
					if (mensaje.Text == "/SalirEmparejamiento")
					{
						HistoriaLocal.Remove(IDdeljugador);
						return false;
					}
					respuesta = "Buscando partida... \n Si desea salir del emparejamiento, presione /SalirEmparejamiento \n";
					return true;
				}
            }
            return false;
        }
    }
}
