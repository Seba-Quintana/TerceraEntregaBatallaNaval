using Telegram.Bot.Types;
using Telegram.Bot;

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
            respuesta = string.Empty;
            if (this.CanHandle(mensaje))
            {
                long IDdeljugadorRendido = mensaje.Chat.Id;
                AlmacenamientoUsuario almacenamiento = AlmacenamientoUsuario.Instance();
                int jugadorRendido = almacenamiento.ConversorIDaNum(IDdeljugadorRendido);
                int NumOponente = Planificador.ObtenerNumOponente(jugadorRendido);
                long IDOponente = almacenamiento.ConversorNumaID(NumOponente);
                TelegramBotClient bot = SingletonBot.Instance(null);
                respuesta += "Rendicion Completada, la partida ha sido guardada. Usted volvera al menu principal. \n Utilize /menu para mas información";
                UsersHistory estados = UsersHistory.Instance();
                if (estados.VerEstado(IDdeljugadorRendido) == 3)
                {
                    bot.SendTextMessageAsync(IDOponente, "Su oponente se ha rendido. Felicitaciones has ganado la partida \n  Usted volvera al menu principal. \n Utilize /menu para mas información");
                    respuesta += $"\n{estados.VerEstado(IDdeljugadorRendido)}";
                    estados.RetrocederEstados(IDdeljugadorRendido,1);
                    estados.RetrocederEstados(IDOponente,1);
                    respuesta += $"\n{estados.VerEstado(IDdeljugadorRendido)}";
                }
                   
                else if (estados.VerEstado(IDdeljugadorRendido) == 4)
                {
                    bot.SendTextMessageAsync(IDOponente, "Su oponente se ha rendido. Felicitaciones has ganado la partida \n  Usted volvera al menu principal. \n Utilize /menu para mas información");
                    respuesta += $"\n{estados.VerEstado(IDdeljugadorRendido)}";
                    estados.RetrocederEstados(IDdeljugadorRendido,2);
                    estados.RetrocederEstados(IDOponente,2);
                    respuesta += $"\n{estados.VerEstado(IDdeljugadorRendido)}";
                }
                return true;
            }
            return false;
        }
    }
}
