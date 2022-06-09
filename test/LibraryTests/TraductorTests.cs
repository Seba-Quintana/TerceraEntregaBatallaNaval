using System;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TestDeTraductor
    {
        /// <summary>
        /// El tablero que va a ser utilizado para los tests.
        /// </summary>
        private Tablero tablero;

        /// <summary>
        /// SetUp Creado con el objetivo de tener los elementos necesatios 
        /// para probar el traductor de coordenadas de diferentes maneras
        /// </summary>
        
        [SetUp]
        public void Setup()
        {
            this.tablero = new Tablero(9, 01);
            int[] inicioDelBarco = new int[2];
            int[] finalDelBarco = new int[2];
            LogicaDeTablero.Añadirbarco(tablero ,inicioDelBarco ,finalDelBarco );
        }

        /// <summary>
        /// Pruebo si una coordenada correcta se traduce correctamente
        /// </summary>
        [Test]
        public void Coordenada()
        {
            int[] a = TraductorDeCoordenadas.Traducir("A1");
            int[] expected = new int[2];
            expected[0] = 0;
            expected[1] = 1;
            Assert.AreEqual(expected, a);
        }

        /// <summary>
        /// Pruebo si al ingresar una fila en minuscula se traduce correctamente
        /// </summary>
        [Test]
        public void CoordenadaMinuscula()
        {
            int[] a = TraductorDeCoordenadas.Traducir("a1");
            int[] expected = new int[2];
            expected[0] = 0;
            expected[1] = 0;
            Assert.AreEqual(expected, a);
        }

        /// <summary>
        /// Pruebo si al ingresar primero las columnas y luego las filas se traduce correctamente
        /// </summary>
        [Test]
        public void CoordenadaAlReves()
        {
            int[] a = TraductorDeCoordenadas.Traducir("1A");
            int[] expected = new int[2];
            expected[0] = 0;
            expected[1] = 0;
            Assert.AreEqual(expected, a);
        }

        /// <summary>
        /// Pruebo si al ingresar primero las columnas y luego las filas,
        /// y ademas se ingresan las coordenadas al reves, se traduce correctamente
        /// </summary>
        [Test]
        public void CoordenadaAlRevesMinuscula()
        {
            int[] a = TraductorDeCoordenadas.Traducir("1a");
            int[] expected = new int[2];
            expected[0] = 0;
            expected[1] = 0;
            Assert.AreEqual(expected, a);
        }

        /// <summary>
        /// Pruebo si al ingresar una coordenada invalida no se traduce
        /// </summary>
        [Test]
        public void CoordenadaInvalida()
        {
            int[] a = TraductorDeCoordenadas.Traducir("a665adsf46a(/%&&/%!$*-+=?587$(/&$/!#5465$%%&/((=6(1");
            int[] expected = new int[2];
            expected[0] = 0;
            expected[1] = 1;
            Assert.AreEqual(expected, a);
        }
    }
}
