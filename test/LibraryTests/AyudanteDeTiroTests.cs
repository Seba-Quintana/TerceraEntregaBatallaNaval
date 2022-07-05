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
        /*/// <summary>
        /// Verifica que al tocar un barco en el centro del tablero el ayudante de tiro señalice correctamente.
        /// </summary>
        [Test]
        public void BarcoCentralTocado()
        {
            int numeroDeJugador1 = Planificador.Registrar("Carlos",67,"player1");
            int numeroDeJugador2 = Planificador.Registrar("Drake",55,"player2");

            Planificador.Emparejar(0,numeroDeJugador1,7);
            Planificador.Emparejar(0,numeroDeJugador2,7);
            PartidasEnJuego partidas = PartidasEnJuego.Instance();
            Partida partida = partidas.ObtenerPartida(numeroDeJugador1);

            partida.AgregarBarco("A1","A6",numeroDeJugador1);
            partida.AgregarBarco("C3","C3",numeroDeJugador1);
            partida.AgregarBarco("F1","F3",numeroDeJugador1);
            partida.AgregarBarco("F5","F6",numeroDeJugador1);
            partida.AgregarBarco("A1","F1",numeroDeJugador2);
            partida.AgregarBarco("A6","F6",numeroDeJugador2);

            partida.Atacar("A1", numeroDeJugador1);
            partida.Atacar("C3", numeroDeJugador2);

            ImprimirTableroOponente imprimir = new ImprimirTableroOponente();
            Tablero tab = partida.VerTablero(numeroDeJugador1);
            char[,] tablero = imprimir.ayudanteDeTiro(tab.VerTablero());

            char expected = '-'; 
            //C3 = 2,2
            //Verifica lateral izquierdo
            Assert.AreEqual(expected,tablero[2,1]);
            //Verifica arriba
            Assert.AreEqual(expected,tablero[1,1]);
            //Verifica abajo
            Assert.AreEqual(expected,tablero[3,1]);
            //Verifica lateral derecho
            Assert.AreEqual(expected,tablero[2,3]);

            partidas.RemoverPartida(partida);
            AlmacenamientoUsuario almacenamiento = AlmacenamientoUsuario.Instance();
            almacenamiento.Remover(numeroDeJugador1);
            almacenamiento.Remover(numeroDeJugador2);
        }
        /// <summary>
        /// Verifica que al tocar un barco en la esquina superior derecha del tablero el ayudante de tiro señalice correctamente.
        /// </summary>
        [Test]
        public void BarcoCentralTocado()
        {
            int numeroDeJugador1 = Planificador.Registrar("Carlos",67,"player1");
            int numeroDeJugador2 = Planificador.Registrar("Drake",55,"player2");

            Planificador.Emparejar(0,numeroDeJugador1,7);
            Planificador.Emparejar(0,numeroDeJugador2,7);
            PartidasEnJuego partidas = PartidasEnJuego.Instance();
            Partida partida = partidas.ObtenerPartida(numeroDeJugador1);

            partida.AgregarBarco("A1","A6",numeroDeJugador1);
            partida.AgregarBarco("C3","C3",numeroDeJugador1);
            partida.AgregarBarco("F1","F3",numeroDeJugador1);
            partida.AgregarBarco("F5","F6",numeroDeJugador1);
            partida.AgregarBarco("A1","F1",numeroDeJugador2);
            partida.AgregarBarco("A6","F6",numeroDeJugador2);

            partida.Atacar("A1", numeroDeJugador1);

            ImprimirTableroOponente imprimir = new ImprimirTableroOponente();
            Tablero tab = partida.VerTablero(numeroDeJugador2);
            char[,] tablero = imprimir.ayudanteDeTiro(tab.VerTablero());

            char expected = '-';
            //Verifica abajo
            Assert.AreEqual(expected,tablero[1,0]);
            //Verifica lateral derecho
            Assert.AreEqual(expected,tablero[0,1]);

            partidas.RemoverPartida(partida);
            AlmacenamientoUsuario almacenamiento = AlmacenamientoUsuario.Instance();
            almacenamiento.Remover(numeroDeJugador1);
            almacenamiento.Remover(numeroDeJugador2);
        }*/
    }
}
