using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Test para un correcto funcionamiento de la clase Logica <see cref="PartidaRapida"/>
    /// </summary>
    [TestFixture]
    public class PartidaRapidaTests
    {
        /// <summary>
        /// La partida que va a ser utilizada para los tests.
        /// </summary>
        private PartidaRapida partida;

        /// <summary>
        /// SetUp Creado con el objetivo de tener un partida al principio de cada test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.partida = new PartidaRapida(9, 1, 2);
        }
        /// <summary>
        /// Test con el objetivo de ver que al atacar una casilla fuera de turno no se realiza el ataque.
        /// </summary>
        [Test]
        public void AtaqueFueraDeTurno()
        {
            string LugarAAtacar = "A1";
            int[] ataque = TraductorDeCoordenadas.Traducir(LugarAAtacar);
            LogicaDeTablero.Atacar(partida.tableros[0], ataque[0], ataque[1]);
            char expected = '\u0000';
            Tablero tablero = partida.tableros[1];
            Assert.AreEqual(expected, tablero.VerCasilla(0,0));
            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(partida);
        }
        /// <summary>
        /// Test con el objetivo de ver que al atacar una casilla fuera de turno no se realiza el ataque.
        /// </summary>
        [Test]
        public void AtaqueFueraDeTurno2()
        {
            string LugarAAtacar = "A1";
            int[] ataque = TraductorDeCoordenadas.Traducir(LugarAAtacar);
            LogicaDeTablero.Atacar(partida.tableros[1], ataque[0], ataque[1]);
            string LugarAAtacar2 = "A2";
            int[] ataque2 = TraductorDeCoordenadas.Traducir(LugarAAtacar);
            LogicaDeTablero.Atacar(partida.tableros[0], ataque2[0], ataque2[1]);
            char expected = '\u0000';
            Tablero tablero = partida.tableros[1];
            Assert.AreEqual(expected, tablero.VerCasilla(0,1));
            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(partida);
        }
        /// <summary>
        /// Test con el objetivo de ver que al atacar una casilla vacia cambia su contenido a 'W' Lo cual simboliza agua.
        /// </summary>
        [Test]
        public void AtaqueAlAgua()
        {
            string LugarAAtacar = "A1";
            int[] ataque = TraductorDeCoordenadas.Traducir(LugarAAtacar);
            LogicaDeTablero.Atacar(partida.tableros[1], ataque[0], ataque[1]);
            char expected = 'W';
            Tablero tablero = partida.tableros[1];
            Assert.AreEqual(expected, tablero.VerCasilla(0,0));
            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(partida);
        }
        /// <summary>
        /// Se ataca un punto del barco para ver que este cambie por 'T'.
        /// </summary>
        [Test]
        public void AtaqueBarcoVertical()
        {
            string inicioDelBarco = "B8";
            string finalDelBarco = "F8";
            partida.AñadirBarco(inicioDelBarco ,finalDelBarco,2);
            string LugarAAtacar = "F8";
            int[] ataque = TraductorDeCoordenadas.Traducir(LugarAAtacar);
            LogicaDeTablero.Atacar(partida.tableros[1], ataque[0], ataque[1]);
            char expected = 'T';
            Tablero tablero = partida.tableros[1];
            Assert.AreEqual(expected, tablero.VerCasilla(5,7));
            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(partida);
        }
        /// <summary>
        /// Se ataca 2 veces el mismo punto del barco para ver que este se mantega siendo 'T'.
        /// </summary>
        [Test]
        public void AtaqueBarcoVerticalEnElMismoLugar()
        {
            string inicioDelBarco = "B8";
            string finalDelBarco = "F8";
            partida.AñadirBarco(inicioDelBarco ,finalDelBarco,2);
            string LugarAAtacar = "F8";
            int[] ataque = TraductorDeCoordenadas.Traducir(LugarAAtacar);
            LogicaDeTablero.Atacar(partida.tableros[1], ataque[0], ataque[1]);
            LogicaDeTablero.Atacar(partida.tableros[1], ataque[0], ataque[1]);
            char expected = 'T';
            Tablero tablero = partida.tableros[1];
            Assert.AreEqual(expected, tablero.VerCasilla(5,7));
            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(partida);
        }
        /// <summary>
        /// Se ataca un punto del barco para ver que este cambie por 'T'.
        /// </summary>
        [Test]
        public void AtaqueBarcoHorizontal()
        {
            string inicioDelBarco = "H4";
            string finalDelBarco = "H8";
            partida.AñadirBarco(inicioDelBarco ,finalDelBarco,2);
            string LugarAAtacar = "H5";
            int[] ataque = TraductorDeCoordenadas.Traducir(LugarAAtacar);
            LogicaDeTablero.Atacar(partida.tableros[1], ataque[0], ataque[1]);
            char expected = 'T';
            Tablero tablero = partida.tableros[1];
            Assert.AreEqual(expected, tablero.VerCasilla(7,4));
            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(partida);
        }
         /// <summary>
        /// Se ataca 2 veces el mismo punto del barco para ver que este se mantega siendo 'T'.
        /// </summary>
        [Test]
        public void AtaqueBarcoHorizontalEnElMismoLugar()
        {
            string inicioDelBarco = "H4";
            string finalDelBarco = "H8";
            partida.AñadirBarco(inicioDelBarco ,finalDelBarco,2);
            string LugarAAtacar = "H6";
            partida.Atacar(LugarAAtacar, 2);
            partida.Atacar(LugarAAtacar, 2);
            int[] ataque = TraductorDeCoordenadas.Traducir(LugarAAtacar);
            LogicaDeTablero.Atacar(partida.tableros[1], ataque[0], ataque[1]);
            LogicaDeTablero.Atacar(partida.tableros[1], ataque[0], ataque[1]);
            char expected = 'T';
            Tablero tablero = partida.tableros[1];
            Assert.AreEqual(expected, tablero.VerCasilla(7,5));
            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(partida);
        }
    }
}