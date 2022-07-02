/*using System;
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
        /// La partida que va a ser utilizado para los tests.
        /// </summary>
        private Partida partida;

        /// <summary>
        /// SetUp Creado con el objetivo de tener una partida al principio de cada test.
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
        public void AgregarBarcoHorizontal1()
        {
            string inicioDelBarco = "E4";
            string finalDelBarco = "E6";
            string respuesta = partida.AgregarBarco(inicioDelBarco ,finalDelBarco,1);
            string expected = "Se Agrego correctamente el barco\nLe quedan 17 barcos para pocicionar";
            Assert.AreEqual(expected, respuesta);
            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(partida);
        }
        /// <summary>
        /// Verifica que se devuelven los mensajes correctamente al añadir un barco horizontal correctamente
        /// cuando se completa la cantidad de barcos por posicionar
        /// </summary>
        [Test]
        public void AgregarBarcoHorizontal2()
        {
            string inicioDelBarco = "B1";
            string finalDelBarco = "B6";
            partida.AgregarBarco(inicioDelBarco ,finalDelBarco,1);
            string inicioDelBarco1 = "C1";
            string finalDelBarco1 = "C6";
            partida.AgregarBarco(inicioDelBarco1 ,finalDelBarco1,1);
            string inicioDelBarco2 = "D1";
            string finalDelBarco2 = "D6";
            partida.AgregarBarco(inicioDelBarco2 ,finalDelBarco2,1);
            string inicioDelBarco3 = "E1";
            string finalDelBarco3 = "E2";
            string respuesta = partida.AgregarBarco(inicioDelBarco3 ,finalDelBarco3,1);
            string expected = "Se Agrego correctamente el barco\nHas posicionado todos Los barcos que tenias disponibles en esta partida";
            Assert.AreEqual(expected, respuesta);
            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(partida);
        }
        /// <summary>
        /// Verifica que se devuelven los mensajes correctamente al intentar añadir un barco horizontal
        /// cuando se ingresa un largo de barco mayor a la cantidad de barcos disponible
        /// </summary>
        [Test]
        public void AgregarBarcoHorizontal3()
        {
            string inicioDelBarco = "B1";
            string finalDelBarco = "B6";
            partida.AgregarBarco(inicioDelBarco ,finalDelBarco,1);
            string inicioDelBarco1 = "C1";
            string finalDelBarco1 = "C6";
            partida.AgregarBarco(inicioDelBarco1 ,finalDelBarco1,1);
            string inicioDelBarco2 = "D1";
            string finalDelBarco2 = "D6";
            partida.AgregarBarco(inicioDelBarco2 ,finalDelBarco2,1);
            string inicioDelBarco3 = "E1";
            string finalDelBarco3 = "E4";
            string respuesta = partida.AgregarBarco(inicioDelBarco3 ,finalDelBarco3,1);
            string expected = "No se añadio su barco ya que le quedan 2 lugar/es para poner barcos, una cantidad inferior a el tamaño del barco que quiso poner";
            Assert.AreEqual(expected, respuesta);
            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(partida);
        }
        /// <summary>
        /// Verifica que se devuelven los mensajes correctamente al intentar añadir un barco horizontal
        /// sobre donde ya se encuentra un barco
        /// </summary>
        [Test]
        public void AgregarBarcoHorizontal4()
        {
            string inicioDelBarco = "B1";
            string finalDelBarco = "B6";
            partida.AgregarBarco(inicioDelBarco ,finalDelBarco,1);
            string inicioDelBarco1 = "B1";
            string finalDelBarco1 = "B6";
            string respuesta = partida.AgregarBarco(inicioDelBarco1 ,finalDelBarco1,1);
            string expected = "Has intentado posicionar un barco sobre otro, Lo cual no esta permitido, envie otra coordenada por favor\nLe quedan 14 barcos para pocicionar";
            Assert.AreEqual(expected, respuesta);
            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(partida);
        }


        /// <summary>
        /// Verifica que se devuelven los mensajes correctamente al añadir un barco vertical correctamente
        /// cuando aun quedan barcos por posicionar
        /// </summary>
        [Test]
        public void AgregarBarcoVertical1()
        {
            string inicioDelBarco = "A1";
            string finalDelBarco = "E1";
            string respuesta = partida.AgregarBarco(inicioDelBarco ,finalDelBarco,1);
            string expected = "Se Agrego correctamente el barco\nLe quedan 15 barcos para pocicionar";
            Assert.AreEqual(expected, respuesta);
            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(partida);
        }
        /// <summary>
        /// Verifica que se devuelven los mensajes correctamente al añadir un barco vertical correctamente
        /// cuando se completa la cantidad de barcos por posicionar
        /// </summary>
        [Test]
        public void AgregarBarcoVertical2()
        {
            string inicioDelBarco = "A1";
            string finalDelBarco = "E1";
            partida.AgregarBarco(inicioDelBarco ,finalDelBarco,1);
            string inicioDelBarco1 = "A2";
            string finalDelBarco1 = "E2";
            partida.AgregarBarco(inicioDelBarco1 ,finalDelBarco1,1);
            string inicioDelBarco2 = "A3";
            string finalDelBarco2 = "E3";
            partida.AgregarBarco(inicioDelBarco2 ,finalDelBarco2,1);
            string inicioDelBarco3 = "A4";
            string finalDelBarco3 = "E4";
            string respuesta = partida.AgregarBarco(inicioDelBarco3 ,finalDelBarco3,1);
            string expected = "Se Agrego correctamente el barco\nHas posicionado todos Los barcos que tenias disponibles en esta partida";
            Assert.AreEqual(expected, respuesta);
            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(partida);
        }
        /// <summary>
        /// Verifica que se devuelven los mensajes correctamente al intentar añadir un barco vertical
        /// cuando se ingresa un largo de barco mayor a la cantidad de barcos disponible
        /// </summary>
        [Test]
        public void AgregarBarcoVertical3()
        {
            string inicioDelBarco = "A1";
            string finalDelBarco = "E1";
            partida.AgregarBarco(inicioDelBarco ,finalDelBarco,1);
            string inicioDelBarco1 = "A2";
            string finalDelBarco1 = "E2";
            partida.AgregarBarco(inicioDelBarco1 ,finalDelBarco1,1);
            string inicioDelBarco2 = "A3";
            string finalDelBarco2 = "E3";
            partida.AgregarBarco(inicioDelBarco2 ,finalDelBarco2,1);
            string inicioDelBarco3 = "A4";
            string finalDelBarco3 = "F4";
            string respuesta = partida.AgregarBarco(inicioDelBarco3 ,finalDelBarco3,1);
            string expected = "No se añadio su barco ya que le quedan 5 lugar/es para poner barcos, una cantidad inferior a el tamaño del barco que quiso poner";
            Assert.AreEqual(expected, respuesta);
            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(partida);
        }
        /// <summary>
        /// Verifica que se devuelven los mensajes correctamente al intentar añadir un barco vertical
        /// sobre donde ya se encuentra un barco
        /// </summary>
        [Test]
        public void AgregarBarcoVertical4()
        {
            string inicioDelBarco = "A1";
            string finalDelBarco = "E1";
            partida.AgregarBarco(inicioDelBarco ,finalDelBarco,1);
            string inicioDelBarco1 = "A1";
            string finalDelBarco1 = "E1";
            string respuesta = partida.AgregarBarco(inicioDelBarco1 ,finalDelBarco1,1);
            string expected = "Has intentado posicionar un barco sobre otro, Lo cual no esta permitido, envie otra coordenada por favor\nLe quedan 15 barcos para pocicionar";
            Assert.AreEqual(expected, respuesta);
            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(partida);
        }
        /// <summary>
        /// Verifica que se devuelven los mensajes correctamente al intentar añadir un barco en diagonal
        /// </summary>
        [Test]
        public void AgregarBarcoDiagonal()
        {
            string inicioDelBarco = "A1";
            string finalDelBarco = "E3";
            string respuesta = partida.AgregarBarco(inicioDelBarco ,finalDelBarco,1);
            string expected = "No se pueden agregar barcos diagonalmente";
            Assert.AreEqual(expected, respuesta);
            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(partida);
        }
        /// <summary>
        /// Verifica que se devuelven los mensajes correctamente al intentar añadir con coordenadas incorrectas
        /// </summary>
        [Test]
        public void AgregarBarcoCoordenadasIncorrectas()
        {
            string inicioDelBarco = "AF";
            string finalDelBarco = "E3";
            string respuesta = partida.AgregarBarco(inicioDelBarco ,finalDelBarco,1);
            string expected = "Una de las coordenadas enviadas fue invalida";
            Assert.AreEqual(expected, respuesta);
            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(partida);
        }
        /// <summary>
        /// Verifica que se devuelven los mensajes correctamente al atacar sin terminar la etapa de posicionamiento
        /// </summary>
        [Test]
        public void AtaqueSinTerminardePosicionar()
        {
            string LugarAAtacar = "A1";
            int[] ataque = TraductorDeCoordenadas.Traducir(LugarAAtacar);
            string respuesta = partida.Atacar("A1", 1);
            string expected = "Estamos en etapa de posicionamiento, si no le quedan barcos para posicionar, entonces espere a que termine de posicionar su oponente";
            Assert.AreEqual(expected, respuesta);
            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(partida);
        }
        /// <summary>
        /// Verifica que se devuelven los mensajes correctamente cuando intentas atacar fuera de turno
        /// </summary>
        [Test]
        public void AtaqueFueraDeTurno()
        {
            string inicioDelBarco = "A1";
            string finalDelBarco = "A7";
            partida.AgregarBarco(inicioDelBarco ,finalDelBarco,1);
            partida.AgregarBarco(inicioDelBarco ,finalDelBarco,2);
            string inicioDelBarco1 = "B1";
            string finalDelBarco1 = "B7";
            partida.AgregarBarco(inicioDelBarco1 ,finalDelBarco1,1);
            partida.AgregarBarco(inicioDelBarco1 ,finalDelBarco1,2);
            string inicioDelBarco2 = "C1";
            string finalDelBarco2 = "C6";
            partida.AgregarBarco(inicioDelBarco2 ,finalDelBarco2,1);
            partida.AgregarBarco(inicioDelBarco2 ,finalDelBarco2,2);
            string respuesta = partida.Atacar("D1", 2);
            string expected = "Debe esperar a que el otro jugador lo ataque.";
            Assert.AreEqual(expected, respuesta);
            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(partida);
        }
        /// <summary>
        /// Verifica que se devuelven los mensajes correctamente cuando se ataca al agua
        /// </summary>
        [Test]
        public void AtaqueAlAgua()
        {
            string inicioDelBarco = "A1";
            string finalDelBarco = "A7";
            partida.AgregarBarco(inicioDelBarco ,finalDelBarco,1);
            partida.AgregarBarco(inicioDelBarco ,finalDelBarco,2);
            string inicioDelBarco1 = "B1";
            string finalDelBarco1 = "B7";
            partida.AgregarBarco(inicioDelBarco1 ,finalDelBarco1,1);
            partida.AgregarBarco(inicioDelBarco1 ,finalDelBarco1,2);
            string inicioDelBarco2 = "C1";
            string finalDelBarco2 = "C6";
            partida.AgregarBarco(inicioDelBarco2 ,finalDelBarco2,1);
            partida.AgregarBarco(inicioDelBarco2 ,finalDelBarco2,2);
            string respuesta = partida.Atacar("D1", 1);
            string expected = "Que lastima! has desperdiciado una bala en el agua";
            Assert.AreEqual(expected, respuesta);
            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(partida);
        }
        /// <summary>
        /// Verifica que se devuelven los mensajes correctamente cuando se ataca al agua dos veces seguidas
        /// </summary>
        [Test]
        public void AtaqueAlAgua2()
        {
            string inicioDelBarco = "A1";
            string finalDelBarco = "A7";
            partida.AgregarBarco(inicioDelBarco ,finalDelBarco,1);
            partida.AgregarBarco(inicioDelBarco ,finalDelBarco,2);
            string inicioDelBarco1 = "B1";
            string finalDelBarco1 = "B7";
            partida.AgregarBarco(inicioDelBarco1 ,finalDelBarco1,1);
            partida.AgregarBarco(inicioDelBarco1 ,finalDelBarco1,2);
            string inicioDelBarco2 = "C1";
            string finalDelBarco2 = "C6";
            partida.AgregarBarco(inicioDelBarco2 ,finalDelBarco2,1);
            partida.AgregarBarco(inicioDelBarco2 ,finalDelBarco2,2);
            partida.Atacar("D1", 1);
            partida.Atacar("D1", 2);
            string respuesta = partida.Atacar("D1", 1);
            string expected = "La casilla ya habia sido atacada y contiene agua";
            Assert.AreEqual(expected, respuesta);
        }
        /// <summary>
        /// Verifica que se devuelven los mensajes correctamente cuando se ataca un barco
        /// </summary>
        [Test]
        public void AtaqueABarco()
        {
            string inicioDelBarco = "A1";
            string finalDelBarco = "A7";
            partida.AgregarBarco(inicioDelBarco ,finalDelBarco,1);
            partida.AgregarBarco(inicioDelBarco ,finalDelBarco,2);
            string inicioDelBarco1 = "B1";
            string finalDelBarco1 = "B7";
            partida.AgregarBarco(inicioDelBarco1 ,finalDelBarco1,1);
            partida.AgregarBarco(inicioDelBarco1 ,finalDelBarco1,2);
            string inicioDelBarco2 = "C1";
            string finalDelBarco2 = "C6";
            partida.AgregarBarco(inicioDelBarco2 ,finalDelBarco2,1);
            partida.AgregarBarco(inicioDelBarco2 ,finalDelBarco2,2);
            string respuesta = partida.Atacar("A1", 1);
            string expected = "Buen tiro, has atacado a un barco";
            Assert.AreEqual(expected, respuesta);
            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(partida);
        }
        /// <summary>
        /// Verifica que se devuelven los mensajes correctamente cuando se ataca a un barco dos veces seguidas
        /// </summary>
        [Test]
        public void AtaqueABarco2()
        {
            string inicioDelBarco = "A1";
            string finalDelBarco = "A7";
            partida.AgregarBarco(inicioDelBarco ,finalDelBarco,1);
            partida.AgregarBarco(inicioDelBarco ,finalDelBarco,2);
            string inicioDelBarco1 = "B1";
            string finalDelBarco1 = "B7";
            partida.AgregarBarco(inicioDelBarco1 ,finalDelBarco1,1);
            partida.AgregarBarco(inicioDelBarco1 ,finalDelBarco1,2);
            string inicioDelBarco2 = "C1";
            string finalDelBarco2 = "C6";
            partida.AgregarBarco(inicioDelBarco2 ,finalDelBarco2,1);
            partida.AgregarBarco(inicioDelBarco2 ,finalDelBarco2,2);
            partida.Atacar("A1", 1);
            partida.Atacar("D1", 2);
            string respuesta = partida.Atacar("A1", 1);
            string expected = "Has atacado una casilla donde que habia sido atacada anteriormente y contenia una parte de un barco dañado";
            Assert.AreEqual(expected, respuesta);
        }
        /// <summary>
        /// Verifica que se devuelven los mensajes correctamente cuando se hunde un barco
        /// </summary>
        [Test]
        public void AtaqueHundeBarco()
        {
            string inicioDelBarco = "A1";
            string finalDelBarco = "A7";
            partida.AgregarBarco(inicioDelBarco ,finalDelBarco,1);
            partida.AgregarBarco(inicioDelBarco ,finalDelBarco,2);
            string inicioDelBarco1 = "B1";
            string finalDelBarco1 = "B7";
            partida.AgregarBarco(inicioDelBarco1 ,finalDelBarco1,1);
            partida.AgregarBarco(inicioDelBarco1 ,finalDelBarco1,2);
            string inicioDelBarco2 = "C1";
            string finalDelBarco2 = "C6";
            partida.AgregarBarco(inicioDelBarco2 ,finalDelBarco2,1);
            partida.AgregarBarco(inicioDelBarco2 ,finalDelBarco2,2);
            int i = 1;
            while (i<7)
            {
                partida.Atacar($"A{i}",1);
                partida.Atacar($"A{i}",2);
                i = i + 1;
            }
            string respuesta = partida.Atacar("A7", 1);
            string expected = "Felicitaciones Has hundido un Barco";
            Assert.AreEqual(expected, respuesta);
        }
        /// <summary>
        /// Verifica que se devuelven los mensajes correctamente cuando se ataca a un barco hundido
        /// </summary>
        [Test]
        public void AtaqueHundeBarco2()
        {
            string inicioDelBarco = "A1";
            string finalDelBarco = "A7";
            partida.AgregarBarco(inicioDelBarco ,finalDelBarco,1);
            partida.AgregarBarco(inicioDelBarco ,finalDelBarco,2);
            string inicioDelBarco1 = "B1";
            string finalDelBarco1 = "B7";
            partida.AgregarBarco(inicioDelBarco1 ,finalDelBarco1,1);
            partida.AgregarBarco(inicioDelBarco1 ,finalDelBarco1,2);
            string inicioDelBarco2 = "C1";
            string finalDelBarco2 = "C6";
            partida.AgregarBarco(inicioDelBarco2 ,finalDelBarco2,1);
            partida.AgregarBarco(inicioDelBarco2 ,finalDelBarco2,2);
            int i = 1;
            while (i<=7)
            {
                partida.Atacar($"A{i}",1);
                partida.Atacar($"A{i}",2);
                i = i + 1;
            }
            string respuesta = partida.Atacar("A7", 1);
            string expected = "Has atacado una casilla donde que habia sido atacada anteriormente y contenia una parte de un barco Hundido";
            Assert.AreEqual(expected, respuesta);
        }
    }
}
*/
