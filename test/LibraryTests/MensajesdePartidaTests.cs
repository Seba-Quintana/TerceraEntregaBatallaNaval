using System;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Tests de traductor <see cref="Partida"/>
    /// </summary>
    [TestFixture]
    public class MensajesdePartidaTests
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
        /// Verifica que se devuelven los mensajes correctamente al añadir un barco horizontal correctamente
        /// cuando aun quedan barcos por posicionar
        /// </summary>
        [Test]
        public void AñadirBarcoHorizontal1()
        {
            string inicioDelBarco = "E4";
            string finalDelBarco = "E6";
            string respuesta = partida.AñadirBarco(inicioDelBarco ,finalDelBarco,1);
            string expected = "Se Agrego correctamente el barco\nLe quedan 17 barcos para pocicionar";
            Assert.AreEqual(expected, respuesta);
        }
        /// <summary>
        /// Verifica que se devuelven los mensajes correctamente al añadir un barco horizontal correctamente
        /// cuando se completa la cantidad de barcos por posicionar
        /// </summary>
        [Test]
        public void AñadirBarcoHorizontal2()
        {
            string inicioDelBarco = "B1";
            string finalDelBarco = "B6";
            partida.AñadirBarco(inicioDelBarco ,finalDelBarco,1);
            string inicioDelBarco1 = "C1";
            string finalDelBarco1 = "C6";
            partida.AñadirBarco(inicioDelBarco1 ,finalDelBarco1,1);
            string inicioDelBarco2 = "D1";
            string finalDelBarco2 = "D6";
            partida.AñadirBarco(inicioDelBarco2 ,finalDelBarco2,1);
            string inicioDelBarco3 = "E1";
            string finalDelBarco3 = "E2";
            string respuesta = partida.AñadirBarco(inicioDelBarco3 ,finalDelBarco3,1);
            string expected = "Se Agrego correctamente el barco\nHas posicionado todos Los barcos que tenias disponibles en esta partida";
            Assert.AreEqual(expected, respuesta);
        }
        /// <summary>
        /// Verifica que se devuelven los mensajes correctamente al intentar añadir un barco horizontal
        /// cuando se ingresa un largo de barco mayor a la cantidad de barcos disponible
        /// </summary>
        [Test]
        public void AñadirBarcoHorizontal3()
        {
            string inicioDelBarco = "B1";
            string finalDelBarco = "B6";
            partida.AñadirBarco(inicioDelBarco ,finalDelBarco,1);
            string inicioDelBarco1 = "C1";
            string finalDelBarco1 = "C6";
            partida.AñadirBarco(inicioDelBarco1 ,finalDelBarco1,1);
            string inicioDelBarco2 = "D1";
            string finalDelBarco2 = "D6";
            partida.AñadirBarco(inicioDelBarco2 ,finalDelBarco2,1);
            string inicioDelBarco3 = "E1";
            string finalDelBarco3 = "E4";
            string respuesta = partida.AñadirBarco(inicioDelBarco3 ,finalDelBarco3,1);
            string expected = "No se añadio su barco ya que le quedan 2 lugar/es para poner barcos, una cantidad inferior a el tamaño del barco que quiso poner";
            Assert.AreEqual(expected, respuesta);
        }
        /// <summary>
        /// Verifica que se devuelven los mensajes correctamente al intentar añadir un barco horizontal
        /// sobre donde ya se encuentra un barco
        /// </summary>
        [Test]
        public void AñadirBarcoHorizontal4()
        {
            string inicioDelBarco = "B1";
            string finalDelBarco = "B6";
            partida.AñadirBarco(inicioDelBarco ,finalDelBarco,1);
            string inicioDelBarco1 = "B1";
            string finalDelBarco1 = "B6";
            string respuesta = partida.AñadirBarco(inicioDelBarco1 ,finalDelBarco1,1);
            string expected = "Has intentado posicionar un barco sobre otro, Lo cual no esta permitido, envie otra coordenada por favor\nLe quedan 14 barcos para pocicionar";
            Assert.AreEqual(expected, respuesta);
        }


        /// <summary>
        /// Verifica que se devuelven los mensajes correctamente al añadir un barco vertical correctamente
        /// cuando aun quedan barcos por posicionar
        /// </summary>
        [Test]
        public void AñadirBarcoVertical1()
        {
            string inicioDelBarco = "A1";
            string finalDelBarco = "E1";
            string respuesta = partida.AñadirBarco(inicioDelBarco ,finalDelBarco,1);
            string expected = "Se Agrego correctamente el barco\nLe quedan 15 barcos para pocicionar";
            Assert.AreEqual(expected, respuesta);
        }
        /// <summary>
        /// Verifica que se devuelven los mensajes correctamente al añadir un barco vertical correctamente
        /// cuando se completa la cantidad de barcos por posicionar
        /// </summary>
        [Test]
        public void AñadirBarcoVertical2()
        {
            string inicioDelBarco = "A1";
            string finalDelBarco = "E1";
            partida.AñadirBarco(inicioDelBarco ,finalDelBarco,1);
            string inicioDelBarco1 = "A2";
            string finalDelBarco1 = "E2";
            partida.AñadirBarco(inicioDelBarco1 ,finalDelBarco1,1);
            string inicioDelBarco2 = "A3";
            string finalDelBarco2 = "E3";
            partida.AñadirBarco(inicioDelBarco2 ,finalDelBarco2,1);
            string inicioDelBarco3 = "A4";
            string finalDelBarco3 = "E4";
            string respuesta = partida.AñadirBarco(inicioDelBarco3 ,finalDelBarco3,1);
            string expected = "Se Agrego correctamente el barco\nHas posicionado todos Los barcos que tenias disponibles en esta partida";
            Assert.AreEqual(expected, respuesta);
        }
        /// <summary>
        /// Verifica que se devuelven los mensajes correctamente al intentar añadir un barco vertical
        /// cuando se ingresa un largo de barco mayor a la cantidad de barcos disponible
        /// </summary>
        [Test]
        public void AñadirBarcoVertical3()
        {
            string inicioDelBarco = "A1";
            string finalDelBarco = "E1";
            partida.AñadirBarco(inicioDelBarco ,finalDelBarco,1);
            string inicioDelBarco1 = "A2";
            string finalDelBarco1 = "E2";
            partida.AñadirBarco(inicioDelBarco1 ,finalDelBarco1,1);
            string inicioDelBarco2 = "A3";
            string finalDelBarco2 = "E3";
            partida.AñadirBarco(inicioDelBarco2 ,finalDelBarco2,1);
            string inicioDelBarco3 = "A4";
            string finalDelBarco3 = "F4";
            string respuesta = partida.AñadirBarco(inicioDelBarco3 ,finalDelBarco3,1);
            string expected = "No se añadio su barco ya que le quedan 5 lugar/es para poner barcos, una cantidad inferior a el tamaño del barco que quiso poner";
            Assert.AreEqual(expected, respuesta);
        }
        /// <summary>
        /// Verifica que se devuelven los mensajes correctamente al intentar añadir un barco vertical
        /// sobre donde ya se encuentra un barco
        /// </summary>
        [Test]
        public void AñadirBarcoVertical4()
        {
            string inicioDelBarco = "A1";
            string finalDelBarco = "E1";
            partida.AñadirBarco(inicioDelBarco ,finalDelBarco,1);
            string inicioDelBarco1 = "A1";
            string finalDelBarco1 = "E1";
            string respuesta = partida.AñadirBarco(inicioDelBarco1 ,finalDelBarco1,1);
            string expected = "Has intentado posicionar un barco sobre otro, Lo cual no esta permitido, envie otra coordenada por favor\nLe quedan 15 barcos para pocicionar";
            Assert.AreEqual(expected, respuesta);
        }
        /// <summary>
        /// Verifica que se devuelven los mensajes correctamente al intentar añadir un barco en diagonal
        /// </summary>
        [Test]
        public void AñadirBarcoDiagonal()
        {
            string inicioDelBarco = "A1";
            string finalDelBarco = "E3";
            string respuesta = partida.AñadirBarco(inicioDelBarco ,finalDelBarco,1);
            string expected = "No se pueden agregar barcos diagonalmente";
            Assert.AreEqual(expected, respuesta);
        }
        /// <summary>
        /// Verifica que se devuelven los mensajes correctamente al intentar añadir con coordenadas incorrectas
        /// </summary>
        [Test]
        public void AñadirBarcoCoordenadasIncorrectas()
        {
            string inicioDelBarco = "AF";
            string finalDelBarco = "E3";
            string respuesta = partida.AñadirBarco(inicioDelBarco ,finalDelBarco,1);
            string expected = "Una de las coordenadas enviadas fue invalida";
            Assert.AreEqual(expected, respuesta);
        }
        /// <summary>
        /// Verifica que se devuelven los mensajes correctamente al atacar sin terminar la etapa de posicionamiento
        /// </summary>
        [Test]
        public void AtaqueAlAgua()
        {
            Partida test = new Partida(7,1,2);
            string LugarAAtacar = "A1";
            int[] ataque = TraductorDeCoordenadas.Traducir(LugarAAtacar);
            string respuesta = test.Atacar("A1", 1);
            string expected = "Estamos en etapa de posicionamiento, si no le quedan barcos para posicionar, entonces espere a que termine de posicionar su oponente";
            Assert.AreEqual(expected, respuesta);
        }
    }
}