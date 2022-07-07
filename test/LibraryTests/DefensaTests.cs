using System;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Tests de funcionalidad pedida en la defensa.
    /// PD: Comente algunos test que no son de esta clase, quedaron mal en la entrega anterior.
    /// </summary>
    [TestFixture]
    public class TestsVerCantidadDisparosAgua
    {
        private AlmacenamientoUsuario removedor;
		private Partida partida;
        private PartidasEnJuego partidasJugando;
        private int jugador1;
        private int jugador2;

        /// <summary>
        /// SetUp Creado con el objetivo de tener los elementos necesarios para realizar ls test
        /// </summary>
        
        [SetUp]
        public void Setup()
        {
            removedor = AlmacenamientoUsuario.Instance();
            partidasJugando = PartidasEnJuego.Instance();
            int i = 1;
            int CantidadUsuarios = removedor.ListaDeUsuarios.Count;
            if (partida == null)
            {
                partidasJugando.RemoverPartida(partida);
            }
            
            while (i <= CantidadUsuarios)
            {
                removedor.Remover(i);
                i++;
            }
            jugador1 = Planificador.Registrar("JugadorTest1", 3214, "Jugador");
            jugador2 = Planificador.Registrar("JugadorTest2", 3215, "Jugador");
            partida = new Partida(7,jugador1,jugador2);
            partida.AgregarBarco("a1","a6",jugador1);
            partida.AgregarBarco("b1","b6",jugador1);
            partida.AgregarBarco("c1","c6",jugador2);
            partida.AgregarBarco("d1","d6",jugador2);
        }
        /// <summary>
        /// Veo la cantidad de disparos al agua mientras estoy en etapa de posicionamiento
        /// para eso creo una nueva partida y por lo tanto es como si volviera a antes de poder atacar
        /// </summary>
        [Test]
        public void CantidadDeDisparosAlAguaEnPosicionamiento()
        {
            partidasJugando.RemoverPartida(partida);
            partida = new Partida(7,jugador1,jugador2);
            int disparosAlAgua= partida.CantidadDeDisparosAlAgua();
            Assert.AreEqual(0,disparosAlAgua);
        }
        /// <summary>
        /// Veo la cantidad de disparos al agua antes de efectuar el primer ataque
        /// </summary>
        [Test]
        public void CantidadDeDisparosAlAgua0()
        {
            int disparosAlAgua= partida.CantidadDeDisparosAlAgua();
            Assert.AreEqual(0,disparosAlAgua);
        }
        /// <summary>
        /// Veo la cantidad de disparos al agua despues de efectuar 1 solo ataque al agua
        /// </summary>
        [Test]
        public void CantidadDeDisparosAguaAtaques1()
        {
            partida.Atacar("e1",jugador1);
            int disparosAlAgua= partida.CantidadDeDisparosAlAgua();
            Assert.AreEqual(1,disparosAlAgua);
        }
        /// <summary>
        /// Veo la cantidad de disparos al agua despues de efectuar 2 disparos correctos al agua
        /// </summary>
        [Test]
        public void CantidadDeDisparosAguaAtaques2()
        {
            partida.Atacar("e1",jugador1);
            partida.Atacar("e2",jugador2);
            int disparosAlAgua= partida.CantidadDeDisparosAlAgua();
            Assert.AreEqual(2,disparosAlAgua);
        }
        /// <summary>
        /// Veo la cantidad de disparos al agua despues de efectuar 3 ataques correctos
        /// </summary>
        [Test]
        public void CantidadDeDisparosAguaAtaques3()
        {
            partida.Atacar("e1",jugador1);
            partida.Atacar("e2",jugador2);
            partida.Atacar("e1",jugador1);
            int disparosAlAgua= partida.CantidadDeDisparosAlAgua();
            Assert.AreEqual(3,disparosAlAgua);
        }
        /// <summary>
        /// Pruebo que al efectuar solo 1 ataque correcto y uno incorrecto no se aplique 
        /// ya que en modo normal solo pueden atacar los jugadores intercalados
        /// </summary>
        [Test]
        public void CantidadDeDisparosAguaAtaquesBienYmal()
        {
            partida.Atacar("e1",jugador1);
            partida.Atacar("e2",jugador1);
            int disparosAlAgua= partida.CantidadDeDisparosAlAgua();
            Assert.AreEqual(1,disparosAlAgua);
        }
        /// <summary>
        /// Pruebo que al efectuar solo 1 ataque correcto y uno incorrecto no se aplique 
        /// ya que el tablero es de tamaño 7
        /// </summary>
        [Test]
        public void CantidadDeDisparosAguaAtaquesBienYmal2()
        {
            partida.Atacar("e1",jugador1);
            partida.Atacar("e9",jugador1);
            int disparosAlAgua= partida.CantidadDeDisparosAlAgua();
            Assert.AreEqual(1,disparosAlAgua);
        }
        /// <summary>
        /// Pruebo que al efectuar solo 2 ataques en el mismo lugar
        /// se sumen ambos a la cantidad de veces que atacaron en agua
        /// El jugador 2 ataca solamente porque los ataques tienen que ser intercalados
        /// entre ambos jugadores y ataca en una coordenada con agua tambien
        /// por lo cual el contador tendria 3
        /// </summary>
        [Test]
        public void AtaqueDobleEnLaMismaCoordenadaDeAgua()
        {
            partida.Atacar("e1",jugador1);
            partida.Atacar("e3",jugador2);
            partida.Atacar("e1",jugador1);
            int disparosAlAgua= partida.CantidadDeDisparosAlAgua();
            Assert.AreEqual(3,disparosAlAgua);
        }
        /// <summary>
        /// Veo la cantidad de disparos al barcos mientras estoy en etapa de posicionamiento
        /// para eso creo una nueva partida y por lo tanto es como si volviera a antes de poder atacar
        /// </summary>
        [Test]
        public void CantidadDeDisparosABarcosEnPosicionamiento()
        {
            partidasJugando.RemoverPartida(partida);
            partida = new Partida(7,jugador1,jugador2);
            int disparosBarcos= partida.CantidadDeDisparosABarcos();
            Assert.AreEqual(0,disparosBarcos);
        }
        /// <summary>
        /// Veo la cantidad de disparos a barcos antes de efectuar el primer ataque
        /// </summary>
        [Test]
        public void CantidadDeDisparosAbarco0()
        {
            int disparosBarcos= partida.CantidadDeDisparosABarcos();
            Assert.AreEqual(0,disparosBarcos);
        }
        /// <summary>
        /// Veo la cantidad de disparos que atacaron barcos despues de efectuar 1 solo ataque a un barco
        /// </summary>
        [Test]
        public void CantidadDeDisparosAbarcoAtaques1()
        {
            partida.Atacar("c1",jugador1);
            int disparosBarcos= partida.CantidadDeDisparosABarcos();
            Assert.AreEqual(1,disparosBarcos);
        }
        /// <summary>
        /// Veo la cantidad de disparos al agua despues de efectuar 2 disparos correctos al agua
        /// </summary>
        [Test]
        public void CantidadDeDisparosAbarcoAtaques2()
        {
            partida.Atacar("c1",jugador1);
            partida.Atacar("a2",jugador2);
            int disparosBarcos= partida.CantidadDeDisparosABarcos();
            Assert.AreEqual(2,disparosBarcos);
        }
        /// <summary>
        /// Veo la cantidad de disparos al agua despues de efectuar 3 ataques correctos
        /// </summary>
        [Test]
        public void CantidadDeDisparosaBarcosAtaques3()
        {
            partida.Atacar("c1",jugador1);
            partida.Atacar("a2",jugador2);
            partida.Atacar("c2",jugador1);
            int disparosBarcos= partida.CantidadDeDisparosABarcos();
            Assert.AreEqual(3,disparosBarcos);
        }
        /// <summary>
        /// Pruebo que al efectuar solo 1 ataque correcto y dos incorrectos no se aplique 
        /// ya que en modo normal solo pueden atacar los jugadores intercalados
        /// </summary>
        [Test]
        public void CantidadDeDisparosABarcoAtaquesBienYmal()
        {
            partida.Atacar("c1",jugador1);
            partida.Atacar("c2",jugador1);
            partida.Atacar("i2",jugador1);
            int disparosBarcos= partida.CantidadDeDisparosABarcos();
            Assert.AreEqual(1,disparosBarcos);
        }
        /// <summary>
        /// Pruebo que al efectuar solo 1 ataque correcto y uno incorrecto no se aplique 
        /// ya que el tablero es de tamaño 7
        /// </summary>
        [Test]
        public void CantidadDeDisparosbarcoAtaquesBienYmal2()
        {
            partida.Atacar("c1",jugador1);
            partida.Atacar("c9",jugador1);
            int disparosBarcos= partida.CantidadDeDisparosABarcos();
            Assert.AreEqual(1,disparosBarcos);
        }
        /// <summary>
        /// Pruebo que al efectuar solo 2 ataques en el mismo lugar
        /// se sumen ambos a la cantidad de veces que atacaron barcos
        /// El jugador 2 ataca solamente porque los ataques tienen que ser intercalados
        /// entre ambos jugadores y ataca en una coordenada vacia
        /// </summary>
        [Test]
        public void AtaqueDobleEnLaMismaCoordenadaDeBarco()
        {
            partida.Atacar("c1",jugador1);
            partida.Atacar("c3",jugador2);
            partida.Atacar("c1",jugador1);
            int disparosBarcos= partida.CantidadDeDisparosABarcos();
            Assert.AreEqual(2,disparosBarcos);
        }
        /// <summary>
        /// Prueba para ver que los contadores se efectuen bien al
        /// atacar en casillas de barco y agua intercaladamente
        /// probando con el contador de disparos a barco
        /// </summary>
        [Test]
        public void AtaquesCombinados()
        {
            partida.Atacar("c1",jugador1);
            partida.Atacar("e1",jugador2);
            partida.Atacar("c2",jugador1);
            int disparosBarcos= partida.CantidadDeDisparosABarcos();
            Assert.AreEqual(2,disparosBarcos);
        }
        /// <summary>
        /// Prueba para ver que los contadores se efectuen bien al
        /// atacar en casillas de barco y agua intercaladamente
        /// probando con el contador de disparos al agua
        /// </summary>
        [Test]
        public void AtaquesCombinados2()
        {
            partida.Atacar("c1",jugador1);
            partida.Atacar("e1",jugador2);
            partida.Atacar("c2",jugador1);
            int disparosAlAgua= partida.CantidadDeDisparosAlAgua();
            Assert.AreEqual(1,disparosAlAgua);
        }
    }
}