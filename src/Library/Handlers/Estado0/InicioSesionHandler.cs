using Telegram.Bot.Types;
using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "InicioSesion".
    /// </summary>
    public class InicioSesionHandler : BaseHandler
    {
        /// <summary>
        /// El estado del handler para cada usuario.
        /// </summary>		
        public Dictionary<long, string[]> HistoriaLocal = new Dictionary<long, string[]>();

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BaseHandler"/>. Esta clase procesa el mensaje "InicioSesion".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public InicioSesionHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/InicioSesion"};
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
        /// Procesa el mensaje "InicioSesion" y retorna true; retorna false en caso contrario.
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
                    EstadosUsuarios historia = EstadosUsuarios.Instance();
                    if (!HistoriaLocal.ContainsKey(IDDelJugador))
                    {
                        HistoriaLocal.Add(IDDelJugador, new string[3]);
                        HistoriaLocal[IDDelJugador][0] = mensaje.Text;
                        respuesta += "Indique su nombre: ";
                        return true;
                    }
                    else
                    {
                        if (HistoriaLocal[IDDelJugador][1] == null)
                        {
                            HistoriaLocal[IDDelJugador][1] = mensaje.Text;
                            respuesta = "Indique su contraseña: ";
                            return true;
                        }
                        else if (HistoriaLocal[IDDelJugador][2] == null)
                        {
                            HistoriaLocal[IDDelJugador][2] = mensaje.Text;
                            AlmacenamientoUsuario conversor = AlmacenamientoUsuario.Instance();
                            if (!Planificador.IniciarSesion(conversor.ConversorIDaNum(IDDelJugador), HistoriaLocal[IDDelJugador][1], HistoriaLocal[IDDelJugador][2]))
                            {
                                HistoriaLocal.Remove(IDDelJugador);
                                respuesta += "Inicio de Sesion fallido. Prueba nuevamente. \nPresione /InicioSesion o /Registrar";
                            }
                            else
                            {
                                respuesta += "Bienvenido, cazador de barcos. \n Presiona /Menu para ver los comandos disponibles \n";
                                historia.AvanzarEstados(IDDelJugador, 1);
                                HistoriaLocal.Remove(IDDelJugador);
                            }
                            return true;
                        }
                    }
                }
                if (HistoriaLocal.ContainsKey(IDDelJugador))
                {
                    HistoriaLocal.Remove(IDDelJugador);
                }
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
