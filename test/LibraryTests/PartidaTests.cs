//--------------------------------------------------------------------------------
// <copyright file="TrainTests.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

/*using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Test para un correcto funcionamiento de la clase Logica <see cref="Partida"/>
    /// </summary>
    [TestFixture]
    public class TestDeLogica
    {
        /// <summary>
        /// El tablero que va a ser utilizado para los tests.Es necesario ya que Logica solo
        ///  se ejecuta si esta en conjunto de la clase tablero;
        /// </summary>
        private LogicaDePartida logicaDePartida;

        /// <summary>
        /// SetUp Creado con el objetivo de tener un tablero vacio al principio de cada test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.logicaDePartida = new LogicaDePartida(9, 01,02);
        }
        /// <summary>
        /// Test con el objetivo de ver si se añade correctamente los barcos horizontales al ser asignados al tablero
        /// testea la casilla donde se inicia el barco y tambien testea que la casilla anterior este vacia.
        /// (Cuando una casilla esta vacia contiene un valor '\u0000')
        /// </summary>

        [Test]
        public void PrincipioDeBarcoHorizontal()
        {
            int[] inicioDelBarco = new int[2];
            inicioDelBarco[0] = 4;
            inicioDelBarco[1] = 3;
            int[] finalDelBarco = new int[2];
            finalDelBarco[0] = 4;
            finalDelBarco[1] = 7;
            logicaDePartida.AñadirBarco(inicioDelBarco ,finalDelBarco,1);
            char expected = 'B';
            char[ , ]tableroActualizado = logicaDePartida.VerTableroPropio(1);
            Assert.AreEqual(expected, tableroActualizado[4,3]);
            Assert.AreEqual('\u0000', tableroActualizado[4,2]);
        }
        /// <summary>
        /// Test con el objetivo de ver si se añade correctamente los barcos horizontales al ser asignados al tablero
        /// testea la casilla donde finaliza el barco y tambien testea que la casilla siguiente este vacia.
        /// (Cuando una casilla esta vacia contiene un valor '\u0000')
        /// </summary>
        [Test]
        public void FinalDeBarcoHorizontal()
        {
            int[] inicioDelBarco = new int[2];
            inicioDelBarco[0] = 4;
            inicioDelBarco[1] = 3;
            int[] finalDelBarco = new int[2];
            finalDelBarco[0] = 4;
            finalDelBarco[1] = 7;
            logicaDePartida.AñadirBarco(inicioDelBarco ,finalDelBarco,1);
            char expected = 'B';
            char[ , ]tableroActualizado = logicaDePartida.VerTableroPropio(01);
            Assert.AreEqual(expected, tableroActualizado[4,7]);
            Assert.AreEqual('\u0000', tableroActualizado[4,8]);
        }
        /// <summary>
        /// Test con el objetivo de ver si se añade correctamente los barcos verticales al ser asignados al tablero
        /// testea la casilla donde se inicia el barco y tambien testea que la casilla anterior este vacia.
        /// (Cuando una casilla esta vacia contiene un valor '\u0000')
        /// </summary>
        [Test]
        public void PrincipioDeBarcoVertical()
        {
            int[] inicioDelBarco = new int[2];
            inicioDelBarco[0] = 1;
            inicioDelBarco[1] = 7;
            int[] finalDelBarco = new int[2];
            finalDelBarco[0] = 5;
            finalDelBarco[1] = 7;
            logicaDePartida.AñadirBarco(inicioDelBarco ,finalDelBarco,1);
            char expected = 'B';
            char[ , ]tableroActualizado = logicaDePartida.VerTableroPropio(01);
            Assert.AreEqual(expected, tableroActualizado[1,7]);
            Assert.AreEqual('\u0000', tableroActualizado[0,7]);
        }
        /// <summary>
        /// Test con el objetivo de ver si se añade correctamente los barcos verticales al ser asignados al tablero
        /// testea la casilla donde finaliza el barco y tambien testea que la casilla siguiente este vacia.
        /// (Cuando una casilla esta vacia contiene un valor '\u0000')
        /// </summary>
        [Test]
        public void FinalDeBarcoVertical()
        {
            int[] inicioDelBarco = new int[2];
            inicioDelBarco[0] = 1;
            inicioDelBarco[1] = 7;
            int[] finalDelBarco = new int[2];
            finalDelBarco[0] = 5;
            finalDelBarco[1] = 7;
            logicaDePartida.AñadirBarco(inicioDelBarco ,finalDelBarco,1);
            char expected = 'B';
            char[ , ]tableroActualizado = logicaDePartida.VerTableroPropio(1);
            Assert.AreEqual(expected, tableroActualizado[5,7]);
            Assert.AreEqual('\u0000', tableroActualizado[6,7]);
        }
        /// <summary>
        /// Test con el objetivo de ver que al atacar una casilla vacia cambia su contenido a 'W' Lo cual simboliza agua.
        /// </summary>
        [Test]
        public void AtaqueAlAgua()
        {
            int[] LugarAAtacar = new int[2];
            LugarAAtacar[0] = 5;
            LugarAAtacar[1] = 7;
            logicaDePartida.Atacar(LugarAAtacar, 1);
            char expected = 'W';
            char[ , ]tableroActualizado = logicaDePartida.VerTableroPropio(2);
            Assert.AreEqual(expected, tableroActualizado[5,7]);
        }
        /// <summary>
        /// Se ataca un punto del barco para ver que este cambie por 'T'.
        /// </summary>
        [Test]
        public void AtaqueBarcoVertical()
        {
            int[] inicioDelBarco = new int[2];
            inicioDelBarco[0] = 1;
            inicioDelBarco[1] = 7;
            int[] finalDelBarco = new int[2];
            finalDelBarco[0] = 5;
            finalDelBarco[1] = 7;
            logicaDePartida.AñadirBarco(inicioDelBarco ,finalDelBarco,1);
            int[] LugarAAtacar = new int[2];
            LugarAAtacar[0] = 5;
            LugarAAtacar[1] = 7;
            logicaDePartida.Atacar(LugarAAtacar,2);
            char expected = 'T';
            char[ , ]tableroActualizado = logicaDePartida.VerTableroPropio(1);
            Assert.AreEqual(expected, tableroActualizado[5,7]);
        }
        /// <summary>
        /// Se ataca 2 veces el mismo punto del barco para ver que este se mantega siendo 'T'.
        /// </summary>
        [Test]
        public void AtaqueBarcoVerticalEnElMismoLugar()
        {
            int[] inicioDelBarco = new int[2];
            inicioDelBarco[0] = 1;
            inicioDelBarco[1] = 7;
            int[] finalDelBarco = new int[2];
            finalDelBarco[0] = 5;
            finalDelBarco[1] = 7;
            logicaDePartida.AñadirBarco(inicioDelBarco ,finalDelBarco,1);
            int[] LugarAAtacar = new int[2];
            LugarAAtacar[0] = 5;
            LugarAAtacar[1] = 7;
            logicaDePartida.Atacar(LugarAAtacar, 2);
            logicaDePartida.Atacar(LugarAAtacar, 2);
            char expected = 'T';
            char[ , ]tableroActualizado = logicaDePartida.VerTableroPropio(1);
            Assert.AreEqual(expected, tableroActualizado[5,7]);
        }
        /// <summary>
        /// Se ataca un punto del barco para ver que este cambie por 'T'.
        /// </summary>
        [Test]
        public void AtaqueBarcoHorizontal()
        {
            int[] inicioDelBarco = new int[2];
            inicioDelBarco[0] = 7;
            inicioDelBarco[1] = 3;
            int[] finalDelBarco = new int[2];
            finalDelBarco[0] = 7;
            finalDelBarco[1] = 7;
            logicaDePartida.AñadirBarco(inicioDelBarco ,finalDelBarco,1);
            int[] LugarAAtacar = new int[2];
            LugarAAtacar[0] = 7;
            LugarAAtacar[1] = 4;
            logicaDePartida.Atacar(LugarAAtacar,2);
            char expected = 'T';
            char[ , ]tableroActualizado = logicaDePartida.VerTableroPropio(01);
            Assert.AreEqual(expected, tableroActualizado[7,4]);
        }
         /// <summary>
        /// Se ataca 2 veces el mismo punto del barco para ver que este se mantega siendo 'T'.
        /// </summary>
        [Test]
        public void AtaqueBarcoHorizontalEnElMismoLugar()
        {
            int[] inicioDelBarco = new int[2];
            inicioDelBarco[0] = 7;
            inicioDelBarco[1] = 3;
            int[] finalDelBarco = new int[2];
            finalDelBarco[0] = 7;
            finalDelBarco[1] = 7;
            logicaDePartida.AñadirBarco(inicioDelBarco ,finalDelBarco,1);
            int[] LugarAAtacar = new int[2];
            LugarAAtacar[0] = 7;
            LugarAAtacar[1] = 5;
            logicaDePartida.Atacar(LugarAAtacar, 2);
            logicaDePartida.Atacar(LugarAAtacar, 2);
            char expected = 'T';
            char[ , ]tableroActualizado = logicaDePartida.VerTableroPropio(1);
            Assert.AreEqual(expected, tableroActualizado[7,5]);
        }
    }
}*/