using Telegram.Bot.Types;
using Telegram.Bot;
using System;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "TiradasBarco".
    /// </summary>
    public class TiradasBarcoHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BaseHandler"/>. Esta clase procesa el mensaje "Remover".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public TiradasBarcoHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/TiradasBarco"};
        }

        /// <summary>
        /// Procesa el mensaje "Remover" y retorna true; retorna false en caso contrario.
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
                    TelegramBotClient bot = SingletonBot.Instance();
                    
                    long IDjugadorActual = mensaje.Chat.Id;
                    int jugadorActual = Planificador.ConversorIDaNum(IDjugadorActual);
                    int NumOponente = Planificador.ObtenerNumOponente(jugadorActual);
                    long IDOponente = Planificador.ConversorNumaID(NumOponente);
                    
                    int tiradasBarco = Planificador.TiradasBarcoTotales(jugadorActual);
                    string respuestaTiradasBarco = tiradasBarco.ToString();

                    respuesta += $"la cantidad de tiradas totales en barcos es de: {respuestaTiradasBarco}.\n";
                    
                    return true;
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
