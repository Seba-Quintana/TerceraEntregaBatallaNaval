using System;
using ClassLibrary;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    /// <summary>
    /// Tests de traductor <see cref="Historial"/>
    /// </summary>
    [TestFixture]
    public class HistorialTests
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
        /// Verifica que un DatosdePartida se agregue correctamente a la lista de Historial
        /// </summary>
        [Test]
        public void AgregarUnDatosdePartida()
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

            //Verifico que se agrego en el historial
            Historial historial = Historial.Instance();
            List<DatosdePartida> expected = almacenamiento.ObtenerPerfil(numeroDeJugador2).ObtenerHistorialPersonal();
            Assert.AreEqual(expected,historial.Partidas);

            partidas.RemoverPartida(partida);
            almacenamiento.Remover(numeroDeJugador1);
            almacenamiento.Remover(numeroDeJugador2);
        }
    }
}
