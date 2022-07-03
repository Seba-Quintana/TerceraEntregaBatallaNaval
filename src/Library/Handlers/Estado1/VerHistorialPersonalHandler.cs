using Telegram.Bot.Types;
using System.Text;
using System.Collections.Generic;

using System;


namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "VerHistorialPersonal".
    /// </summary>
    public class VerHistorialPersonalHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BaseHandler"/>. Esta clase procesa el mensaje "VerHistorialPersonal".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public VerHistorialPersonalHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/VerHistorialPersonal"};
        }

        /// <summary>
        /// Procesa el mensaje "VerHistorialPersonal" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="mensaje">El mensaje a procesar.</param>
        /// <param name="respuesta">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message mensaje, out string respuesta)
        {  
            try
            {
                if (this.CanHandle(mensaje))
                {
                    long IDdeljugador = mensaje.Chat.Id;
                    AlmacenamientoUsuario almacenamiento = AlmacenamientoUsuario.Instance();
                    int jugador = almacenamiento.ConversorIDaNum(IDdeljugador);
                    Planificador.VerHistorialPersonal(jugador);
                    respuesta = "Este es tu Historial Personal.";
                    return true;
                }

                respuesta = "No tienes nada en tu historial personal";
                return false;
            }
            catch (Exception)
            {
                respuesta = "Ha habido un error. Intente de nuevo \n";
                return true;
            }
        }
    }
}
