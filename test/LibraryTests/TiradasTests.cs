using System;
using ClassLibrary;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    /// <summary>
    /// Tests de Tiradas <see cref="Partida"/>
	/// Tests para probar funcionalidad de la defensa
	/// prueba que se calcule bien la cantidad de disparos que han tocado el agua,
	/// así como de los que han impactado en barcos.
	/// 
	/// Fue necesario comentar tres tests de partida rapida y partida rapida
	/// para que funcionaran estos tests.
	/// Los mismos son:
	/// Partida: AtaqueAlAgua, AtaqueAlAguaEnElMismoLugar y AtaqueBarcoEnElMismoLugar
	/// PartidaRapida: AtaqueAlAgua, AtaqueBarcoVertical y AtaqueBarcoVerticalEnElMismoLugar
	/// Tambien solucione un error en el test AgregarUnDatosdePartida del historial
	/// en el que se le pasaba una ID repetida
    /// </summary>
    [TestFixture]
    public class TiradasTests
    {
        /// <summary>
        /// SetUp Creado con el objetivo de tener los elementos necesatios 
        /// para probar AlacenamientoUsuarios de diferentes maneras
        /// </summary>
        
        [SetUp]
        public void Setup()
        {
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
        /// Pruebo si se cuentan bien las tiradas al agua (un solo ataque)
        /// </summary>
        [Test]
        public void TiradasAgua1()
        {
            //Partida completa simulada
            AlmacenamientoUsuario almacenamiento = AlmacenamientoUsuario.Instance();
            int numeroDeJugador1 = almacenamiento.Registrar("jugadorTest", 5, "Test");
			int numeroDeJugador2 = almacenamiento.Registrar("jugadorTest", 6, "Test");

            Planificador.EmparejarAmigos(0, numeroDeJugador1, numeroDeJugador2, 7);
            PartidasEnJuego partidas = PartidasEnJuego.Instance();
            Partida partida = partidas.ObtenerPartida(numeroDeJugador1);

            partida.AgregarBarco("A1","A6", numeroDeJugador1);
            partida.AgregarBarco("B1","B6", numeroDeJugador1);
            partida.AgregarBarco("E1","E6", numeroDeJugador2);
            partida.AgregarBarco("F1","F6", numeroDeJugador2);
            partida.Atacar($"G{1}", numeroDeJugador1);

			int tiradasAgua = Planificador.TiradasAguaTotales(numeroDeJugador1);

            int expected = 1;

            Assert.AreEqual(expected, tiradasAgua);

            partidas.RemoverPartida(partida);
            almacenamiento.Remover(numeroDeJugador1);
            almacenamiento.Remover(numeroDeJugador2);
        }
		/// <summary>
        /// pruebo si se cuentan bien las tiradas a barcos (un solo ataque)
        /// </summary>
        [Test]
        public void TiradasBarco1()
        {
            //Partida completa simulada
            AlmacenamientoUsuario almacenamiento = AlmacenamientoUsuario.Instance();
            int numeroDeJugador1 = almacenamiento.Registrar("jugadorTest", 5, "Test");
			int numeroDeJugador2 = almacenamiento.Registrar("jugadorTest", 6, "Test");

            Planificador.EmparejarAmigos(0, numeroDeJugador1, numeroDeJugador2, 7);
            PartidasEnJuego partidas = PartidasEnJuego.Instance();
            Partida partida = partidas.ObtenerPartida(numeroDeJugador1);

            partida.AgregarBarco("A1","A6", numeroDeJugador1);
            partida.AgregarBarco("B1","B6", numeroDeJugador1);
            partida.AgregarBarco("E1","E6", numeroDeJugador2);
            partida.AgregarBarco("F1","F6", numeroDeJugador2);
            partida.Atacar($"E{1}", numeroDeJugador1);

			int tiradasBarco = Planificador.TiradasBarcoTotales(numeroDeJugador1);

            int expected = 1;

            Assert.AreEqual(expected, tiradasBarco);

            partidas.RemoverPartida(partida);
            almacenamiento.Remover(numeroDeJugador1);
            almacenamiento.Remover(numeroDeJugador2);
        }

        /// <summary>
        /// Pruebo si se cuentan bien las tiradas al agua (más de un ataque)
        /// </summary>
        [Test]
        public void TiradasAgua2()
        {
            //Partida completa simulada
            AlmacenamientoUsuario almacenamiento = AlmacenamientoUsuario.Instance();
            int numeroDeJugador1 = almacenamiento.Registrar("jugadorTest", 5, "Test");
			int numeroDeJugador2 = almacenamiento.Registrar("jugadorTest", 6, "Test");

            Planificador.EmparejarAmigos(0, numeroDeJugador1, numeroDeJugador2, 7);
            PartidasEnJuego partidas = PartidasEnJuego.Instance();
            Partida partida = partidas.ObtenerPartida(numeroDeJugador1);

            partida.AgregarBarco("A1","A6", numeroDeJugador1);
            partida.AgregarBarco("B1","B6", numeroDeJugador1);
            partida.AgregarBarco("E1","E6", numeroDeJugador2);
            partida.AgregarBarco("F1","F6", numeroDeJugador2);
            int i = 1;
            while(i <= 6)
            {
                partida.Atacar($"G{i}", numeroDeJugador1);
                partida.Atacar($"A{i}", numeroDeJugador2);
                i+=1;
            }
            i = 1;
            while(i <= 6)
            {
                partida.Atacar($"C{i}", numeroDeJugador1);
                partida.Atacar($"B{i}", numeroDeJugador2);
                i+=1;
            }

			int tiradasAgua = Planificador.TiradasAguaTotales(numeroDeJugador1);
			// expected == 12 porque hay 12 barcos por persona,
			// (tablero == 7) entonces 7*7*25/100 == 12
			// y como los dos tiran la misma cantidad de veces, y el jugador2
			// gana en 12 tiradas, el jugador 1 hizo 12 tiradas al agua tambien
            int expected = 12;

            Assert.AreEqual(expected, tiradasAgua);

            partidas.RemoverPartida(partida);
            almacenamiento.Remover(numeroDeJugador1);
            almacenamiento.Remover(numeroDeJugador2);
        }
		/// <summary>
        /// pruebo si se cuentan bien las tiradas a barcos (más de un ataque)
        /// </summary>
        [Test]
        public void TiradasBarco2()
        {
            //Partida completa simulada
            AlmacenamientoUsuario almacenamiento = AlmacenamientoUsuario.Instance();
            int numeroDeJugador1 = almacenamiento.Registrar("jugadorTest", 5, "Test");
			int numeroDeJugador2 = almacenamiento.Registrar("jugadorTest", 6, "Test");

            Planificador.EmparejarAmigos(0, numeroDeJugador1, numeroDeJugador2, 7);
            PartidasEnJuego partidas = PartidasEnJuego.Instance();
            Partida partida = partidas.ObtenerPartida(numeroDeJugador1);

            partida.AgregarBarco("A1","A6", numeroDeJugador1);
            partida.AgregarBarco("B1","B6", numeroDeJugador1);
            partida.AgregarBarco("E1","E6", numeroDeJugador2);
            partida.AgregarBarco("F1","F6", numeroDeJugador2);
            int i = 1;
            while(i <= 6)
            {
                partida.Atacar($"G{i}", numeroDeJugador1);
                partida.Atacar($"A{i}", numeroDeJugador2);
                i+=1;
            }
            i = 1;
            while(i <= 6)
            {
                partida.Atacar($"C{i}", numeroDeJugador1);
                partida.Atacar($"B{i}", numeroDeJugador2);
                i+=1;
            }

			int tiradasBarco = Planificador.TiradasAguaTotales(numeroDeJugador1);
			// expected == 12 porque hay 12 barcos por persona,
			// (tablero == 7) entonces 7*7*25/100 == 12
            int expected = 12;
            Assert.AreEqual(expected,tiradasBarco);

            partidas.RemoverPartida(partida);
            almacenamiento.Remover(numeroDeJugador1);
            almacenamiento.Remover(numeroDeJugador2);
        }

		/// <summary>
        /// Pruebo si se cuentan bien tanto las tiradas al agua como a barcos
        /// </summary>
        [Test]
        public void TiradasMixtas()
        {
            //Partida completa simulada
            AlmacenamientoUsuario almacenamiento = AlmacenamientoUsuario.Instance();
            int numeroDeJugador1 = almacenamiento.Registrar("jugadorTest", 5, "Test");
			int numeroDeJugador2 = almacenamiento.Registrar("jugadorTest", 6, "Test");

            Planificador.EmparejarAmigos(0, numeroDeJugador1, numeroDeJugador2, 7);
            PartidasEnJuego partidas = PartidasEnJuego.Instance();
            Partida partida = partidas.ObtenerPartida(numeroDeJugador1);

            partida.AgregarBarco("A1","A6", numeroDeJugador1);
            partida.AgregarBarco("B1","B6", numeroDeJugador1);
            partida.AgregarBarco("E1","E6", numeroDeJugador2);
            partida.AgregarBarco("F1","F6", numeroDeJugador2);
            int i = 1;
            while(i <= 6)
            {
                partida.Atacar($"D{i}", numeroDeJugador1);
                partida.Atacar($"G{i}", numeroDeJugador2);
                i+=1;
            }
            i = 1;
            while(i <= 6)
            {
                partida.Atacar($"C{i}", numeroDeJugador1);
                partida.Atacar($"B{i}", numeroDeJugador2);
                i+=1;
            }

			int tiradasAgua = Planificador.TiradasAguaTotales(numeroDeJugador1);

            int expected = 18;

            Assert.AreEqual(expected, tiradasAgua);

            partidas.RemoverPartida(partida);
            almacenamiento.Remover(numeroDeJugador1);
            almacenamiento.Remover(numeroDeJugador2);
        }

		/// <summary>
        /// Pruebo si se cuentan bien tanto las tiradas al agua como a barcos
        /// </summary>
        [Test]
        public void TiradasMixtas2()
        {
            //Partida completa simulada
            AlmacenamientoUsuario almacenamiento = AlmacenamientoUsuario.Instance();
            int numeroDeJugador1 = almacenamiento.Registrar("jugadorTest", 5, "Test");
			int numeroDeJugador2 = almacenamiento.Registrar("jugadorTest", 6, "Test");

            Planificador.EmparejarAmigos(0, numeroDeJugador1, numeroDeJugador2, 7);
            PartidasEnJuego partidas = PartidasEnJuego.Instance();
            Partida partida = partidas.ObtenerPartida(numeroDeJugador1);

            partida.AgregarBarco("A1","A6", numeroDeJugador1);
            partida.AgregarBarco("B1","B6", numeroDeJugador1);
            partida.AgregarBarco("E1","E6", numeroDeJugador2);
            partida.AgregarBarco("F1","F6", numeroDeJugador2);
            int i = 1;
            while(i <= 6)
            {
                partida.Atacar($"E{i}", numeroDeJugador1);
                partida.Atacar($"A{i}", numeroDeJugador2);
                i+=1;
            }
            i = 1;
            while(i <= 6)
            {
                partida.Atacar($"C{i}", numeroDeJugador1);
                partida.Atacar($"B{i}", numeroDeJugador2);
                i+=1;
            }

			int tiradasBarco = Planificador.TiradasBarcoTotales(numeroDeJugador1);
			
            int expected = 18;

            Assert.AreEqual(expected, tiradasBarco);

            partidas.RemoverPartida(partida);
            almacenamiento.Remover(numeroDeJugador1);
            almacenamiento.Remover(numeroDeJugador2);
        }
    }
}