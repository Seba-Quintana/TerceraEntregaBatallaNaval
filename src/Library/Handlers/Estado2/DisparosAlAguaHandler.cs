using Telegram.Bot.Types;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "Comenzar".
    /// </summary>
    public class DisparosAguaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BaseHandler"/>. Esta clase procesa el mensaje "Comenzar".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public DisparosAguaHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/VerDisparosAlAgua"};
        }

        /// <summary>
        /// Procesa el mensaje "Comenzar" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="mensaje">El mensaje a procesar.</param>
        /// <param name="respuesta">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message mensaje, out string respuesta)
        {
            if (this.CanHandle(mensaje))
            {
                long IDDelJugador= mensaje.Chat.Id;
                int numeroDeJugador = Planificador.ConversorIDaNum(IDDelJugador);
                respuesta = $"Esta es la cantidad de disparos que han efectuado ambos jugadores al Agua {Planificador.CantidadDeDisparosAlAgua(numeroDeJugador)}";
                EstadosUsuarios estado = EstadosUsuarios.Instance();
                if (estado.VerEstado(IDDelJugador) == 2)
                respuesta += $"Vuelva a utilizar /posicionar para poder seguir añadiendo barcos"; //Lo agrego para que siga siendo facil utilizar el bot. Es innecesario para el problema
                else if (estado.VerEstado(IDDelJugador) == 3)
                respuesta += $"Vuelva a utilizar /Atacar para poder seguir atacando barcos"; //Lo agrego para que siga siendo facil utilizar el bot. Es innecesario para el problema
                return true;
            }
            respuesta = string.Empty;
            return false;
        }
    }
}
