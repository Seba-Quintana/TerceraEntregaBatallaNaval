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
                if (this.CanHandle(mensaje))
                {
                    long IDdeljugador = mensaje.Chat.Id;
                    UsersHistory historia = UsersHistory.Instance();
                    if (!HistoriaLocal.ContainsKey(IDdeljugador))
                    {
                        HistoriaLocal.Add(IDdeljugador, new string[3]);
                        HistoriaLocal[IDdeljugador][0] = mensaje.Text;
                        respuesta = "Indique su nombre: ";
                        return true;
                    }
                    else
                    {
                        if (HistoriaLocal[IDdeljugador][1] == null)
                        {
                            HistoriaLocal[IDdeljugador][1] = mensaje.Text;
                            respuesta = "Indique su contraseña: ";
                            return true;
                        }
                        else if (HistoriaLocal[IDdeljugador][2] == null)
                        {
                            HistoriaLocal[IDdeljugador][2] = mensaje.Text;
                            AlmacenamientoUsuario conversor = AlmacenamientoUsuario.Instance();
                            if (!Planificador.IniciarSesion(conversor.ConversorIDaNum(IDdeljugador), HistoriaLocal[IDdeljugador][1], HistoriaLocal[IDdeljugador][2]))
                            {
                                HistoriaLocal.Remove(IDdeljugador);
                                respuesta += "Inicio de Sesion fallido. Prueba nuevamente. \n Presione /InicioSesion";
                            }
                            else
                            {
                                respuesta += "Bienvenido, cazador de barcos. Presiona /Menu para ver los comandos disponibles \n";
                                historia.AvanzarEstados(IDdeljugador, 1);
                                HistoriaLocal.Remove(IDdeljugador);
                            }
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception)
            {
                respuesta = string.Empty;
                respuesta += "Ha habido un error. Intente de nuevo \n";
                return true;
            }
        }
    }
}
