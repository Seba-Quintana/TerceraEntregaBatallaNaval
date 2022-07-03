using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase se encarga de añadir las partidas que se jugaron a una lista,
    /// con el objetivo de mantener un registro de las partidas jugadas.
    /// </summary>
    public class Historial
    {
      /// <summary>
      /// Lista de DatosdePartida
      /// </summary>
      public List<DatosdePartida> Partidas = new List<DatosdePartida>();
      /// <summary>
      /// Parte de singleton. Atributo donde se guarda la instancia del Historial (o null si no fue creada).
      /// </summary>
      static Historial instance;

      /// <summary>
      /// Parte de singleton. Constructor llamado por el metodo Instance de crearse un Historial.
      /// </summary>
      private Historial()
      {
      }

      /// <summary>
      /// Singleton de Historial. Si no existe una instancia de Historial, crea una. Si ya existe la devuelve
      /// </summary>
      /// <returns> Instancia nueva de Historial, o de darse el caso, una previamente creada </returns>
        public static Historial Instance()
        {
            if (instance == null)
            {
                instance = new Historial();
            }
            return instance;
        }

      /// <summary>
      /// Almacena la partida en el historial general y los historiales personales de los jugadores.
      /// </summary>
      /// <param name="partida"> partida a almacenar </param>
      public void AlmacenarPartida(DatosdePartida partida)
      {
        AlmacenamientoUsuario buscador = AlmacenamientoUsuario.Instance();
        PerfilUsuario jugador1 = buscador.ObtenerPerfil(partida.Jugadores[0]);
        PerfilUsuario jugador2 = buscador.ObtenerPerfil(partida.Jugadores[1]);
        jugador1.AgregarAlHistorial(partida);
        jugador2.AgregarAlHistorial(partida);
        Partidas.Add(partida);
      }
      public string SerializarUsuarios()
        {
            
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true
            };
            string usuarios= JsonSerializer.Serialize<List<DatosdePartida>>(Partidas,options);
            return usuarios;
        }
        public void LoadFromJson(string rutaDeArchivo)
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true
            };
            string json = System.IO.File.ReadAllText(rutaDeArchivo);
            List<DatosdePartida> listavieja = JsonSerializer.Deserialize<List<DatosdePartida>>(json, options);
            foreach (DatosdePartida Partidasviejas in listavieja)
            {
              this.Partidas.Add(Partidasviejas);
            }
        }
    }
}
