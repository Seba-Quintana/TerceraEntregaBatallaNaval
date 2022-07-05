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
        /// Procesa el mensaje "BuscarPartida" y retorna true; retorna false en caso contrario.
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
                    TelegramBotClient bot = SingletonBot.Instance();
                    EstadosUsuarios historia = EstadosUsuarios.Instance();
                    if (!HistoriaLocal.ContainsKey(IDDelJugador))
                    {
                        HistoriaLocal.Add(IDDelJugador, new string[3]);
                        respuesta += $"Elija el modo de juego entre las siguientes opciones:";
                        respuesta += $"\n0 para jugar en modo normal.";
                        respuesta += $"\n1 para jugar en modo rapido.";
                        return true;
                    }
                    else if (HistoriaLocal[IDDelJugador][0] == null)
                    {
                        int modoingresado = Int32.Parse(mensaje.Text);
                        if ( 0 != modoingresado && 1 != modoingresado)
                        {
                            throw new ModoInvalidoException();
                        }

                        HistoriaLocal[IDDelJugador][0] = mensaje.Text;
                        respuesta = "Indique el tamaño del tablero: \nEntre 2 y 11";
                        return true;
                    }
                    else if (HistoriaLocal[IDDelJugador][1] == null)
                    {
                        int tamanoingresado = Int32.Parse(mensaje.Text);
                        if ( 2 > tamanoingresado || tamanoingresado > 11 )
                        {
                            throw new TableroInvalidoException();
                        }
                        
                        HistoriaLocal[IDDelJugador][1] = mensaje.Text;
                        
                        AlmacenamientoUsuario conversor = AlmacenamientoUsuario.Instance();
                        EstadosUsuarios Estados = EstadosUsuarios.Instance();
                        int[] emparejado; 
                        emparejado = Planificador.Emparejar(Int32.Parse(HistoriaLocal[IDDelJugador][0]), conversor.ConversorIDaNum(IDDelJugador), Int32.Parse(HistoriaLocal[IDDelJugador][1]));
                        if (emparejado==null)
                        {
                            respuesta = "Buscando partida... \nSi desea salir del emparejamiento, presione /SalirEmparejamiento \n";
                        }
                        else
                        {
                            respuesta = "Partida encontrada! \nPresione /Posicionar para posicionar un barco";
                            AlmacenamientoUsuario almacenamientodeUsuarios = AlmacenamientoUsuario.Instance();
                            int IntJugadorEnemigo = emparejado[0];
                            long IDJugadorEnemigo = almacenamientodeUsuarios.ConversorNumaID(IntJugadorEnemigo);
                            bot.SendTextMessageAsync(IDJugadorEnemigo,"Partida encontrada! \nPresione /Posicionar para posicionar un barco");
                            HistoriaLocal.Remove(IDDelJugador);
                            HistoriaLocal.Remove(IDJugadorEnemigo);
                            Estados.AvanzarEstados(IDDelJugador,1);
                            Estados.AvanzarEstados(IDJugadorEnemigo,1);
                        }
                        
                        return true;
                    }
                    else
                    {
                        respuesta = "Buscando partida... \nSi desea salir del emparejamiento, presione /SalirEmparejamiento \n";
                        if (mensaje.Text == "/SalirEmparejamiento")
                        {
                            HistoriaLocal.Remove(IDDelJugador);
                            return false;
                        }
                        return true;
                    }
                }
                if (HistoriaLocal.ContainsKey(IDDelJugador))
                {
                    HistoriaLocal.Remove(IDDelJugador);
                }
                return false;
            }
            catch (ModoInvalidoException)
            {

                respuesta = "Elije entre los modos 0 y 1 por favor";
                return true;
            }
            catch (TableroInvalidoException)
            {
                respuesta = "Los tamaños de tablero solo pueden ser numeros entre 2 y 11";
                return true;
            }
            catch (Exception)
            {
                EstadosUsuarios estados = EstadosUsuarios.Instance();
                long IDDelJugador = mensaje.Chat.Id;
                respuesta = "Ha habido un error. Intente de nuevo \n";
                estados.ReiniciarEstados(IDDelJugador);
                return true;
            }
        }
    }
}
