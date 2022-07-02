/*using System;
using ClassLibrary;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
	/// <summary>
	/// Tests de PerfilUsuario <see cref="PerfilUsuario"/>
	/// </summary>
    [TestFixture]
    public class PerfilUsuarioTests
    {
        private Jugador jugador;

        private int ganadas = 0;

        private int perdidas = 0;

        private List<DatosdePartida> HistorialPersonal = new List<DatosdePartida>();

        List<PerfilUsuario> ListadeUsuarios = new List<PerfilUsuario>();

        /// <summary>
        /// Pruebo si el historial personal se almacena correctamente
        /// en solo los usuarios que participaron de la partida
        /// </summary>
        [Test]
        public void obtenerHistorialPersonal()
        {
            AlmacenamientoUsuario almacenamiento = AlmacenamientoUsuario.Instance();
            Jugador jugador1 = new Jugador("Carlos",67,"player1");
            Jugador jugador2 = new Jugador("Drake",55,"player2");
            Jugador jugador3 = new Jugador("LUIS",34,"robgdfodf");

            jugador1.BuscarPartida(0,7);
            jugador2.BuscarPartida(0,7);

            jugador1.PosicionarBarcos("A1","A6");
            jugador1.PosicionarBarcos("B1","B6");
            jugador2.PosicionarBarcos("E1","E6");
            jugador2.PosicionarBarcos("F1","F6");
            
            int i = 1;
            while(i <= 6)
            {
                jugador1.Atacar($"G{i}");
                jugador2.Atacar($"A{i}");
                i+=1;
            }
            i = 1;
            while(i < 6)
            {
                jugador1.Atacar($"C{i}");
                jugador2.Atacar($"B{i}");
                i+=1;
            }

            jugador1.Atacar("C6");
            jugador2.Atacar("B6"); //Termino la partida
            PerfilUsuario perfil1 = almacenamiento.ObtenerPerfil(jugador1.NumeroDeJugador);
            List<DatosdePartida> historialpersonal = perfil1.ObtenerHistorialPersonal();
            PerfilUsuario perfil3 = almacenamiento.ObtenerPerfil(jugador3.NumeroDeJugador);
            List<DatosdePartida> historialpersonal3 = perfil3.ObtenerHistorialPersonal();
            PerfilUsuario perfil2 = almacenamiento.ObtenerPerfil(jugador2.NumeroDeJugador);
            List<DatosdePartida> historialpersonal2 = perfil2.ObtenerHistorialPersonal();

            Assert.AreNotEqual(historialpersonal,historialpersonal3);
            Assert.AreEqual(historialpersonal,historialpersonal2);    
        }
    }
}*/
