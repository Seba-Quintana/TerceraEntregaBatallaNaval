using Telegram.Bot.Types;
using System.Collections.Generic;
using System;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "Registrar".
    /// </summary>
    public class RegistrarHandler : BaseHandler
    {
        /// <summary>
        /// El estado del handler para cada usuario.
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
        /// Procesa el mensaje "Registrar" y retorna true; retorna false en caso contrario.
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
                        respuesta = "Indique su nombre :";
                        return true;
                    }
                    else
                    {
                        if (HistoriaLocal[IDDelJugador][1] == null)
                        {
                            HistoriaLocal[IDDelJugador][1] = mensaje.Text;
                            respuesta = $"{HistoriaLocal[IDDelJugador][1]} \n" + "Indique su contraseña :";
                            return true;
                        }
                        else if (HistoriaLocal[IDDelJugador][2] == null)
                        {
                            HistoriaLocal[IDDelJugador][2] = mensaje.Text;
                            int numDeUsuario = Planificador.Registrar(HistoriaLocal[IDDelJugador][1] , IDDelJugador, HistoriaLocal[IDDelJugador][2]);
                            respuesta += "Registro Completado";
                            respuesta += $"\nSu nombre de usuario es {HistoriaLocal[IDDelJugador][1]} y su contraseña {HistoriaLocal[IDDelJugador][2]}.";
                            respuesta += $"\nEste es tu numero de Usuario : {numDeUsuario}. Recuerdelo.";
                            respuesta += $"\nSeras enviado al menu principal,";
                            respuesta += $"\nUtilice /menu para poder obtener mas información.";
                            historia.AvanzarEstados(IDDelJugador, 1);
                            HistoriaLocal.Remove(IDDelJugador);
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
            catch (CuentaYaExistenteException e)
            {
                respuesta = e.Message + "\nPresione /InicioSesion para ingresar,\no /Remover si quiere crearse un usuario nuevo";
                return true;
            }
            catch (Exception)
            {
                respuesta = "Ha ocurrido un error. Intente de nuevo\n";
                return true;
            }
        }
    }
}
