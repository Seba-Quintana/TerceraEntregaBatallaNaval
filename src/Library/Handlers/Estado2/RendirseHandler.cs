using Telegram.Bot.Types;
using Telegram.Bot;
using System;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "Rendirse".
    /// </summary>
    public class RendirseHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BaseHandler"/>. Esta clase procesa el mensaje "Remover".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public RendirseHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/Rendirse"};
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
                    AlmacenamientoUsuario almacenamiento = AlmacenamientoUsuario.Instance();
                    TelegramBotClient bot = SingletonBot.Instance();
                    EstadosUsuarios estados = EstadosUsuarios.Instance();
                    
                    long IDdeljugadorRendido = mensaje.Chat.Id;
                    int jugadorRendido = almacenamiento.ConversorIDaNum(IDdeljugadorRendido);
                    int NumOponente = Planificador.ObtenerNumOponente(jugadorRendido);
                    long IDOponente = almacenamiento.ConversorNumaID(NumOponente);
                    
                    Planificador.Rendirse(jugadorRendido);

                    respuesta += "Rendicion Completada, la partida ha sido guardada. Usted volvera al menu principal. \n Utilize /menu para mas información";
                    Planificador.Rendirse(jugadorRendido);
                    if (estados.VerEstado(IDdeljugadorRendido) == 2)
                    {
                        bot.SendTextMessageAsync(IDOponente, "Su oponente se ha rendido. Felicitaciones has ganado la partida \n  Usted volvera al menu principal. \n Utilize /menu para mas información");
                        estados.RetrocederEstados(IDdeljugadorRendido,1);
                        estados.RetrocederEstados(IDOponente,1);
                    }
                    
                    else if (estados.VerEstado(IDdeljugadorRendido) == 3)
                    {
                        bot.SendTextMessageAsync(IDOponente, "Su oponente se ha rendido. Felicitaciones has ganado la partida \n  Usted volvera al menu principal. \n Utilize /menu para mas información");
                        estados.RetrocederEstados(IDdeljugadorRendido,2);
                        estados.RetrocederEstados(IDOponente,2);
                    }
                    return true;
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
