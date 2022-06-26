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
            partida.AñadirBarco(inicioDelBarco ,finalDelBarco,1);
            char expected = 'B';
            char[ , ]tableroActualizado = partida.VerTableroPropio(1);
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
            partida.AñadirBarco(inicioDelBarco ,finalDelBarco,1);
            char expected = 'B';
            char[ , ]tableroActualizado = partida.VerTableroPropio(1);
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
            partida.AñadirBarco(inicioDelBarco ,finalDelBarco,1);
            char expected = 'B';
            char[ , ]tableroActualizado = partida.VerTableroPropio(1);
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
            partida.AñadirBarco(inicioDelBarco ,finalDelBarco,1);
            char expected = 'B';
            char[ , ]tableroActualizado = partida.VerTableroPropio(1);
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
            string LugarAAtacar = "A1";
            int[] ataque = TraductorDeCoordenadas.Traducir(LugarAAtacar);
            LogicaDeTablero.Atacar(partida.tableros[1], ataque[0], ataque[1]);
            char expected = 'W';
            Tablero tablero = partida.tableros[1];
            //char[,] charAct = tablero.VerCasilla(1, 7);
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
