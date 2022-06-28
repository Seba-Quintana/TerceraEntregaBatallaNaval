using Telegram.Bot.Types;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "Registrar".
    /// </summary>
    public class RegistrarHandler : BaseHandler
    {
        /// <summary>
        /// El estado del comando.
        /// </summary>
        public Dictionary<long, string[]> HistoriaLocal = new Dictionary<long, string[]>();

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BaseHandler"/>. Esta clase procesa el mensaje "Registrar".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public RegistrarHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/Registrar" };
        }


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
        /// Procesa el mensaje "Registrar" y retorna true; retorna false en caso contrario.
        /// <summary>
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
                    HistoriaLocal[IDdeljugador][0] = mensaje.Text;
                    respuesta = "Indique su nombre :";
                    return true;
                }
                else
                {
                    if (HistoriaLocal[IDdeljugador][1] == null)
                    {
                            HistoriaLocal[IDdeljugador][1] = mensaje.Text;
                            respuesta = $"{HistoriaLocal[IDdeljugador][1]} \n" + "Indique su contraseña :";
                            return true;
                    }
                    else if (HistoriaLocal[IDdeljugador][2] == null)
                    {
                            HistoriaLocal[IDdeljugador][2] = mensaje.Text;
                            int numDeUsuario = Planificador.Registrar(HistoriaLocal[IDdeljugador][1] , IDdeljugador, HistoriaLocal[IDdeljugador][2]);
                            respuesta += "Registro Completado";
                            respuesta += $"\nNombre {HistoriaLocal[IDdeljugador][1]} y Contraseña {HistoriaLocal[IDdeljugador][2]} ";
                            respuesta += $"\nEste es tu numero de Usuario {numDeUsuario} , recuerdalo  ";
                            historia.AvanzarEstados(IDdeljugador, 1);
                            HistoriaLocal.Remove(IDdeljugador);
                            return true;
                    }
                }
            }

            return false;
        }
    }
}
