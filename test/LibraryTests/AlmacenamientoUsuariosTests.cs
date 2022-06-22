/*using System;
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
            int i = 1;
            int CantidadUsuarios = Test.ListaDeUsuarios.Count;
            while (i <= CantidadUsuarios)
            {
                Test.Remover(i);
                i++;
            }
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
			int expected = 1;
			
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
			int expected = 1;
			if (perfil == Test.ListaDeUsuarios[numerodejugador-1])
            	Assert.AreEqual(expected, numerodejugador);
        }

		/// <summary>
        /// Pruebo si una coordenada correcta se traduce correctamente
        /// </summary>
        [Test]
        public void Remover()
        {
			Test.Registrar("jugadorTest", 5, "Test");
			PerfilUsuario perfil = Test.ObtenerPerfil(1);
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
			Test.Registrar("jugadorTest", 5, "Test");
			Test.Registrar("jugadorTest", 5, "Test");
            Planificador.EmparejarAmigos(0, 1, 2, 7);
            Planificador.Posicionar("A1","A6", 1);
            Planificador.Posicionar("B1","B6", 1);
            Planificador.Posicionar("E1","E6", 2);
            Planificador.Posicionar("F1","F6", 2);
            int i = 1;
            while(i <= 6)
            {
                Planificador.Atacar($"G{i}", 1);
                Planificador.Atacar($"A{i}", 2);
                i+=1;
            }
            i = 1;
            while(i < 6)
            {
                Planificador.Atacar($"C{i}", 1);
                Planificador.Atacar($"B{i}", 2);
                i+=1;
            }
            Planificador.Atacar("C6", 1);
            Planificador.Atacar("B6", 2);
			List<PerfilUsuario> ranking = Test.ObtenerRanking();
			PerfilUsuario perfilGanador = Test.ObtenerPerfil(2);
			Assert.AreEqual(perfilGanador.NumeroDeJugador, ranking[0].NumeroDeJugador);
        }
    }
}*/
