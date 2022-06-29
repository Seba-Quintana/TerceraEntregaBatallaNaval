using Telegram.Bot;

namespace ClassLibrary
{

    /// <summary>
    /// Un programa que implementa un bot de Telegram.
    /// </summary>
    public class SingletonBot
    {
        
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
        public static TelegramBotClient Instance(string token)
        {
            if (instance == null)
            {
                instance = new TelegramBotClient(token);
            }
            return instance;
        }
    }
}