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
        /// <summary>
        /// SetUp Creado con el objetivo de tener los elementos necesatios 
        /// para probar AyudanteDeTiro de diferentes maneras
        /// </summary>
        [SetUp]
        public void Setup()
        {
			PartidasEnJuego partidas = PartidasEnJuego.Instance();
            if (partidas.partidas.Count > 0)
                partidas.RemoverPartida(partidas.ObtenerPartida(1));
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

            partida.AgregarBarco("A1","A7",numeroDeJugador1);
            partida.AgregarBarco("C3","C4",numeroDeJugador1);
            partida.AgregarBarco("F1","F3",numeroDeJugador1);
            partida.AgregarBarco("F5","F6",numeroDeJugador1);
            partida.AgregarBarco("A1","F1",numeroDeJugador2);
            partida.AgregarBarco("A6","F6",numeroDeJugador2);

            partida.Atacar("A1", numeroDeJugador1);
            Console.WriteLine(partida.Atacar("C3", numeroDeJugador2));

            ImprimirTableroOponente imprimir = new ImprimirTableroOponente();
            Tablero tab = partida.VerTablero(numeroDeJugador1);
            char[,] matriz = tab.VerTablero();
            //QUITO LOS BARCOS DEL CLON OBTENIDO DE LA MATRIZ DEL TABLERO
            //Ya que ayudante de tiro siempre recibe la matriz sin barcos en ImprimirTableroOponente
            char[ , ] matrizSinBarcos = matriz;
            for (int i = 0; i <  matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if (matrizSinBarcos[i,j]== 'B')
                    {
                        matrizSinBarcos[i,j]= '\u0000';
                    }
                }
            }
            char[,] matrizConAyudante = imprimir.ayudanteDeTiro(matrizSinBarcos);


            char expected = '-'; 
            //C3 = 2,2
            //Verifica lateral izquierdo
            Assert.AreEqual(expected,matrizSinBarcos[2,1]);
            //Verifica arriba
            Assert.AreEqual(expected,matrizSinBarcos[1,2]);
            //Verifica abajo
            Assert.AreEqual(expected,matrizSinBarcos[3,2]);
            //Verifica lateral derecho
            Assert.AreEqual(expected,matrizSinBarcos[2,3]);

            partidas.RemoverPartida(partida);
            AlmacenamientoUsuario almacenamiento = AlmacenamientoUsuario.Instance();
            almacenamiento.Remover(numeroDeJugador1);
            almacenamiento.Remover(numeroDeJugador2);
        }
    }
}
