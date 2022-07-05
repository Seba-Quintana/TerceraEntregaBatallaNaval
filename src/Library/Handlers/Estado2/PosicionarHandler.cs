using Telegram.Bot.Types;
using System.Collections.Generic;
using Telegram.Bot;
using System;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "VerHistorialPersonal".
    /// </summary>
    public class PosicionarHandler : BaseHandler
    {
        /// <summary>
        /// Contiene como key un long el cual es ocupado por los id de los distintos jugadores.
        /// El array de string se utiliza para poder ver los estados y 
        /// guardar informacion al cambiar el estado interno.
        /// </summary>
        /// <returns></returns>
        public Dictionary<long, string[]> EstadoLocal = new Dictionary<long, string[]>();
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BaseHandler"/>. Esta clase procesa el mensaje "Menu".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public PosicionarHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/Posicionar"};
        }
        /// <summary>
        /// Cambio el CanHandle que herede para poder utilizar el estado interno del handler.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected override bool CanHandle(Message message)
        {
            if (!EstadoLocal.ContainsKey(message.Chat.Id) || (message.Text).StartsWith("/"))
            {
                return base.CanHandle(message);
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Procesa el mensaje "Menu" y retorna true; retorna false en caso contrario.
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
                    int numdelJugador = Planificador.ConversorIDaNum(IDDelJugador);
                    
                    int NumDelJugadorOponente = Planificador.ObtenerNumOponente(numdelJugador);
                    long IDDelOponente = Planificador.ConversorNumaID (NumDelJugadorOponente);
                    TelegramBotClient bot = SingletonBot.Instance();
                
                    if (!EstadoLocal.ContainsKey(IDDelJugador))
                    {
                        respuesta += "Bienvenido a la etapa de posicionamiento";
                        respuesta += $"\nEn esta etapa no se pueden posicionar barcos diagonalmente";
                        EstadoLocal.Add(IDDelJugador, new string[3]);
                        respuesta += $"\n{Planificador.VerTablero(numdelJugador)}";
                        respuesta += $"\nIndique la casilla de inicio del barco :";
                        return true;
                    }
                    else
                    {
                        if (EstadoLocal[IDDelJugador][0] == null)
                        {
                            EstadoLocal[IDDelJugador][0] = mensaje.Text;
                            respuesta = "Indique la casilla final del barco :";
                            return true;
                        }
                        else if (EstadoLocal[IDDelJugador][1] == null)
                        {
                            EstadoLocal[IDDelJugador][1] = mensaje.Text;
                            string ResultadoPosicionamiento = Planificador.Posicionar(EstadoLocal[IDDelJugador][0] , EstadoLocal[IDDelJugador][1], numdelJugador);
                            respuesta += ResultadoPosicionamiento;
                            respuesta += $"\n{Planificador.VerTablero(numdelJugador)}";
                            this.EstadoLocal[IDDelJugador][0] = null;
                            this.EstadoLocal[IDDelJugador][1] = null;
                            if (Planificador.PosicionamientoFinalizado(numdelJugador))
                            {
                                if (Planificador.PosicionamientoFinalizado(NumDelJugadorOponente))
                                {
                                    bot.SendTextMessageAsync(IDDelOponente, $"El oponente a finalizado su etapa de posicionamiento \nUtiliza /Atacar para poder atacar barcos del tablero enemigo.");
                                    respuesta += $"\nHa terminado la etapa de posicionamiento, apartir de ahora podras atacar \nUtiliza /Atacar para iniciar tu ofensiva, Buena suerte.";
                                }
                                else
                                {
                                    respuesta += $"\nYa no podras posicionar más barcos en esta partida, espera a que tu oponente termine de colocar sus barcos. \n Te notificare cuando suceda."; 
                                }
                                historia.AvanzarEstados(IDDelJugador, 1);
                                EstadoLocal.Remove(IDDelJugador);
                            }
                            else
                            {
                                respuesta += "Indique la casilla de inicio del proximo barco :";
                            }
                            return true;
                        }
                    }
                }
                if (EstadoLocal.ContainsKey(IDDelJugador))
                {
                    EstadoLocal.Remove(IDDelJugador);
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
