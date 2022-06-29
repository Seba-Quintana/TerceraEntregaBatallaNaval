using System;
using ClassLibrary;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    /// <summary>
    /// Tests de traductor <see cref="PartidasEnJuegoTests"/>
    /// </summary>
    [TestFixture]
    public class PartidasEnJuegoTests
    {
        /// <summary>
        /// Verifica que una Partida se agregue correctamente a la lista de PartidasEnJuego
        /// </summary>
        [Test]
        public void AgregarUnaPartida()
        {
            PartidasEnJuego test = PartidasEnJuego.Instance();
            Partida part = new Partida(9, 5, 6);
            Assert.AreEqual(part.jugadores,test.ObtenerPartida(5).jugadores);
            test.RemoverPartida(part);
        }
        /// <summary>
        /// Verifica que una Partida se obtenga correctamente de la lista de PartidasEnJuego
        /// </summary>
        [Test]
        public void ObtenerUnaPartida()
        {
            PartidasEnJuego test = PartidasEnJuego.Instance();
            Partida part = new Partida(9, 5, 6);
            Partida expected = test.ObtenerPartida(5);
            Assert.AreEqual(expected.jugadores,part.jugadores);
            test.RemoverPartida(part);
        }
        /// <summary>
        /// Verifica que una Partida se elimina correctamente a la lista de PartidasEnJuego
        /// </summary>
        [Test]
        public void RemoverUnaPartida()
        {
            PartidasEnJuego test = PartidasEnJuego.Instance();
            Partida part = new Partida(9, 5, 6);
            test.RemoverPartida(part);
            Assert.AreEqual(test.ObtenerPartida(5),null);
        }
    }
}
