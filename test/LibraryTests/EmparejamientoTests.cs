using System;
using ClassLibrary;
using NUnit.Framework;

/*namespace Tests
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
            int numeroDeJugador1 = Planificador.Registrar("Carlos",67,"player1");
            int numeroDeJugador2 = Planificador.Registrar("Drake",55,"player2");
            int numeroDeJugador3 = Planificador.Registrar("Raul",85,"player3");

            int[] emparejados1 = emparejamiento.EmparejarAleatorio(0,numeroDeJugador1);
            emparejamiento.RemoverListaEspera(numeroDeJugador1);
            int[] emparejados2 = emparejamiento.EmparejarAleatorio(0,numeroDeJugador2);
            int[] emparejados3 = emparejamiento.EmparejarAleatorio(0,numeroDeJugador3);

            int[] verificar = new int[2];
            verificar[0] = numeroDeJugador2;
            verificar[1] = numeroDeJugador3;
            Assert.AreEqual(emparejados1,null);
            Assert.AreEqual(emparejados2,null);
            Assert.AreEqual(emparejados3[0],verificar[0]);
            Assert.AreEqual(emparejados3[1],verificar[1]);

            removedor.Remover(numeroDeJugador1);
            removedor.Remover(numeroDeJugador2);
            removedor.Remover(numeroDeJugador3);
            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(remover.ObtenerPartida(2));
        }
        /// <summary>
        /// Prueba que si se remueve correctamente un usuario de la cola de emparejamiento aleatorio en modo rapido
        /// </summary>
        [Test]
        public void RemoverFilaEsperaEmparejamientoAleatorioModoRapido()
        {
            int numeroDeJugador1 = Planificador.Registrar("Carlos",67,"player1");
            int numeroDeJugador2 = Planificador.Registrar("Drake",55,"player2");
            int numeroDeJugador3 = Planificador.Registrar("Raul",85,"player3");

            int[] emparejados1 = emparejamiento.EmparejarAleatorio(1,numeroDeJugador1);
            emparejamiento.RemoverListaEspera(numeroDeJugador1);
            int[] emparejados2 = emparejamiento.EmparejarAleatorio(1,numeroDeJugador2);
            int[] emparejados3 = emparejamiento.EmparejarAleatorio(1,numeroDeJugador3);

            int[] verificar = new int[2];
            verificar[0] = numeroDeJugador2;
            verificar[1] = numeroDeJugador3;
            Assert.AreEqual(emparejados1,null);
            Assert.AreEqual(emparejados2,null);
            Assert.AreEqual(emparejados3[0],verificar[0]);
            Assert.AreEqual(emparejados3[1],verificar[1]);

            removedor.Remover(numeroDeJugador1);
            removedor.Remover(numeroDeJugador2);
            removedor.Remover(numeroDeJugador3);
            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(remover.ObtenerPartida(2));
        }
        /// <summary>
        /// Prueba que si se emparejan correctamente los jugadores al entrar en emparejamiento aleatorio buscando una partida en modo normal.
        /// </summary>
        [Test]
        public void EmparejamientoAleatorioModoNormal()
        {
            int numeroDeJugador1 = Planificador.Registrar("Carlos",67,"player1");
            int numeroDeJugador2 = Planificador.Registrar("Drake",55,"player2");
            int numeroDeJugador3 = Planificador.Registrar("Raul",85,"player3");

            int[] emparejados1 = emparejamiento.EmparejarAleatorio(0,numeroDeJugador1);
            int[] emparejados2 = emparejamiento.EmparejarAleatorio(0,numeroDeJugador2);
            int[] emparejados3 = emparejamiento.EmparejarAleatorio(0,numeroDeJugador3);
            int[] verificar = new int[2];
            verificar[0] = numeroDeJugador1;
            verificar[1] = numeroDeJugador2;
            Assert.AreEqual(emparejados1,null);
            Assert.AreEqual(emparejados2[0],verificar[0]);
            Assert.AreEqual(emparejados2[1],verificar[1]);
            Assert.AreEqual(emparejados3,null);

            emparejamiento.RemoverListaEspera(numeroDeJugador3);
            removedor.Remover(numeroDeJugador1);
            removedor.Remover(numeroDeJugador2);
            removedor.Remover(numeroDeJugador3);
            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(remover.ObtenerPartida(1));
        }
        /// <summary>
        /// Prueba que si se emparejan correctamente los jugadores al entrar en emparejamiento aleatorio buscando una partida en modo rapido
        /// </summary>
        [Test]
        public void EmparejamientoAleatorioModoRapido()
        {
            int numeroDeJugador1 = Planificador.Registrar("Carlos",67,"player1");
            int numeroDeJugador2 = Planificador.Registrar("Drake",55,"player2");
            int numeroDeJugador3 = Planificador.Registrar("Raul",85,"player3");
            int[] emparejados1 = emparejamiento.EmparejarAleatorio(1,numeroDeJugador1);
            int[] emparejados2 = emparejamiento.EmparejarAleatorio(1,numeroDeJugador2);
            int[] emparejados3 = emparejamiento.EmparejarAleatorio(1,numeroDeJugador3);

            int[] verificar = new int[2];
            verificar[0] = numeroDeJugador1;
            verificar[1] = numeroDeJugador2;
            Assert.AreEqual(emparejados1,null);
            Assert.AreEqual(emparejados2[0],verificar[0]);
            Assert.AreEqual(emparejados2[1],verificar[1]);
            Assert.AreEqual(emparejados3,null);

            emparejamiento.RemoverListaEspera(numeroDeJugador3);
            removedor.Remover(numeroDeJugador1);
            removedor.Remover(numeroDeJugador2);
            removedor.Remover(numeroDeJugador3);
            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(remover.ObtenerPartida(1));
        }
        /// <summary>
        /// Prueba si dos jugadores se emparejan correctamente en una partida amistosa en modo normal
        /// </summary>
        [Test]
        public void EmparejarAmigosModoNormal()
        {
            int numeroDeJugador1 = Planificador.Registrar("Carlos",67,"player1");
            int numeroDeJugador2 = Planificador.Registrar("Drake",55,"player2");

            int[] emparejados = emparejamiento.EmparejarAmigos(0,numeroDeJugador1,numeroDeJugador2);
            
            int[] verificar = new int[2];
            verificar[0] = numeroDeJugador1;
            verificar[1] = numeroDeJugador2;
            Assert.AreEqual(emparejados[0],verificar[0]);
            Assert.AreEqual(emparejados[1],verificar[1]);

            removedor.Remover(numeroDeJugador1);
            removedor.Remover(numeroDeJugador2);
            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(remover.ObtenerPartida(1));     
        }
        /// <summary>
        /// Prueba si dos jugadores se emparejan correctamente en una partida amistosa en modo rapido
        /// </summary>
        [Test]
        public void EmparejarAmigosModoRapido()
        {
            int numeroDeJugador1 = Planificador.Registrar("Carlos",67,"player1");
            int numeroDeJugador2 = Planificador.Registrar("Drake",55,"player2");
            int[] emparejados = emparejamiento.EmparejarAmigos(1,numeroDeJugador1,numeroDeJugador2);
            
            int[] verificar = new int[2];
            verificar[0] = numeroDeJugador1;
            verificar[1] = numeroDeJugador2;
            Assert.AreEqual(emparejados[0],verificar[0]);
            Assert.AreEqual(emparejados[1],verificar[1]);

            removedor.Remover(numeroDeJugador1);
            removedor.Remover(numeroDeJugador2);
            PartidasEnJuego remover = PartidasEnJuego.Instance();
            remover.RemoverPartida(remover.ObtenerPartida(1));
        }
    }
}*/
