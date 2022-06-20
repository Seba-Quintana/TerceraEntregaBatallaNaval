using System;
using ClassLibrary;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
	/// <summary>
	/// Tests de AlmacenamientoUsuarios <see cref="AlmacenamientoUsuario"/>
	/// </summary>
    [TestFixture]
    public class TestDeAlmacenamientoUsuarios
    {
		/// <summary>
		/// Instancia de almacenamiento usuarios
		/// </summary>
		private AlmacenamientoUsuario Test;

        /// <summary>
        /// SetUp Creado con el objetivo de tener los elementos necesatios 
        /// para probar AlacenamientoUsuarios de diferentes maneras
        /// </summary>
        
        [SetUp]
        public void Setup()
        {
			Test = AlmacenamientoUsuario.Instance();
        }

		/// <summary>
        /// Pruebo si una coordenada correcta se traduce correctamente
        /// </summary>
        [Test]
        public void ObtenerPerfil()
        {
			Test.Registrar("jugadorTest", 5, "Test");
			PerfilUsuario perfil = Test.ObtenerPerfil(1);
			int expected = 1;
           	Assert.AreEqual(expected, perfil.NumeroDeJugador);
        }

        /// <summary>
        /// Pruebo si una coordenada correcta se traduce correctamente
        /// </summary>
        [Test]
        public void Registrar()
        {
            int numerodejugador = Test.Registrar("jugadorTest", 5, "Test");
			int expected = 2;
            Assert.AreEqual(expected, numerodejugador);
        }

		/// <summary>
        /// Pruebo si una coordenada correcta se traduce correctamente
        /// </summary>
        [Test]
        public void Registrar2()
        {
            int numerodejugador = Test.Registrar("jugadorTest", 5, "Test");
			PerfilUsuario perfil = Test.ObtenerPerfil(numerodejugador);
			int expected = 3;
			if (perfil == Test.ListaDeUsuarios[numerodejugador-1])
            	Assert.AreEqual(expected, numerodejugador);
        }

		/// <summary>
        /// Pruebo si una coordenada correcta se traduce correctamente
        /// </summary>
        [Test]
        public void Remover()
        {
			// remuevo al jugador 2
			PerfilUsuario perfil = Test.ObtenerPerfil(2);
			int numerodejugador = perfil.NumeroDeJugador;
			int antesDeRemover = Test.ListaDeUsuarios.Count;
            Test.Remover(numerodejugador);
			int despuesDeRemover = Test.ListaDeUsuarios.Count;
           	Assert.AreNotEqual(despuesDeRemover, antesDeRemover);
        }

		/// <summary>
        /// Pruebo si una coordenada correcta se traduce correctamente
        /// </summary>
        [Test]
        public void ObtenerRanking()
        {
            Admin.EmparejarAmigos(0, 1, 2, 7);
            jugador1.PosicionarBarcos("A1","A6");
            jugador1.PosicionarBarcos("B1","B6");
            jugador2.PosicionarBarcos("E1","E6");
            jugador2.PosicionarBarcos("F1","F6");
            int i = 1;
            while(i <= 6)
            {
                jugador1.Atacar($"G{i}");
                jugador2.Atacar($"A{i}");
                i+=1;
            }
            i = 1;
            while(i < 6)
            {
                jugador1.Atacar($"C{i}");
                jugador2.Atacar($"B{i}");
                i+=1;
            }
            jugador1.Atacar("C6");
            jugador2.Atacar("B6");
			List<PerfilUsuario> ranking = Test.ObtenerRanking();
			PerfilUsuario perfilGanador = Test.ObtenerPerfil(jugador2.NumeroDeJugador);
			Assert.AreEqual(perfilGanador, ranking[0]);
        }
    }
}
