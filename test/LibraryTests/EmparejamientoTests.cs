using System;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Tests de traductor <see cref="Emparejamiento"/>
    /// </summary>
    [TestFixture]
    public class EmparejamientoTests
    {
        private AlmacenamientoUsuario removedor;

        /// <summary>
		/// Instancia de Emparejamiento;
		/// </summary>
		private Emparejamiento emparejamiento;

        /// <summary>
        /// SetUp Creado con el objetivo de tener los elementos necesarios para realizar ls test
        /// </summary>
        
        [SetUp]
        public void Setup()
        {
			emparejamiento = Emparejamiento.Instance();
            removedor = AlmacenamientoUsuario.Instance();
            int i = 1;
            int CantidadUsuarios = removedor.ListaDeUsuarios.Count;
            while (i <= CantidadUsuarios)
            {
                removedor.Remover(i);
                i++;
            }
        }
        /// <summary>
        /// Prueba que si se remueve correctamente un usuario de la cola de emparejamiento aleatorio en modo normal
        /// </summary>
        [Test]
        public void RemoverFilaEsperaEmparejamientoAleatorioModoNormal()
        {
            Jugador jugador1 = new Jugador("Jugador1",1,"contraseña");
            Jugador jugador2 = new Jugador("Jugador2",2,"contraseña");
            Jugador jugador3 = new Jugador("Jugador3",3,"contraseña");
            int[] emparejados1 = emparejamiento.EmparejarAleatorio(0,jugador1.NumeroDeJugador);
            emparejamiento.RemoverListaEspera(jugador1.NumeroDeJugador);
            int[] emparejados2 = emparejamiento.EmparejarAleatorio(0,jugador2.NumeroDeJugador);
            int[] emparejados3 = emparejamiento.EmparejarAleatorio(0,jugador3.NumeroDeJugador);
            int[] verificar = new int[2];
            verificar[0] = jugador2.NumeroDeJugador;
            verificar[1] = jugador3.NumeroDeJugador;
            Assert.AreEqual(emparejados1,null);
            Assert.AreEqual(emparejados2,null);
            Assert.AreEqual(emparejados3[0],verificar[0]);
            Assert.AreEqual(emparejados3[1],verificar[1]);
            removedor.Remover(1);
            removedor.Remover(2);
            removedor.Remover(3);
        }
        /// <summary>
        /// Prueba que si se remueve correctamente un usuario de la cola de emparejamiento aleatorio en modo rapido
        /// </summary>
        [Test]
        public void RemoverFilaEsperaEmparejamientoAleatorioModoRapido()
        {
            Jugador jugador1 = new Jugador("Jugador1",1,"contraseña");
            Jugador jugador2 = new Jugador("Jugador2",2,"contraseña");
            Jugador jugador3 = new Jugador("Jugador3",3,"contraseña");
            int[] emparejados1 = emparejamiento.EmparejarAleatorio(1,jugador1.NumeroDeJugador);
            emparejamiento.RemoverListaEspera(jugador1.NumeroDeJugador);
            int[] emparejados2 = emparejamiento.EmparejarAleatorio(1,jugador2.NumeroDeJugador);
            int[] emparejados3 = emparejamiento.EmparejarAleatorio(1,jugador3.NumeroDeJugador);
            int[] verificar = new int[2];
            verificar[0] = jugador2.NumeroDeJugador;
            verificar[1] = jugador3.NumeroDeJugador;
            Assert.AreEqual(emparejados1,null);
            Assert.AreEqual(emparejados2,null);
            Assert.AreEqual(emparejados3[0],verificar[0]);
            Assert.AreEqual(emparejados3[1],verificar[1]);
        }
        /// <summary>
        /// Prueba que si se emparejan correctamente los jugadores al entrar en emparejamiento aleatorio buscando una partida en modo normal.
        /// </summary>
        [Test]
        public void EmparejamientoAleatorioModoNormal()
        {
            Jugador jugador1 = new Jugador("Jugador1",1,"contraseña");
            Jugador jugador2 = new Jugador("Jugador2",2,"contraseña");
            Jugador jugador3 = new Jugador("Jugador3",3,"contraseña");
            int[] emparejados1 = emparejamiento.EmparejarAleatorio(0,jugador1.NumeroDeJugador);
            int[] emparejados2 = emparejamiento.EmparejarAleatorio(0,jugador2.NumeroDeJugador);
            int[] emparejados3 = emparejamiento.EmparejarAleatorio(0,jugador3.NumeroDeJugador);
            int[] verificar = new int[2];
            verificar[0] = jugador1.NumeroDeJugador;
            verificar[1] = jugador2.NumeroDeJugador;
            Assert.AreEqual(emparejados1,null);
            Assert.AreEqual(emparejados2[0],verificar[0]);
            Assert.AreEqual(emparejados2[1],verificar[1]);
            Assert.AreEqual(emparejados3,null);
            emparejamiento.RemoverListaEspera(jugador3.NumeroDeJugador);
        }
        /// <summary>
        /// Prueba que si se emparejan correctamente los jugadores al entrar en emparejamiento aleatorio buscando una partida en modo rapido
        /// </summary>
        [Test]
        public void EmparejamientoAleatorioModoRapido()
        {
            Jugador jugador1 = new Jugador("Jugador1",1,"contraseña");
            Jugador jugador2 = new Jugador("Jugador2",2,"contraseña");
            Jugador jugador3 = new Jugador("Jugador3",3,"contraseña");
            int[] emparejados1 = emparejamiento.EmparejarAleatorio(1,jugador1.NumeroDeJugador);
            int[] emparejados2 = emparejamiento.EmparejarAleatorio(1,jugador2.NumeroDeJugador);
            int[] emparejados3 = emparejamiento.EmparejarAleatorio(1,jugador3.NumeroDeJugador);
            int[] verificar = new int[2];
            verificar[0] = jugador1.NumeroDeJugador;
            verificar[1] = jugador2.NumeroDeJugador;
            Assert.AreEqual(emparejados1,null);
            Assert.AreEqual(emparejados2[0],verificar[0]);
            Assert.AreEqual(emparejados2[1],verificar[1]);
            Assert.AreEqual(emparejados3,null);
            emparejamiento.RemoverListaEspera(jugador3.NumeroDeJugador);
        }
        /// <summary>
        /// Prueba si dos jugadores se emparejan correctamente en una partida amistosa en modo normal
        /// </summary>
        [Test]
        public void EmparejarAmigosModoNormal()
        {
            Jugador jugador1 = new Jugador("Jugador1",1,"contraseña");
            Jugador jugador2 = new Jugador("Jugador2",2,"contraseña");
            int[] emparejados = emparejamiento.EmparejarAmigos(0,jugador1.NumeroDeJugador,jugador2.NumeroDeJugador);
            int[] verificar = new int[2];
            verificar[0] = jugador1.NumeroDeJugador;
            verificar[1] = jugador2.NumeroDeJugador;
            Assert.AreEqual(emparejados[0],verificar[0]);
            Assert.AreEqual(emparejados[1],verificar[1]);      
        }
        /// <summary>
        /// Prueba si dos jugadores se emparejan correctamente en una partida amistosa en modo rapido
        /// </summary>
        [Test]
        public void EmparejarAmigosModoRapido()
        {
            Jugador jugador1 = new Jugador("Jugador1",1,"contraseña");
            Jugador jugador2 = new Jugador("Jugador2",2,"contraseña");
            int[] emparejados = emparejamiento.EmparejarAmigos(1,jugador1.NumeroDeJugador,jugador2.NumeroDeJugador);
            int[] verificar = new int[2];
            verificar[0] = jugador1.NumeroDeJugador;
            verificar[1] = jugador2.NumeroDeJugador;
            Assert.AreEqual(emparejados[0],verificar[0]);
            Assert.AreEqual(emparejados[1],verificar[1]);
        }
    }
}