using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Telegram.Bot;
namespace ClassLibrary
{

    /// <summary>
    /// Un programa que implementa un bot de Telegram.
    /// </summary>
    public class SingletonBot
    {
        private static string token;
        // Esta clase es un POCO -vean https://en.wikipedia.org/wiki/Plain_old_CLR_object- para representar el token
        // secreto del bot.
        private class BotSecret
        {
            public string Token { get; set; }
        }
        
        // Una interfaz requerida para configurar el servicio que lee el token secreto del bot.
        private interface ISecretService
        {
            string Token { get; }
        }

        // Una clase que provee el servicio de leer el token secreto del bot.
        private class SecretService : ISecretService
        {
            private readonly BotSecret _secrets;

            public SecretService(IOptions<BotSecret> secrets)
            {
                _secrets = secrets.Value ?? throw new ArgumentNullException(nameof(secrets));
            }

            public string Token { get { return _secrets.Token; } }
        }
        private static void Start()
        {
            // Lee una variable de entorno NETCORE_ENVIRONMENT que si no existe o tiene el valor 'development' indica
            // que estamos en un ambiente de desarrollo.
            var developmentEnvironment = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
            var isDevelopment =
                string.IsNullOrEmpty(developmentEnvironment) ||
                developmentEnvironment.ToLower() == "development";

            var builder = new ConfigurationBuilder();
            builder
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            // En el ambiente de desarrollo el token secreto del bot se toma de la configuración secreta
            if (isDevelopment)
            {
                builder.AddUserSecrets<SingletonBot>();
            }

            var configuration = builder.Build();

            IServiceCollection services = new ServiceCollection();

            // Mapeamos la implementación de las clases para  inyección de dependencias
            services
                .Configure<BotSecret>(configuration.GetSection(nameof(BotSecret)))
                .AddSingleton<ISecretService, SecretService>();

            var serviceProvider = services.BuildServiceProvider();
            var revealer = serviceProvider.GetService<ISecretService>();
            SingletonBot.token = revealer.Token;
        }

        /// <summary>
        /// Parte de singleton. Atributo donde se guarda la instancia del AlmacenamientoUsuario (o null si no fue creada).
        /// </summary>
        static TelegramBotClient instance;

        /// <summary>
        /// Parte de singleton. Constructor llamado por el metodo Instance de crearse un AlmacenamientoUsuario.
        /// </summary>
        private SingletonBot()
        {
        }

        /// <summary>
        /// Singleton de AlmacenamientoUsuario. Si no existe una instancia de AlmacenamientoUsuario, crea una. Si ya existe la devuelve
        /// </summary>
        /// <returns> Instancia nueva de AlmacenamientoUsuario, o de darse el caso, una previamente creada </returns>
        public static TelegramBotClient Instance()
        {
            if (instance == null)
            {
                instance = new TelegramBotClient(token);
            }
            return instance;
        }

        public static void StartBot()
        {
            Start();
        }
    }
}
