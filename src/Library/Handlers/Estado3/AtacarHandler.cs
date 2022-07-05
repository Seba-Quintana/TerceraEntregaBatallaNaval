using Telegram.Bot.Types;
using System.Collections.Generic;
using Telegram.Bot;
using System;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "Atacar".
    /// </summary>
    public class AtacarHandler : BaseHandler
    {
        /// <summary>
        /// Contiene como key un long el cual es ocupado por los id de los distintos jugadores.
        /// El array de string se utiliza para poder ver los estados y 
        /// guardar informacion al cambiar el estado interno.
        /// </summary>
        /// <returns></returns>
        public List<long> EstadoLocal = new List<long>();
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BaseHandler"/>. Esta clase procesa el mensaje "Atacar".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public AtacarHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/Atacar"};
        }
        /// <summary>
        /// Cambio el CanHandle que herede para poder utilizar el estado interno del handler.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected override bool CanHandle(Message message)
        {
            if (!EstadoLocal.Contains(message.Chat.Id) || (message.Text).StartsWith("/"))
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
                    long IDDelOponente = Planificador.ConversorNumaID(NumDelJugadorOponente);

                    TelegramBotClient bot = SingletonBot.Instance();
                
                    if (!EstadoLocal.Contains(IDDelJugador))
                    {
                        EstadoLocal.Add(IDDelJugador);
                        respuesta += $"\nIndique la casilla que desee atacar,\no presione /rendirse cuando lo desee:";
                        return true;
                    }
                    else
                    {
                        string mensajeOponente = string.Empty;
                        string ResultadoAtacar = Planificador.Atacar(mensaje.Text, numdelJugador);
                        respuesta += ResultadoAtacar;
                        respuesta += $"\nAl oponente le quedan {Planificador.CantidadDeBarcosintactos(NumDelJugadorOponente)} partes de barco enteras";
                        respuesta += $"\n{Planificador.VerTableroOponente(NumDelJugadorOponente)}";
                        if (ResultadoAtacar != "Debe esperar a que el otro jugador lo ataque")
                            if (ResultadoAtacar != "La coordenada enviada fue invalida")
                            {
                                mensajeOponente = $"Has sido atacado en {mensaje.Text}\n\nTABLERO PROPIO \n\n{Planificador.VerTablero(NumDelJugadorOponente)}";
                                if (Planificador.PartidaFinalizada(numdelJugador))
                                {
                                    respuesta += $"\n\nFelicitaciones!!, has ganado la partida. \nLa partida se guardara en su historial y seras enviado al menu principal \nPresione /menu para mas información";
                                    mensajeOponente += "\n\nLamentablemente has perdido. \nLa partida se guardara en su historial y seras enviado al menu principal \nPresione /menu para mas información";
                                    historia.ReiniciarEstados(IDDelOponente);
                                    historia.ReiniciarEstados(IDDelJugador);
                                    EstadoLocal.Remove(IDDelOponente);
                                    EstadoLocal.Remove(IDDelJugador);
                                }
                                else if(Planificador.TurnoDelJugador(numdelJugador))
                                {
                                    respuesta += "Le queda un disparo, utilizelo sabiamente.";
                                }
                                else
                                {
                                    mensajeOponente += $"Indique la proxima casilla que desea atacar:";
                                    respuesta += $"Le notificaremos cuando vuelva a ser su turno de atacar, espere el mensaje por favor.";
                                }
                                bot.SendTextMessageAsync(IDDelOponente, mensajeOponente);
                            }
                        return true;
                    }
                }
                if (EstadoLocal.Contains(IDDelJugador))
                {
                    EstadoLocal.Remove(IDDelJugador);
                }
                return false;
            }
            catch (Exception)
            {
                long IDdeljugador = mensaje.Chat.Id;
                EstadosUsuarios estados = EstadosUsuarios.Instance();
                respuesta = "Ha ocurrido un error. Intente de nuevo \n";
                estados.ReiniciarEstados(IDdeljugador);
                return true;
            }
        }
    }
}

