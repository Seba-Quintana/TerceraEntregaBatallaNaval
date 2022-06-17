using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class Admin
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="PerfilUsuario"></typeparam>
        /// <returns></returns>
        public List<PerfilUsuario> ListaDeUsuarios = new List<PerfilUsuario>();
        static Admin instance;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Admin()
        {
        }
        public static Admin Instance()
        {
            if (instance == null)
            {
                instance = new Admin();
            }
            return instance;
        }
        /// <summary>
        /// Crea un nuevo perfil de usuario asignandole un numero de jugador, si es el primer usuario creado le asigna el numero 1 y de lo contrario le asigna el numero mas alto de un jugador existente +1, luego crea un PerfilUsuario con estos datos y lo agrega a la lista de perfiles que contiene admin.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="id"></param>
        /// <param name="contraseña"></param>
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
        /// Si el numero de usuarios pertenece a un PerfilUsuario en la lista de perfiles de admin, lo elimina de la lista.
        /// </summary>
        /// <param name="NumeroDeJugador"></param>
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
        /// Si el PerfilUsuario que contiene el int ingresado se encuentra en la lista de perfiles de admin, este metodo lo devuelve.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
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
        
        public void VerPerfil(int usuario)
        {
            Iimpresora imprimir = ImpresoraConsola.Instance();
            imprimir.ImprimirPerfilUsuario(ObtenerPerfil(usuario));
        }
        /// <summary>
        /// Si el numero de jugador ingresado tiene una partida en juego pide mostrar el tablero del oponente.
        /// </summary>
        /// <param name="jugador"></param>
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
        /// Si el numero de jugador ingresado tiene una partida en juego pide mostrar el tablero propio.
        /// </summary>
        /// <param name="jugador"></param>
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
        /// Si el int ingresado es 0 pide mostrar el historial general de todos las partidas jugadas, si el int pertenece a un PerfilUsuario en la lista de perfiles de Admin pide mostrar el HistorialPersonal de este perfil.
        /// </summary>
        /// <param name="numerodejugador"></param>
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
        /// Realiza una lista de PerfilUsuario ordenados por cantidad de partidas ganadas y le pide a la impresora que la muestre.
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
        /// Pide guardar el historial de una DatosdePartida jugada, tanto al historial general como al historial personal de cada jugador.
        /// </summary>
        /// <param name="partida"></param>
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
        /// Crea una LogicadePartida, asignandole un tamaño y dos numeros de jugador.
        /// </summary>
        /// <param name="tamaño"></param>
        /// <param name="jugador1"></param>
        /// <param name="jugador2"></param>
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
        ///
        /// </summary>
        /// <param name="modo"></param>
        /// <param name="jugador1"></param>
        public void Emparejar(int modo, int jugador1)
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
                EmparejamientoConCola.EmparejarAleatorio(modo, jugador1);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo ejecutar correctamente el programa", e);
            }            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modo"></param>
        /// <param name="jugador1"></param>
        /// <param name="jugador2"></param>
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
