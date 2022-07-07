using Telegram.Bot.Types;
using System.Text;
using System.Collections.Generic;
using System;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "VerHistorial".
    /// </summary>
    public class VerTiradasBarcoHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BaseHandler"/>. Esta clase procesa el mensaje "VerHistorial".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public VerTiradasBarcoHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/VerAtaquesABarcos"};
        }

        /// <summary>
        /// Procesa el mensaje "VerHistorial" y retorna true; retorna false en caso contrario.
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
                    long IDDelJugador = mensaje.Chat.Id;
                    int numdelJugador = Planificador.ConversorIDaNum(IDDelJugador);
                    respuesta += $"La cantidad de tiradas a barcos hasta el momento es: {Planificador.VerAtaquesABarcos(numdelJugador)}\n";
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                respuesta = "Ha ocurrido un error. Intente de nuevo \n";
                return true;
            }
        }

    }
}
