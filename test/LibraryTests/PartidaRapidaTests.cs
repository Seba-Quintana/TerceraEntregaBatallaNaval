using ClassLibrary;
using NUnit.Framework;
using System;

namespace Tests
{
    /// <summary>
    /// Test para un correcto funcionamiento de la clase Logica <see cref="PartidaRapida"/>
    /// </summary>
    [TestFixture]
    public class PartidaRapidaTests
    {
        /// <summary>
        /// Test con el objetivo de ver que al atacar una casilla fuera de turno no se realiza el ataque.
        /// </summary>
        [Test]
        public void AtaqueFueraDeTurno()
        {
            int numeroDeJugador1 = Planificador.Registrar("Carlos",67,"player1");
            int numeroDeJugador2 = Planificador.Registrar("Drake",55,"player2");

            Planificador.Emparejar(1,numeroDeJugador1,7);
            Planificador.Emparejar(1,numeroDeJugador2,7);
            PartidasEnJuego partidas = PartidasEnJuego.Instance();
            Partida partida = partidas.ObtenerPartida(numeroDeJugador1);

            partida.AgregarBarco("A1","A6",numeroDeJugador1);
            partida.AgregarBarco("B1","B6",numeroDeJugador1);
            partida.AgregarBarco("E1","E6",numeroDeJugador2);
            partida.AgregarBarco("F1","F6",numeroDeJugador2);
            
            partida.Atacar("B1",numeroDeJugador2); //Primer tiro autorizado
            partida.Atacar("B1",numeroDeJugador2); //Segundo tiro autorizado
            partida.Atacar("E1",numeroDeJugador2); //Tercer tiro fuera de turno

            char expected = '\u0000';
            Tablero tablero = partida.VerTablero(numeroDeJugador1);
            Assert.AreEqual(expected, tablero.VerCasilla(4,0));

            partidas.RemoverPartida(partida);
            AlmacenamientoUsuario almacenamiento = AlmacenamientoUsuario.Instance();
            almacenamiento.Remover(numeroDeJugador1);
            almacenamiento.Remover(numeroDeJugador2);
        }
        /// <summary>
        /// Test con el objetivo de ver que al atacar una casilla vacia cambia su contenido a 'W' Lo cual simboliza agua.
        /// </summary>
        [Test]
        public void AtaqueAlAgua()
        {
            int numeroDeJugador1 = Planificador.Registrar("Carlos",77,"player1");
            int numeroDeJugador2 = Planificador.Registrar("Drake",56,"player2");

            Planificador.Emparejar(1,numeroDeJugador1,7);
            Planificador.Emparejar(1,numeroDeJugador2,7);
            PartidasEnJuego partidas = PartidasEnJuego.Instance();
            Partida partida = partidas.ObtenerPartida(numeroDeJugador1);

            partida.AgregarBarco("A1","A6",numeroDeJugador1);
            partida.AgregarBarco("B1","B6",numeroDeJugador1);
            partida.AgregarBarco("E1","E6",numeroDeJugador2);
            partida.AgregarBarco("F1","F6",numeroDeJugador2);
            
            partida.Atacar("C1",numeroDeJugador1);

            char expected = 'W';
            Tablero tablero = partida.VerTablero(numeroDeJugador2);
            Assert.AreEqual(expected, tablero.VerCasilla(2,0));

            partidas.RemoverPartida(partida);
            AlmacenamientoUsuario almacenamiento = AlmacenamientoUsuario.Instance();
            almacenamiento.Remover(numeroDeJugador1);
            almacenamiento.Remover(numeroDeJugador2);
        }
        /// <summary>
        /// Se ataca un punto del barco para ver que este cambie por 'T'.
        /// </summary>
        [Test]
        public void AtaqueBarcoVertical()
        {
            int numeroDeJugador1 = Planificador.Registrar("Carlos",67,"player1");
            int numeroDeJugador2 = Planificador.Registrar("Drake",55,"player2");

            Planificador.Emparejar(1,numeroDeJugador1,7);
            Planificador.Emparejar(1,numeroDeJugador2,7);
            PartidasEnJuego partidas = PartidasEnJuego.Instance();
            Partida partida = partidas.ObtenerPartida(numeroDeJugador1);

            partida.AgregarBarco("A1","A6",numeroDeJugador1);
            partida.AgregarBarco("B1","B6",numeroDeJugador1);
            partida.AgregarBarco("E1","E6",numeroDeJugador2);
            partida.AgregarBarco("F1","F6",numeroDeJugador2);
            
            partida.Atacar("E1",numeroDeJugador1);

            char expected = 'T';
            Tablero tablero = partida.VerTablero(numeroDeJugador2);
            Assert.AreEqual(expected, tablero.VerCasilla(4,0));

            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(partida);
            AlmacenamientoUsuario almacenamiento = AlmacenamientoUsuario.Instance();
            almacenamiento.Remover(numeroDeJugador1);
            almacenamiento.Remover(numeroDeJugador2);
        }
        /// <summary>
        /// Se ataca 2 veces el mismo punto del barco para ver que este se mantega siendo 'T'.
        /// </summary>
        [Test]
        public void AtaqueBarcoVerticalEnElMismoLugar()
        {
            int numeroDeJugador1 = Planificador.Registrar("Carlos",67,"player1");
            int numeroDeJugador2 = Planificador.Registrar("Drake",55,"player2");

            Planificador.EmparejarAmigos(0,numeroDeJugador2,numeroDeJugador1,7);
            PartidasEnJuego partidas = PartidasEnJuego.Instance();
            Partida partida = partidas.ObtenerPartida(numeroDeJugador1);

            partida.AgregarBarco("A1","A6",numeroDeJugador1);
            partida.AgregarBarco("B1","B6",numeroDeJugador1);
            partida.AgregarBarco("E1","E6",numeroDeJugador2);
            partida.AgregarBarco("F1","F6",numeroDeJugador2);
            
            partida.Atacar("E1",numeroDeJugador1);
            partida.Atacar("E1",numeroDeJugador1);

            char expected = 'T';
            Tablero tablero = partida.VerTablero(numeroDeJugador2);
            Assert.AreEqual(expected, tablero.VerCasilla(4,0));

            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(partida);
            AlmacenamientoUsuario almacenamiento = AlmacenamientoUsuario.Instance();
            almacenamiento.Remover(numeroDeJugador1);
            almacenamiento.Remover(numeroDeJugador2);
        }
    }
}

