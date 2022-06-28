/*using System;
using System.Collections.Generic;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Se crea una clase para poder realizar los test que sean posibles de la clase Jugador
    /// /// </summary>
    public class JugadorTests
    {
        private Jugador jugador;

        /// <summary>
        /// remueve los jugadores sobrantes al final para que no sean considerados en otros tests
        /// </summary>
        private AlmacenamientoUsuario removedor;

        /// <summary>
        /// SetUp Creado con el objetivo de tener los elementos necesarios para realizar ls test
        /// </summary>
        [SetUp]
        public void Setup()
        {
            removedor = AlmacenamientoUsuario.Instance();
            int i = 1;
            int CantidadUsuarios = removedor.ListaDeUsuarios.Count;
            while (i <= CantidadUsuarios)
            {
                removedor.Remover(i);
                i++;
            }
        }

        /// <summary>
        /// Comparo si el número de jugador antes del registro y el número de jugador después del registro son iguales.
        /// </summary>
        
        [Test]
        public void Registrar()
        {
            AlmacenamientoUsuario perfil = AlmacenamientoUsuario.Instance();
            Jugador jugador1 = new Jugador("Samuel",12,"milanesa");
            int expected = jugador1.NumeroDeJugador;
            int actual = perfil.ObtenerPerfil(jugador1.NumeroDeJugador).NumeroDeJugador; 
            Assert.AreEqual(expected,actual);
            jugador1.Remover();
        }
        /// <summary>
        /// Se realiza test para comprobar si un jugador se remueve.
        /// </summary>
        [Test]
        public void Remover()
        {
            AlmacenamientoUsuario perfil = AlmacenamientoUsuario.Instance();
            Jugador jugador3 = new Jugador("Martin",56,"pildora");
            jugador3.Remover();
            PerfilUsuario expected = null;
            PerfilUsuario actual = perfil.ObtenerPerfil(jugador3.NumeroDeJugador);
            Assert.AreEqual(expected,actual);
        }
        /// <summary>
        /// Se realiza test para comprobar si un jugador mantiene su número de Jugador removiendo a otro Jugador.
        /// </summary>
        [Test]
        public void RemoverConNum()
        {
            Jugador jugador3 = new Jugador("Martin",56,"pildora");
            Jugador jugador4 = new Jugador("Valentino",46,"yamaha");
            int expected = jugador4.NumeroDeJugador;
            jugador3.Remover();
            int actual = jugador4.NumeroDeJugador;
            Assert.AreEqual(expected,actual);
            jugador4.Remover();

        }
        /// <summary>
        /// Con este test podremos ver el Perfil de un jugador utilizando a su Número de Jugador el cual lo tiene definido.
        /// </summary>
        [Test]
        public void VerAlPerfil()
        {
            Jugador jugador1 = new Jugador("Samuel",12,"milanesa");
            int actual = jugador1.NumeroDeJugador;
            jugador1.VerPerfil(jugador1.NumeroDeJugador);
            int expected = 1;
            Assert.AreEqual(expected,actual);
            jugador1.Remover();
        }
        /// <summary>
        /// Con este test se verifica de que el método Rendirse de la clase Jugador funcione, primero de todo se simula una parte de la partida, 
        /// llamando al método con uno de los jugadores que están en la partida.  
        /// </summary>
        [Test]
        public void Rendir()
        {
            AlmacenamientoUsuario perfil = AlmacenamientoUsuario.Instance();
            PartidasEnJuego partidas = PartidasEnJuego.Instance();
            Jugador jugador1 = new Jugador("Samuel",12,"milanesa");
            Jugador jugador2 = new Jugador("Calamardo",25,"pez");

            jugador1.PartidaAmistosa(0, jugador2.NumeroDeJugador, 7);
            jugador1.BuscarPartida(0,7);
            jugador2.BuscarPartida(0,7);

            jugador1.PosicionarBarcos("A1","A6");
            jugador1.PosicionarBarcos("B1","B6");
            jugador2.PosicionarBarcos("E1","E6");
            jugador2.PosicionarBarcos("F1","F6");
            
            int i = 1;
            while(i <= 6)
            {
                jugador1.Atacar($"G{i}");
                jugador2.Atacar($"A{i}");
                i+=1;
            }
            i = 1;

            string actual = jugador1.Rendirse();
            string expected = "se ha efectuado la rendicion";
            Assert.AreEqual(expected,actual);
            jugador1.Remover();
            jugador2.Remover();

        }
        /// <summary>
        /// Este test es similar al anterior, hace lo mismo a diferencia de que se comprueba de que el Jugador que se haya rendido no tenga la partida ganada,
        /// en cambio de comprobar que al otro Jugador se le añada la partida ganada. 
        /// </summary>
        [Test]
        public void RendirseConGanada()
        {
            AlmacenamientoUsuario perfil = AlmacenamientoUsuario.Instance();
            List<DatosdePartida> HistorialPersonal = new List<DatosdePartida>();
            PartidasEnJuego partidas = PartidasEnJuego.Instance();
            Jugador jugador1 = new Jugador("Samuel",12,"milanesa");
            Jugador jugador2 = new Jugador("Calamardo",25,"pez");

            jugador1.PartidaAmistosa(0, jugador2.NumeroDeJugador, 7);
            jugador1.BuscarPartida(0,7);
            jugador2.BuscarPartida(0,7);

            jugador1.PosicionarBarcos("A1","A6");
            jugador1.PosicionarBarcos("B1","B6");
            jugador2.PosicionarBarcos("E1","E6");
            jugador2.PosicionarBarcos("F1","F6");
            
            int i = 1;
            while(i <= 6)
            {
                jugador1.Atacar($"G{i}");
                jugador2.Atacar($"A{i}");
                i+=1;
            }
            i = 1;

            jugador1.Rendirse();
            PerfilUsuario perfil1 = perfil.ObtenerPerfil(jugador1.NumeroDeJugador);
            PerfilUsuario perfil2 = perfil.ObtenerPerfil(jugador2.NumeroDeJugador);
            int ganadasj1= perfil1.Ganadas;
            int ganadasj2 = perfil2.Ganadas;

            Assert.AreEqual(0,ganadasj1);
            Assert.AreEqual(1,ganadasj2);
            jugador1.Remover();
            jugador2.Remover();

        }
    
    }
}
*/