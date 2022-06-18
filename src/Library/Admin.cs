using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Clase administradora. Se encarga de manejar distintos aspectos del programa,
    /// como los usuarios o el historial.
    /// Sera cambiada en gran parte por los handlers.
    /// </summary>
    public class Admin
    {
        /// <summary>
        /// Almacenamiento de usuarios
        /// </summary>
        public List<PerfilUsuario> ListaDeUsuarios = new List<PerfilUsuario>();
        
        /// <summary>
        /// Parte de singleton. Atributo donde se guarda la instancia del admin (o null si no fue creada).
        /// </summary>
        static Admin instance;

        /// <summary>
        /// Parte de singleton. Constructor llamado por el metodo Instance de crearse un admin.
        /// </summary>
        private Admin()
        {
        }

        /// <summary>
        /// Singleton de admin. Si no existe una instancia de admin, crea una. Si ya existe la devuelve
        /// </summary>
        /// <returns> Instancia nueva de admin, o de darse el caso, una previamente creada </returns>
        public static Admin Instance()
        {
            if (instance == null)
            {
                instance = new Admin();
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
            if (ListaDeUsuarios.Count != 0)
            {
                numeroDeJugador = ListaDeUsuarios[ListaDeUsuarios.Count - 1].NumeroDeJugador + 1;
            }    
            PerfilUsuario usuario = new PerfilUsuario(nombre, id, contraseña, numeroDeJugador);
            ListaDeUsuarios.Add(usuario);
            return numeroDeJugador;
        }
        /// <summary>
        /// Si el numero de usuarios pertenece a un PerfilUsuario existente
        /// en la lista de perfiles de admin, lo elimina de la misma.
        /// </summary>
        /// <param name="NumeroDeJugador"> numero del jugador a remover</param>
        public void Remover(int NumeroDeJugador)
        {
            if(ObtenerPerfil(NumeroDeJugador) != null)
            {
                int i = 0;
                while (i <= ListaDeUsuarios.Count - 1)
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
        /// se encuentra en la lista de perfiles de admin, este metodo devuelve su perfil.
        /// </summary>
        /// <param name="usuario"> numero del jugador </param>
        /// <returns> perfil de usuario </returns>
        public PerfilUsuario ObtenerPerfil(int usuario)
        {
            int i = 0;
            if (i != ListaDeUsuarios.Count)
            {
                while (i <= ListaDeUsuarios.Count - 1)
                {
                    if (ListaDeUsuarios[i].NumeroDeJugador == usuario) 
                        return ListaDeUsuarios[i];
                    i++;
                }
            }
            return null;
        }
        
        /// <summary>
        /// Permite visualizar el perfil de un usuario.
        /// </summary>
        /// <param name="usuario"> jugador del cual se quiere ver el perfil </param>
        public void VerPerfil(int usuario)
        {
            Iimpresora imprimir = ImpresoraConsola.Instance();
            imprimir.ImprimirPerfilUsuario(ObtenerPerfil(usuario));
        }

        /// <summary>
        /// Si el numero de jugador ingresado tiene una partida en juego,
        /// pide mostrar el tablero del oponente.
        /// </summary>
        /// <param name="jugador"> jugador en partida </param>
        public void ObtenerTableroOponente(int jugador)
        {
            ImpresoraConsola imprimir = ImpresoraConsola.Instance();
            LogicaDePartida juego = PartidasEnJuego.ObtenerLogicadePartida(jugador);
            if (juego != null)
            {
                imprimir.ImprimirTablero(juego.VistaOponente(jugador), false);
            }
        }

        /// <summary>
        /// Si el numero de jugador ingresado tiene una partida en juego,
        /// pide mostrar su propio tablero.
        /// </summary>
        /// <param name="jugador"> jugador en partida </param>
        public void ObtenerTablero(int jugador)
        {
            ImpresoraConsola imprimir = ImpresoraConsola.Instance();
            LogicaDePartida juego = PartidasEnJuego.ObtenerLogicadePartida(jugador);
            if (juego != null)
            {
                imprimir.ImprimirTablero(juego.VerTableroPropio(jugador), true);
            }
        }

        /// <summary>
        /// Si el numero ingresado es 0 pide mostrar el historial general de todos las partidas jugadas,
        /// si el numero pertenece a un PerfilUsuario en la lista de perfiles de Admin
        /// pide mostrar el HistorialPersonal de este perfil.
        /// </summary>
        /// <param name="numerodejugador"> historial que se quiere ver</param>
        public void ObtenerHistorial(int numerodejugador)
        {
            ImpresoraConsola imprimir = ImpresoraConsola.Instance();
            try
            {
                if (!ListaDeUsuarios.Contains(ObtenerPerfil(numerodejugador)) && (numerodejugador != 0))
                {
                    throw new NullReferenceException("Usuario no encontrado");
                }
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException("Usuario no encontrado", e);
            }
            try
            {
                if (numerodejugador == 0)
                {
                    List<DatosdePartida> historial = Historial.partidas;
                    imprimir.ImprimirHistorial(historial);
                }
                else if (ListaDeUsuarios.Contains(ObtenerPerfil(numerodejugador)))
                {
                    PerfilUsuario perfil = ObtenerPerfil(numerodejugador);
                    imprimir.ImprimirHistorial(perfil.VerHistorialPersonal());
                }
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo ejecutar ObtenerHistorial", e);
            }
        }

        /// <summary>
        /// Realiza una lista de PerfilUsuario ordenados por cantidad de partidas ganadas,
        /// y le pide a la impresora que la muestre.
        /// </summary>
        public void ObtenerRanking()
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
            while ((actual < ListaDeUsuarios.Count))
            {   i=actual;
                j= i+1;
                while ((i < ListaDeUsuarios.Count)&&(j < ListaDeUsuarios.Count))
                {
                    if (ranking[i].Ganadas < ranking[j].Ganadas)
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
            ImpresoraConsola imprimir = ImpresoraConsola.Instance();
            imprimir.ImprimirRanking(ranking);
        }

        /// <summary>
        /// Añade una partida jugada tanto al historial general
        /// como al historial personal de cada jugador.
        /// </summary>
        /// <param name="partida"> partida a añadir </param>
        public void ActualizarHistorial(DatosdePartida partida)
        {
            Historial.AlmacenarPartida(partida);
            foreach (PerfilUsuario usuario in ListaDeUsuarios)
            {
                if (partida.Ganador == usuario.NumeroDeJugador)
                {
                    PerfilUsuario jugador = ObtenerPerfil(partida.Ganador);
                    jugador.AñadiralHistorial(partida);
                }
                else
                {
                    PerfilUsuario jugador = ObtenerPerfil(partida.Perdedor);
                    jugador.AñadiralHistorial(partida);
                }
            }
        }

        /// <summary>
        /// Crea una LogicadePartida, asignandole un tamaño
        /// y los dos numeros de jugador de quienes quieren comenzar una partida.
        /// </summary>
        /// <param name="tamaño"> tamaño del tablero </param>
        /// <param name="modo"> modo de juego a jugar </param>
        /// <param name="jugadores"> jugadores </param>
        public void CrearLogicadePartida(int tamaño, int modo, int[] jugadores)
        {
            if (modo == 0)
            {
                LogicaDePartida partida = new LogicaDePartida(tamaño, jugadores[0], jugadores[1]);
            }
            else
            {
                LogicaDePartidaRapida partida = new LogicaDePartidaRapida(tamaño, jugadores[0], jugadores[1]);
            }
        }

        /// <summary>
        /// Empareja a dos jugadores, siendo uno de ellos el jugador que busca partida,
        /// y el otro un jugador que este esperando por una partida.
        /// </summary>
        /// <param name="modo"> modo elegido </param>
        /// <param name="jugador1"> jugador que busca partida </param>
        /// <param name="tamano"> tamaño del tablero </param>
        public void Emparejar(int modo, int jugador1, int tamano)
        {
            try
            {
                if (!ListaDeUsuarios.Contains(ObtenerPerfil(jugador1)))
                {
                    throw new NullReferenceException("El usuario no existe");
                }
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException("El usuario no existe", e);
            }
            try
            {
                int[] jugadores = EmparejamientoConCola.EmparejarAleatorio(modo, jugador1);
                CrearLogicadePartida(tamano, modo, jugadores);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo ejecutar correctamente el programa", e);
            }            
        }
        /// <summary>
        /// Empareja a dos jugadores por sus numeros de jugador.
        /// </summary>
        /// <param name="modo"> modo de juego elegido </param>
        /// <param name="jugador1"> jugador 1 </param>
        /// <param name="jugador2"> jugador 2 </param>
        /// <param name="tamano"> tamaño del tablero </param>
        public void EmparejarAmigos(int modo, int jugador1, int jugador2, int tamano)
        {
            if (ListaDeUsuarios.Contains(ObtenerPerfil(jugador1)) && ListaDeUsuarios.Contains(ObtenerPerfil(jugador1)))
            {
                int[] jugadores = EmparejamientoConCola.EmparejarAmigos(modo, jugador1, jugador2);
                CrearLogicadePartida(tamano, modo, jugadores);
            }
        }
    }

}
