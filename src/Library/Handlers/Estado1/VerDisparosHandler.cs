using Telegram.Bot.Types;
using System.Text;
using System.Collections.Generic;

using System;


namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "VerHistorialPersonal".
    /// </summary>
    public class VerDisparosHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BaseHandler"/>. Esta clase procesa el mensaje "VerHistorialPersonal".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public VerDisparosHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/VerDisparos"};
        }

        /// <summary>
        /// Procesa el mensaje "VerHistorialPersonal" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="mensaje">El mensaje a procesar.</param>
        /// <param name="respuesta">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message mensaje, out string respuesta)
        {
            Disparos disparos = new Disparos();
            int numdisparos = disparos.DisparosEnGeneral();
            try
            {
                respuesta = string.Empty;
                if (this.CanHandle(mensaje))
                {
                    respuesta = "Estos son los disparos:\n";
                    respuesta += numdisparos;
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

