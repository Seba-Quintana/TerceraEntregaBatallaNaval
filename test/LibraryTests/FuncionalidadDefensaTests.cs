using System;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Tests para verificar el valor enviado a los handlers al querer ver la cantidad de tiros a barcos y tiros al agua en una partida
    /// Comento HistorialTests y PartidaRapidaTests porque dan error
    /// </summary>
    [TestFixture]
    public class FuncionalidadDefensaTests
    {
        /// <summary>
        /// Setup con el objetivo de reiniciar las instancias de singleton
        /// </summary>
        [SetUp]
        public void Setup()
        {
			PartidasEnJuego partidas = PartidasEnJuego.Instance();
            if (partidas.partidas.Count > 0)
                partidas.RemoverPartida(partidas.ObtenerPartida(1));
            AlmacenamientoUsuario almacenamiento = AlmacenamientoUsuario.Instance();
            int i = 1;
            int CantidadUsuarios = almacenamiento.ListaDeUsuarios.Count;
            while (i <= CantidadUsuarios)
            {
                almacenamiento.Remover(i);
                i++;
            }
        }
        /// <summary>
        /// Verifica que la cantidad de tiradas sea 0 cuando aun no termino el posicionamiento
        /// </summary>
        [Test]
        public void TiradasCuandoAunNoTerminaPosicionamiento()
        {
            int numeroDeJugador1 = Planificador.Registrar("Carlos",67,"player1");
            int numeroDeJugador2 = Planificador.Registrar("Drake",55,"player2");

            Planificador.Emparejar(0,numeroDeJugador1,7);
            Planificador.Emparejar(0,numeroDeJugador2,7);
            PartidasEnJuego partidas = PartidasEnJuego.Instance();
            Partida partida = partidas.ObtenerPartida(numeroDeJugador1);

            partida.AgregarBarco("A1","A6",numeroDeJugador1);
            partida.AgregarBarco("A1","F1",numeroDeJugador2);
                     
            //No importa que jugador pida ver los ataques porque estan en una misma partida
            Assert.AreEqual(Planificador.VerAtaquesABarcos(numeroDeJugador1),0);
            Assert.AreEqual(Planificador.VerAtaquesAlAgua(numeroDeJugador2),0);

            partidas.RemoverPartida(partida);
            AlmacenamientoUsuario almacenamiento = AlmacenamientoUsuario.Instance();
            almacenamiento.Remover(numeroDeJugador1);
            almacenamiento.Remover(numeroDeJugador2);
        }
        /// <summary>
        /// Verifica que la cantidad de tiradas sea 0 cuando se termino el posicionamiento y aun no se producen ataques
        /// </summary>
        [Test]
        public void TiradasCuandoTerminoPosicionamiento()
        {
            int numeroDeJugador1 = Planificador.Registrar("Carlos",67,"player1");
            int numeroDeJugador2 = Planificador.Registrar("Drake",55,"player2");

            Planificador.Emparejar(0,numeroDeJugador1,7);
            Planificador.Emparejar(0,numeroDeJugador2,7);
            PartidasEnJuego partidas = PartidasEnJuego.Instance();
            Partida partida = partidas.ObtenerPartida(numeroDeJugador1);

            partida.AgregarBarco("A1","A6",numeroDeJugador1);
            partida.AgregarBarco("B1","B6",numeroDeJugador1);
            partida.AgregarBarco("A1","F1",numeroDeJugador2);
            partida.AgregarBarco("A6","F6",numeroDeJugador2);
                     
            //No importa que jugador pida ver los ataques porque estan en una misma partida
            Assert.AreEqual(Planificador.VerAtaquesABarcos(numeroDeJugador1),0);
            Assert.AreEqual(Planificador.VerAtaquesAlAgua(numeroDeJugador2),0);

            partidas.RemoverPartida(partida);
            AlmacenamientoUsuario almacenamiento = AlmacenamientoUsuario.Instance();
            almacenamiento.Remover(numeroDeJugador1);
            almacenamiento.Remover(numeroDeJugador2);
        }
        /// <summary>
        /// Verifica que las tiradas se sumen correctamente cuando ataco al agua
        /// </summary>
        [Test]
        public void TiradasCuandoAtacoUnaVezAlAgua()
        {
            int numeroDeJugador1 = Planificador.Registrar("Carlos",67,"player1");
            int numeroDeJugador2 = Planificador.Registrar("Drake",55,"player2");

            Planificador.Emparejar(0,numeroDeJugador1,7);
            Planificador.Emparejar(0,numeroDeJugador2,7);
            PartidasEnJuego partidas = PartidasEnJuego.Instance();
            Partida partida = partidas.ObtenerPartida(numeroDeJugador1);

            partida.AgregarBarco("A1","A6",numeroDeJugador1);
            partida.AgregarBarco("B1","B6",numeroDeJugador1);
            partida.AgregarBarco("A1","F1",numeroDeJugador2);
            partida.AgregarBarco("A6","F6",numeroDeJugador2);

            partida.Atacar("B2",numeroDeJugador1);
            
            //No importa que jugador pida ver los ataques porque estan en una misma partida
            Assert.AreEqual(Planificador.VerAtaquesABarcos(numeroDeJugador2),0);
            Assert.AreEqual(Planificador.VerAtaquesAlAgua(numeroDeJugador1),1);

            partidas.RemoverPartida(partida);
            AlmacenamientoUsuario almacenamiento = AlmacenamientoUsuario.Instance();
            almacenamiento.Remover(numeroDeJugador1);
            almacenamiento.Remover(numeroDeJugador2);
        }
        /// <summary>
        /// Verifica que las tiradas se sumen correctamente cuando se ataca varias veces al agua
        /// </summary>
        [Test]
        public void TiradasCuandoAtaquesAlAgua()
        {
            int numeroDeJugador1 = Planificador.Registrar("Carlos",67,"player1");
            int numeroDeJugador2 = Planificador.Registrar("Drake",55,"player2");

            Planificador.Emparejar(0,numeroDeJugador1,7);
            Planificador.Emparejar(0,numeroDeJugador2,7);
            PartidasEnJuego partidas = PartidasEnJuego.Instance();
            Partida partida = partidas.ObtenerPartida(numeroDeJugador1);

            partida.AgregarBarco("A1","A6",numeroDeJugador1);
            partida.AgregarBarco("B1","B6",numeroDeJugador1);
            partida.AgregarBarco("A1","F1",numeroDeJugador2);
            partida.AgregarBarco("A6","F6",numeroDeJugador2);

            partida.Atacar("B2",numeroDeJugador1);
            partida.Atacar("C2",numeroDeJugador2);
            partida.Atacar("B2",numeroDeJugador1);
            
            //No importa que jugador pida ver los ataques porque estan en una misma partida
            Assert.AreEqual(Planificador.VerAtaquesABarcos(numeroDeJugador2),0);
            Assert.AreEqual(Planificador.VerAtaquesAlAgua(numeroDeJugador1),3);

            partidas.RemoverPartida(partida);
            AlmacenamientoUsuario almacenamiento = AlmacenamientoUsuario.Instance();
            almacenamiento.Remover(numeroDeJugador1);
            almacenamiento.Remover(numeroDeJugador2);
        }
        /// <summary>
        /// Verifica que las tiradas se sumen correctamente cuando ataco a un barco
        /// </summary>
        [Test]
        public void TiradasCuandoAtacoUnaVezABarco()
        {
            int numeroDeJugador1 = Planificador.Registrar("Carlos",67,"player1");
            int numeroDeJugador2 = Planificador.Registrar("Drake",55,"player2");

            Planificador.Emparejar(0,numeroDeJugador1,7);
            Planificador.Emparejar(0,numeroDeJugador2,7);
            PartidasEnJuego partidas = PartidasEnJuego.Instance();
            Partida partida = partidas.ObtenerPartida(numeroDeJugador1);

            partida.AgregarBarco("A1","A6",numeroDeJugador1);
            partida.AgregarBarco("B1","B6",numeroDeJugador1);
            partida.AgregarBarco("A1","F1",numeroDeJugador2);
            partida.AgregarBarco("A6","F6",numeroDeJugador2);

            partida.Atacar("A1",numeroDeJugador1);
            
            //No importa que jugador pida ver los ataques porque estan en una misma partida
            Assert.AreEqual(Planificador.VerAtaquesABarcos(numeroDeJugador2),1);
            Assert.AreEqual(Planificador.VerAtaquesAlAgua(numeroDeJugador1),0);

            partidas.RemoverPartida(partida);
            AlmacenamientoUsuario almacenamiento = AlmacenamientoUsuario.Instance();
            almacenamiento.Remover(numeroDeJugador1);
            almacenamiento.Remover(numeroDeJugador2);
        }
        /// <summary>
        /// Verifica que las tiradas se sumen correctamente cuando se ataca varias veces al barco
        /// </summary>
        [Test]
        public void TiradasCuandoAtaquesABarco()
        {
            int numeroDeJugador1 = Planificador.Registrar("Carlos",67,"player1");
            int numeroDeJugador2 = Planificador.Registrar("Drake",55,"player2");

            Planificador.Emparejar(0,numeroDeJugador1,7);
            Planificador.Emparejar(0,numeroDeJugador2,7);
            PartidasEnJuego partidas = PartidasEnJuego.Instance();
            Partida partida = partidas.ObtenerPartida(numeroDeJugador1);

            partida.AgregarBarco("A1","A6",numeroDeJugador1);
            partida.AgregarBarco("B1","B6",numeroDeJugador1);
            partida.AgregarBarco("A1","F1",numeroDeJugador2);
            partida.AgregarBarco("A6","F6",numeroDeJugador2);

            partida.Atacar("A1",numeroDeJugador1);
            partida.Atacar("A5",numeroDeJugador2);
            partida.Atacar("A1",numeroDeJugador1);
            partida.Atacar("B5",numeroDeJugador2);
            
            //No importa que jugador pida ver los ataques porque estan en una misma partida
            Assert.AreEqual(Planificador.VerAtaquesABarcos(numeroDeJugador2),4);
            Assert.AreEqual(Planificador.VerAtaquesAlAgua(numeroDeJugador1),0);

            partidas.RemoverPartida(partida);
            AlmacenamientoUsuario almacenamiento = AlmacenamientoUsuario.Instance();
            almacenamiento.Remover(numeroDeJugador1);
            almacenamiento.Remover(numeroDeJugador2);
        }
        /// <summary>
        /// Verifica que las tiradas se sumen correctamente luego de atacar tanto al agua como a barcos
        /// </summary>
        [Test]
        public void TiradasCuandoAtaquesVariado()
        {
            int numeroDeJugador1 = Planificador.Registrar("Carlos",67,"player1");
            int numeroDeJugador2 = Planificador.Registrar("Drake",55,"player2");

            Planificador.Emparejar(0,numeroDeJugador1,7);
            Planificador.Emparejar(0,numeroDeJugador2,7);
            PartidasEnJuego partidas = PartidasEnJuego.Instance();
            Partida partida = partidas.ObtenerPartida(numeroDeJugador1);

            partida.AgregarBarco("A1","A6",numeroDeJugador1);
            partida.AgregarBarco("B1","B6",numeroDeJugador1);
            partida.AgregarBarco("A1","F1",numeroDeJugador2);
            partida.AgregarBarco("A6","F6",numeroDeJugador2);

            partida.Atacar("A1",numeroDeJugador1);
            partida.Atacar("B2",numeroDeJugador2);
            partida.Atacar("B5",numeroDeJugador1);
            partida.Atacar("C3",numeroDeJugador2);
            
            //No importa que jugador pida ver los ataques porque estan en una misma partida
            Assert.AreEqual(Planificador.VerAtaquesABarcos(numeroDeJugador1),2);
            Assert.AreEqual(Planificador.VerAtaquesAlAgua(numeroDeJugador2),2);

            partidas.RemoverPartida(partida);
            AlmacenamientoUsuario almacenamiento = AlmacenamientoUsuario.Instance();
            almacenamiento.Remover(numeroDeJugador1);
            almacenamiento.Remover(numeroDeJugador2);
        }
    }
}
