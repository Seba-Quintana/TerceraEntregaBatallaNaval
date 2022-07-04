using System;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Test para un correcto funcionamiento de la clase Logica <see cref="Partida"/>
    /// </summary>
    [TestFixture]
    public class TestDePartida
    {
        /// <summary>
        /// El tablero que va a ser utilizado para los tests.Es necesario ya que Logica solo
        ///  se ejecuta si esta en conjunto de la clase tablero;
        /// </summary>
        private Partida partida;

        /// <summary>
        /// SetUp Creado con el objetivo de tener un tablero vacio al principio de cada test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.partida = new Partida(9, 1, 2);
        }
        /// <summary>
        /// Test con el objetivo de ver si se añade correctamente los barcos horizontales al ser asignados al tablero
        /// testea la casilla donde se inicia el barco y tambien testea que la casilla anterior este vacia.
        /// (Cuando una casilla esta vacia contiene un valor '\u0000')
        /// </summary>

        [Test]
        public void PrincipioDeBarcoHorizontal()
        {
            string inicioDelBarco = "E4";
            string finalDelBarco = "E6";
            partida.AgregarBarco(inicioDelBarco ,finalDelBarco,1);
            char expected = 'B';
            char[ , ]tableroActualizado = partida.VerTablero(1).VerTablero();
            Assert.AreEqual(expected, tableroActualizado[4,3]);
            Assert.AreEqual('\u0000', tableroActualizado[4,2]);
            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(partida);
        }
        /// <summary>
        /// Test con el objetivo de ver si se añade correctamente los barcos horizontales al ser asignados al tablero
        /// testea la casilla donde finaliza el barco y tambien testea que la casilla siguiente este vacia.
        /// (Cuando una casilla esta vacia contiene un valor '\u0000')
        /// </summary>
        [Test]
        public void FinalDeBarcoHorizontal()
        {
            string inicioDelBarco = "E4";
            string finalDelBarco = "E6";
            partida.AgregarBarco(inicioDelBarco ,finalDelBarco,1);
            char expected = 'B';
            char[ , ]tableroActualizado = partida.VerTablero(1).VerTablero();
            Assert.AreEqual(expected, tableroActualizado[4,5]);
            Assert.AreEqual('\u0000', tableroActualizado[4,6]);
            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(partida);
        }
        /// <summary>
        /// Test con el objetivo de ver si se añade correctamente los barcos verticales al ser asignados al tablero
        /// testea la casilla donde se inicia el barco y tambien testea que la casilla anterior este vacia.
        /// (Cuando una casilla esta vacia contiene un valor '\u0000')
        /// </summary>
        [Test]
        public void PrincipioDeBarcoVertical()
        {
            string inicioDelBarco = "B8";
            string finalDelBarco = "F8";
            partida.AgregarBarco(inicioDelBarco ,finalDelBarco,1);
            char expected = 'B';
            char[ , ]tableroActualizado = partida.VerTablero(1).VerTablero();
            Assert.AreEqual(expected, tableroActualizado[1,7]);
            Assert.AreEqual('\u0000', tableroActualizado[0,7]);
            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(partida);
        }
        /// <summary>
        /// Test con el objetivo de ver si se añade correctamente los barcos verticales al ser asignados al tablero
        /// testea la casilla donde finaliza el barco y tambien testea que la casilla siguiente este vacia.
        /// (Cuando una casilla esta vacia contiene un valor '\u0000')
        /// </summary>
        [Test]
        public void FinalDeBarcoVertical()
        {
            string inicioDelBarco = "B8";
            string finalDelBarco = "F8";
            partida.AgregarBarco(inicioDelBarco ,finalDelBarco,1);
            char expected = 'B';
            char[ , ]tableroActualizado = partida.VerTablero(1).VerTablero();
            Assert.AreEqual(expected, tableroActualizado[5,7]);
            Assert.AreEqual('\u0000', tableroActualizado[6,7]);
            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(partida);
        }
        /// <summary>
        /// Test con el objetivo de ver que al atacar una casilla vacia cambia su contenido a 'W' Lo cual simboliza agua.
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
            
            partida.Atacar("C1",numeroDeJugador1);

            char expected = 'W';
            Tablero tablero = partida.VerTablero(numeroDeJugador2);
            Assert.AreEqual(expected, tablero.VerCasilla(2,0));

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
            partida.AgregarBarco("B1","B7",numeroDeJugador1);
            partida.AgregarBarco("D1","D7",numeroDeJugador1);
            partida.AgregarBarco("D1","D6",numeroDeJugador2);
            partida.AgregarBarco("E1","E7",numeroDeJugador2);
            partida.AgregarBarco("F1","F7",numeroDeJugador2);
            
            partida.Atacar("C1",numeroDeJugador1);
            partida.Atacar("C1",numeroDeJugador2);
            partida.Atacar("C1",numeroDeJugador1);

            char expected = 'W';
            Tablero tablero = partida.VerTablero(numeroDeJugador2);
            Assert.AreEqual(expected, tablero.VerCasilla(2,0));

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
        public void AtaqueBarcoVertical()
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

            partida.Atacar("C1",numeroDeJugador2);

            char expected = 'T';
            Tablero tablero = partida.VerTablero(numeroDeJugador1);
            Assert.AreEqual(expected, tablero.VerCasilla(2,0));

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

            partida.AgregarBarco("A1","A6",numeroDeJugador1);
            partida.AgregarBarco("B1","B7",numeroDeJugador1);
            partida.AgregarBarco("C1","C7",numeroDeJugador1);
            partida.AgregarBarco("F1","F7",numeroDeJugador2);
            partida.AgregarBarco("A2","A7",numeroDeJugador2);
            partida.AgregarBarco("B2","B4",numeroDeJugador2);
            partida.AgregarBarco("A1","D1",numeroDeJugador2);

            partida.Atacar("C1",numeroDeJugador1);
            partida.Atacar("C1",numeroDeJugador2);
            partida.Atacar("C1",numeroDeJugador1);

            char expected = 'T';
            Tablero tablero = partida.VerTablero(numeroDeJugador2);
            Assert.AreEqual(expected, tablero.VerCasilla(2,0));

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
        public void AtaqueBarcoHorizontal()
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
            
            partida.Atacar("A1",numeroDeJugador2);

            char expected = 'T';
            Tablero tablero = partida.VerTablero(numeroDeJugador1);
            Assert.AreEqual(expected, tablero.VerCasilla(0,0));

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
        public void AtaqueBarcoHorizontalEnElMismoLugar()
        {
            int numeroDeJugador1 = Planificador.Registrar("Carlos",67,"player1");
            int numeroDeJugador2 = Planificador.Registrar("Drake",55,"player2");

            Planificador.EmparejarAmigos(0,numeroDeJugador1,numeroDeJugador2,7);
            PartidasEnJuego partidas = PartidasEnJuego.Instance();
            Partida partida = partidas.ObtenerPartida(numeroDeJugador1);

            partida.AgregarBarco("A1","A6",numeroDeJugador1);
            partida.AgregarBarco("B1","B7",numeroDeJugador1);
            partida.AgregarBarco("C1","C7",numeroDeJugador1);
            partida.AgregarBarco("D1","D6",numeroDeJugador2);
            partida.AgregarBarco("E1","E7",numeroDeJugador2);
            partida.AgregarBarco("F1","F7",numeroDeJugador2);
            
            partida.Atacar("E1",numeroDeJugador1);
            partida.Atacar("E1",numeroDeJugador2);
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
