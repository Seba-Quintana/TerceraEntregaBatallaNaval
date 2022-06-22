/*using System;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Tests de traductor <see cref="TraductorDeCoordenadas"/>
    /// </summary>
    [TestFixture]
    public class TestDeTraductor
    {
        /// <summary>
        /// Pruebo si una coordenada correcta se traduce correctamente
        /// </summary>
        [Test]
        public void CoordenadaCorrecta1()
        {
            int[] coord = TraductorDeCoordenadas.Traducir("A1");
            int[] expected = new int[2];
            expected[0] = 0;
            expected[1] = 0;
            Assert.AreEqual(expected, coord);
        }

        /// <summary>
        /// Pruebo si una coordenada correcta se traduce correctamente
        /// </summary>
        [Test]
        public void CoordenadaCorrecta2()
        {
            int[] coord = TraductorDeCoordenadas.Traducir("j1");
            int[] expected = new int[2];
            expected[0] = 9;
            expected[1] = 0;
            Assert.AreEqual(expected, coord);
        }

        /// <summary>
        /// Pruebo si una coordenada correcta se traduce correctamente
        /// </summary>
        [Test]
        public void CoordenadaCorrecta3()
        {
            int[] coord = TraductorDeCoordenadas.Traducir("A10");
            int[] expected = new int[2];
            expected[0] = 0;
            expected[1] = 9;
            Assert.AreEqual(expected, coord);
        }

        /// <summary>
        /// Pruebo si una coordenada correcta se traduce correctamente
        /// </summary>
        [Test]
        public void CoordenadaCorrecta4()
        {
            int[] coord = TraductorDeCoordenadas.Traducir("o15");
            int[] expected = new int[2];
            expected[0] = 14;
            expected[1] = 14;
            Assert.AreEqual(expected, coord);
        }

        /// <summary>
        /// Pruebo si al ingresar una fila en minuscula se traduce correctamente
        /// </summary>
        [Test]
        public void CoordenadaMinuscula()
        {
            int[] coord = TraductorDeCoordenadas.Traducir("a1");
            int[] expected = new int[2];
            expected[0] = 0;
            expected[1] = 0;
            Assert.AreEqual(expected, coord);
        }

        /// <summary>
        /// Pruebo si al ingresar primero las columnas y luego las filas se traduce correctamente
        /// </summary>
        [Test]
        public void CoordenadaAlReves()
        {
            int[] coord = TraductorDeCoordenadas.Traducir("1A");
            int[] expected = null;
            Assert.AreEqual(expected, coord);
        }

        /// <summary>
        /// Pruebo si al ingresar primero las columnas y luego las filas,
        /// y ademas se ingresan las coordenadas al reves, se traduce correctamente
        /// </summary>
        [Test]
        public void CoordenadaAlRevesMinuscula()
        {
            int[] coord = TraductorDeCoordenadas.Traducir("1a");
            int[] expected = null;
            Assert.AreEqual(expected, coord);
        }

        /// <summary>
        /// Pruebo si al ingresar una coordenada invalida no se traduce
        /// </summary>
        [Test]
        public void CoordenadaInvalidaUnaLetra()
        {
            int[] coord = TraductorDeCoordenadas.Traducir("d");
            int[] expected = null;
            Assert.AreEqual(expected, coord);
        }

        /// <summary>
        /// Pruebo si al ingresar una coordenada invalida no se traduce
        /// </summary>
        [Test]
        public void CoordenadaInvalidaUnNumero()
        {
            int[] coord = TraductorDeCoordenadas.Traducir("3");
            int[] expected = null;
            Assert.AreEqual(expected, coord);
        }

        /// <summary>
        /// Pruebo si al ingresar una coordenada invalida no se traduce
        /// </summary>
        [Test]
        public void CoordenadaInvalidaDosLetras()
        {
            int[] coord = TraductorDeCoordenadas.Traducir("aa");
            int[] expected = null;
            Assert.AreEqual(expected, coord);
        }

        /// <summary>
        /// Pruebo si al ingresar una coordenada invalida no se traduce
        /// </summary>
        [Test]
        public void CoordenadaInvalidaDosNumeros()
        {
            int[] coord = TraductorDeCoordenadas.Traducir("15");
            int[] expected = null;
            Assert.AreEqual(expected, coord);
        }

        /// <summary>
        /// Pruebo si al ingresar una coordenada invalida no se traduce
        /// </summary>
        [Test]
        public void CoordenadaInvalidaTresLetras()
        {
            int[] coord = TraductorDeCoordenadas.Traducir("abc");
            int[] expected = null;
            Assert.AreEqual(expected, coord);
        }

        /// <summary>
        /// Pruebo si al ingresar una coordenada invalida no se traduce
        /// </summary>
        [Test]
        public void CoordenadaInvalidaTresNumeros()
        {
            int[] coord = TraductorDeCoordenadas.Traducir("123");
            int[] expected = null;
            Assert.AreEqual(expected, coord);
        }

        /// <summary>
        /// Pruebo si al ingresar una coordenada invalida no se traduce
        /// </summary>
        [Test]
        public void CoordenadaInvalidaNada()
        {
            int[] coord = TraductorDeCoordenadas.Traducir("");
            int[] expected = null;
            Assert.AreEqual(expected, coord);
        }

        /// <summary>
        /// Pruebo si al ingresar una coordenada invalida no se traduce
        /// </summary>
        [Test]
        public void CoordenadaInvalidaTodo()
        {
            int[] coord = TraductorDeCoordenadas.Traducir("a665adsf46a(/%&&/%!$*-+=?587$(/&$/!#5465$%%&/((=6(1");
            int[] expected = null;
            Assert.AreEqual(expected, coord);
        }
    }
}*/
