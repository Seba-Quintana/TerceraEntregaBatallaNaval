using Telegram.Bot.Types;
using System.Collections.Generic;
using System.Text;
using System;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "BuscarPartidaAmistosa".
    /// </summary>
    public class BuscarPartidaAmistosaHandler : BaseHandler
    {
		/// <summary>
        /// El estado del comando.
        /// </summary>
		public Dictionary<long, string[]> HistoriaLocal = new Dictionary<long, string[]>();

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BaseHandler"/>. Esta clase procesa el mensaje "BuscarPartidaAmistosa".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public BuscarPartidaAmistosaHandler(BaseHandler next) : base(next)
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
        /// Procesa el mensaje "BuscarPartidaAmistosa" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="mensaje">El mensaje a procesar.</param>
        /// <param name="respuesta">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message mensaje, out string respuesta)
        {
            try
            {
                respuesta = string.Empty;
                if (this.CanHandle(mensaje))
                {
                    AlmacenamientoUsuario conversor = AlmacenamientoUsuario.Instance();
                    long invitado = Planificador.VerListaEsperaAmigos(mensaje.Chat.Id);
                    if (!HistoriaLocal.ContainsKey(mensaje.Chat.Id))
                    {
                        respuesta = $"Desea aceptar la partida?";
                        HistoriaLocal.Add(mensaje.Chat.Id, new string[3]);
                        return true;
                    }
                    long IDdeljugador = mensaje.Chat.Id;
                    if (HistoriaLocal[IDdeljugador][0] == null)
                    {
                        HistoriaLocal[IDdeljugador][0] = mensaje.Text;
                        respuesta = $"{HistoriaLocal[IDdeljugador][0]} \n" + "Indique el modo de juego: \n";
                        return true;
                    }
                    else if (HistoriaLocal[IDdeljugador][1] == null)
                    {
                        HistoriaLocal[IDdeljugador][1] = mensaje.Text;
                        respuesta = $"{HistoriaLocal[IDdeljugador][1]} \n" + "Indique el tamaño del tablero: \n";
                        return true;
                    }
                    
                    else if (HistoriaLocal[IDdeljugador][2] == null)
                    {
                        HistoriaLocal[IDdeljugador][2] = mensaje.Text;
                        

                        bool emparejado = Planificador.EmparejarAmigos(
                        Int32.Parse(HistoriaLocal[IDdeljugador][1]),
                        conversor.ConversorIDaNum(IDdeljugador),
                        conversor.ConversorIDaNum(invitado),
                        Int32.Parse(HistoriaLocal[IDdeljugador][2]));
                        return true;
                    }
                    respuesta = "No tienes invitaciones pendientes";
                    return false;
                }
                return false;
            }
            catch (Exception)
            {
                long IDdeljugador = mensaje.Chat.Id;
                EstadosUsuarios estados = EstadosUsuarios.Instance();
                respuesta = "Ha habido un error. Intente de nuevo \n";
                estados.ReiniciarEstados(IDdeljugador);
                return true;
            }
        }
    }
}
