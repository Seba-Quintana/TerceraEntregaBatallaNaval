using System;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Tests de AyudanteDeTiro se hacen individualmente debido a su 
    /// importancia por ser parte de los agregados del proyecto. <see cref="Partida"/>
    /// </summary>
    [TestFixture]
    public class AyudanteDeTiroTests
    {
        Jugador jugador1;
        Jugador jugador2;
        PartidasEnJuego PartidaSimulada;
        int NumeroDeJugador1;
        int NumeroDeJugador2;
        Partida PartidaTest;
     
        /// <summary>
        /// 
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.jugador1 = new Jugador("test1", 12 , "test");
            this.jugador2 = new Jugador("test1", 14 , "test");
            this.NumeroDeJugador1 = this.jugador1.NumeroDeJugador; 
            this.NumeroDeJugador2 = this.jugador2.NumeroDeJugador;
            this.PartidaSimulada = PartidasEnJuego.Instance(); 
            

            this.jugador1.BuscarPartida(0, 6);
            this.jugador2.BuscarPartida(0, 6);
            
            this.PartidaTest = this.PartidaSimulada.ObtenerPartida(NumeroDeJugador1);

            jugador1.PosicionarBarcos("A1","A6");
            jugador1.PosicionarBarcos("B1","B3");
            jugador2.PosicionarBarcos("A2","A3");
            jugador2.PosicionarBarcos("C3","C5");
            jugador2.PosicionarBarcos("B3","B5");
            jugador2.PosicionarBarcos("F6","F6");

        }

        /// <summary>
        /// Testea si se utiliza bien el ayudantede tiro al tener una parte de barco tocada.
        /// </summary>
        [Test]
        public void AyudanteDeTiroEnUnaCasilla()
        {
            jugador1.Atacar("C3");

            char[,] matrizTest = PartidaTest.VistaOponente(NumeroDeJugador1);
            
            int[] coordenadaSuperior = TraductorDeCoordenadas.Traducir("B3");
            int coordenadaSuperiorFila = coordenadaSuperior[0];
            int coordenadaSuperiorColumna = coordenadaSuperior[1];

            int[] coordenadaInferior = TraductorDeCoordenadas.Traducir("D3");
            int coordenadaInferiorFila = coordenadaInferior[0];
            int coordenadaInferiorColumna = coordenadaInferior[1];

            int[] coordenadaDeLaIzquierda = TraductorDeCoordenadas.Traducir("C2");
            int coordenadaDeLaIzquierdaFila = coordenadaDeLaIzquierda[0];
            int coordenadaDeLaIzquierdaColumna = coordenadaDeLaIzquierda[1];

            int[] coordenadaDeLaDerecha = TraductorDeCoordenadas.Traducir("C4");
            int coordenadaDeLaDerechaFila = coordenadaDeLaDerecha[0];
            int coordenadaDeLaDerechaColumna = coordenadaDeLaDerecha[1];

            Assert.AreEqual('-', matrizTest[coordenadaDeLaDerechaFila,coordenadaDeLaDerechaColumna]);

            Assert.AreEqual('-', matrizTest[coordenadaDeLaIzquierdaFila,coordenadaDeLaIzquierdaColumna]);

            Assert.AreEqual('-', matrizTest[coordenadaInferiorFila,coordenadaInferiorColumna]);

            Assert.AreEqual('-', matrizTest[coordenadaSuperiorFila,coordenadaSuperiorColumna]);
        }
            /*
            Jugador jugador1 = new Jugador("Jugador1", 98, "tonto");
            Jugador jugador2 = new Jugador("Jugador2",87,"perro");

            //jugador1.PartidaAmistosa(0, jugador2.NumeroDeJugador, 7);
            jugador1.BuscarPartida(0,300);
            jugador2.BuscarPartida(0,300);
            jugador1.VisualizarTableros();
            /*Console.WriteLine(jugador1.PosicionarBarcos("A1","A6"));
            Console.WriteLine(jugador1.PosicionarBarcos("B1","B3"));
            Console.WriteLine(jugador2.PosicionarBarcos("A2","A3"));
            Console.WriteLine(jugador2.PosicionarBarcos("C3","C5"));
            Console.WriteLine(jugador2.PosicionarBarcos("B3","B5"));
            Console.WriteLine(jugador2.PosicionarBarcos("F6","F6"));

            Console.WriteLine(jugador1.Atacar("A1"));
            Console.WriteLine(jugador2.Atacar("A1"));
            jugador1.VisualizarTableros();

            //EsquinaSuperiorizquierda
            
            Console.WriteLine(jugador1.Atacar("F1"));
            Console.WriteLine(jugador2.Atacar("A1"));
            jugador1.VisualizarTableros();

            //EsquinaInferiorizquierda

            Console.WriteLine(jugador1.Atacar("c1"));
            Console.WriteLine(jugador2.Atacar("A1"));
            jugador1.VisualizarTableros();

            //Lateral Izquierdo

            
            //Centro

            Console.WriteLine(jugador1.Atacar("F6"));
            Console.WriteLine(jugador2.Atacar("A1"));
            
            //Esquina inferior izquierda
            //Final test 1 casilla

            Console.WriteLine(jugador1.Atacar("C3"));
            Console.WriteLine(jugador2.Atacar("A1"));
            Console.WriteLine(jugador1.Atacar("B3"));
            Console.WriteLine(jugador2.Atacar("A1"));
            Console.WriteLine(jugador1.Atacar("C4"));
            Console.WriteLine(jugador2.Atacar("A1"));
            Console.WriteLine(jugador1.Atacar("C5"));
            Console.WriteLine(jugador2.Atacar("A1"));
            jugador1.VisualizarTableros();*/


    }
}
