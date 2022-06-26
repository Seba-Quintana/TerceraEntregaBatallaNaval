using System;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Tests de traductor <see cref="PartidaRapida"/>
    /// </summary>
    [TestFixture]
    public class MensajesdePartidaRapidaTests
    {
        /// <summary>
        /// La partida que va a ser utilizado para los tests.
        /// </summary>
        private PartidaRapida partida;

        /// <summary>
        /// SetUp Creado con el objetivo de tener una partida al principio de cada test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.partida = new PartidaRapida(9, 1, 2);
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
            partida.AñadirBarco(inicioDelBarco ,finalDelBarco,1);
            partida.AñadirBarco(inicioDelBarco ,finalDelBarco,2);
            string inicioDelBarco1 = "B1";
            string finalDelBarco1 = "B7";
            partida.AñadirBarco(inicioDelBarco1 ,finalDelBarco1,1);
            partida.AñadirBarco(inicioDelBarco1 ,finalDelBarco1,2);
            string inicioDelBarco2 = "C1";
            string finalDelBarco2 = "C6";
            partida.AñadirBarco(inicioDelBarco2 ,finalDelBarco2,1);
            partida.AñadirBarco(inicioDelBarco2 ,finalDelBarco2,2);
            string respuesta = partida.Atacar("D1", 2);
            string expected = "Debe esperar a que el otro jugador lo ataque.";
            Assert.AreEqual(expected, respuesta);
            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(partida);
        }
        /// <summary>
        /// Verifica que se devuelven los mensajes correctamente cuando intentas atacar fuera de turno
        /// </summary>
        [Test]
        public void AtaqueFueraDeTurno2()
        {
            string inicioDelBarco = "A1";
            string finalDelBarco = "A7";
            partida.AñadirBarco(inicioDelBarco ,finalDelBarco,1);
            partida.AñadirBarco(inicioDelBarco ,finalDelBarco,2);
            string inicioDelBarco1 = "B1";
            string finalDelBarco1 = "B7";
            partida.AñadirBarco(inicioDelBarco1 ,finalDelBarco1,1);
            partida.AñadirBarco(inicioDelBarco1 ,finalDelBarco1,2);
            string inicioDelBarco2 = "C1";
            string finalDelBarco2 = "C6";
            partida.AñadirBarco(inicioDelBarco2 ,finalDelBarco2,1);
            partida.AñadirBarco(inicioDelBarco2 ,finalDelBarco2,2);
            partida.Atacar("D1", 1);
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
            partida.AñadirBarco(inicioDelBarco ,finalDelBarco,1);
            partida.AñadirBarco(inicioDelBarco ,finalDelBarco,2);
            string inicioDelBarco1 = "B1";
            string finalDelBarco1 = "B7";
            partida.AñadirBarco(inicioDelBarco1 ,finalDelBarco1,1);
            partida.AñadirBarco(inicioDelBarco1 ,finalDelBarco1,2);
            string inicioDelBarco2 = "C1";
            string finalDelBarco2 = "C6";
            partida.AñadirBarco(inicioDelBarco2 ,finalDelBarco2,1);
            partida.AñadirBarco(inicioDelBarco2 ,finalDelBarco2,2);
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
            partida.AñadirBarco(inicioDelBarco ,finalDelBarco,1);
            partida.AñadirBarco(inicioDelBarco ,finalDelBarco,2);
            string inicioDelBarco1 = "B1";
            string finalDelBarco1 = "B7";
            partida.AñadirBarco(inicioDelBarco1 ,finalDelBarco1,1);
            partida.AñadirBarco(inicioDelBarco1 ,finalDelBarco1,2);
            string inicioDelBarco2 = "C1";
            string finalDelBarco2 = "C6";
            partida.AñadirBarco(inicioDelBarco2 ,finalDelBarco2,1);
            partida.AñadirBarco(inicioDelBarco2 ,finalDelBarco2,2);
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
            partida.AñadirBarco(inicioDelBarco ,finalDelBarco,1);
            partida.AñadirBarco(inicioDelBarco ,finalDelBarco,2);
            string inicioDelBarco1 = "B1";
            string finalDelBarco1 = "B7";
            partida.AñadirBarco(inicioDelBarco1 ,finalDelBarco1,1);
            partida.AñadirBarco(inicioDelBarco1 ,finalDelBarco1,2);
            string inicioDelBarco2 = "C1";
            string finalDelBarco2 = "C6";
            partida.AñadirBarco(inicioDelBarco2 ,finalDelBarco2,1);
            partida.AñadirBarco(inicioDelBarco2 ,finalDelBarco2,2);
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
            partida.AñadirBarco(inicioDelBarco ,finalDelBarco,1);
            partida.AñadirBarco(inicioDelBarco ,finalDelBarco,2);
            string inicioDelBarco1 = "B1";
            string finalDelBarco1 = "B7";
            partida.AñadirBarco(inicioDelBarco1 ,finalDelBarco1,1);
            partida.AñadirBarco(inicioDelBarco1 ,finalDelBarco1,2);
            string inicioDelBarco2 = "C1";
            string finalDelBarco2 = "C6";
            partida.AñadirBarco(inicioDelBarco2 ,finalDelBarco2,1);
            partida.AñadirBarco(inicioDelBarco2 ,finalDelBarco2,2);
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
            partida.AñadirBarco(inicioDelBarco ,finalDelBarco,1);
            partida.AñadirBarco(inicioDelBarco ,finalDelBarco,2);
            string inicioDelBarco1 = "B1";
            string finalDelBarco1 = "B7";
            partida.AñadirBarco(inicioDelBarco1 ,finalDelBarco1,1);
            partida.AñadirBarco(inicioDelBarco1 ,finalDelBarco1,2);
            string inicioDelBarco2 = "C1";
            string finalDelBarco2 = "C6";
            partida.AñadirBarco(inicioDelBarco2 ,finalDelBarco2,1);
            partida.AñadirBarco(inicioDelBarco2 ,finalDelBarco2,2);
            int i = 1;
            while (i<7)
            {
                partida.Atacar($"A{i}",1);
                partida.Atacar($"A{i}",1);
                partida.Atacar($"A{i}",2);
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
            partida.AñadirBarco(inicioDelBarco ,finalDelBarco,1);
            partida.AñadirBarco(inicioDelBarco ,finalDelBarco,2);
            string inicioDelBarco1 = "B1";
            string finalDelBarco1 = "B7";
            partida.AñadirBarco(inicioDelBarco1 ,finalDelBarco1,1);
            partida.AñadirBarco(inicioDelBarco1 ,finalDelBarco1,2);
            string inicioDelBarco2 = "C1";
            string finalDelBarco2 = "C6";
            partida.AñadirBarco(inicioDelBarco2 ,finalDelBarco2,1);
            partida.AñadirBarco(inicioDelBarco2 ,finalDelBarco2,2);
            int i = 1;
            while (i<=7)
            {
                partida.Atacar($"A{i}",1);
                partida.Atacar($"A{i}",1);
                partida.Atacar($"A{i}",2);
                partida.Atacar($"A{i}",2);
                i = i + 1;
            }
            string respuesta = partida.Atacar("A7", 1);
            string expected = "Has atacado una casilla donde que habia sido atacada anteriormente y contenia una parte de un barco Hundido";
            Assert.AreEqual(expected, respuesta);
        }
    }
}

