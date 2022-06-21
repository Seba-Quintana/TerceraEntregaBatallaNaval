using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Clase AlmacenamientoUsuarioistradora. Se encarga de manejar distintos aspectos del programa,
    /// como los usuarios o el historial.
    /// Sera cambiada en gran parte por los handlers.
    /// </summary>
    public class AlmacenamientoUsuario
    {
        /// <summary>
        /// Almacenamiento de usuarios
        /// </summary>
        private List<PerfilUsuario> listaDeUsuarios = new List<PerfilUsuario>();

        /// <summary>
        /// Getter de listaDeUsuarios
        /// </summary>
        /// <value> Lista de usuarios </value>
        public List<PerfilUsuario> ListaDeUsuarios
        {
            get
            {
                return listaDeUsuarios;
            }
        }
        
        /// <summary>
        /// Parte de singleton. Atributo donde se guarda la instancia del AlmacenamientoUsuario (o null si no fue creada).
        /// </summary>
        static AlmacenamientoUsuario instance;

        /// <summary>
        /// Parte de singleton. Constructor llamado por el metodo Instance de crearse un AlmacenamientoUsuario.
        /// </summary>
        private AlmacenamientoUsuario()
        {
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
        /// <summary>
        /// Crea un nuevo perfil de usuario asignandole un numero de jugador.
        /// Si es el primer usuario creado le asigna el numero 1, de lo contrario le asigna el
        /// numero mas alto de un jugador existente +1,
        /// y luego crea un PerfilUsuario con los datos necesarios para agregarlo a la lista de usuarios.
        /// </summary>
        /// <param name="nombre"> nombre del usuario</param>
        /// <param name="id"> id proporcionada por el bot </param>
        /// <param name="contraseña"> contraseña </param>
        public int Registrar(string nombre, int id, string contraseña)
        {
            int numeroDeJugador = 1;
            if (listaDeUsuarios.Count != 0)
            {
                numeroDeJugador = listaDeUsuarios[listaDeUsuarios.Count - 1].NumeroDeJugador + 1;
            }    
            PerfilUsuario usuario = new PerfilUsuario(nombre, id, contraseña, numeroDeJugador);
            listaDeUsuarios.Add(usuario);
            return numeroDeJugador;
        }
        /// <summary>
        /// Si el numero de usuarios pertenece a un PerfilUsuario existente
        /// en la lista de perfiles de AlmacenamientoUsuario, lo elimina de la misma.
        /// </summary>
        /// <param name="NumeroDeJugador"> numero del jugador a remover</param>
        public void Remover(int NumeroDeJugador)
        {
            if (!listaDeUsuarios.Contains(ObtenerPerfil(NumeroDeJugador)))
            {}
            else
            if(ObtenerPerfil(NumeroDeJugador) != null)
            {
                int i = 0;
                while (i < listaDeUsuarios.Count )
                {
                    if (listaDeUsuarios[i].NumeroDeJugador == NumeroDeJugador)
                    {
                        listaDeUsuarios.Remove(listaDeUsuarios[i]);  
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
            foreach(PerfilUsuario perfil in listaDeUsuarios)
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
                if (!listaDeUsuarios.Contains(ObtenerPerfil(jugador)))
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
                if (!listaDeUsuarios.Contains(ObtenerPerfil(jugador)))
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
        /// Si el numero ingresado es 0 pide mostrar el historial general de todos las partidas jugadas,
        /// si el numero pertenece a un PerfilUsuario en la lista de perfiles de AlmacenamientoUsuario
        /// pide mostrar el HistorialPersonal de este perfil.
        /// </summary>
        /// <param name="numerodejugador"> historial que se quiere ver</param>
        public List<DatosdePartida> ObtenerHistorialPersonal(int numerodejugador)
        {
            try
            {
                if (!listaDeUsuarios.Contains(ObtenerPerfil(numerodejugador)))
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
        /// y le pide a la impresora que la muestre.
        /// </summary>
        public List<PerfilUsuario> ObtenerRanking()
        {
            List<PerfilUsuario> ranking = new List<PerfilUsuario>();
            int i = 0;
            while (i < listaDeUsuarios.Count)
            {
                ranking.Add(listaDeUsuarios[i]);
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
    }
}
