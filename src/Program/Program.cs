﻿using System;
using ClassLibrary;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using System.Text.Json;

namespace ConsoleApplication
{

    /// <summary>
    /// Un programa que implementa un bot de Telegram.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// La instancia del bot.
        /// </summary>
        private static TelegramBotClient Bot;
        private static EstadosUsuarios HistoriaDeUsuarios = EstadosUsuarios.Instance();
        private static IHandler inicialHandler;
        private static IHandler primerHandler;
        private static IHandler segundoHandler;
        private static IHandler tercerHandler;
        private static IHandler cuartoHandler;
        /// <summary>
        /// Punto de entrada al programa.
        /// </summary>
        public static void Main(string[] args)
        {
            SingletonBot.StartBot();

            Bot = SingletonBot.Instance(); 

            AlmacenamientoUsuario UsuariosGuardados = AlmacenamientoUsuario.Instance();

            Historial HistorialGuardado = Historial.Instance();
            SingletonBot.StartBot();

            if (System.IO.File.Exists(@"HistorialGeneral.json"))
            {
                
                HistorialGuardado.LoadFromJson(@"HistorialGeneral.json");
            }
            if (System.IO.File.Exists(@"Usuarios.json"))
            {
                
                UsuariosGuardados.LoadFromJson(@"Usuarios.json");
            }
            

            inicialHandler = new ComenzarHandler(null);

            primerHandler = new InicioSesionHandler(new RegistrarHandler(new RemoverUsuarioHandler(null)));

            segundoHandler = new MenuHandler(new AyudaHandler(new VerRankingHandler(new VerHistorialHandler(new VerPerfilHandler(new VerHistorialPersonalHandler(new BuscarPartidaHandler(new BuscarPartidaAmistosaHandler(new ConfirmarPartidaHandler(new SalirEmparejamientoHandler(new RemoverUsuarioHandler(null)))))))))));

            // El handler para rendirse se encuentra tanto en el tercer como en el cuarto handler
            // porque el usuario se debe poder rendir en cualquiera de los dos estados
            tercerHandler = new PosicionarHandler(new RendirseHandler(new VerTiradasAguaHandler(new VerTiradasBarcoHandler(null))));

            cuartoHandler = new AtacarHandler(new RendirseHandler(new VerTiradasAguaHandler(new VerTiradasBarcoHandler(null))));


            var cts = new CancellationTokenSource();

            // Comenzamos a escuchar mensajes. Esto se hace en otro hilo (en background). El primer método
            // HandleUpdateAsync es invocado por el bot cuando se recibe un mensaje. El segundo método HandleErrorAsync
            // es invocado cuando ocurre un error.
            Bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                new ReceiverOptions()
                {
                    AllowedUpdates = Array.Empty<UpdateType>()
                },
                cts.Token
            );

            Console.WriteLine($"Bot is up!");

            // Esperamos a que el usuario aprete Enter en la consola para terminar el bot.
            Console.ReadLine();
            
            System.IO.File.WriteAllText(@"HistorialGeneral.json", HistorialGuardado.SerializarUsuarios());
            System.IO.File.WriteAllText(@"Usuarios.json", UsuariosGuardados.SerializarUsuarios());           

            // Terminamos el bot.
            cts.Cancel();
        }

        /// <summary>
        /// Maneja las actualizaciones del bot (todo lo que llega), incluyendo mensajes, ediciones de mensajes,
        /// respuestas a botones, etc. En este ejemplo sólo manejamos mensajes de texto.
        /// </summary>
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            try
            {
                // Sólo respondemos a mensajes de texto
                if (update.Type == UpdateType.Message)
                {
                    await HandleMessageReceived(botClient, update.Message);
                }
            }
            catch(Exception e)
            {
                await HandleErrorAsync(botClient, e, cancellationToken);
            }
        }

        /// <summary>
        /// Maneja los mensajes que se envían al bot.
        /// Lo único que hacemos por ahora es escuchar 3 tipos de mensajes:
        /// </summary>
        /// <param name="message">El mensaje recibido</param>
        /// <param name="botClient"></param>

        /// <returns></returns>
        private static async Task HandleMessageReceived(ITelegramBotClient botClient, Message message)
        {
            long IdDeUsuario = message.Chat.Id;
            Console.WriteLine($"Received a message from {message.From.FirstName} saying: {message.Text}");
            string response = string.Empty;

            if(HistoriaDeUsuarios.ContieneId(IdDeUsuario))
            {
                /* Segun el estado en el que se encuentre el jugador, cambian los handlers que
                tiene a su disposicion. De esta manera se restringe el acceso al usuario
                segun las acciones que tiene disponibles en cada estado*/
                int EstadoActual = HistoriaDeUsuarios.VerEstado(IdDeUsuario);
                switch(EstadoActual)
                {
                    case 0:
                        primerHandler.Handle(message, out response);
                        break;
                    case 1:
                        segundoHandler.Handle(message, out response);
                        break;
                    case 2:
                        tercerHandler.Handle(message, out response);
                        break;
                    case 3:
                        cuartoHandler.Handle(message, out response);
                        break;

                }
            }
            else
            {
                inicialHandler.Handle(message, out response);
            }
            
            if (!string.IsNullOrEmpty(response))
            {
                await Bot.SendTextMessageAsync(IdDeUsuario, response);
            }
        }

        /// <summary>
        /// Manejo de excepciones. Por ahora simplemente la imprimimos en la consola.
        /// </summary>
        public static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(exception.Message);
            return Task.CompletedTask;
        }
    }
}
