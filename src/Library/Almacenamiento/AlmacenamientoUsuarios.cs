using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Clase AlmacenamientoUsuario. Se encarga de manejar todos los datos vinculados con los usuarios.
    /// </summary>
    public class AlmacenamientoUsuario
    {
        /// <summary>
        /// Almacenamiento de usuarios
        /// </summary>
        public List<PerfilUsuario> ListaDeUsuarios;
        
        /// <summary>
        /// Parte de singleton. Atributo donde se guarda la instancia del AlmacenamientoUsuario (o null si no fue creada).
        /// </summary>
        static AlmacenamientoUsuario instance;

        /// <summary>
        /// Parte de singleton. Constructor llamado por el metodo Instance de crearse un AlmacenamientoUsuario.
        /// </summary>
        private AlmacenamientoUsuario()
        {
            this.Inicializar();
        }

        /// <summary>
        /// Singleton de AlmacenamientoUsuario. Si no existe una instancia de AlmacenamientoUsuario, crea una. Si ya existe la devuelve
        /// </summary>
        /// <returns> Instancia nueva de AlmacenamientoUsuario, o de darse el caso, una previamente creada </returns>
        public static AlmacenamientoUsuario Instance()
        {
            if (instance == null)
            {
                instance = new AlmacenamientoUsuario();
            }
            return instance;
        }
        public void Inicializar()
        {
            ListaDeUsuarios = new List<PerfilUsuario>();
        }
        /// <summary>
        /// Crea un nuevo perfil de usuario asignandole un numero de jugador.
        /// Si es el primer usuario creado le asigna el numero 1, de lo contrario le asigna el
        /// numero mas alto de un jugador existente +1,
        /// y luego crea un PerfilUsuario con los datos necesarios para agregarlo a la lista de usuarios.
        /// </summary>
        /// <param name="nombre"> nombre del usuario</param>
        /// <param name="id"> id proporcionada por el bot </param>
        /// <param name="contrasena"> contraseña </param>
        public int Registrar(string nombre, long id, string contrasena)
        {
            int numeroDeJugador = 1;
            if (ListaDeUsuarios.Count != 0)
            {
                numeroDeJugador = ListaDeUsuarios[ListaDeUsuarios.Count - 1].NumeroDeJugador + 1;
            }    
            PerfilUsuario usuario = new PerfilUsuario(nombre, id, contrasena, numeroDeJugador);
            ListaDeUsuarios.Add(usuario);
            return numeroDeJugador;
        }
        /// <summary>
        /// Si el numero de usuarios pertenece a un PerfilUsuario existente
        /// en la lista de perfiles de AlmacenamientoUsuario, lo elimina de la misma.
        /// </summary>
        /// <param name="NumeroDeJugador"> numero del jugador a remover </param>
        public void Remover(int NumeroDeJugador)
        {
            if(ObtenerPerfil(NumeroDeJugador) != null)
            {
                int i = 0;
                while (i < ListaDeUsuarios.Count )
                {
                    if (ListaDeUsuarios[i].NumeroDeJugador == NumeroDeJugador)
                    {
                        ListaDeUsuarios.Remove(ListaDeUsuarios[i]);  
                        i = i - 1;
                    }
                    i = i + 1;
                }
            }
        }
        /// <summary>
        /// Si el PerfilUsuario que contiene el numero de usuario ingresado
        /// se encuentra en la lista de perfiles de AlmacenamientoUsuario, este metodo devuelve su perfil.
        /// </summary>
        /// <param name="usuario"> numero del jugador </param>
        /// <returns> perfil de usuario </returns>
        public PerfilUsuario ObtenerPerfil(int usuario)
        {
            foreach(PerfilUsuario perfil in ListaDeUsuarios)
            {
                if (perfil.NumeroDeJugador == usuario)
                {
                    return perfil;
                }
            }
            return null;
        }

        /// <summary>
        /// Si el numero de jugador ingresado tiene una partida en juego,
        /// pide mostrar el tablero del oponente.
        /// </summary>
        /// <param name="jugador"> jugador en partida </param>
        public char[,] ObtenerTableroOponente(int jugador)
        {
            try
            {
                if (!ListaDeUsuarios.Contains(ObtenerPerfil(jugador)))
                    throw new JugadorNoEncontradoException();
            }
            catch (JugadorNoEncontradoException)
            {
                throw new JugadorNoEncontradoException
                ("No se encontro el tablero del oponente", jugador);
            }
            PartidasEnJuego partidas = PartidasEnJuego.Instance();
            if (partidas.EstaElJugadorEnPartida(jugador))
            {
                Partida juego = partidas.ObtenerPartida(jugador);
                return juego.VistaOponente(jugador);
            }
            
            return null;
        }

        /// <summary>
        /// Si el numero de jugador ingresado tiene una partida en juego,
        /// pide mostrar su propio tablero.
        /// </summary>
        /// <param name="jugador"> jugador en partida </param>
        public char[,] ObtenerTablero(int jugador)
        {
            try
            {
                if (!ListaDeUsuarios.Contains(ObtenerPerfil(jugador)))
                    throw new JugadorNoEncontradoException();
            }
            catch (JugadorNoEncontradoException)
            {
                throw new JugadorNoEncontradoException
                ("No se encontro el tablero del jugador", jugador);
            }
            PartidasEnJuego partidas = PartidasEnJuego.Instance();
            if (partidas.EstaElJugadorEnPartida(jugador))
            {
                Partida juego = partidas.ObtenerPartida(jugador);
                return juego.VerTableroPropio(jugador);
            }
            return null;
        }

        /// <summary>
        /// Si el numero pertenece a un PerfilUsuario en la lista de perfiles de AlmacenamientoUsuario
        /// pide mostrar el HistorialPersonal de todas las partidas jugadas de este perfil.
        /// </summary>
        /// <param name="numerodejugador"> historial que se quiere ver</param>
        public List<DatosdePartida> ObtenerHistorialPersonal(int numerodejugador)
        {
            try
            {
                if (!ListaDeUsuarios.Contains(ObtenerPerfil(numerodejugador)))
                    throw new JugadorNoEncontradoException();
            }
            catch (JugadorNoEncontradoException)
            {
                throw new JugadorNoEncontradoException
                ("No se encontro el historial del jugador", numerodejugador);
            }
            PerfilUsuario perfil = ObtenerPerfil(numerodejugador);
            return perfil.ObtenerHistorialPersonal();
        }

        /// <summary>
        /// Realiza una lista de PerfilUsuario ordenados por cantidad de partidas ganadas,
        /// y le pide a la retorna.
        /// </summary>
        public List<PerfilUsuario> ObtenerRanking()
        {
            List<PerfilUsuario> ranking = new List<PerfilUsuario>();
            int i = 0;
            while (i < ListaDeUsuarios.Count)
            {
                ranking.Add(ListaDeUsuarios[i]);
                i++;
            }
            int j = 0;
            i = 0;
            int actual = 0;
            while ((actual < ranking.Count))
            {   i=actual;
                j= i+1;
                while ((i < ranking.Count)&&(j < ranking.Count))
                {
                    if (ranking[i].Ganadas > ranking[j].Ganadas)
                    {
                        j=j+1;
                    }
                    else 
                    {
                        i=j;
                        j=j+1;
                        
                    }
                }
                PerfilUsuario claseCopia = (PerfilUsuario)ranking[i].Clone();
                ranking[i] = (PerfilUsuario)ranking[actual].Clone();
                ranking[actual] = claseCopia;
                actual++;
            }
            return ranking;
        }

        /// <summary>
        /// Se fija si un usuario existe o no
        /// </summary>
        /// <param name="iDdelUsuario"> ID del usuario </param>
        /// <returns> devuelve true de existir el usuario, y de lo contrario false </returns>
        public bool ExisteUsuario(long iDdelUsuario)
        {
            foreach(PerfilUsuario perfil in ListaDeUsuarios)
            {
                if (perfil.ID == iDdelUsuario)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Convierte la ID de un usuario a su respectivo numero de jugador
        /// </summary>
        /// <param name="iDdelUsuario"> ID del usuario</param>
        /// <returns> numero de jugador del usuario </returns>
        public int ConversorIDaNum(long iDdelUsuario)
        {
            foreach(PerfilUsuario perfil in ListaDeUsuarios)
            {
                if (perfil.ID == iDdelUsuario)
                {
                    return perfil.NumeroDeJugador;
                }
            }
            return 0;
        }

        /// <summary>
        /// Convierte el numero de jugador de un usuario a su respectiva ID
        /// </summary>
        /// <param name="numdelUsuario"> numero del jugador </param>
        /// <returns> ID del jugador </returns>
        public long ConversorNumaID(int numdelUsuario)
        {
            foreach(PerfilUsuario perfil in ListaDeUsuarios)
            {
                if (perfil.NumeroDeJugador == numdelUsuario)
                {
                    return perfil.ID;
                }
            }
            return 0;
        }
        
        /// <summary>
        /// Se fija si un usuario existe, y de existir devuelve true
        /// </summary>
        /// <param name="numeroDeJugador"></param>
        /// <param name="nombre"></param>
        /// <param name="contrasena"></param>
        /// <returns></returns>
        public bool InicioSesion(int numeroDeJugador, string nombre, string contrasena)
        {
            PerfilUsuario jugador = ObtenerPerfil(numeroDeJugador);
            foreach (PerfilUsuario perfil in ListaDeUsuarios)
            {
                if (perfil.Nombre == nombre)
                {
                    if (perfil.Contrasena == contrasena)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        
        public string SerializarUsuarios()
        {
            
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true
            };
            string usuarios= JsonSerializer.Serialize<List<PerfilUsuario>>(ListaDeUsuarios,options);
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
            List<PerfilUsuario> listavieja = JsonSerializer.Deserialize<List<PerfilUsuario>>(json, options);
            foreach (PerfilUsuario usuario in listavieja)
            {
                this.ListaDeUsuarios.Add(usuario);
            }
        }

       
    }
}
