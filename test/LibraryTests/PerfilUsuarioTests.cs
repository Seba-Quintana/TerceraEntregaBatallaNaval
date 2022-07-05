using System;
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
        /// <summary>
        /// SetUp Creado con el objetivo de tener los elementos necesatios 
        /// para probar PerfilUsuario de diferentes maneras
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
        /// Pruebo si el historial personal se almacena correctamente
        /// en solo los usuarios que participaron de la partida
        /// </summary>
        [Test]
        public void obtenerHistorialPersonal()
        {
            int numeroDeJugador1 = Planificador.Registrar("Carlos",67,"player1");
            int numeroDeJugador2 = Planificador.Registrar("Drake",55,"player2");
            int numeroDeJugador3 = Planificador.Registrar("Fede",70,"player3");

            Planificador.EmparejarAmigos(0,numeroDeJugador2,numeroDeJugador1,7);

            Planificador.Posicionar("A1","A6",numeroDeJugador1);
            Planificador.Posicionar("B1","B6",numeroDeJugador1);
            Planificador.Posicionar("E1","E6",numeroDeJugador2);
            Planificador.Posicionar("F1","F6",numeroDeJugador2);
            
            int i = 1;
            while(i <= 6)
            {
                Planificador.Atacar($"G{i}",numeroDeJugador1);
                Planificador.Atacar($"A{i}",numeroDeJugador2);
                i+=1;
            }
            i = 1;
            while(i < 6)
            {
                Planificador.Atacar($"C{i}",numeroDeJugador1);
                Planificador.Atacar($"B{i}",numeroDeJugador2);
                i+=1;
            }
            Planificador.Rendirse(numeroDeJugador1);

            AlmacenamientoUsuario almacenamiento = AlmacenamientoUsuario.Instance();
            PerfilUsuario perfil1 = almacenamiento.ObtenerPerfil(numeroDeJugador1);
            List<DatosdePartida> historialpersonal = perfil1.ObtenerHistorialPersonal();
            PerfilUsuario perfil3 = almacenamiento.ObtenerPerfil(numeroDeJugador3);
            List<DatosdePartida> historialpersonal3 = perfil3.ObtenerHistorialPersonal();
            PerfilUsuario perfil2 = almacenamiento.ObtenerPerfil(numeroDeJugador2);
            List<DatosdePartida> historialpersonal2 = perfil2.ObtenerHistorialPersonal();
            List<DatosdePartida> aver= new List<DatosdePartida>();

            Assert.AreNotEqual(historialpersonal.Count,historialpersonal3.Count);
            Assert.AreEqual(historialpersonal.Count,historialpersonal2.Count);

            almacenamiento.Remover(numeroDeJugador1);
            almacenamiento.Remover(numeroDeJugador2);
            almacenamiento.Remover(numeroDeJugador3);
        }
    }
}
