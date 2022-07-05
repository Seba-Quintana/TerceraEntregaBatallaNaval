using System;
using ClassLibrary;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    /// <summary>
    /// Tests de traductor <see cref="Partida"/>
    /// </summary>
    [TestFixture]
    public class MensajesdePartidaTests
    {
        /// <summary>
        /// SetUp Creado con el objetivo de tener los elementos necesatios 
        /// para probar Partida de diferentes maneras
        /// </summary>
        [SetUp]
        public void Setup()
        {
			PartidasEnJuego partidas = PartidasEnJuego.Instance();
            if (partidas.partidas.Count > 0)
                partidas.RemoverPartida(partidas.ObtenerPartida(1));
        }
        /// <summary>
        /// Test con el objetivo de ver que al atacar una casilla que contiene agua se envien los mensajes correctos
        /// </summary>
        [Test]
        public void AtaqueAlAgua()
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
            
            string respuesta = partida.Atacar("C1",numeroDeJugador2);

            string expected = "Que lastima! has desperdiciado una bala en el agua";
            Assert.AreEqual(expected, respuesta);

            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(partida);
            AlmacenamientoUsuario almacenamiento = AlmacenamientoUsuario.Instance();
            almacenamiento.Remover(numeroDeJugador1);
            almacenamiento.Remover(numeroDeJugador2);
        }
        /// <summary>
        /// Test con el objetivo de ver que al atacar una casilla vacia cambia su contenido a 'W' Lo cual simboliza agua.
        /// </summary>
        [Test]
        public void AtaqueAlAguaEnElMismoLugar()
        {
            int numeroDeJugador1 = Planificador.Registrar("Carlos",67,"player1");
            int numeroDeJugador2 = Planificador.Registrar("Drake",55,"player2");

            Planificador.EmparejarAmigos(0,numeroDeJugador2,numeroDeJugador1,7);
            PartidasEnJuego partidas = PartidasEnJuego.Instance();
            Partida partida = partidas.ObtenerPartida(numeroDeJugador1);

            partida.AgregarBarco("A1","A6",numeroDeJugador1);
            partida.AgregarBarco("B1","B6",numeroDeJugador1);
            partida.AgregarBarco("D1","D6",numeroDeJugador2);
            partida.AgregarBarco("E1","E6",numeroDeJugador2);
            
            partida.Atacar("C1",numeroDeJugador1);
            partida.Atacar("C1",numeroDeJugador2);
            string respuesta = partida.Atacar("C1",numeroDeJugador1);

            string expected = "Que lastima! has desperdiciado una bala en el agua";
            Assert.AreEqual(expected, respuesta);

            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(partida);
            AlmacenamientoUsuario almacenamiento = AlmacenamientoUsuario.Instance();
            almacenamiento.Remover(numeroDeJugador1);
            almacenamiento.Remover(numeroDeJugador2);
        }
        /// <summary>
        /// Se ataca un punto del barco para ver que este cambie por 'T'.
        /// </summary>
        [Test]
        public void AtaqueBarco()
        {
            int numeroDeJugador1 = Planificador.Registrar("Carlos",67,"player1");
            int numeroDeJugador2 = Planificador.Registrar("Drake",55,"player2");

            Planificador.EmparejarAmigos(0,numeroDeJugador1,numeroDeJugador2,7);
            PartidasEnJuego partidas = PartidasEnJuego.Instance();
            Partida partida = partidas.ObtenerPartida(numeroDeJugador1);

            partida.AgregarBarco("A1","A7",numeroDeJugador1);
            partida.AgregarBarco("B1","F1",numeroDeJugador1);
            partida.AgregarBarco("B1","B6",numeroDeJugador2);
            partida.AgregarBarco("F1","F6",numeroDeJugador2);

            partida.Atacar("B1",numeroDeJugador1);

            char expected = 'T';
            Tablero tablero = partida.VerTablero(numeroDeJugador2);
            Assert.AreEqual(expected, tablero.VerCasilla(1,0));

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

            Planificador.EmparejarAmigos(0,numeroDeJugador1,numeroDeJugador2,7);
            PartidasEnJuego partidas = PartidasEnJuego.Instance();
            Partida partida = partidas.ObtenerPartida(numeroDeJugador1);

            partida.AgregarBarco("A1","A7",numeroDeJugador1);
            partida.AgregarBarco("B1","F1",numeroDeJugador1);
            partida.AgregarBarco("B1","B6",numeroDeJugador2);
            partida.AgregarBarco("F1","F6",numeroDeJugador2);

            partida.Atacar("B1",numeroDeJugador1);
            partida.Atacar("B1",numeroDeJugador2);
            partida.Atacar("B1",numeroDeJugador1);

            char expected = 'T';
            Tablero tablero = partida.VerTablero(numeroDeJugador2);
            Assert.AreEqual(expected, tablero.VerCasilla(1,0));

            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(partida);
            AlmacenamientoUsuario almacenamiento = AlmacenamientoUsuario.Instance();
            almacenamiento.Remover(numeroDeJugador1);
            almacenamiento.Remover(numeroDeJugador2);
        }
    }
}

